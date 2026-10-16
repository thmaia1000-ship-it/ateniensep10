using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar.Faltas
{
    public partial class GestaoFaltas : Form
    {
        public GestaoFaltas()
        {
            InitializeComponent();
        }

        int idSelecionado;
        private void Turmas()
        {
            //POPULAR COMBOBOX Turma
            string vqueryTurmas = $@"
                SELECT
                ID_turma,
                nome_turma
                 FROM
                      tb_turmas
                WHERE ano_letivo = {DateTime.Now.ToString("yyyy")}";


            cb_turma.DataSource = Banco.dql(vqueryTurmas);
            cb_turma.DisplayMember = "nome_turma";
            cb_turma.ValueMember = "ID_turma";

            cb_turma.SelectedValue = -1;

        }

        private void Atualizar()
        {
            dgv_alunos.Rows.Clear();
            string status = "";
            int ID_historico = 0;
            string vQuery = $@"
                SELECT 
                tba.ID_aluno,
                tba.nome_aluno,
                tba.datanasc,
                tba.turno,
                tbc.nome_curso
            FROM 
                tb_alunos AS tba
            INNER JOIN tb_cursos as tbc ON tba.idcurso = tbc.ID_curso
            INNER JOIn tb_alunos_turmas as at ON at.idaluno = tba.ID_aluno
            INNER JOIN tb_turmas as tbt ON tbt.ID_turma = at.idturma
            WHERE tbt.ID_turma = {cb_turma.SelectedValue}
            ORDER BY 
                tba.nome_aluno";

            DataTable alunos = Banco.dql(vQuery);

            for (int i = 0; i < alunos.Rows.Count; i++)
            {
                int ID_aluno = alunos.Rows[i].Field<Int32>("ID_aluno");
                string vqueryFaltas = $@"
                    SELECT 
                        tbf.status,
                        tbf.ID_historico
                    FROM 
                        tb_faltas_historico AS tbf
                    WHERE 
                        tbf.idaluno = {ID_aluno}
                        AND tbf.data_gerada = '{dtp_data1.Value.ToString("yyyy-MM-dd")}' ";
                DataTable faltas = Banco.dql(vqueryFaltas);

                string nome_aluno = alunos.Rows[i].Field<string>("nome_aluno");
                bool teste = false;
                if (faltas.Rows.Count > 0)
                {
                    status = faltas.Rows[0].Field<string>("status");
                    ID_historico = faltas.Rows[0].Field<Int32>("ID_historico");
                }
                else
                {
                    status = "";
                    ID_historico = 0;
                }

                dgv_alunos.Rows.Add(nome_aluno,status, ID_historico,ID_aluno);
            }

            dgv_alunos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void GestaoFaltas_Load(object sender, EventArgs e)
        {
            dtp_data1.Value = DateTime.Today;

            Turmas();
        }

        private void dgv_alunos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgv_alunos.ClearSelection();
            if (dgv_alunos.Columns[e.ColumnIndex].Name == "status")
            {
                if (e.Value is string status)
                {
                    if (status == "PRESENTE")
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    else if (status == "FALTOU")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salvar estes Dados?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                string Bimestre = "SELECT ID_bimestre FROM tb_bimestres WHERE CURDATE() BETWEEN data_inicio AND data_fim";

                DataTable dt = Banco.dql(Bimestre);

                int bimestre = dt.Rows[0].Field<Int32>("ID_bimestre");

                string Etapa = $"SELECT idetapa FROM tb_turmas WHERE ID_turma={cb_turma.SelectedValue}";

                DataTable etapa = Banco.dql(Etapa);

                int idetapa = etapa.Rows[0].Field<Int32>("idetapa");

                for (int i = 0; i < dgv_alunos.Rows.Count; i++)
                {
                    int ID_aluno = Convert.ToInt32(dgv_alunos.Rows[dgv_alunos.Rows[i].Index].Cells[3].Value);
                    idSelecionado = Convert.ToInt32(dgv_alunos.Rows[dgv_alunos.Rows[i].Index].Cells[2].Value);
                    string status = dgv_alunos.Rows[dgv_alunos.Rows[i].Index].Cells[1].Value.ToString();
                    if (idSelecionado == 0 && status != "")
                    {
                        string InserirFaltas = $@"
                        INSERT INTO tb_faltas_historico (status,idaluno,idturma,bimestre,idetapa,ano_letivo,data_gerada,usuario)
                         VALUES('{status}',{ID_aluno},{cb_turma.SelectedValue},{bimestre},{idetapa},{dtp_data1.Value.Year},'{dtp_data1.Value.ToString("yyyy-MM-dd")}','{Globais.Main.PassarUsuario}')";                          
                        Banco.dml(InserirFaltas);
                    }
                    else
                    {
                        string Faltas = $@"SELECT * FROM tb_faltas_historico WHERE ID_historico= {idSelecionado}";
                        DataTable faltas = Banco.dql(Faltas);

                        string status_antigo = faltas.Rows[0].Field<string>("status");

                        string AtualizarFaltas = $@"UPDATE tb_faltas_historico SET status='{status}' WHERE ID_historico={idSelecionado}";
                        Banco.dml(AtualizarFaltas);

                        string acao = "UPDATE";
                        string tabela_afetada = "tb_faltas_historico";
                        int id_registro = Convert.ToInt32(idSelecionado);
                        string data_hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string detalhes = $"Editou status da falta de {status_antigo} para {status}";

                        Banco.log(acao, tabela_afetada, id_registro, detalhes, data_hora); // Inserindo dados na Log
                    }
                }

                MessageBox.Show("Dados Salvos com Sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Atualizar();
            }
            
        }

        private void dgv_alunos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a linha e a coluna clicada são válidas
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtém a célula clicada
                DataGridViewCell cell = dgv_alunos.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Alterna entre os valores "FALTOU" e "PRESENTE"
                if (cell.Value != null && cell.Value.ToString() == "FALTOU")
                {
                    cell.Value = "PRESENTE";
                }
                else if (cell.Value != null && cell.Value.ToString() == "PRESENTE")
                {
                    cell.Value = "FALTOU";
                }
                else
                {
                    cell.Value = "PRESENTE";
                }
            }

            dgv_alunos.ClearSelection();
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (dgv_alunos.Rows.Count > 0)
            {
                if (MessageBox.Show("Excluir estes Dados?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    for (int i = 0; i < dgv_alunos.Rows.Count; i++)
                    {
                        idSelecionado = Convert.ToInt32(dgv_alunos.Rows[dgv_alunos.Rows[i].Index].Cells[2].Value);
                        string vQueryExcluir = $@"DELETE FROM tb_faltas_historico WHERE ID_historico={idSelecionado}";
                        Banco.dql(vQueryExcluir);

                        
                        Atualizar();
                    }

                    MessageBox.Show("Diário excluído com sucesso!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }
    }
}
