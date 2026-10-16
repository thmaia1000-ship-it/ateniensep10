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
using MySql.Data.MySqlClient;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Escolar.Gestão;
using System.Net;
using static Escolar.Banco;

namespace Escolar
{
    public partial class F_GestaoAlunos : Form
    {
        string idSelecionado = "";
        int idetapa;
        int linha = 0;
        int IDTurmaAntigo;
        public F_GestaoAlunos()
        {
            InitializeComponent();
        }

        private void PegarIDEtapa()
        {
            if (cb_turma.Text == "MATERNAL I")
            {
                idetapa = 1;
            }
            else if (cb_turma.Text == "MATERNAL II")
            {
                idetapa = 9;
            }
            else if (cb_turma.Text == "JARDIM I")
            {
                idetapa = 2;
            }
            else if (cb_turma.Text == "JARDIM II")
            {
                idetapa = 3;
            }
            else if (cb_turma.Text == "1° ANO")
            {
                idetapa = 4;
            }
            else if (cb_turma.Text == "2° ANO")
            {
                idetapa = 5;
            }
            else if (cb_turma.Text == "3° ANO")
            {
                idetapa = 6;
            }
            else if (cb_turma.Text == "4° ANO")
            {
                idetapa = 7;
            }
            else if (cb_turma.Text == "5° ANO")
            {
                idetapa = 8;
            }
        }
        private async void btn_imagem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idSelecionado))
            {
                MessageBox.Show("Nenhum aluno selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abre o diálogo para selecionar o arquivo
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione uma imagem para enviar";
                openFileDialog.Filter = "Imagens (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtém o caminho do arquivo selecionado
                    string filePath = openFileDialog.FileName;

                    using (F_Loading loading = new F_Loading("Enviando imagem..."))
                    {
                        loading.Owner = this;
                        loading.Show();
                        loading.BringToFront();
                        loading.Refresh();

                        try
                        {
                            // Antes de enviar, verifica/cria pasta no FTP (em background)
                            string pastaAluno = idSelecionado;
                            await Task.Run(() =>
                            {
                                if (!PastaExisteFTP(pastaAluno))
                                {
                                    FtpWebRequest criarPasta = Banco.ConexaoFTP.CriarConexao(pastaAluno, WebRequestMethods.Ftp.MakeDirectory);
                                    using (var resp = (FtpWebResponse)criarPasta.GetResponse()) { }
                                }
                            });

                            // Chama o método de upload em background
                            await Task.Run(() => UploadImageToFTP(filePath));

                            loading.Close();

                            MessageBox.Show("Imagem enviada com sucesso!", "Mensagem do Sistema",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            loading.Close();
                            MessageBox.Show($"Erro ao enviar imagem: {ex.Message}", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void F_GestaoAlunos_Load(object sender, EventArgs e)
        {
            btn_RespFinan.Enabled = false;

            Dictionary<string, string> sexo = new Dictionary<string, string>();

            sexo.Add("Masculino", "Masculino");
            sexo.Add("Feminino", "Feminino");
            cb_Sexo.DataSource = new BindingSource(sexo, null);
            cb_Sexo.DisplayMember = "Value";
            cb_Sexo.ValueMember = "Key";

            Dictionary<string, string> status = new Dictionary<string, string>();

            status.Add("ATIVO", "ATIVO");
            status.Add("TRANCADO", "TRANCADO");
            status.Add("DESATIVADO", "DESATIVADO");
            cb_status.DataSource = new BindingSource(status, null);
            cb_status.DisplayMember = "Value";
            cb_status.ValueMember = "Key";

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

            //POPULAR COMBOBOX Turma
            string vqueryEtapas = String.Format(@"
                SELECT
                ID_turma,
                nome_turma
                 FROM tb_turmas
                     WHERE ID_turma > 0 AND ano_letivo={0}", DateTime.Now.ToString("yyyy"));


            cb_turma.DataSource = Banco.dql(vqueryEtapas);
            cb_turma.DisplayMember = "nome_turma";
            cb_turma.ValueMember = "ID_turma";

            Dictionary<string, string> ano = new Dictionary<string, string>();

            ano.Add("2020", "2020");
            ano.Add("2021", "2021");
            ano.Add("2022", "2022");
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
            ano.Add("2036", "2036");
            ano.Add("2037", "2037");
            ano.Add("2038", "2038");
            ano.Add("2039", "2039");
            ano.Add("2040", "2040");
            ano.Add("2041", "2041");
            ano.Add("2042", "2042");
            ano.Add("2043", "2043");
            ano.Add("2044", "2044");
            ano.Add("2045", "2045");
            ano.Add("2046", "2046");
            ano.Add("2047", "2047");
            ano.Add("2048", "2048");
            ano.Add("2049", "2049");
            ano.Add("2050", "2050");

            cb_ano.DataSource = new BindingSource(ano, null);
            cb_ano.DisplayMember = "Value";
            cb_ano.ValueMember = "Key";

            if (Globais.nivel >= 5)
            {
                btn_Excluir.Enabled = true;
            }
            else
            {
                btn_Excluir.Enabled = false;
            }

        }

        private void btn_Salvar_Click(object sender, EventArgs e)

        {
            if (MessageBox.Show("Deseja salvar estes dados?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                PegarIDEtapa();
                DateTime nascimento = Convert.ToDateTime(mstb_DataNasc.Text);
                string DataNascimento = nascimento.ToString("yyyy-MM-dd");


                linha = dgv_GestaoAlunos.SelectedRows[0].Index;
                string queryAtualizarAluno = String.Format(@"UPDATE tb_alunos SET nome_aluno='{0}',datanasc='{1}', sexo='{2}',cor='{3}',cidade='{4}',nacionalidade='{5}',UF='{6}',rua='{7}',bairro='{8}',cep='{9}',numero='{10}',zona='{11}',telefone='{12}',vive_com='{13}',doenca='{14}',emergencia='{15}',mae='{16}',pai='{17}',responsavel1='{18}',responsavel2='{19}',ano_letivo={20},status='{21}',turno='{22}' WHERE ID_aluno={23}", tb_Aluno.Text.ToUpper(),DataNascimento,cb_Sexo.SelectedValue,cb_Cor.SelectedValue,tb_Cidade.Text,tb_Nacionalidade.Text,cb_UF.SelectedValue,tb_Rua.Text,tb_BairroEnd.Text,tb_CEPEnd.Text,tb_NumeroEnd.Text,tb_zona.Text,mstb_TelefoneEnd.Text,tb_ViveCom.Text,tb_Doenca.Text,tb_Emergencia.Text,tb_Mae.Text,tb_Pai.Text,tb_Outro1.Text,tb_Outro2.Text,cb_ano.SelectedValue,cb_status.Text,cb_Turno.SelectedValue,idSelecionado);

                Banco.dml(queryAtualizarAluno);

                queryAtualizarAluno = String.Format(@"UPDATE tb_mensalidades SET idturma={0} WHERE idaluno={1} AND ano_letivo={2}", idetapa, idSelecionado, cb_ano.Text);

                Banco.dml(queryAtualizarAluno);

                dgv_GestaoAlunos[1, linha].Value = tb_Aluno.Text;
                
                if(cb_turma.Text != "")
                {


                string verifEtapa = String.Format(@"
                    SELECT 
                        t.serie,
                        t.turno
                    FROM tb_alunos_turmas at
                    INNER JOIN tb_alunos a 
                        ON a.ID_aluno = at.idaluno
                    INNER JOIN tb_turmas t 
                        ON t.ID_turma = at.idturma
                    WHERE t.ID_turma = {0} LIMIT 1", cb_turma.SelectedValue);
                DataTable dt = Banco.dql(verifEtapa);

                    string AtlzEtapa = String.Format(@"UPDATE tb_alunos SET etapa='{0}', turno='{1}' WHERE ID_aluno={2}", dt.Rows[0].Field<string>("serie"), dt.Rows[0].Field<string>("turno"), idSelecionado);

                Banco.dml(AtlzEtapa);

                string AtlzTurma = String.Format(@"UPDATE tb_alunos_turmas SET idturma={0} WHERE idaluno={1} AND idturma={2}", cb_turma.SelectedValue, idSelecionado, IDTurmaAntigo);

                Banco.dml(AtlzTurma);

                }

                MessageBox.Show("Dados Alterados com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }



        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir os dados deste Aluno?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
            string vqueryExcluirAluno = String.Format(@"
                DELETE FROM
                    tb_alunos
                WHERE
                    ID_aluno={0}
                 ", idSelecionado);
            Banco.dml(vqueryExcluirAluno);
            dgv_GestaoAlunos.Rows.Remove(dgv_GestaoAlunos.CurrentRow);
            MessageBox.Show("Aluno excluído", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    


        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void dgv_GestaoAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                tb_Aluno.Text = dgv_GestaoAlunos.Rows[dgv_GestaoAlunos.SelectedRows[0].Index].Cells[1].Value.ToString();
                idSelecionado = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();

                string vqueryCampos = String.Format(@"
                    SELECT 
                    tbt.ID_turma,
                    tba.*
                FROM tb_alunos tba
                LEFT JOIN tb_alunos_turmas tat ON tat.idaluno = tba.ID_aluno
                LEFT JOIN tb_turmas tbt ON tbt.ID_turma = tat.idturma
                WHERE tba.ID_aluno = {0}
                 ", idSelecionado);

                DataTable dt = Banco.dql(vqueryCampos);
                tb_Aluno.Text = dt.Rows[0].Field<string>("nome_aluno");
                mstb_DataNasc.Text = dt.Rows[0].Field<DateTime>("datanasc").ToString("dd/MM/yyyy");
                cb_Sexo.SelectedValue = dt.Rows[0].Field<string>("sexo");
                cb_Cor.SelectedValue = dt.Rows[0].Field<string>("cor");
                tb_Cidade.Text = dt.Rows[0].Field<string>("cidade");
                tb_Nacionalidade.Text = dt.Rows[0].Field<string>("nacionalidade");
                cb_UF.SelectedValue = dt.Rows[0].Field<string>("UF");
                tb_Rua.Text = dt.Rows[0].Field<string>("rua");
                tb_BairroEnd.Text = dt.Rows[0].Field<string>("bairro");
                tb_CEPEnd.Text = dt.Rows[0].Field<string>("cep");
                tb_NumeroEnd.Text = dt.Rows[0].Field<string>("numero");
                tb_zona.Text = dt.Rows[0].Field<string>("zona");
                mstb_TelefoneEnd.Text = dt.Rows[0].Field<string>("telefone");
                tb_ViveCom.Text = dt.Rows[0].Field<string>("vive_com");
                tb_Doenca.Text = dt.Rows[0].Field<string>("doenca");
                tb_Emergencia.Text = dt.Rows[0].Field<string>("emergencia");
                tb_Mae.Text = dt.Rows[0].Field<string>("mae");
                tb_Pai.Text = dt.Rows[0].Field<string>("pai");
                tb_Outro1.Text = dt.Rows[0].Field<string>("responsavel1");
                tb_Outro2.Text = dt.Rows[0].Field<string>("responsavel2");
                cb_Turno.SelectedValue = dt.Rows[0].Field<string>("turno");
                if (!dt.Rows[0].IsNull("ID_turma"))
                {
                    cb_turma.SelectedValue = dt.Rows[0].Field<int>("ID_turma");
                    IDTurmaAntigo = dt.Rows[0].Field<Int32>("ID_turma");
                }
                else
                {
                    cb_turma.SelectedIndex = -1; // ou definir vazio
                }
                //cb_Cursos.SelectedValue = dt.Rows[0].Field<Int32>("idcurso");
                cb_ano.Text = dt.Rows[0].Field<Int32>("ano_letivo").ToString();
                string Usuario = dt.Rows[0].Field<string>("usuario");
                string data_gerada = dt.Rows[0].Field<DateTime>("data_gerada").ToString("dd/MM/yyyy");
                cb_status.SelectedValue = dt.Rows[0].Field<string>("status");
                tb_usuario.Text = Usuario + " no dia " + data_gerada;
                Globais.Main.PassarIdAluno = dt.Rows[0].Field<Int32>("ID_aluno").ToString();

                if (!string.IsNullOrWhiteSpace(tb_Aluno.Text) && !string.IsNullOrEmpty(idSelecionado))
                {
                    string nomeArquivo = tb_Aluno.Text.Trim().Replace(" ", "_") + ".jpg";
                    string caminhoRelativoFTP = $"{idSelecionado}/{nomeArquivo}";

                    await CarregarImagemNoPictureBox(caminhoRelativoFTP, foto_aluno);
                }
                else
                {
                    foto_aluno.Image = null;
                    lb_foto.Visible = true;
                }



                string VerificarFinan = String.Format(@"
                 SELECT
                    tbf.nome
                FROM
                    tb_responsavel_financeiro as tbf
                WHERE tbf.idaluno =" + idSelecionado);
                DataTable verificarfinan = Banco.dql(VerificarFinan);

                string VerificarAcad = String.Format(@"
                 SELECT
                    tbc.nome
                FROM
                    tb_responsavel_academico as tbc
                WHERE tbc.idaluno =" + idSelecionado);
                DataTable verificaracad = Banco.dql(VerificarAcad);


                if (verificarfinan.Rows.Count > 0)
                {
                    if (verificaracad.Rows.Count > 0)
                    {
                        btn_RespFinan.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Este Aluno(a) não possui um Responsável Acadêmico cadastrado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btn_RespFinan.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Este Aluno(a) não possui um Responsável Financeiro cadastrado!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_RespFinan.Enabled = false;
                }

            }
        }


        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (tb_pesquisa.Text != "")
            {

                var vcon = Banco.ConexaoBanco();

                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "SELECT ID_aluno as 'ID', nome_aluno as 'Aluno' FROM tb_alunos WHERE nome_aluno LIKE ('" + tb_pesquisa.Text + "%')";

                cm.Connection = vcon;
                MySqlDataAdapter da = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cm;
                da.Fill(dt);
                dgv_GestaoAlunos.DataSource = dt;
                dgv_GestaoAlunos.Columns[0].Width = 40;
                dgv_GestaoAlunos.Columns[1].Width = 235;
                vcon.Close();

                dgv_GestaoAlunos.ClearSelection();

                idSelecionado = "";
            }
            else
            {
                MessageBox.Show("Preencha o campo nome para pesquisar");
            }
        } 

       

        private void btn_RespFinan_Click(object sender, EventArgs e)
        {
            F_GestaoRespFinan f_GestaoRespFinan = new F_GestaoRespFinan();
            f_GestaoRespFinan.ShowDialog();
        }

        private void btn_obs_Click(object sender, EventArgs e)
        {
            F_Observacoes f_Observacoes = new F_Observacoes();
            f_Observacoes.ShowDialog();
        }

        private void btn_obs_Click_1(object sender, EventArgs e)
        {
            if (idSelecionado != "")
            {
                F_Observacoes f_Observacoes = new F_Observacoes();
                f_Observacoes.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um Aluno!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {

            if (idSelecionado != "")
            {
                Globais.Main.PassarAno = cb_ano.Text;
                F_FichaIndividual ficha = new F_FichaIndividual();
                ficha.Show();
            }
            else
            {
                MessageBox.Show("Selecione um Aluno!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btn_Carteira_Click(object sender, EventArgs e)
        {
            if (idSelecionado != "") 
            {
                Carteira.F_LancarSaldo f_LancarSaldo = new Carteira.F_LancarSaldo(this);
                f_LancarSaldo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum Aluno(a) selecionado", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_camera_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idSelecionado))
            {
                try
                {
                    Globais.Main.PassarAluno = tb_Aluno.Text.ToUpper().Trim();
                    Globais.Main.PassarIdAluno = idSelecionado;

                    // === Verifica/cria pasta no FTP antes de salvar imagem ===
                    string pastaAluno = idSelecionado;
                    if (!PastaExisteFTP(pastaAluno))
                    {
                        FtpWebRequest criarPasta = Banco.ConexaoFTP.CriarConexao(pastaAluno, WebRequestMethods.Ftp.MakeDirectory);
                        using (var resp = (FtpWebResponse)criarPasta.GetResponse()) { }
                    }

                    // Abre o form de captura
                    Cadastros.CadastrarImagem cadastrarImagem = new Cadastros.CadastrarImagem();
                    cadastrarImagem.ShowDialog();

                    if (!string.IsNullOrWhiteSpace(tb_Aluno.Text))
                    {
                        string nomeArquivo = tb_Aluno.Text.Trim().Replace(" ", "_") + ".jpg";
                        string caminhoRelativoFTP = $"{idSelecionado}/{nomeArquivo}";

                        // Carrega imagem do FTP de forma assíncrona
                        await CarregarImagemNoPictureBox(caminhoRelativoFTP, foto_aluno);
                    }
                    else
                    {
                        foto_aluno.Image = null;
                        lb_foto.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um Aluno!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void foto_aluno_Resize(object sender, EventArgs e)
        {
           foto_aluno.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // ========================== DOCUMENTOS BUTTON ==========================
        private async void documentosButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idSelecionado))
            {
                MessageBox.Show("Selecione um Aluno!", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string anoSelecionado = cb_ano.Text; // lê o valor aqui na UI thread

            using (var loading = new F_Loading("Acessando documentos do Aluno..."))
            {
                loading.Show();

                await Task.Run(() =>
                {
                    try
                    {
                        CriarPastasFTP(idSelecionado, anoSelecionado);
                        AtualizarBancoFTP(idSelecionado);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao processar pastas: " + ex.Message);
                    }
                });

                loading.Close();
            }

        }


        private void CriarPastasFTP(string idSelecionado, string anoSelecionado)
        {
            string pastaAluno = idSelecionado;
            string[] subPastas = { "", "documentos", "contratos", $"contratos/{anoSelecionado}" };
            foreach (string sub in subPastas)
            {
                string caminhoFTP = string.IsNullOrEmpty(sub) ? pastaAluno : $"{pastaAluno}/{sub}";

                if (!PastaExisteFTP(caminhoFTP))
                {
                    FtpWebRequest criarPasta = Banco.ConexaoFTP.CriarConexao(caminhoFTP, WebRequestMethods.Ftp.MakeDirectory);
                    using (var resp = (FtpWebResponse)criarPasta.GetResponse()) { }
                }
            }
        }

        private void AtualizarBancoFTP(string pastaAluno)
        {
            string vqueryVerifica = $"SELECT COUNT(*) FROM tb_caminhoftp WHERE idaluno={pastaAluno}";
            DataTable dt = Banco.dql(vqueryVerifica);

            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count > 0)
            {
                this.Invoke(new Action(() =>
                {
                    Globais.Main.PassarAno = cb_ano.Text;
                    Globais.Main.PassarIdAluno = idSelecionado;
                    DocumentosAluno documento = new DocumentosAluno();
                    documento.Show();
                }));
            }
            else
            {
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

        // ========================== UPLOAD DA IMAGEM ==========================
        public void UploadImageToFTP(string filePath)
        {
            try
            {
                string nomeAluno = tb_Aluno.Text.Trim();
                if (string.IsNullOrWhiteSpace(nomeAluno))
                {
                    MessageBox.Show("Selecione um Aluno", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nome do arquivo sempre baseado no nome do aluno
                string nomeArquivo = $"{nomeAluno.Replace(" ", "_")}.jpg";
                string caminhoRelativoFTP = $"{idSelecionado}/{nomeArquivo}";

                // Envia o arquivo para o FTP
                FtpWebRequest request = ConexaoFTP.CriarConexao(caminhoRelativoFTP, WebRequestMethods.Ftp.UploadFile);
                byte[] fileContents = File.ReadAllBytes(filePath);
                request.ContentLength = fileContents.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    // Upload bem sucedido
                }

                // Atualiza a interface na thread principal
                if (foto_aluno.InvokeRequired)
                {
                    foto_aluno.Invoke(new Action(() =>
                    {
                        lb_foto.Visible = false;
                        _ = CarregarImagemNoPictureBox(caminhoRelativoFTP, foto_aluno);
                    }));
                }
                else
                {
                    lb_foto.Visible = false;
                    _ = CarregarImagemNoPictureBox(caminhoRelativoFTP, foto_aluno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========================== CARREGAR IMAGEM ==========================
        public async Task CarregarImagemNoPictureBox(string caminhoRelativoFTP, PictureBox pictureBox)
        {
            try
            {
                // Limpa primeiro para evitar imagem antiga
                LimparPictureBox(pictureBox);

                if (string.IsNullOrEmpty(caminhoRelativoFTP))
                    return;

                // Usa Task.Run para não travar a UI
                await Task.Run(async () =>
                {
                    try
                    {
                        FtpWebRequest request = ConexaoFTP.CriarConexao(caminhoRelativoFTP, WebRequestMethods.Ftp.DownloadFile);
                        request.UsePassive = true;
                        request.KeepAlive = false;
                        request.Timeout = 5000; // 5 segundos de timeout

                        // Tenta obter a resposta
                        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            // Lê a imagem para memory stream
                            using (MemoryStream ms = new MemoryStream())
                            {
                                await responseStream.CopyToAsync(ms);
                                ms.Position = 0;

                                pictureBox.Invoke(new Action(() =>
                                {
                                    using (var img = System.Drawing.Image.FromStream(ms))
                                    {
                                        AtualizarPictureBoxComPreenchimento(pictureBox, img);
                                    }
                                    lb_foto.Visible = false;
                                }));
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        // Verifica se é erro 550
                        if (ex.Response is FtpWebResponse ftpResponse &&
                            ftpResponse.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                        {
                            // Erro 550 - comportamento normal, apenas limpa
                            LimparPictureBox(pictureBox);
                        }
                        else
                        {
                            // Outro erro de rede
                            throw;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                // Outros erros
                if (!ex.Message.Contains("550"))
                {
                    MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimparPictureBox(PictureBox pictureBox)
        {
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke(new Action(() => LimparPictureBox(pictureBox)));
                return;
            }

            pictureBox.Image = null;
            lb_foto.Visible = true;
        }



        private void AtualizarPictureBoxComPreenchimento(PictureBox pictureBox, System.Drawing.Image img)
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black); // cor de fundo, se quiser
                float ratioImg = (float)img.Width / img.Height;
                float ratioBox = (float)pictureBox.Width / pictureBox.Height;

                System.Drawing.Rectangle destRect;

                if (ratioImg > ratioBox)
                {
                    // imagem mais larga que o box
                    int altura = pictureBox.Height;
                    int largura = (int)(altura * ratioImg);
                    int x = (pictureBox.Width - largura) / 2;
                    destRect = new System.Drawing.Rectangle(x, 0, largura, altura);
                }
                else
                {
                    // imagem mais alta que o box
                    int largura = pictureBox.Width;
                    int altura = (int)(largura / ratioImg);
                    int y = (pictureBox.Height - altura) / 2;
                    destRect = new System.Drawing.Rectangle(0, y, largura, altura);
                }

                g.DrawImage(img, destRect);
            }

            pictureBox.Image = bmp;
        }

        private void F_GestaoAlunos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globais.Main.PassarIdAluno = "";
            Globais.Main.PassarAluno = "";
            Globais.Main.PassarAno = "";
            
        }
    }
}