# -*- mode: python ; coding: utf-8 -*-

import os
import sys

block_cipher = None

# Diretório base
spec_dir = os.path.abspath(os.path.dirname(__file__) if '__file__' in locals() else '.')

datas = [
    (os.path.join(spec_dir, 'templates'), 'templates'),
    (os.path.join(spec_dir, 'static'), 'static'),
    (os.path.join(spec_dir, 'database'), 'database'),
]

hidden_imports = [
    'sqlite3',
    'http.server',
    'urllib.parse',
    'json',
    'threading',
    'webbrowser',
    'socket',
    'datetime',
    'shutil',
    'services',
    'services.auth',
    'services.secretaria',
    'services.financeiro',
    'services.academico',
    'services.contabil',
    'services.produtos',
    'services.cursos',
    'services.documentos',
    'database',
    'database.db',
    'import_database',
]

a = Analysis(
    ['app_launcher.py'],
    pathex=[spec_dir],
    binaries=[],
    datas=datas,
    hiddenimports=hidden_imports,
    hookspath=[],
    hooksconfig={},
    runtime_hooks=[],
    excludes=[],
    win_no_prefer_redirects=False,
    win_private_assemblies=False,
    cipher=block_cipher,
    noarchive=False,
)

pyz = PYZ(a.pure, a.zipped_data, cipher=block_cipher)

exe = EXE(
    pyz,
    a.scripts,
    a.binaries,
    a.zipfiles,
    a.datas,
    [],
    name='Ateniense',
    debug=False,
    bootloader_ignore_signals=False,
    strip=False,
    upx=True,
    upx_exclude=[],
    runtime_tmpdir=None,
    console=True, # Mantém console informativo com status e URLs
    disable_windowed_traceback=False,
    argv_emulation=False,
    target_arch=None,
    codesign_identity=None,
    entitlements_file=None,
    icon=None,
)
