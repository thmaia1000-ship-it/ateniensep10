import hashlib
import hmac
import json
import os
from pathlib import Path
import sqlite3
import tempfile
import threading
import unittest
from urllib.error import HTTPError
from urllib.request import Request, urlopen
from unittest.mock import patch

import server
from services import mercadopago as mp


class Pagamentos(unittest.TestCase):
    def setUp(self):
        tmp = tempfile.TemporaryDirectory()
        self.addCleanup(tmp.cleanup)
        path = Path(tmp.name)/'teste.db'
        path.touch()
        env = patch.dict(os.environ, ATENIENSE_DB_PATH=str(path), MP_ENABLED='true',
                         MP_ENVIRONMENT='test', MP_WEBHOOK_SECRET='segredo-ficticio', APP_BASE_URL='https://example.org')
        env.start()
        self.addCleanup(env.stop)
        # Reproduz apenas o esquema legado. Todos os registros de teste são fictícios.
        with sqlite3.connect('file:database/ateniense.db?mode=ro', uri=True) as source, mp.get_connection() as db:
            for table in ('tb_caixa','tb_mensalidades','tb_alunos'):
                db.execute(source.execute('SELECT sql FROM sqlite_master WHERE name=?',(table,)).fetchone()[0])
            db.execute("""INSERT INTO tb_mensalidades VALUES
                (1,2,200,200,100,'2020-01-01',0,2020,'','','','Regular',1,'',1,1)""")
        mp.migrate()
        mp.generate()
        self.token = mp.staff_link(1)['portal'].split('#')[1]
        self.ref = mp.current(self.token)['ref']

    def payment(self, **changes):
        return dict(dict(id=1, live_mode=False, status='approved', external_reference=self.ref,
                         currency_id='BRL', transaction_amount=100, payment_method_id='pix'), **changes)

    def test_repeated_and_refunded(self):
        mp.generate()
        with patch.object(mp,'api',return_value=self.payment()):
            mp.reconcile('1')
            mp.reconcile('1')
        self.assertEqual(mp.current(self.token)['parcela'],2)
        with patch.object(mp,'api',return_value=self.payment(status='refunded')):
            mp.reconcile('1')
        with mp.get_connection() as db:
            self.assertEqual(db.execute('SELECT count(*) FROM tb_caixa').fetchone()[0],1)
        self.assertEqual(mp.staff_link(1)['revisar'][0]['status'],'revisar:refunded')

    def test_mismatch_and_unknown_invite(self):
        self.assertIsNone(mp.current('falso'))
        with patch.object(mp,'api',return_value=self.payment(transaction_amount=50)):
            mp.reconcile('1')
        self.assertEqual(mp.current(self.token)['parcela'],1)
        self.assertTrue(mp.staff_link(1)['revisar'])

    def test_http(self):
        httpd = server.ThreadingHTTPServer(('127.0.0.1',0),server.AtenienseHandler)
        thread = threading.Thread(target=httpd.serve_forever,daemon=True)
        thread.start()
        self.addCleanup(httpd.server_close)
        self.addCleanup(httpd.shutdown)
        def post(action, body, headers=None):
            url = 'http://127.0.0.1:%s/api/mp/' % httpd.server_port + action
            with urlopen(Request(url,data=json.dumps(body).encode(),headers=headers or {})) as response:
                return json.load(response)
        with self.assertRaises(HTTPError) as error:
            post('portal',{'contrato':1})
        self.assertEqual(error.exception.code,401)
        self.assertEqual(post('parcela',{'token':self.token})['centavos'],10000)
        with patch.object(mp,'api',return_value={'sandbox_init_point':'https://example.org/test'}) as api:
            for _ in range(2):
                self.assertEqual(post('checkout',{'token':self.token})['url'],'https://example.org/test')
            api.assert_called_once()
        with self.assertRaises(HTTPError):
            post('webhook?data.id=1',{'type':'payment'})
        signature = hmac.new(b'segredo-ficticio', b'id:1;request-id:abc;ts:123;', hashlib.sha256).hexdigest()
        with patch.object(mp,'api',return_value=self.payment(payment_method_id='visa')):
            post('webhook?data.id=1',{'type':'payment'},{'x-request-id':'abc','x-signature':'ts=123,v1='+signature})
        self.assertEqual(mp.current(self.token)['parcela'],2)
