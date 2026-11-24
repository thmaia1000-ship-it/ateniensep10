"""Cobranças por parcela, portal por convite e conciliação do Checkout Pro."""
import hashlib
import hmac
import json
import logging
import os
import re
import secrets
import threading
from datetime import datetime
from decimal import Decimal
from urllib.parse import urlparse
from urllib.request import Request, urlopen
from zoneinfo import ZoneInfo

from database.db import get_connection
from services.financeiro import registrar_baixa


def enabled():
    return os.getenv('MP_ENABLED', 'false').lower() == 'true'


def base():
    return os.environ['APP_BASE_URL'].rstrip('/')


def initialize():
    if not enabled():
        return
    if (urlparse(base()).scheme != 'https' or not os.getenv('MP_ACCESS_TOKEN')
            or not os.getenv('MP_WEBHOOK_SECRET') or os.getenv('MP_ENVIRONMENT') not in ('test', 'production')):
        raise RuntimeError('Confira a configuração do Mercado Pago')
    migrate()
    threading.Thread(target=worker, daemon=True).start()


def migrate():
    with get_connection() as db:
        db.executescript("""
            CREATE TABLE IF NOT EXISTS mp_portal (contrato INTEGER PRIMARY KEY, token TEXT UNIQUE NOT NULL);
            CREATE TABLE IF NOT EXISTS mp_cobranca (
                ref TEXT PRIMARY KEY, contrato INTEGER NOT NULL, parcela INTEGER NOT NULL,
                valor INTEGER NOT NULL, checkout_url TEXT, UNIQUE(contrato, parcela));
            CREATE TABLE IF NOT EXISTS mp_pagamento (
                id TEXT PRIMARY KEY, ref TEXT NOT NULL, status TEXT NOT NULL, caixa INTEGER);
        """)

def worker():
    pause = threading.Event()
    while True:
        try:
            generate()
        except Exception:
            logging.exception('Falha ao gerar cobranças')
        pause.wait(3600)


def generate():
    month = datetime.now(ZoneInfo(os.getenv('APP_TIMEZONE', 'America/Manaus'))).strftime('%Y-%m')
    with get_connection() as db:
        db.execute("BEGIN IMMEDIATE")
        rows = db.execute("""SELECT * FROM tb_mensalidades WHERE CAST(saldo_devedor AS REAL)>0
            AND date(data_inicio) IS NOT NULL""")
        for row in rows:
            start = datetime.fromisoformat(row['data_inicio'])
            year, mon = map(int, month.split('-'))
            due = (year-start.year)*12 + mon-start.month+1
            paid = int(row['parcelas_pagas'] or 0)
            remaining = Decimal(str(row['saldo_devedor']))
            for installment in range(paid+1, min(due, int(row['n_parcelas'] or 0))+1):
                amount = min(remaining, Decimal(str(row['valor_parcela'] or 0)))
                cents = int(round(amount*100))
                if cents <= 0:
                    break
                db.execute("INSERT OR IGNORE INTO mp_cobranca (ref,contrato,parcela,valor) VALUES (?,?,?,?)",
                           (secrets.token_hex(20), row['ID_mensalidade'], installment, cents))
                remaining -= amount


def staff_link(contract):
    with get_connection() as db:
        if not db.execute("SELECT 1 FROM tb_mensalidades WHERE ID_mensalidade=?", (contract,)).fetchone():
            raise ValueError('Contrato inexistente')
        db.execute("INSERT OR IGNORE INTO mp_portal VALUES (?,?)", (contract, secrets.token_urlsafe(32)))
        token = db.execute("SELECT token FROM mp_portal WHERE contrato=?", (contract,)).fetchone()[0]
        reviews = db.execute("""SELECT p.id, p.status FROM mp_pagamento p JOIN mp_cobranca c ON p.ref=c.ref
            WHERE c.contrato=? AND p.status LIKE 'revisar:%'""", (contract,)).fetchall()
    return {'portal': base()+'/pagamentos#'+token, 'revisar': [dict(row) for row in reviews]}


def current(token):
    with get_connection() as db:
        return db.execute("""SELECT c.* FROM mp_portal p JOIN tb_mensalidades m ON m.ID_mensalidade=p.contrato
            JOIN mp_cobranca c ON c.contrato=p.contrato AND c.parcela=CAST(COALESCE(NULLIF(m.parcelas_pagas,''),0) AS INTEGER)+1
            WHERE p.token=? AND c.valor=ROUND(100*MIN(CAST(m.saldo_devedor AS REAL), CAST(m.valor_parcela AS REAL)))""",
                          (token,)).fetchone()


def api(path, data=None):
    req = Request('https://api.mercadopago.com'+path,
                  data=json.dumps(data).encode() if data is not None else None,
                  headers={'Authorization': 'Bearer '+os.environ['MP_ACCESS_TOKEN'], 'Content-Type': 'application/json'})
    with urlopen(req, timeout=12) as response:
        return json.load(response)


def checkout(token):
    charge = current(token)
    if not charge:
        raise ValueError('Nenhuma parcela disponível')
    if charge['checkout_url']:
        return {'url': charge['checkout_url']}
    pref = api('/checkout/preferences', {
        'items': [{'title': f"Mensalidade escolar - parcela {charge['parcela']}", 'quantity': 1,
                   'currency_id': 'BRL', 'unit_price': charge['valor']/100}],
        'external_reference': charge['ref'],
        'payment_methods': {'excluded_payment_types': [{'id': 'ticket'}, {'id': 'atm'}]},
        'notification_url': base()+'/api/mp/webhook?source_news=webhooks',
    })
    key = 'init_point' if os.environ['MP_ENVIRONMENT']=='production' else 'sandbox_init_point'
    with get_connection() as db:
        db.execute("UPDATE mp_cobranca SET checkout_url=COALESCE(checkout_url,?) WHERE ref=?", (pref[key], charge['ref']))
        url = db.execute("SELECT checkout_url FROM mp_cobranca WHERE ref=?", (charge['ref'],)).fetchone()[0]
    return {'url': url}


def signed(pid, headers):
    fields = dict(item.strip().split('=',1) for item in headers.get('x-signature','').split(',') if '=' in item)
    ts = fields.get('ts','')
    request_id = headers.get('x-request-id','')
    if not re.fullmatch(r'[0-9]+', pid) or not ts.isdigit() or not request_id:
        return False
    manifest = f'id:{pid};request-id:{request_id};ts:{ts};'
    expected = hmac.new(os.environ['MP_WEBHOOK_SECRET'].encode(), manifest.encode(), hashlib.sha256).hexdigest()
    return hmac.compare_digest(expected, fields.get('v1',''))


def reconcile(pid):
    payment = api('/v1/payments/'+pid)
    if str(payment['id']) != pid or payment['live_mode'] != (os.environ['MP_ENVIRONMENT']=='production'):
        return
    with get_connection() as db:
        db.execute('BEGIN IMMEDIATE')
        charge = db.execute('SELECT * FROM mp_cobranca WHERE ref=?', (payment.get('external_reference'),)).fetchone()
        if not charge:
            return
        old = db.execute('SELECT caixa FROM mp_pagamento WHERE id=?', (pid,)).fetchone()
        caixa = old['caixa'] if old else None
        status = payment['status']
        if status in ('refunded', 'charged_back') or payment.get('transaction_amount_refunded', 0):
            status = 'revisar:'+status
        elif status == 'approved' and caixa is None:
            contract = db.execute('SELECT * FROM tb_mensalidades WHERE ID_mensalidade=?', (charge['contrato'],)).fetchone()
            amount = Decimal(str(payment['transaction_amount']))
            if (contract and int(contract['parcelas_pagas'] or 0)+1 == charge['parcela']
                    and payment['currency_id']=='BRL' and amount*100==charge['valor']
                    and amount==min(Decimal(str(contract['saldo_devedor'])), Decimal(str(contract['valor_parcela'])))):
                caixa = registrar_baixa(db, charge['contrato'], 1, payment['payment_method_id'],
                                        'MERCADO PAGO', 'Pagamento '+pid)['caixa_id']
            else:
                status = 'revisar:divergência'
        db.execute('INSERT OR REPLACE INTO mp_pagamento VALUES (?,?,?,?)', (pid, charge['ref'], status, caixa))
