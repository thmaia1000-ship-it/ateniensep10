namespace Escolar
{
    partial class F_NovoAluno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_NovoAluno));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Novo = new System.Windows.Forms.Button();
            this.btn_Gravar = new System.Windows.Forms.Button();
            this.tb_Aluno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Cidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Nacionalidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mstb_DataNasc = new System.Windows.Forms.MaskedTextBox();
            this.cb_UF = new System.Windows.Forms.ComboBox();
            this.Label124 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_Rua = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_NumeroEnd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_BairroEnd = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_CEPEnd = new System.Windows.Forms.TextBox();
            this.tb_Mae = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cb_Sexo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Turno = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_Cor = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_Zona = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tb_Pai = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_Outro2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_Outro1 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.tb_ViveCom = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.Liberar_Doenca = new System.Windows.Forms.CheckBox();
            this.tb_Doenca = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tb_Emergencia = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mstb_TelefoneEnd = new System.Windows.Forms.MaskedTextBox();
            this.cb_etapa = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_Curso = new System.Windows.Forms.ComboBox();
            this.cb_ano = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label1.Location = new System.Drawing.Point(8, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aluno(a)";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.btn_Cancelar);
            this.panel1.Controls.Add(this.btn_Novo);
            this.panel1.Controls.Add(this.btn_Gravar);
            this.panel1.Location = new System.Drawing.Point(0, 618);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 77);
            this.panel1.TabIndex = 29;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Enabled = false;
            this.btn_Cancelar.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btn_Cancelar.Location = new System.Drawing.Point(548, 5);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(251, 66);
            this.btn_Cancelar.TabIndex = 21;
            this.btn_Cancelar.Text = "Limpar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Novo
            // 
            this.btn_Novo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Novo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btn_Novo.Location = new System.Drawing.Point(244, 5);
            this.btn_Novo.Name = "btn_Novo";
            this.btn_Novo.Size = new System.Drawing.Size(251, 66);
            this.btn_Novo.TabIndex = 22;
            this.btn_Novo.Text = "Novo";
            this.btn_Novo.UseVisualStyleBackColor = true;
            this.btn_Novo.Click += new System.EventHandler(this.btn_Novo_Click);
            // 
            // btn_Gravar
            // 
            this.btn_Gravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Gravar.Enabled = false;
            this.btn_Gravar.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btn_Gravar.Location = new System.Drawing.Point(843, 5);
            this.btn_Gravar.Name = "btn_Gravar";
            this.btn_Gravar.Size = new System.Drawing.Size(251, 66);
            this.btn_Gravar.TabIndex = 20;
            this.btn_Gravar.Text = "Salvar Cadastro";
            this.btn_Gravar.UseVisualStyleBackColor = true;
            this.btn_Gravar.Click += new System.EventHandler(this.btn_Gravar_Click);
            // 
            // tb_Aluno
            // 
            this.tb_Aluno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Aluno.Enabled = false;
            this.tb_Aluno.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Aluno.Location = new System.Drawing.Point(12, 108);
            this.tb_Aluno.Name = "tb_Aluno";
            this.tb_Aluno.Size = new System.Drawing.Size(654, 46);
            this.tb_Aluno.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label2.Location = new System.Drawing.Point(8, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data. Nasc";
            // 
            // tb_Cidade
            // 
            this.tb_Cidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Cidade.Enabled = false;
            this.tb_Cidade.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Cidade.Location = new System.Drawing.Point(10, 280);
            this.tb_Cidade.Name = "tb_Cidade";
            this.tb_Cidade.Size = new System.Drawing.Size(485, 46);
            this.tb_Cidade.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label3.Location = new System.Drawing.Point(6, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cidade";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label4.Location = new System.Drawing.Point(501, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "UF";
            // 
            // tb_Nacionalidade
            // 
            this.tb_Nacionalidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Nacionalidade.Enabled = false;
            this.tb_Nacionalidade.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Nacionalidade.Location = new System.Drawing.Point(10, 372);
            this.tb_Nacionalidade.Name = "tb_Nacionalidade";
            this.tb_Nacionalidade.Size = new System.Drawing.Size(288, 46);
            this.tb_Nacionalidade.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label5.Location = new System.Drawing.Point(6, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nacionalidade";
            // 
            // mstb_DataNasc
            // 
            this.mstb_DataNasc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mstb_DataNasc.Enabled = false;
            this.mstb_DataNasc.Font = new System.Drawing.Font("Verdana", 24F);
            this.mstb_DataNasc.Location = new System.Drawing.Point(10, 200);
            this.mstb_DataNasc.Mask = "00/00/0000";
            this.mstb_DataNasc.Name = "mstb_DataNasc";
            this.mstb_DataNasc.Size = new System.Drawing.Size(203, 46);
            this.mstb_DataNasc.TabIndex = 1;
            this.mstb_DataNasc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mstb_DataNasc.ValidatingType = typeof(System.DateTime);
            // 
            // cb_UF
            // 
            this.cb_UF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_UF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_UF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_UF.Font = new System.Drawing.Font("Verdana", 16F);
            this.cb_UF.FormattingEnabled = true;
            this.cb_UF.Location = new System.Drawing.Point(507, 287);
            this.cb_UF.Name = "cb_UF";
            this.cb_UF.Size = new System.Drawing.Size(159, 33);
            this.cb_UF.TabIndex = 9;
            // 
            // Label124
            // 
            this.Label124.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label124.AutoSize = true;
            this.Label124.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.Label124.Location = new System.Drawing.Point(994, 251);
            this.Label124.Name = "Label124";
            this.Label124.Size = new System.Drawing.Size(93, 32);
            this.Label124.TabIndex = 17;
            this.Label124.Text = "Curso";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|.png";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label9.Location = new System.Drawing.Point(8, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 32);
            this.label9.TabIndex = 23;
            this.label9.Text = "Rua";
            // 
            // tb_Rua
            // 
            this.tb_Rua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Rua.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Rua.Location = new System.Drawing.Point(12, 455);
            this.tb_Rua.Name = "tb_Rua";
            this.tb_Rua.Size = new System.Drawing.Size(483, 46);
            this.tb_Rua.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label11.Location = new System.Drawing.Point(8, 505);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 32);
            this.label11.TabIndex = 28;
            this.label11.Text = "CEP";
            // 
            // tb_NumeroEnd
            // 
            this.tb_NumeroEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_NumeroEnd.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_NumeroEnd.Location = new System.Drawing.Point(507, 455);
            this.tb_NumeroEnd.Name = "tb_NumeroEnd";
            this.tb_NumeroEnd.Size = new System.Drawing.Size(159, 46);
            this.tb_NumeroEnd.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label12.Location = new System.Drawing.Point(502, 425);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 32);
            this.label12.TabIndex = 29;
            this.label12.Text = "N°";
            // 
            // tb_BairroEnd
            // 
            this.tb_BairroEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_BairroEnd.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_BairroEnd.Location = new System.Drawing.Point(306, 372);
            this.tb_BairroEnd.Name = "tb_BairroEnd";
            this.tb_BairroEnd.Size = new System.Drawing.Size(362, 46);
            this.tb_BairroEnd.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label14.Location = new System.Drawing.Point(298, 337);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 32);
            this.label14.TabIndex = 33;
            this.label14.Text = "Bairro";
            // 
            // tb_CEPEnd
            // 
            this.tb_CEPEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_CEPEnd.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_CEPEnd.Location = new System.Drawing.Point(12, 540);
            this.tb_CEPEnd.Name = "tb_CEPEnd";
            this.tb_CEPEnd.Size = new System.Drawing.Size(206, 46);
            this.tb_CEPEnd.TabIndex = 14;
            // 
            // tb_Mae
            // 
            this.tb_Mae.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Mae.Enabled = false;
            this.tb_Mae.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Mae.Location = new System.Drawing.Point(695, 108);
            this.tb_Mae.Name = "tb_Mae";
            this.tb_Mae.Size = new System.Drawing.Size(324, 46);
            this.tb_Mae.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label16.Location = new System.Drawing.Point(696, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 32);
            this.label16.TabIndex = 36;
            this.label16.Text = "Mãe";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(460, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(453, 35);
            this.label20.TabIndex = 45;
            this.label20.Text = "DADOS GERAIS DO ALUNO";
            // 
            // cb_Sexo
            // 
            this.cb_Sexo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_Sexo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Sexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Sexo.Enabled = false;
            this.cb_Sexo.Font = new System.Drawing.Font("Verdana", 24F);
            this.cb_Sexo.FormattingEnabled = true;
            this.cb_Sexo.Location = new System.Drawing.Point(223, 200);
            this.cb_Sexo.Name = "cb_Sexo";
            this.cb_Sexo.Size = new System.Drawing.Size(212, 46);
            this.cb_Sexo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label6.Location = new System.Drawing.Point(219, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 32);
            this.label6.TabIndex = 120;
            this.label6.Text = "Sexo";
            // 
            // cb_Turno
            // 
            this.cb_Turno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_Turno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Turno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Turno.Enabled = false;
            this.cb_Turno.Font = new System.Drawing.Font("Verdana", 24F);
            this.cb_Turno.FormattingEnabled = true;
            this.cb_Turno.Location = new System.Drawing.Point(695, 286);
            this.cb_Turno.Name = "cb_Turno";
            this.cb_Turno.Size = new System.Drawing.Size(270, 46);
            this.cb_Turno.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label7.Location = new System.Drawing.Point(689, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 32);
            this.label7.TabIndex = 122;
            this.label7.Text = "Contrato";
            // 
            // cb_Cor
            // 
            this.cb_Cor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_Cor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Cor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Cor.Enabled = false;
            this.cb_Cor.Font = new System.Drawing.Font("Verdana", 24F);
            this.cb_Cor.FormattingEnabled = true;
            this.cb_Cor.Location = new System.Drawing.Point(447, 200);
            this.cb_Cor.Name = "cb_Cor";
            this.cb_Cor.Size = new System.Drawing.Size(219, 46);
            this.cb_Cor.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label13.Location = new System.Drawing.Point(443, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 32);
            this.label13.TabIndex = 127;
            this.label13.Text = "Cor";
            // 
            // tb_Zona
            // 
            this.tb_Zona.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Zona.Enabled = false;
            this.tb_Zona.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Zona.Location = new System.Drawing.Point(235, 540);
            this.tb_Zona.Name = "tb_Zona";
            this.tb_Zona.Size = new System.Drawing.Size(193, 46);
            this.tb_Zona.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label15.Location = new System.Drawing.Point(229, 505);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 32);
            this.label15.TabIndex = 129;
            this.label15.Text = "Zona";
            // 
            // tb_Pai
            // 
            this.tb_Pai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Pai.Enabled = false;
            this.tb_Pai.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Pai.Location = new System.Drawing.Point(1040, 108);
            this.tb_Pai.Name = "tb_Pai";
            this.tb_Pai.Size = new System.Drawing.Size(311, 46);
            this.tb_Pai.TabIndex = 18;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label17.Location = new System.Drawing.Point(1035, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 32);
            this.label17.TabIndex = 131;
            this.label17.Text = "Pai";
            // 
            // tb_Outro2
            // 
            this.tb_Outro2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Outro2.Enabled = false;
            this.tb_Outro2.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Outro2.Location = new System.Drawing.Point(1041, 194);
            this.tb_Outro2.Name = "tb_Outro2";
            this.tb_Outro2.Size = new System.Drawing.Size(310, 46);
            this.tb_Outro2.TabIndex = 20;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label18.Location = new System.Drawing.Point(1035, 163);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(269, 32);
            this.label18.TabIndex = 135;
            this.label18.Text = "Outro Responsável";
            // 
            // tb_Outro1
            // 
            this.tb_Outro1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Outro1.Enabled = false;
            this.tb_Outro1.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Outro1.Location = new System.Drawing.Point(695, 194);
            this.tb_Outro1.Name = "tb_Outro1";
            this.tb_Outro1.Size = new System.Drawing.Size(324, 46);
            this.tb_Outro1.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label19.Location = new System.Drawing.Point(696, 163);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(269, 32);
            this.label19.TabIndex = 133;
            this.label19.Text = "Outro Responsável";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // tb_ViveCom
            // 
            this.tb_ViveCom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_ViveCom.Enabled = false;
            this.tb_ViveCom.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_ViveCom.Location = new System.Drawing.Point(694, 369);
            this.tb_ViveCom.Name = "tb_ViveCom";
            this.tb_ViveCom.Size = new System.Drawing.Size(293, 46);
            this.tb_ViveCom.TabIndex = 23;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label21.Location = new System.Drawing.Point(689, 339);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(153, 32);
            this.label21.TabIndex = 137;
            this.label21.Text = "Vive com?";
            // 
            // Liberar_Doenca
            // 
            this.Liberar_Doenca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Liberar_Doenca.AutoSize = true;
            this.Liberar_Doenca.Enabled = false;
            this.Liberar_Doenca.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.Liberar_Doenca.Location = new System.Drawing.Point(1280, 337);
            this.Liberar_Doenca.Name = "Liberar_Doenca";
            this.Liberar_Doenca.Size = new System.Drawing.Size(71, 29);
            this.Liberar_Doenca.TabIndex = 24;
            this.Liberar_Doenca.TabStop = false;
            this.Liberar_Doenca.Text = "Sim";
            this.Liberar_Doenca.UseVisualStyleBackColor = true;
            this.Liberar_Doenca.CheckedChanged += new System.EventHandler(this.Liberar_Doenca_CheckedChanged);
            // 
            // tb_Doenca
            // 
            this.tb_Doenca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Doenca.Enabled = false;
            this.tb_Doenca.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Doenca.Location = new System.Drawing.Point(1000, 369);
            this.tb_Doenca.Name = "tb_Doenca";
            this.tb_Doenca.Size = new System.Drawing.Size(349, 46);
            this.tb_Doenca.TabIndex = 25;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label23.Location = new System.Drawing.Point(994, 339);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(115, 32);
            this.label23.TabIndex = 140;
            this.label23.Text = "Doença";
            // 
            // tb_Emergencia
            // 
            this.tb_Emergencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Emergencia.Enabled = false;
            this.tb_Emergencia.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Emergencia.Location = new System.Drawing.Point(695, 454);
            this.tb_Emergencia.Name = "tb_Emergencia";
            this.tb_Emergencia.Size = new System.Drawing.Size(654, 46);
            this.tb_Emergencia.TabIndex = 26;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.label24.Location = new System.Drawing.Point(697, 424);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(350, 25);
            this.label24.TabIndex = 142;
            this.label24.Text = "Em caso de Emergência chamar";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label8.Location = new System.Drawing.Point(688, 504);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 32);
            this.label8.TabIndex = 235;
            this.label8.Text = "Telefone";
            // 
            // mstb_TelefoneEnd
            // 
            this.mstb_TelefoneEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mstb_TelefoneEnd.Enabled = false;
            this.mstb_TelefoneEnd.Font = new System.Drawing.Font("Verdana", 24F);
            this.mstb_TelefoneEnd.Location = new System.Drawing.Point(694, 540);
            this.mstb_TelefoneEnd.Mask = "(99) 00000-0000";
            this.mstb_TelefoneEnd.Name = "mstb_TelefoneEnd";
            this.mstb_TelefoneEnd.Size = new System.Drawing.Size(325, 46);
            this.mstb_TelefoneEnd.TabIndex = 27;
            this.mstb_TelefoneEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_etapa
            // 
            this.cb_etapa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_etapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_etapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_etapa.Enabled = false;
            this.cb_etapa.Font = new System.Drawing.Font("Verdana", 24F);
            this.cb_etapa.FormattingEnabled = true;
            this.cb_etapa.Location = new System.Drawing.Point(447, 540);
            this.cb_etapa.Name = "cb_etapa";
            this.cb_etapa.Size = new System.Drawing.Size(219, 46);
            this.cb_etapa.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label10.Location = new System.Drawing.Point(441, 504);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 32);
            this.label10.TabIndex = 236;
            this.label10.Text = "Etapa";
            // 
            // tb_Curso
            // 
            this.tb_Curso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Curso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_Curso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tb_Curso.Enabled = false;
            this.tb_Curso.Font = new System.Drawing.Font("Verdana", 24F);
            this.tb_Curso.FormattingEnabled = true;
            this.tb_Curso.Location = new System.Drawing.Point(1000, 286);
            this.tb_Curso.Name = "tb_Curso";
            this.tb_Curso.Size = new System.Drawing.Size(351, 46);
            this.tb_Curso.TabIndex = 237;
            // 
            // cb_ano
            // 
            this.cb_ano.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_ano.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ano.Enabled = false;
            this.cb_ano.Font = new System.Drawing.Font("Verdana", 24F);
            this.cb_ano.FormattingEnabled = true;
            this.cb_ano.Location = new System.Drawing.Point(1041, 540);
            this.cb_ano.Name = "cb_ano";
            this.cb_ano.Size = new System.Drawing.Size(308, 46);
            this.cb_ano.TabIndex = 28;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 20.25F);
            this.label22.Location = new System.Drawing.Point(1035, 503);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(157, 32);
            this.label22.TabIndex = 238;
            this.label22.Text = "Ano Letivo";
            // 
            // F_NovoAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 695);
            this.Controls.Add(this.cb_ano);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tb_Curso);
            this.Controls.Add(this.cb_etapa);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mstb_TelefoneEnd);
            this.Controls.Add(this.tb_Emergencia);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tb_Doenca);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.Liberar_Doenca);
            this.Controls.Add(this.tb_ViveCom);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tb_Outro2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tb_Outro1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tb_Pai);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tb_Zona);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cb_Cor);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cb_Turno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_Sexo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tb_Mae);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tb_CEPEnd);
            this.Controls.Add(this.tb_BairroEnd);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tb_NumeroEnd);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_Rua);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Label124);
            this.Controls.Add(this.cb_UF);
            this.Controls.Add(this.mstb_DataNasc);
            this.Controls.Add(this.tb_Nacionalidade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_Cidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Aluno);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_NovoAluno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Aluno";
            this.Load += new System.EventHandler(this.F_NovoAluno_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Gravar;
        private System.Windows.Forms.Button btn_Novo;
        private System.Windows.Forms.Label Label124;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cb_Sexo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_Turno;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tb_Aluno;
        public System.Windows.Forms.TextBox tb_Cidade;
        public System.Windows.Forms.TextBox tb_Nacionalidade;
        public System.Windows.Forms.MaskedTextBox mstb_DataNasc;
        public System.Windows.Forms.ComboBox cb_UF;
        public System.Windows.Forms.TextBox tb_Rua;
        public System.Windows.Forms.TextBox tb_NumeroEnd;
        public System.Windows.Forms.TextBox tb_BairroEnd;
        public System.Windows.Forms.TextBox tb_CEPEnd;
        public System.Windows.Forms.TextBox tb_Mae;
        private System.Windows.Forms.ComboBox cb_Cor;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox tb_Zona;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox tb_Pai;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox tb_Outro2;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox tb_Outro1;
        private System.Windows.Forms.Label label19;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        public System.Windows.Forms.TextBox tb_ViveCom;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox Liberar_Doenca;
        public System.Windows.Forms.TextBox tb_Doenca;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.TextBox tb_Emergencia;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.MaskedTextBox mstb_TelefoneEnd;
        public System.Windows.Forms.ComboBox cb_etapa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox tb_Curso;
        private System.Windows.Forms.ComboBox cb_ano;
        private System.Windows.Forms.Label label22;
    }
}