using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Escolar
{
    public partial class F_NovoAluno : Form
    {
        //string OrigemCompleto="";
        //string foto ="";
        //string PastaDestino = Globais.caminhoFotos;
        //string DestinoCompleto = "";
        private void abreForm(int nivel, Form f)
        {
            if (Globais.logado)
            {

                if (Globais.nivel >= nivel)
                //Procedimentos
                {

                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }

            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }
        

        public F_NovoAluno()
        {
            InitializeComponent();
        }

        private void F_NovoAluno_Load(object sender, EventArgs e)
        {
            tb_Aluno.Enabled = false;
            mstb_DataNasc.Enabled = false;
            tb_Cidade.Enabled = false;
            tb_Nacionalidade.Enabled = false;
            cb_UF.Enabled = false;
            tb_Rua.Enabled = false;
            tb_NumeroEnd.Enabled = false;
            tb_BairroEnd.Enabled = false;
            tb_CEPEnd.Enabled = false;
            tb_Curso.Enabled = false;
            tb_Mae.Enabled = false;

            Dictionary<string, string> etapa = new Dictionary<string, string>();

            etapa.Add("MATERNAL I", "MATERNAL I");
            etapa.Add("MATERNAL II", "MATERNAL II");
            etapa.Add("JARDIM I", "JARDIM I");
            etapa.Add("JARDIM II", "JARDIM II");
            etapa.Add("1° ANO", "1° ANO");
            cb_etapa.DataSource = new BindingSource(etapa, null);
            cb_etapa.DisplayMember = "Value";
            cb_etapa.ValueMember = "Key";

            Dictionary<string, string> sexo = new Dictionary<string, string>();

            sexo.Add("Masculino", "Masculino");
            sexo.Add("Feminino", "Feminino");
            cb_Sexo.DataSource = new BindingSource(sexo, null);
            cb_Sexo.DisplayMember = "Value";
            cb_Sexo.ValueMember = "Key";

            Dictionary<string, string> cor = new Dictionary<string, string>();

            cor.Add("Amarelo", "Amarelo");
            cor.Add("Branco", "Branco");
            cor.Add("Indígena", "Indígena");
            cor.Add("Negro", "Negro");
            cor.Add("Pardo", "Pardo");
            cb_Cor.DataSource = new BindingSource(cor, null);
            cb_Cor.DisplayMember = "Value";
            cb_Cor.ValueMember = "Key";

            Dictionary<string, string> turno = new Dictionary<string, string>();


            turno.Add("MATUTINO", "MATUTINO");
            turno.Add("MATUTINO M. PERIODO", "MATUTINO M. PERIODO");
            turno.Add("VESPERTINO", "VESPERTINO");
            turno.Add("VESPERTINO M. PERIODO", "VESPERTINO M. PERIODO");
            turno.Add("INTEGRAL", "INTEGRAL");
            cb_Turno.DataSource = new BindingSource(turno, null);
            cb_Turno.DisplayMember = "Value";
            cb_Turno.ValueMember = "Key";


            Dictionary<string, string> uf = new Dictionary<string, string>();

            uf.Add("AC", "AC");
            uf.Add("AL", "AL");
            uf.Add("AP", "AP");
            uf.Add("AM", "AM");
            uf.Add("BA", "BA");
            uf.Add("CE", "CE");
            uf.Add("DF", "DF");
            uf.Add("ES", "ES");
            uf.Add("GO", "GO");
            uf.Add("MA", "MA");
            uf.Add("MT", "MT");
            uf.Add("MS", "MS");
            uf.Add("MG", "MG");
            uf.Add("PA", "PA");
            uf.Add("PB", "PB");
            uf.Add("PR", "PR");
            uf.Add("PE", "PE");
            uf.Add("PI", "PI");
            uf.Add("RJ", "RJ");
            uf.Add("RN", "RN");
            uf.Add("RS", "RS");
            uf.Add("RO", "RO");
            uf.Add("RR", "RR");
            uf.Add("SC", "SC");
            uf.Add("SP", "SP");
            uf.Add("SE", "SE");
            uf.Add("TO", "TO");
            uf.Add("Outro", "Outro");

            cb_UF.DataSource = new BindingSource(uf, null);
            cb_UF.DisplayMember = "Value";
            cb_UF.ValueMember = "Key";

            tb_Doenca.Text = "Nenhuma";

            string vqueryCursos = @"
                SELECT
                ID_curso,
                nome_curso
   
                 FROM
                      tb_cursos
                 ORDER BY
                      ID_curso";
            tb_Curso.Items.Clear();
            tb_Curso.DataSource = Banco.dql(vqueryCursos);
            tb_Curso.DisplayMember = "nome_curso";
            tb_Curso.ValueMember = "ID_curso";
            tb_Curso.SelectedValue = -1;

            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2023", "2023");
            ano.Add("2024", "2024");
            ano.Add("2025", "2025");
            ano.Add("2026", "2026");
            ano.Add("2027", "2027");
            ano.Add("2028", "2028");
            ano.Add("2029", "2029");
            ano.Add("2030", "2030");
            ano.Add("2031", "2031");
            ano.Add("2032", "2032");
            ano.Add("2033", "2033");
            ano.Add("2034", "2034");
            ano.Add("2035", "2035");
            cb_ano.DataSource = new BindingSource(ano, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";



            if (Globais.Main.PassarPlanoContrato == "Matricula2026")
            {
                cb_ano.SelectedValue = 2026;
            }
            else if (Globais.Main.PassarPlanoContrato == "Matricula2027")
            {
                cb_ano.SelectedValue = 2027;
            }
            else
            {
                string AnoAtual = DateTime.Now.ToString("yyyy");
                cb_ano.SelectedValue = AnoAtual;
            }

        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            tb_Aluno.Enabled = true;
            mstb_DataNasc.Enabled = true;
            cb_Cor.Enabled = true;
            cb_Sexo.Enabled = true;
            tb_Cidade.Enabled = true;
            tb_Nacionalidade.Enabled = true;
            cb_UF.Enabled = true;
            tb_Rua.Enabled = true;
            tb_NumeroEnd.Enabled = true;
            tb_BairroEnd.Enabled = true;
            tb_CEPEnd.Enabled = true;
            tb_Zona.Enabled = true;
            tb_Mae.Enabled = true;
            tb_Pai.Enabled = true;
            tb_Outro1.Enabled = true;
            tb_Outro2.Enabled = true;
            cb_Turno.Enabled = true;
            tb_ViveCom.Enabled = true;
            Liberar_Doenca.Enabled = true;
            tb_Doenca.Enabled = false;
            tb_Emergencia.Enabled = true;
            tb_Curso.Enabled = true;
            mstb_TelefoneEnd.Enabled = true;
            cb_etapa.Enabled = true;
            cb_ano.Enabled = true;

            tb_Aluno.Clear();
            mstb_DataNasc.Clear();
            cb_Cor.SelectedValue = -1;
            cb_Sexo.SelectedValue = -1;
            cb_Turno.SelectedValue = -1;
            tb_Cidade.Clear();
            tb_Nacionalidade.Clear();
            cb_UF.SelectedValue = -1;
            tb_Rua.Clear();
            tb_NumeroEnd.Clear();
            tb_BairroEnd.Clear();
            tb_CEPEnd.Clear();
            tb_Zona.Clear();
            tb_Mae.Clear();
            tb_Pai.Clear();
            tb_Outro1.Clear();
            tb_Outro2.Clear();
            cb_Turno.SelectedValue = -1;
            tb_ViveCom.Clear();
            mstb_TelefoneEnd.Clear();
            tb_Emergencia.Clear();


            tb_Aluno.Focus();
            btn_Gravar.Enabled = true;
            btn_Cancelar.Enabled = true;
            btn_Novo.Enabled = false;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {

            tb_Aluno.Enabled = false;
            mstb_DataNasc.Enabled = false;
            cb_Cor.Enabled = false;
            cb_Sexo.Enabled = false;
            tb_Cidade.Enabled = false;
            tb_Nacionalidade.Enabled = false;
            cb_UF.Enabled = false;
            tb_Rua.Enabled = false;
            tb_NumeroEnd.Enabled = false;
            tb_BairroEnd.Enabled = false;
            tb_CEPEnd.Enabled = false;
            tb_Zona.Enabled = false;
            tb_Mae.Enabled = false;
            tb_Pai.Enabled = false;
            tb_Outro1.Enabled = false;
            tb_Outro2.Enabled = false;
            cb_Turno.Enabled = false;
            tb_ViveCom.Enabled = false;
            Liberar_Doenca.Enabled = false;
            tb_Doenca.Enabled = false;
            tb_Emergencia.Enabled = false;
            mstb_TelefoneEnd.Enabled = false;
            cb_etapa.Enabled = false;
            cb_ano.Enabled = false;

            tb_Aluno.Clear();
            mstb_TelefoneEnd.Clear();
            mstb_DataNasc.Clear();
            cb_Cor.SelectedValue = -1;
            cb_Sexo.SelectedValue = -1;
            tb_Cidade.Clear();
            tb_Nacionalidade.Clear();
            cb_UF.SelectedValue = -1;
            tb_Rua.Clear();
            tb_NumeroEnd.Clear();
            tb_BairroEnd.Clear();
            tb_CEPEnd.Clear();
            tb_Zona.Clear();
            tb_Mae.Clear();
            tb_Pai.Clear();
            tb_Outro1.Clear();
            tb_Outro2.Clear();
            cb_Turno.SelectedValue = -1;
            cb_etapa.SelectedValue = -1;
            tb_ViveCom.Clear();
            tb_Emergencia.Clear();

            btn_Gravar.Enabled = false;
            btn_Cancelar.Enabled = false;
            btn_Novo.Enabled = true;
        }


        private void btn_Gravar_Click(object sender, EventArgs e)
        {
                if (tb_Aluno.Text == "")
                {
                    MessageBox.Show("O nome do Aluno(a) é obrigatório!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_Aluno.Focus();
                }
                else if (tb_Curso.Text == "")
                {
                    MessageBox.Show("Informe o Curso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_Curso.Focus();
                }
                else if (MessageBox.Show("Confirmar registro de Matrícula?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DateTime nascimento = Convert.ToDateTime(mstb_DataNasc.Text);
                    string DataNascimento = nascimento.ToString("yyyy-MM-dd");
                    string Data = DateTime.Now.ToString("yyyy-MM-dd");

                    string queryInsertAluno = String.Format(@"
                        INSERT INTO tb_alunos 
                            (nome_aluno,datanasc,sexo,cor,cidade,nacionalidade,UF,rua,bairro,cep,numero,zona,telefone,vive_com,doenca,emergencia,mae,pai,responsavel1,responsavel2,turno,etapa,idcurso,data_gerada,usuario,ano_letivo, status)  
                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}',{22},'{23}','{24}',{25},'{26}');
                        SELECT LAST_INSERT_ID();",
                        tb_Aluno.Text.ToUpper(), DataNascimento, cb_Sexo.SelectedValue, cb_Cor.SelectedValue, tb_Cidade.Text, tb_Nacionalidade.Text,
                        cb_UF.SelectedValue, tb_Rua.Text, tb_BairroEnd.Text, tb_CEPEnd.Text, tb_NumeroEnd.Text, tb_Zona.Text, mstb_TelefoneEnd.Text,
                        tb_ViveCom.Text, tb_Doenca.Text, tb_Emergencia.Text, tb_Mae.Text, tb_Pai.Text, tb_Outro1.Text, tb_Outro2.Text,
                        cb_Turno.SelectedValue, cb_etapa.SelectedValue, tb_Curso.SelectedValue, Data, Globais.Main.PassarUsuario, cb_ano.SelectedValue.ToString(), "ATIVO"
                    );

                    // Executa o insert e já pega o último ID inserido
                    DataTable dt = Banco.dql(queryInsertAluno);
                    string ultimoId = dt.Rows[0][0].ToString();

                    MessageBox.Show("Aluno Cadastrado", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Globais.Main.PassarCurso = tb_Curso.Text;
                    Globais.Main.PassarAluno = tb_Aluno.Text.ToUpper().Trim();
                    Globais.Main.PassarIdAluno = ultimoId;

                    CriarPastaFTP(ultimoId);

                    //Cadastrar Imagem do Aluno
                if (MessageBox.Show("Registrar Foto?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Cadastros.CadastrarImagem cadastrar = new Cadastros.CadastrarImagem();
                        cadastrar.ShowDialog();
                    }

                    F_ResponsavelFinanceiro f_ResponsavelFinanceiro = new F_ResponsavelFinanceiro();
                    f_ResponsavelFinanceiro.ShowDialog();

                    tb_Aluno.Enabled = false;
                    mstb_DataNasc.Enabled = false;
                    cb_Cor.Enabled = false;
                    cb_Sexo.Enabled = false;
                    tb_Cidade.Enabled = false;
                    tb_Nacionalidade.Enabled = false;
                    cb_UF.Enabled = false;
                    tb_Rua.Enabled = false;
                    tb_NumeroEnd.Enabled = false;
                    tb_BairroEnd.Enabled = false;
                    tb_CEPEnd.Enabled = false;
                    tb_Zona.Enabled = false;
                    tb_Mae.Enabled = false;
                    tb_Pai.Enabled = false;
                    tb_Outro1.Enabled = false;
                    tb_Outro2.Enabled = false;
                    cb_Turno.Enabled = false;
                    tb_ViveCom.Enabled = false;
                    Liberar_Doenca.Enabled = false;
                    tb_Doenca.Enabled = false;
                    tb_Emergencia.Enabled = false;
                    mstb_TelefoneEnd.Enabled = false;
                    cb_etapa.Enabled = false;
                    cb_ano.Enabled = false;

                    tb_Aluno.Clear();
                    mstb_DataNasc.Clear();
                    cb_Cor.SelectedValue = -1;
                    cb_Sexo.SelectedValue = -1;
                    cb_Turno.SelectedValue = -1;
                    tb_Cidade.Clear();
                    tb_Nacionalidade.Clear();
                    cb_UF.SelectedValue = -1;
                    tb_Rua.Clear();
                    tb_NumeroEnd.Clear();
                    tb_BairroEnd.Clear();
                    tb_CEPEnd.Clear();
                    tb_Zona.Clear();
                    tb_Mae.Clear();
                    tb_Pai.Clear();
                    tb_Outro1.Clear();
                    tb_Outro2.Clear();
                    cb_Turno.SelectedValue = -1;
                    tb_ViveCom.Clear();
                    mstb_TelefoneEnd.Clear();
                    tb_Emergencia.Clear();
                    cb_etapa.SelectedValue = -1;
                    btn_Gravar.Enabled = false;
                    btn_Cancelar.Enabled = false;
                    btn_Novo.Enabled = true;
            }
        }

        private void CriarPastaFTP(string idSelecionado)
        {

            string pastaAluno = idSelecionado;
            string[] subPastas = { "", "documentos", "contratos", $"contratos/{cb_ano.Text}" };
            bool algumaCriada = false;

            // Cria/verifica as pastas no FTP
            foreach (string sub in subPastas)
            {
                string caminhoFTP = string.IsNullOrEmpty(sub) ? pastaAluno : $"{pastaAluno}/{sub}";

                if (!PastaExisteFTP(caminhoFTP))
                {
                    FtpWebRequest criarPasta = Banco.ConexaoFTP.CriarConexao(caminhoFTP, WebRequestMethods.Ftp.MakeDirectory);
                    using (var resp = (FtpWebResponse)criarPasta.GetResponse()) { }
                    algumaCriada = true;
                }
            }

            AtualizarBancoFTP(pastaAluno);

        }

        // ========================== ATUALIZA BANCO ==========================
        private void AtualizarBancoFTP(string pastaAluno)
        {
            string vqueryVerifica = $"SELECT COUNT(*) FROM tb_caminhoftp WHERE idaluno={pastaAluno}";
            DataTable dt = Banco.dql(vqueryVerifica);

            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count > 0)
            {
                // Já existe no banco → nada faz
                return;
            }
            else
            {
                // Insere novo registro apenas com o ID do aluno
                string insertQuery = $@"
                INSERT INTO tb_caminhoftp (idaluno, data_gerada, usuario)
                VALUES ({pastaAluno}, '{DateTime.Today:yyyy-MM-dd}', '{Globais.Main.PassarUsuario}')";
                Banco.dml(insertQuery);
            }
        }

        // ========================== VERIFICA PASTA EXISTE ==========================
        private bool PastaExisteFTP(string caminhoFTP)
        {
            try
            {
                FtpWebRequest request = Banco.ConexaoFTP.CriarConexao(caminhoFTP, WebRequestMethods.Ftp.ListDirectory);
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void btn_Turma_Click(object sender, EventArgs e)
        {
            F_SelecionarCurso f_SelecionarTurma = new F_SelecionarCurso(this);
            f_SelecionarTurma.ShowDialog();

        }

        private void Liberar_Doenca_CheckedChanged(object sender, EventArgs e)
        {
            if (Liberar_Doenca.Checked == true)
            {
                tb_Doenca.Enabled = true;
                tb_Doenca.Clear();
                tb_Doenca.Focus();
            }
            else
            {
                tb_Doenca.Enabled = false;
                tb_Doenca.Text = "Nenhuma";
            }
        }

    }
}

