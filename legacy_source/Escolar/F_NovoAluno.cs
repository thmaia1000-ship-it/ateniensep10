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


namespace Escolar
{
    public partial class F_NovoAluno : Form
    {
        string OrigemCompleto="";
        string foto ="";
        string PastaDestino = Globais.caminhoFotos;
        string DestinoCompleto = "";


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
            cb_Sexo.Enabled = false;
            mstb_DataNasc.Enabled = false;
            cb_Cor.Enabled = false;
            tb_Cidade.Enabled = false;
            tb_Nacionalidade.Enabled = false;
            cb_UF.Enabled = false;
            tb_Rua.Enabled = false;
            tb_NumeroEnd.Enabled = false;
            tb_BairroEnd.Enabled = false;
            tb_CEPEnd.Enabled = false;
            tb_Zona.Enabled = false;
            mstb_TelefoneEnd.Enabled = false;
            tb_Turma.Enabled = false;
            tb_ViveCom.Enabled = false;
            registrar_doenca.Enabled = false;
            pictureBox1.Enabled = false;
            btn_abrir_responsavelAcad.Enabled = false;

            tb_Emergencia.Enabled = false;
            tb_Mae.Enabled = false;
            tb_Pai.Enabled = false;
            tb_OutroResp1.Enabled = false;
            tb_OutroResp2.Enabled = false;

            tb_DescDoenca.Enabled = false;
            tb_DescDoenca.Text = "Nenhuma";

            Dictionary<string, string> sexo = new Dictionary<string, string>();

            sexo.Add("M", "Masculino");
            sexo.Add("F", "Feminino");
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

            cb_UF.DataSource = new BindingSource(uf, null);
            cb_UF.DisplayMember = "Value";
            cb_UF.ValueMember = "Key";


            
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            tb_Aluno.Enabled = true; 
            cb_Sexo.Enabled = true;
            mstb_DataNasc.Enabled = true;
            cb_Cor.Enabled = true;
            tb_Cidade.Enabled = true;
            tb_Nacionalidade.Enabled = true;
            cb_UF.Enabled = true;
            tb_Rua.Enabled = true;
            tb_NumeroEnd.Enabled = true;
            tb_BairroEnd.Enabled = true;
            tb_CEPEnd.Enabled = true;
            tb_Zona.Enabled = true;
            registrar_doenca.Enabled = true;
            
            mstb_TelefoneEnd.Enabled = true;
            tb_DescDoenca.Enabled = false;
            tb_Turma.Enabled = true;
            tb_ViveCom.Enabled = true;
            tb_Emergencia.Enabled = true;
            tb_Mae.Enabled = true;
            tb_Pai.Enabled = true;
            tb_OutroResp1.Enabled = true;
            tb_OutroResp2.Enabled = true;
            pictureBox1.Enabled = true;
            btn_abrir_responsavelAcad.Enabled = true;

            tb_Aluno.Clear();
            cb_Sexo.SelectedIndex = 0;
            mstb_DataNasc.Clear();
            cb_Cor.SelectedIndex = 0;
            tb_Cidade.Clear();
            tb_Nacionalidade.Clear();
            cb_UF.SelectedIndex = 0;
            tb_Rua.Clear();
            tb_NumeroEnd.Clear();
            tb_BairroEnd.Clear();
            tb_CEPEnd.Clear();
            tb_Zona.Clear();
            mstb_TelefoneEnd.Clear();
            tb_Turma.Clear();
            tb_ViveCom.Clear();

            tb_Emergencia.Clear();
            tb_Mae.Clear();
            tb_Pai.Clear();
            tb_OutroResp1.Clear();
            tb_OutroResp2.Clear();


            tb_Aluno.Focus();
            btn_Turma.Enabled = true;
            btn_Gravar.Enabled = true;
            btn_Cancelar.Enabled = true;
            btn_Novo.Enabled = false;
            


        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {

            tb_Aluno.Enabled = false;
            cb_Sexo.Enabled = false;
            mstb_DataNasc.Enabled = false;
            cb_Cor.Enabled = false;
            tb_Cidade.Enabled = false;
            tb_Nacionalidade.Enabled = false;
            cb_UF.Enabled = false;
            tb_Rua.Enabled = false;
            tb_NumeroEnd.Enabled = false;
            tb_BairroEnd.Enabled = false;
            tb_CEPEnd.Enabled = false;
            tb_Zona.Enabled = false;
            tb_DescDoenca.Enabled = false;
            registrar_doenca.Enabled = false;

            mstb_TelefoneEnd.Enabled = false;
            tb_Turma.Enabled = false;
            tb_ViveCom.Enabled = false;
            tb_Emergencia.Enabled = false;
            tb_Mae.Enabled = false;
            tb_Pai.Enabled = false;
            tb_OutroResp1.Enabled = false;
            tb_OutroResp2.Enabled = false;
            pictureBox1.Enabled = false;
            btn_abrir_responsavelAcad.Enabled = false;

            tb_Aluno.Clear();
            cb_Sexo.SelectedIndex = 0;
            mstb_DataNasc.Clear();
            cb_Cor.SelectedIndex = 0;
            tb_Cidade.Clear();
            tb_Nacionalidade.Clear();
            cb_UF.SelectedIndex = 0;
            tb_Rua.Clear();
            tb_NumeroEnd.Clear();
            tb_BairroEnd.Clear();
            tb_CEPEnd.Clear();
            tb_Zona.Clear();
            mstb_TelefoneEnd.Clear();
            tb_Turma.Clear();
            tb_ViveCom.Clear();
            tb_Emergencia.Clear();
            tb_Mae.Clear();
            tb_Pai.Clear();
            tb_OutroResp1.Clear();
            tb_OutroResp2.Clear();

            registrar_doenca.Checked= false;
            tb_DescDoenca.Enabled = false;
            tb_DescDoenca.Text = "Nenhuma";

            btn_Turma.Enabled = false;
            btn_Gravar.Enabled = false;
            btn_Cancelar.Enabled = false;
            btn_Novo.Enabled = true;


        }

        private void registrar_doenca_CheckedChanged(object sender, EventArgs e)
        {

            if (registrar_doenca.Checked == true)
            {
                tb_DescDoenca.Enabled = true;
                tb_DescDoenca.Clear();
                tb_DescDoenca.Focus();
            }
            else
            {
                tb_DescDoenca.Enabled = false;
                tb_DescDoenca.Text = "Nenhuma";
            }
        }

        private void btn_Gravar_Click(object sender, EventArgs e)
        {
            //if(DestinoCompleto == "")
            //{
            //    if(MessageBox.Show("Sem foto selecionada, deseja continuar?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        return;
            //    }
            //}
            //if (DestinoCompleto != "")
            //{
            //    System.IO.File.Copy(OrigemCompleto, DestinoCompleto, true);
            //    if (File.Exists(DestinoCompleto))
            //    {
            //        pb_FotoAluno.ImageLocation = DestinoCompleto;
            //    }
            //    else
            //    {
            //        if (MessageBox.Show("Erro ao localizar a foto,deseja continuar?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //        {
            //            return;
            //        }               
            //    }
            //}

            if (tb_Aluno.Text == "")
            {
                MessageBox.Show("O nome do Aluno(a) é obrigatório!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Aluno.Focus();
            } 
            else if (mstb_DataNasc.Text == "")
            {
                MessageBox.Show("A data de nascimento é obrigatória!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mstb_DataNasc.Focus();
            }
            else if (tb_Cidade.Text == "")
            {
                MessageBox.Show("Informe a Cidade!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mstb_DataNasc.Focus();
            }
            else if (tb_Nacionalidade.Text == "")
            {
                MessageBox.Show("Informe a Nacionalidade!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Nacionalidade.Focus();
            }
            else if (tb_Rua.Text == "")
            {
                MessageBox.Show("Informe a Rua!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Rua.Focus();
            }
            else if (tb_NumeroEnd.Text == "")
            {
                MessageBox.Show("Informe o Número da casa!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_NumeroEnd.Focus();
            }
            else if (tb_BairroEnd.Text == "")
            {
                MessageBox.Show("Informe o Bairro!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_BairroEnd.Focus();
            }
            else if (tb_CEPEnd.Text == "")
            {
                MessageBox.Show("Informe o CEP!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_CEPEnd.Focus();
            }
            else if (tb_Zona.Text == "")
            {
                MessageBox.Show("Informe a Zona!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Zona.Focus();
            }
            else if (mstb_TelefoneEnd.Text == "")
            {
                MessageBox.Show("Informe o Telefone!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mstb_TelefoneEnd.Focus();
            }
            else if (tb_Turma.Text == "")
            {
                MessageBox.Show("É nescessário escolher uma turma!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Turma.Focus();
            }
            else if (tb_ViveCom.Text == "")
            {
                MessageBox.Show("Informe com quem a criança Vive!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_ViveCom.Focus();
            }
            else if (tb_DescDoenca.Text == "")
            {
                MessageBox.Show("Informe a Doença!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_DescDoenca.Focus();
            }
            else if (tb_Emergencia.Text == "")
            {
                MessageBox.Show("Informe quem chamar em casos de Emergência!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Emergencia.Focus();
            }
           

            else if (MessageBox.Show("Confirmar registro de Matrícula?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                string queryInsertAluno = String.Format(@"
                INSERT INTO 
                    tb_alunos (nome_aluno,datanasc,sexo,cor,cidade,nacionalidade,UF,rua, bairro, cep, zona, telefone,numero,vive_com,doenca,emergencia,mae,pai,responsavel1,responsavel2,idturma)  
                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},'{13}','{14}','{15}','{16}','{17}','{18}','{19}',{20})", tb_Aluno.Text, mstb_DataNasc.Text, cb_Sexo.SelectedValue, cb_Cor.SelectedValue, tb_Cidade.Text, tb_Nacionalidade.Text, cb_UF.SelectedValue, tb_Rua.Text, tb_BairroEnd.Text, tb_CEPEnd.Text, tb_Zona.Text, mstb_TelefoneEnd.Text, tb_NumeroEnd.Text.ToString(), tb_ViveCom.Text, tb_DescDoenca.Text, tb_Emergencia.Text, tb_Mae.Text, tb_Pai.Text, tb_OutroResp1.Text, tb_OutroResp2.Text, tb_Turma.Tag.ToString());
            Banco.dml(queryInsertAluno);

                MessageBox.Show("Faça o cadastro do Responsável Academico do Aluno(a): " + tb_Aluno.Text, "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                tb_Aluno.Enabled = false;
            cb_Sexo.Enabled = false;
            mstb_DataNasc.Enabled = false;
            cb_Cor.Enabled = false;
            tb_Cidade.Enabled = false;
            tb_Nacionalidade.Enabled = false;
            cb_UF.Enabled = false;
            tb_Rua.Enabled = false;
            tb_NumeroEnd.Enabled = false;
            tb_BairroEnd.Enabled = false;
            tb_CEPEnd.Enabled = false;
            tb_Zona.Enabled = false;
            mstb_TelefoneEnd.Enabled = false;
            tb_Turma.Enabled = false;
            tb_ViveCom.Enabled = false;
            tb_Emergencia.Enabled = false;
            tb_Mae.Enabled = false;
            tb_Pai.Enabled = false;
            tb_OutroResp1.Enabled = false;
            tb_OutroResp2.Enabled = false;

            tb_Aluno.Clear();
            cb_Sexo.SelectedIndex = 0;
            mstb_DataNasc.Clear();
            cb_Cor.SelectedIndex = 0;
            tb_Cidade.Clear();
            tb_Nacionalidade.Clear();
            cb_UF.SelectedIndex = 0;
            tb_Rua.Clear();
            tb_NumeroEnd.Clear();
            tb_BairroEnd.Clear();
            tb_CEPEnd.Clear();
            tb_Zona.Clear();
            mstb_TelefoneEnd.Clear();
            tb_Turma.Clear();
            tb_ViveCom.Clear();
            tb_Emergencia.Clear();
            tb_Mae.Clear();
            tb_Pai.Clear();
            tb_OutroResp1.Clear();
            tb_OutroResp2.Clear();

            registrar_doenca.Checked = true;
            tb_DescDoenca.Enabled = false;
            tb_DescDoenca.Text = "Nenhuma";

            btn_Turma.Enabled = false;
            btn_Gravar.Enabled = false;
            btn_Cancelar.Enabled = false;
            btn_Novo.Enabled = true;

                ResponsavelAcademico responsavelAcademico = new ResponsavelAcademico();
                responsavelAcademico.Show();
            }
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Turma_Click(object sender, EventArgs e)
        {
            F_SelecionarTurma f_SelecionarTurma = new F_SelecionarTurma(this);
            f_SelecionarTurma.ShowDialog();

        }

        private void btn_abrir_responsavelAcad_MouseClick(object sender, MouseEventArgs e)
        {
            ResponsavelAcademico responsavelAcademico = new ResponsavelAcademico();
            responsavelAcademico.ShowDialog();
        }

        

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ResponsavelFinanceiro responsavelFinanceiro = new ResponsavelFinanceiro();
            responsavelFinanceiro.Show();
        }

        private void btn_abrir_responsavelAcad_Click(object sender, EventArgs e)
        {
            ResponsavelAcademico responsavelAcademico = new ResponsavelAcademico();
            responsavelAcademico.Show();
        }

        //private void btn_Foto_Click(object sender, EventArgs e)
        //{
        //     OrigemCompleto = "";
        //     foto = "";
        //     PastaDestino = Globais.caminhoFotos;
        //     DestinoCompleto = "";


        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)

        //    {
        //        OrigemCompleto = openFileDialog1.FileName;
        //        foto = openFileDialog1.SafeFileName;
        //        DestinoCompleto = PastaDestino + foto;

        //    }
        //    if (File.Exists(DestinoCompleto))
        //    {
        //        if (MessageBox.Show("Arquivo já existe, Deseja substituir?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        //        {
        //            return;
        //        }
        //    }

        //        pb_FotoAluno.ImageLocation = OrigemCompleto;

    }
    }

