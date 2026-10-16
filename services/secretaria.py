# -*- coding: utf-8 -*-
"""
Serviço de Secretaria: Alunos, Turmas, Professores e Responsáveis
"""

from datetime import datetime
from database.db import query_all, query_one, execute

def get_alunos_turma(turma_id, busca='', status='', limit=100, offset=0):
    params = [turma_id]
    extra_where = []
    if busca:
        extra_where.append("(a.nome_aluno LIKE ? OR a.ID_aluno = ?)")
        params.extend([f"%{busca}%", busca if busca.isdigit() else -1])
    if status:
        extra_where.append("a.status = ?")
        params.append(status)
    else:
        extra_where.append("a.status != 'INATIVO'")
        
    extra_str = (" AND " + " AND ".join(extra_where)) if extra_where else ""
    
    # 1. Busca primeiro por enturmação explícita em tb_alunos_turmas
    alunos = query_all(f"""
        SELECT DISTINCT
            a.ID_aluno as id,
            a.nome_aluno as nome,
            a.datanasc,
            a.sexo,
            a.etapa,
            a.turno,
            a.telefone,
            a.ano_letivo,
            a.status,
            t.nome_turma,
            t.ID_turma as idturma
        FROM tb_alunos_turmas at
        JOIN tb_alunos a ON at.idaluno = a.ID_aluno
        JOIN tb_turmas t ON at.idturma = t.ID_turma
        WHERE at.idturma = ? {extra_str}
        ORDER BY a.nome_aluno ASC
        LIMIT ? OFFSET ?
    """, tuple(params + [limit, offset]))
    
    if alunos:
        return alunos
        
    # 2. Fallback caso a turma não possua enturmação em tb_alunos_turmas
    t = query_one('SELECT * FROM tb_turmas WHERE ID_turma = ?', (turma_id,))
    if not t:
        return []
        
    params2 = [t['nome_turma'], t['ID_turma'], t['serie'], t['serie'], t['turno'], t['ano_letivo'], t['ano_letivo']]
    extra_where2 = []
    if busca:
        extra_where2.append("(a.nome_aluno LIKE ? OR a.ID_aluno = ?)")
        params2.extend([f"%{busca}%", busca if busca.isdigit() else -1])
    if status:
        extra_where2.append("a.status = ?")
        params2.append(status)
    else:
        extra_where2.append("a.status != 'INATIVO'")
        
    extra_str2 = (" AND " + " AND ".join(extra_where2)) if extra_where2 else ""
    
    return query_all(f"""
        SELECT DISTINCT
            a.ID_aluno as id,
            a.nome_aluno as nome,
            a.datanasc,
            a.sexo,
            a.etapa,
            a.turno,
            a.telefone,
            a.ano_letivo,
            a.status,
            ? as nome_turma,
            ? as idturma
        FROM tb_alunos a
        WHERE (a.etapa = ? OR a.etapa LIKE '%' || ? || '%')
          AND a.turno = ?
          AND (a.ano_letivo = ? OR ? IS NULL)
          {extra_str2}
        ORDER BY a.nome_aluno ASC
        LIMIT ? OFFSET ?
    """, tuple(params2 + [limit, offset]))

def list_alunos(busca='', status='', turma_id=None, limit=100, offset=0):
    if turma_id:
        return get_alunos_turma(turma_id, busca, status, limit, offset)

    params = []
    where_clauses = []
    
    if busca:
        where_clauses.append("(a.nome_aluno LIKE ? OR a.ID_aluno = ? OR a.rua LIKE ? OR a.bairro LIKE ?)")
        params.extend([f"%{busca}%", busca if busca.isdigit() else -1, f"%{busca}%", f"%{busca}%"])
        
    if status:
        where_clauses.append("a.status = ?")
        params.append(status)
        
    where_str = ("WHERE " + " AND ".join(where_clauses)) if where_clauses else ""
    
    sql = f"""
    SELECT DISTINCT
        a.ID_aluno as id,
        a.nome_aluno as nome,
        a.datanasc,
        a.sexo,
        a.etapa,
        a.turno,
        a.telefone,
        a.ano_letivo,
        a.status,
        t.nome_turma,
        t.ID_turma as idturma
    FROM tb_alunos a
    LEFT JOIN tb_alunos_turmas at ON a.ID_aluno = at.idaluno
    LEFT JOIN tb_turmas t ON at.idturma = t.ID_turma
    {where_str}
    ORDER BY a.nome_aluno ASC
    LIMIT ? OFFSET ?
    """
    params.extend([limit, offset])
    return query_all(sql, tuple(params))

def count_alunos(busca='', status='', turma_id=None):
    if turma_id:
        alunos = get_alunos_turma(turma_id, busca, status, limit=9999, offset=0)
        return len(alunos)

    params = []
    where_clauses = []
    if busca:
        where_clauses.append("(a.nome_aluno LIKE ? OR a.ID_aluno = ?)")
        params.extend([f"%{busca}%", busca if busca.isdigit() else -1])
    if status:
        where_clauses.append("a.status = ?")
        params.append(status)
    where_str = ("WHERE " + " AND ".join(where_clauses)) if where_clauses else ""
    sql = f"""
    SELECT COUNT(DISTINCT a.ID_aluno) as total
    FROM tb_alunos a
    LEFT JOIN tb_alunos_turmas at ON a.ID_aluno = at.idaluno
    LEFT JOIN tb_turmas t ON at.idturma = t.ID_turma
    {where_str}
    """
    res = query_one(sql, tuple(params))
    return res['total'] if res else 0

def get_aluno(aluno_id):
    aluno = query_one("""
    SELECT 
        a.*,
        t.nome_turma,
        t.ID_turma as idturma
    FROM tb_alunos a
    LEFT JOIN tb_alunos_turmas at ON a.ID_aluno = at.idaluno
    LEFT JOIN tb_turmas t ON at.idturma = t.ID_turma
    WHERE a.ID_aluno = ?
    """, (aluno_id,))
    
    if not aluno:
        return None
        
    resp_acad = query_one("SELECT * FROM tb_responsavel_academico WHERE idaluno = ?", (aluno_id,))
    resp_fin = query_one("SELECT * FROM tb_responsavel_financeiro WHERE idaluno = ?", (aluno_id,))
    mensalidades = query_all("SELECT * FROM tb_mensalidades WHERE idaluno = ? ORDER BY ID_mensalidade DESC", (aluno_id,))
    
    return {
        'aluno': aluno,
        'responsavel_academico': resp_acad,
        'responsavel_financeiro': resp_fin,
        'mensalidades': mensalidades
    }

def create_aluno(data, usuario='ADMIN'):
    data_gerada = datetime.now().strftime('%Y-%m-%d')
    next_aluno = query_one("SELECT COALESCE(MAX(ID_aluno), 0) + 1 as next_id FROM tb_alunos")
    aluno_id = next_aluno['next_id'] if next_aluno else 1

    execute("""
    INSERT INTO tb_alunos (
        ID_aluno, nome_aluno, datanasc, sexo, cor, cidade, nacionalidade, UF, rua, bairro, cep,
        numero, zona, telefone, vive_com, doenca, emergencia, mae, pai,
        responsavel1, responsavel2, idcurso, turno, etapa, observacao,
        ano_letivo, status, usuario, data_gerada
    ) VALUES (
        ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,
        ?, ?, ?, ?, ?, ?, ?, ?,
        ?, ?, ?, ?, ?, ?,
        ?, ?, ?, ?, ?
    )
    """, (
        aluno_id,
        data.get('nome_aluno', ''),
        data.get('datanasc', ''),
        data.get('sexo', 'Masculino'),
        data.get('cor', 'Pardo'),
        data.get('cidade', 'MANAUS'),
        data.get('nacionalidade', 'BRASILEIRA'),
        data.get('UF', 'AM'),
        data.get('rua', ''),
        data.get('bairro', ''),
        data.get('cep', ''),
        data.get('numero', ''),
        data.get('zona', 'URBANA'),
        data.get('telefone', ''),
        data.get('vive_com', 'PAIS'),
        data.get('doenca', 'NÃO'),
        data.get('emergencia', ''),
        data.get('mae', ''),
        data.get('pai', ''),
        data.get('responsavel1', ''),
        data.get('responsavel2', ''),
        data.get('idcurso', None),
        data.get('turno', 'Manhã'),
        data.get('etapa', ''),
        data.get('observacao', ''),
        data.get('ano_letivo', datetime.now().strftime('%Y')),
        data.get('status', 'ATIVO'),
        usuario,
        data_gerada
    ))
    
    # Responsável Acadêmico
    next_acad = query_one("SELECT COALESCE(MAX(ID_responsavel_academico), 0) + 1 as next_id FROM tb_responsavel_academico")
    acad_id = next_acad['next_id'] if next_acad else 1
    execute("""
    INSERT INTO tb_responsavel_academico (
        ID_responsavel_academico, nome, parentesco, CPF, RG, orgao_emissor, data_emissao, datanasc, nacionalidade,
        estado_civil, profissao, grau_instrucao, rua, bairro, numero, CEP, email, telefone, idaluno
    ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    """, (
        acad_id,
        data.get('resp_acad_nome', data.get('mae', '')),
        data.get('resp_acad_parentesco', 'MÃE'),
        data.get('resp_acad_cpf', ''),
        data.get('resp_acad_rg', ''),
        data.get('resp_acad_orgao', 'SSP/AM'),
        data.get('resp_acad_emissao', ''),
        data.get('resp_acad_nasc', ''),
        data.get('resp_acad_nacionalidade', 'BRASILEIRA'),
        data.get('resp_acad_civil', 'CASADO(A)'),
        data.get('resp_acad_profissao', ''),
        data.get('resp_acad_instrucao', 'SUPERIOR'),
        data.get('resp_acad_rua', data.get('rua', '')),
        data.get('resp_acad_bairro', data.get('bairro', '')),
        data.get('resp_acad_numero', data.get('numero', '')),
        data.get('resp_acad_cep', data.get('cep', '')),
        data.get('resp_acad_email', ''),
        data.get('resp_acad_telefone', data.get('telefone', '')),
        aluno_id
    ))
    
    # Responsável Financeiro
    next_fin = query_one("SELECT COALESCE(MAX(ID_responsavel_financeiro), 0) + 1 as next_id FROM tb_responsavel_financeiro")
    fin_id = next_fin['next_id'] if next_fin else 1
    execute("""
    INSERT INTO tb_responsavel_financeiro (
        ID_responsavel_financeiro, nome, parentesco, CPF, RG, orgao_emissor, data_emissao, datanasc, nacionalidade,
        estado_civil, profissao, grau_instrucao, rua, bairro, numero, CEP, email, telefone, idaluno
    ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    """, (
        fin_id,
        data.get('resp_fin_nome', data.get('pai', '')),
        data.get('resp_fin_parentesco', 'PAI'),
        data.get('resp_fin_cpf', ''),
        data.get('resp_fin_rg', ''),
        data.get('resp_fin_orgao', 'SSP/AM'),
        data.get('resp_fin_emissao', ''),
        data.get('resp_fin_nasc', ''),
        data.get('resp_fin_nacionalidade', 'BRASILEIRA'),
        data.get('resp_fin_civil', 'CASADO(A)'),
        data.get('resp_fin_profissao', ''),
        data.get('resp_fin_instrucao', 'SUPERIOR'),
        data.get('resp_fin_rua', data.get('rua', '')),
        data.get('resp_fin_bairro', data.get('bairro', '')),
        data.get('resp_fin_numero', data.get('numero', '')),
        data.get('resp_fin_cep', data.get('cep', '')),
        data.get('resp_fin_email', ''),
        data.get('resp_fin_telefone', data.get('telefone', '')),
        aluno_id
    ))
    
    # Aloca na turma se informada
    if data.get('idturma'):
        execute("INSERT INTO tb_alunos_turmas (idaluno, idturma) VALUES (?, ?)", (aluno_id, data['idturma']))
        
    return aluno_id

def update_aluno(aluno_id, data):
    execute("""
    UPDATE tb_alunos SET
        nome_aluno = ?, datanasc = ?, sexo = ?, cor = ?, cidade = ?,
        nacionalidade = ?, UF = ?, rua = ?, bairro = ?, cep = ?,
        numero = ?, zona = ?, telefone = ?, vive_com = ?, doenca = ?,
        emergencia = ?, mae = ?, pai = ?, responsavel1 = ?, responsavel2 = ?,
        turno = ?, etapa = ?, observacao = ?, status = ?
    WHERE ID_aluno = ?
    """, (
        data.get('nome_aluno', ''),
        data.get('datanasc', ''),
        data.get('sexo', 'Masculino'),
        data.get('cor', 'Pardo'),
        data.get('cidade', 'MANAUS'),
        data.get('nacionalidade', 'BRASILEIRA'),
        data.get('UF', 'AM'),
        data.get('rua', ''),
        data.get('bairro', ''),
        data.get('cep', ''),
        data.get('numero', ''),
        data.get('zona', 'URBANA'),
        data.get('telefone', ''),
        data.get('vive_com', 'PAIS'),
        data.get('doenca', 'NÃO'),
        data.get('emergencia', ''),
        data.get('mae', ''),
        data.get('pai', ''),
        data.get('responsavel1', ''),
        data.get('responsavel2', ''),
        data.get('turno', 'Manhã'),
        data.get('etapa', ''),
        data.get('observacao', ''),
        data.get('status', 'ATIVO'),
        aluno_id
    ))
    
    # Atualiza responsável acadêmico se dados passados
    if 'resp_acad_nome' in data:
        execute("""
        UPDATE tb_responsavel_academico SET
            nome = ?, parentesco = ?, CPF = ?, RG = ?, orgao_emissor = ?,
            datanasc = ?, profissao = ?, rua = ?, bairro = ?, numero = ?,
            CEP = ?, email = ?, telefone = ?
        WHERE idaluno = ?
        """, (
            data.get('resp_acad_nome', ''),
            data.get('resp_acad_parentesco', ''),
            data.get('resp_acad_cpf', ''),
            data.get('resp_acad_rg', ''),
            data.get('resp_acad_orgao', ''),
            data.get('resp_acad_nasc', ''),
            data.get('resp_acad_profissao', ''),
            data.get('resp_acad_rua', ''),
            data.get('resp_acad_bairro', ''),
            data.get('resp_acad_numero', ''),
            data.get('resp_acad_cep', ''),
            data.get('resp_acad_email', ''),
            data.get('resp_acad_telefone', ''),
            aluno_id
        ))
        
    # Atualiza responsável financeiro se dados passados
    if 'resp_fin_nome' in data:
        execute("""
        UPDATE tb_responsavel_financeiro SET
            nome = ?, parentesco = ?, CPF = ?, RG = ?, orgao_emissor = ?,
            datanasc = ?, profissao = ?, rua = ?, bairro = ?, numero = ?,
            CEP = ?, email = ?, telefone = ?
        WHERE idaluno = ?
        """, (
            data.get('resp_fin_nome', ''),
            data.get('resp_fin_parentesco', ''),
            data.get('resp_fin_cpf', ''),
            data.get('resp_fin_rg', ''),
            data.get('resp_fin_orgao', ''),
            data.get('resp_fin_nasc', ''),
            data.get('resp_fin_profissao', ''),
            data.get('resp_fin_rua', ''),
            data.get('resp_fin_bairro', ''),
            data.get('resp_fin_numero', ''),
            data.get('resp_fin_cep', ''),
            data.get('resp_fin_email', ''),
            data.get('resp_fin_telefone', ''),
            aluno_id
        ))
        
    # Atualiza turma
    if 'idturma' in data:
        execute("DELETE FROM tb_alunos_turmas WHERE idaluno = ?", (aluno_id,))
        if data['idturma']:
            execute("INSERT INTO tb_alunos_turmas (idaluno, idturma) VALUES (?, ?)", (aluno_id, data['idturma']))
            
    return True

def delete_aluno(aluno_id):
    execute("DELETE FROM tb_responsavel_academico WHERE idaluno = ?", (aluno_id,))
    execute("DELETE FROM tb_responsavel_financeiro WHERE idaluno = ?", (aluno_id,))
    execute("DELETE FROM tb_alunos_turmas WHERE idaluno = ?", (aluno_id,))
    return execute("DELETE FROM tb_alunos WHERE ID_aluno = ?", (aluno_id,))

def list_turmas():
    return query_all("""
    SELECT 
        t.ID_turma as id,
        t.nome_turma,
        t.serie,
        t.turno,
        t.ano_letivo,
        t.qtd_alunos,
        COALESCE(p.nome_professor, 'Não atribuído') as professor_nome,
        COUNT(at.idaluno) as total_matriculados
    FROM tb_turmas t
    LEFT JOIN tb_professores p ON t.idprofessor = p.ID_professor
    LEFT JOIN tb_alunos_turmas at ON t.ID_turma = at.idturma
    GROUP BY t.ID_turma
    ORDER BY t.nome_turma ASC
    """)

def create_turma(data, usuario='ADMIN'):
    data_gerada = datetime.now().strftime('%Y-%m-%d')
    next_turma = query_one("SELECT COALESCE(MAX(ID_turma), 0) + 1 as next_id FROM tb_turmas")
    turma_id = next_turma['next_id'] if next_turma else 1
    execute("""
    INSERT INTO tb_turmas (ID_turma, nome_turma, serie, turno, qtd_alunos, idprofessor, ano_letivo, idetapa, data_gerada, usuario)
    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    """, (
        turma_id,
        data.get('nome_turma', ''),
        data.get('serie', ''),
        data.get('turno', 'MATUTINO'),
        int(data.get('qtd_alunos', 30)),
        int(data.get('idprofessor', 0)),
        int(data.get('ano_letivo', datetime.now().strftime('%Y'))),
        int(data.get('idetapa', 1)),
        data_gerada,
        usuario
    ))
    return turma_id

def list_professores():
    return query_all("""
    SELECT 
        p.ID_professor as id, 
        p.nome_professor as nome, 
        p.telefone, 
        p.username,
        (SELECT COUNT(*) FROM tb_turmas WHERE idprofessor = p.ID_professor) as total_turmas
    FROM tb_professores p 
    ORDER BY p.nome_professor ASC
    """)

def create_professor(data):
    next_prof = query_one("SELECT COALESCE(MAX(ID_professor), 0) + 1 as next_id FROM tb_professores")
    prof_id = next_prof['next_id'] if next_prof else 1
    nome = (data.get('nome') or data.get('nome_professor', '')).strip()
    telefone = (data.get('telefone', '')).strip()
    username = (data.get('username') or nome.lower().replace(' ', '')[:15]).strip()
    senha = (data.get('senha') or '123456').strip()
    execute(
        "INSERT INTO tb_professores (ID_professor, nome_professor, telefone, username, senha) VALUES (?, ?, ?, ?, ?)",
        (prof_id, nome, telefone, username, senha)
    )
    return prof_id

def list_responsaveis(tipo='financeiro', busca=''):
    tabela = 'tb_responsavel_financeiro' if tipo == 'financeiro' else 'tb_responsavel_academico'
    id_col = 'ID_responsavel_financeiro' if tipo == 'financeiro' else 'ID_responsavel_academico'
    params = []
    where = ""
    if busca:
        where = f"WHERE r.nome LIKE ? OR r.CPF LIKE ? OR a.nome_aluno LIKE ?"
        params.extend([f"%{busca}%", f"%{busca}%", f"%{busca}%"])
    return query_all(f"""
    SELECT 
        r.{id_col} as id,
        r.nome,
        r.CPF,
        r.RG,
        r.telefone,
        r.email,
        r.parentesco,
        r.profissao,
        r.rua,
        r.bairro,
        a.nome_aluno,
        a.ID_aluno as idaluno
    FROM {tabela} r
    LEFT JOIN tb_alunos a ON r.idaluno = a.ID_aluno
    {where}
    ORDER BY r.nome ASC
    LIMIT 150
    """, tuple(params))
