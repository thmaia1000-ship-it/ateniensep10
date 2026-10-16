# -*- coding: utf-8 -*-
"""
Serviço Acadêmico: Boletim, Diário Online, Lançamento de Notas, Bimestres e Faltas
"""

from datetime import datetime
from database.db import query_all, query_one, execute

def list_bimestres():
    hoje = datetime.now().strftime('%Y-%m-%d')
    bimestres = query_all("SELECT * FROM tb_bimestres ORDER BY ID_bimestre ASC")
    res = []
    for b in bimestres:
        d_ini = b['data_inicio'] or ''
        d_fim = b['data_fim'] or ''
        if hoje < d_ini:
            status = 'Previsto'
            status_badge = 'bg-info text-dark'
        elif d_ini <= hoje <= d_fim:
            status = 'Em Andamento'
            status_badge = 'bg-success'
        else:
            status = 'Encerrado'
            status_badge = 'bg-secondary'
        res.append({
            'id': b['ID_bimestre'],
            'nome': f"{b['ID_bimestre']}º Bimestre",
            'data_inicio': d_ini,
            'data_fim': d_fim,
            'status': status,
            'status_badge': status_badge
        })
    return res

def update_bimestre(b_id, data_inicio, data_fim):
    execute("UPDATE tb_bimestres SET data_inicio = ?, data_fim = ? WHERE ID_bimestre = ?", (data_inicio, data_fim, b_id))
    return {'id': b_id, 'data_inicio': data_inicio, 'data_fim': data_fim}

def list_materias():
    return query_all("SELECT ID_materia as id, materia FROM tb_materias ORDER BY materia ASC")

def get_boletim(aluno_id, ano=None):
    if not ano:
        aluno = query_one("SELECT ano_letivo, nome_aluno, etapa, turno FROM tb_alunos WHERE ID_aluno = ?", (aluno_id,))
        ano = aluno['ano_letivo'] if aluno else datetime.now().strftime('%Y')
    else:
        aluno = query_one("SELECT ano_letivo, nome_aluno, etapa, turno FROM tb_alunos WHERE ID_aluno = ?", (aluno_id,))
        
    if not aluno:
        return None
        
    # Busca turma do aluno
    turma = query_one("""
    SELECT t.nome_turma, t.serie, t.turno 
    FROM tb_alunos_turmas at 
    JOIN tb_turmas t ON at.idturma = t.ID_turma 
    WHERE at.idaluno = ?
    """, (aluno_id,))
    
    # Busca todas as matérias associadas às notas deste aluno
    materias = query_all("""
    SELECT DISTINCT m.ID_materia as id, m.materia
    FROM tb_notas n
    JOIN tb_materias m ON n.idmateria = m.ID_materia
    WHERE n.idaluno = ?
    ORDER BY m.materia ASC
    """, (aluno_id,))
    
    # Se não houver notas ainda, busca matérias padrão
    if not materias:
        materias = query_all("SELECT ID_materia as id, materia FROM tb_materias LIMIT 10")
        
    boletim_linhas = []
    
    for mat in materias:
        mat_id = mat['id']
        notas_row = {'materia': mat['materia'], 'b1': '-', 'b2': '-', 'b3': '-', 'b4': '-', 'media': '-', 'situacao': 'Cursando'}
        notas = query_all("""
        SELECT bimestre, nota 
        FROM tb_notas 
        WHERE idaluno = ? AND idmateria = ?
        """, (aluno_id, mat_id))
        
        soma = 0.0
        qtd = 0
        for n in notas:
            b = str(n['bimestre'])
            val_str = str(n['nota']).strip()
            if b in ['1', '1º']:
                notas_row['b1'] = val_str
            elif b in ['2', '2º']:
                notas_row['b2'] = val_str
            elif b in ['3', '3º']:
                notas_row['b3'] = val_str
            elif b in ['4', '4º']:
                notas_row['b4'] = val_str
                
            try:
                # Tenta converter nota numérica
                num = float(val_str.replace(',', '.'))
                soma += num
                qtd += 1
            except ValueError:
                pass
                
        if qtd > 0:
            media = soma / qtd
            notas_row['media'] = f"{media:.1f}"
            notas_row['situacao'] = 'Aprovado' if media >= 6.0 else 'Recuperação'
        else:
            notas_row['media'] = '-'
            notas_row['situacao'] = '-'
            
        boletim_linhas.append(notas_row)
        
    # Busca total de faltas
    faltas_count = query_one("""
    SELECT COUNT(*) as total FROM tb_faltas_historico 
    WHERE idaluno = ? AND status = 'FALTOU'
    """, (aluno_id,))
    total_faltas = faltas_count['total'] if faltas_count else 0
    
    return {
        'aluno': aluno,
        'turma': turma,
        'ano': ano,
        'materias': boletim_linhas,
        'total_faltas': total_faltas
    }

def list_diario(turma_id=None, busca=None, limit=100):
    params = []
    where_clauses = []
    if turma_id:
        where_clauses.append("(d.turma = ? OR t.ID_turma = ?)")
        params.extend([turma_id, turma_id])
    if busca:
        where_clauses.append("(d.nome_professor LIKE ? OR d.comp_curricular LIKE ? OR d.conteudos LIKE ? OR d.serie LIKE ?)")
        params.extend([f"%{busca}%", f"%{busca}%", f"%{busca}%", f"%{busca}%"])
    
    where_str = ("WHERE " + " AND ".join(where_clauses)) if where_clauses else ""
    sql = f"""
    SELECT 
        d.ID_diario as id,
        d.nome_professor,
        d.comp_curricular,
        d.data_diario,
        d.serie,
        COALESCE(t.nome_turma, d.serie) as nome_turma,
        d.conteudos,
        d.desenvolvimento,
        d.objetivos,
        d.atividade_sala,
        d.atividade_casa,
        d.recursos,
        d.avaliacao,
        d.ano_letivo,
        d.turma
    FROM tb_diario d
    LEFT JOIN tb_turmas t ON d.turma = t.ID_turma
    {where_str}
    ORDER BY d.data_diario DESC, d.ID_diario DESC
    LIMIT {limit}
    """
    return query_all(sql, tuple(params))

def create_diario(data, usuario='ADMIN'):
    data_gerada = datetime.now().strftime('%Y-%m-%d')
    next_id_row = query_one("SELECT COALESCE(MAX(ID_diario), 0) + 1 as next_id FROM tb_diario")
    diario_id = next_id_row['next_id'] if next_id_row else 1

    execute("""
    INSERT INTO tb_diario (
        ID_diario, nome_professor, comp_curricular, data_diario, serie, turma,
        atividades_percepcao, objetivos, conteudos, desenvolvimento,
        atividade_sala, atividade_casa, recursos, avaliacao, ano_letivo,
        data_gerada, usuario
    ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    """, (
        diario_id,
        data.get('nome_professor', ''),
        data.get('comp_curricular', ''),
        data.get('data_diario', data_gerada),
        data.get('serie', ''),
        int(data.get('turma', 1) or 1),
        data.get('atividades_percepcao', ''),
        data.get('objetivos', ''),
        data.get('conteudos', ''),
        data.get('desenvolvimento', ''),
        data.get('atividade_sala', ''),
        data.get('atividade_casa', ''),
        data.get('recursos', ''),
        data.get('avaliacao', ''),
        int(data.get('ano_letivo', datetime.now().strftime('%Y')) or 2026),
        data_gerada,
        usuario
    ))
    return diario_id

def lancar_nota(aluno_id, materia_id, bimestre, nota, ano_letivo, usuario='ADMIN'):
    data_gerada = datetime.now().strftime('%Y-%m-%d')
    # Checa se já existe nota
    existente = query_one("""
    SELECT ID_nota FROM tb_notas 
    WHERE idaluno = ? AND idmateria = ? AND bimestre = ? AND ano_letivo = ?
    """, (aluno_id, materia_id, bimestre, ano_letivo))
    
    if existente:
        execute("""
        UPDATE tb_notas SET nota = ?, usuario = ? WHERE ID_nota = ?
        """, (str(nota), usuario, existente['ID_nota']))
        return existente['ID_nota']
    else:
        next_id_row = query_one("SELECT COALESCE(MAX(ID_nota), 0) + 1 as next_id FROM tb_notas")
        nota_id = next_id_row['next_id'] if next_id_row else 1
        aluno = query_one("SELECT nome_aluno FROM tb_alunos WHERE ID_aluno = ?", (aluno_id,))
        materia = query_one("SELECT materia FROM tb_materias WHERE ID_materia = ?", (materia_id,))
        aluno_nome = aluno['nome_aluno'] if aluno else ''
        materia_nome = materia['materia'] if materia else ''
        execute("""
        INSERT INTO tb_notas (ID_nota, aluno, professor, materia, nota, bimestre, idaluno, idcurso, idmateria, idetapa, idprofessor, ano_letivo, data_gerada, usuario)
        VALUES (?, ?, '', ?, ?, ?, ?, 1, ?, 1, 1, ?, ?, ?)
        """, (nota_id, aluno_nome, materia_nome, str(nota), bimestre, aluno_id, materia_id, ano_letivo, data_gerada, usuario))
        return nota_id

def list_faltas(turma_id=None, limit=100):
    params = []
    where = ""
    if turma_id:
        where = "WHERE f.turma = ?"
        params.append(turma_id)
    sql = f"""
    SELECT 
        f.ID_falta_historico as id,
        f.data_falta,
        f.status,
        f.materia,
        f.idaluno,
        a.nome_aluno
    FROM tb_faltas_historico f
    LEFT JOIN tb_alunos a ON f.idaluno = a.ID_aluno
    {where}
    ORDER BY f.data_falta DESC, f.ID_falta_historico DESC
    LIMIT {limit}
    """
    return query_all(sql, tuple(params))
