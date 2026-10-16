namespace Escolar
{
    partial class F_BoletimEscolar
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
            this.tb_Aluno = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_Fechar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.lb_materia = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_selecionarAluno = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_selecionarProfessor = new System.Windows.Forms.Button();
            this.tb_Professor = new System.Windows.Forms.TextBox();
            this.tb_nota1 = new System.Windows.Forms.TextBox();
            this.tb_nota3 = new System.Windows.Forms.TextBox();
            this.tb_nota2 = new System.Windows.Forms.TextBox();
            this.tb_nota4 = new System.Windows.Forms.TextBox();
            this.tb_media = new System.Windows.Forms.TextBox();
            this.lb_resultado = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_turma = new System.Windows.Forms.TextBox();
            this.tb_turno = new System.Windows.Forms.TextBox();
            this.tb_sala = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_materia = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_obgnota1 = new System.Windows.Forms.Label();
            this.lb_obgnota2 = new System.Windows.Forms.Label();
            this.lb_obgnota3 = new System.Windows.Forms.Label();
            this.lb_obgnota4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_obgAluno = new System.Windows.Forms.Label();
            this.lb_obgProfessor = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Aluno
            // 
            this.tb_Aluno.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Aluno.Enabled = false;
            this.tb_Aluno.Location = new System.Drawing.Point(18, 37);
            this.tb_Aluno.Name = "tb_Aluno";
            this.tb_Aluno.ReadOnly = true;
            this.tb_Aluno.Size = new System.Drawing.Size(189, 20);
            this.tb_Aluno.TabIndex = 19;
            this.tb_Aluno.Tag = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_imprimir);
            this.panel2.Controls.Add(this.btn_Fechar);
            this.panel2.Controls.Add(this.btn_Cancelar);
            this.panel2.Controls.Add(this.btn_Salvar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 215);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 58);
            this.panel2.TabIndex = 21;
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_imprimir.Location = new System.Drawing.Point(256, 10);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(90, 36);
            this.btn_imprimir.TabIndex = 9;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_Fechar
            // 
            this.btn_Fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Fechar.Location = new System.Drawing.Point(358, 10);
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.Size = new System.Drawing.Size(90, 36);
            this.btn_Fechar.TabIndex = 10;
            this.btn_Fechar.Text = "Fechar";
            this.btn_Fechar.UseVisualStyleBackColor = true;
            this.btn_Fechar.Click += new System.EventHandler(this.btn_Fechar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Location = new System.Drawing.Point(143, 10);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(90, 36);
            this.btn_Cancelar.TabIndex = 8;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Salvar.Location = new System.Drawing.Point(33, 10);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(90, 36);
            this.btn_Salvar.TabIndex = 7;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // lb_materia
            // 
            this.lb_materia.AutoSize = true;
            this.lb_materia.BackColor = System.Drawing.Color.Transparent;
            this.lb_materia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lb_materia.Location = new System.Drawing.Point(15, 121);
            this.lb_materia.Name = "lb_materia";
            this.lb_materia.Size = new System.Drawing.Size(26, 18);
            this.lb_materia.TabIndex = 22;
            this.lb_materia.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "ALUNO(A)";
            // 
            // btn_selecionarAluno
            // 
            this.btn_selecionarAluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selecionarAluno.Location = new System.Drawing.Point(206, 36);
            this.btn_selecionarAluno.Name = "btn_selecionarAluno";
            this.btn_selecionarAluno.Size = new System.Drawing.Size(30, 22);
            this.btn_selecionarAluno.TabIndex = 0;
            this.btn_selecionarAluno.Text = "...";
            this.btn_selecionarAluno.UseVisualStyleBackColor = true;
            this.btn_selecionarAluno.Click += new System.EventHandler(this.btn_selecionarAluno_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "PROFESSOR(A)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "TURMA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "TURNO";
            // 
            // btn_selecionarProfessor
            // 
            this.btn_selecionarProfessor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selecionarProfessor.Location = new System.Drawing.Point(426, 36);
            this.btn_selecionarProfessor.Name = "btn_selecionarProfessor";
            this.btn_selecionarProfessor.Size = new System.Drawing.Size(30, 22);
            this.btn_selecionarProfessor.TabIndex = 1;
            this.btn_selecionarProfessor.Text = "...";
            this.btn_selecionarProfessor.UseVisualStyleBackColor = true;
            this.btn_selecionarProfessor.Click += new System.EventHandler(this.btn_selecionarProfessor_Click);
            // 
            // tb_Professor
            // 
            this.tb_Professor.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Professor.Enabled = false;
            this.tb_Professor.Location = new System.Drawing.Point(244, 38);
            this.tb_Professor.Name = "tb_Professor";
            this.tb_Professor.ReadOnly = true;
            this.tb_Professor.Size = new System.Drawing.Size(190, 20);
            this.tb_Professor.TabIndex = 34;
            this.tb_Professor.Tag = "";
            // 
            // tb_nota1
            // 
            this.tb_nota1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_nota1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tb_nota1.Location = new System.Drawing.Point(18, 166);
            this.tb_nota1.MaxLength = 5;
            this.tb_nota1.Name = "tb_nota1";
            this.tb_nota1.Size = new System.Drawing.Size(52, 30);
            this.tb_nota1.TabIndex = 3;
            this.tb_nota1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nota1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nota1_KeyPress);
            // 
            // tb_nota3
            // 
            this.tb_nota3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_nota3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tb_nota3.Location = new System.Drawing.Point(152, 166);
            this.tb_nota3.Name = "tb_nota3";
            this.tb_nota3.Size = new System.Drawing.Size(52, 30);
            this.tb_nota3.TabIndex = 5;
            this.tb_nota3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nota3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nota3_KeyPress);
            // 
            // tb_nota2
            // 
            this.tb_nota2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_nota2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tb_nota2.Location = new System.Drawing.Point(86, 166);
            this.tb_nota2.Name = "tb_nota2";
            this.tb_nota2.Size = new System.Drawing.Size(52, 30);
            this.tb_nota2.TabIndex = 4;
            this.tb_nota2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nota2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nota2_KeyPress);
            // 
            // tb_nota4
            // 
            this.tb_nota4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_nota4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tb_nota4.Location = new System.Drawing.Point(215, 165);
            this.tb_nota4.Name = "tb_nota4";
            this.tb_nota4.Size = new System.Drawing.Size(52, 30);
            this.tb_nota4.TabIndex = 6;
            this.tb_nota4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nota4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nota4_KeyPress);
            // 
            // tb_media
            // 
            this.tb_media.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_media.Enabled = false;
            this.tb_media.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tb_media.Location = new System.Drawing.Point(286, 165);
            this.tb_media.Name = "tb_media";
            this.tb_media.Size = new System.Drawing.Size(60, 30);
            this.tb_media.TabIndex = 42;
            this.tb_media.TabStop = false;
            this.tb_media.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_resultado
            // 
            this.lb_resultado.AutoSize = true;
            this.lb_resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lb_resultado.Location = new System.Drawing.Point(357, 173);
            this.lb_resultado.Name = "lb_resultado";
            this.lb_resultado.Size = new System.Drawing.Size(23, 18);
            this.lb_resultado.TabIndex = 43;
            this.lb_resultado.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Nota 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Nota 1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(298, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Média";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(212, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Nota 4";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(149, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "Nota 3";
            // 
            // tb_turma
            // 
            this.tb_turma.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_turma.Enabled = false;
            this.tb_turma.Location = new System.Drawing.Point(18, 77);
            this.tb_turma.Name = "tb_turma";
            this.tb_turma.ReadOnly = true;
            this.tb_turma.Size = new System.Drawing.Size(130, 20);
            this.tb_turma.TabIndex = 57;
            this.tb_turma.Tag = "";
            // 
            // tb_turno
            // 
            this.tb_turno.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_turno.Enabled = false;
            this.tb_turno.Location = new System.Drawing.Point(164, 76);
            this.tb_turno.Name = "tb_turno";
            this.tb_turno.ReadOnly = true;
            this.tb_turno.Size = new System.Drawing.Size(72, 20);
            this.tb_turno.TabIndex = 58;
            this.tb_turno.Tag = "";
            // 
            // tb_sala
            // 
            this.tb_sala.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_sala.Enabled = false;
            this.tb_sala.Location = new System.Drawing.Point(245, 76);
            this.tb_sala.Name = "tb_sala";
            this.tb_sala.ReadOnly = true;
            this.tb_sala.Size = new System.Drawing.Size(71, 20);
            this.tb_sala.TabIndex = 59;
            this.tb_sala.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "SALA";
            // 
            // cb_materia
            // 
            this.cb_materia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_materia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_materia.FormattingEnabled = true;
            this.cb_materia.Location = new System.Drawing.Point(328, 76);
            this.cb_materia.Name = "cb_materia";
            this.cb_materia.Size = new System.Drawing.Size(128, 21);
            this.cb_materia.TabIndex = 2;
            this.cb_materia.SelectedIndexChanged += new System.EventHandler(this.cb_materia_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(325, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "MATÉRIA";
            // 
            // lb_obgnota1
            // 
            this.lb_obgnota1.AutoSize = true;
            this.lb_obgnota1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_obgnota1.Location = new System.Drawing.Point(55, 150);
            this.lb_obgnota1.Name = "lb_obgnota1";
            this.lb_obgnota1.Size = new System.Drawing.Size(15, 20);
            this.lb_obgnota1.TabIndex = 63;
            this.lb_obgnota1.Text = "*";
            // 
            // lb_obgnota2
            // 
            this.lb_obgnota2.AutoSize = true;
            this.lb_obgnota2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_obgnota2.Location = new System.Drawing.Point(127, 150);
            this.lb_obgnota2.Name = "lb_obgnota2";
            this.lb_obgnota2.Size = new System.Drawing.Size(15, 20);
            this.lb_obgnota2.TabIndex = 64;
            this.lb_obgnota2.Text = "*";
            // 
            // lb_obgnota3
            // 
            this.lb_obgnota3.AutoSize = true;
            this.lb_obgnota3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_obgnota3.Location = new System.Drawing.Point(189, 150);
            this.lb_obgnota3.Name = "lb_obgnota3";
            this.lb_obgnota3.Size = new System.Drawing.Size(15, 20);
            this.lb_obgnota3.TabIndex = 65;
            this.lb_obgnota3.Text = "*";
            // 
            // lb_obgnota4
            // 
            this.lb_obgnota4.AutoSize = true;
            this.lb_obgnota4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_obgnota4.Location = new System.Drawing.Point(252, 150);
            this.lb_obgnota4.Name = "lb_obgnota4";
            this.lb_obgnota4.Size = new System.Drawing.Size(15, 20);
            this.lb_obgnota4.TabIndex = 66;
            this.lb_obgnota4.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "SITUAÇÃO";
            // 
            // lb_obgAluno
            // 
            this.lb_obgAluno.AutoSize = true;
            this.lb_obgAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_obgAluno.Location = new System.Drawing.Point(69, 21);
            this.lb_obgAluno.Name = "lb_obgAluno";
            this.lb_obgAluno.Size = new System.Drawing.Size(15, 20);
            this.lb_obgAluno.TabIndex = 68;
            this.lb_obgAluno.Text = "*";
            // 
            // lb_obgProfessor
            // 
            this.lb_obgProfessor.AutoSize = true;
            this.lb_obgProfessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_obgProfessor.Location = new System.Drawing.Point(324, 21);
            this.lb_obgProfessor.Name = "lb_obgProfessor";
            this.lb_obgProfessor.Size = new System.Drawing.Size(15, 20);
            this.lb_obgProfessor.TabIndex = 69;
            this.lb_obgProfessor.Text = "*";
            // 
            // F_BoletimEscolar
            // 
            this.AcceptButton = this.btn_Salvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_materia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_sala);
            this.Controls.Add(this.tb_turno);
            this.Controls.Add(this.tb_turma);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_resultado);
            this.Controls.Add(this.tb_media);
            this.Controls.Add(this.tb_nota4);
            this.Controls.Add(this.tb_nota2);
            this.Controls.Add(this.tb_nota3);
            this.Controls.Add(this.btn_selecionarProfessor);
            this.Controls.Add(this.tb_Professor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_selecionarAluno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_materia);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tb_Aluno);
            this.Controls.Add(this.tb_nota1);
            this.Controls.Add(this.lb_obgnota4);
            this.Controls.Add(this.lb_obgnota3);
            this.Controls.Add(this.lb_obgnota2);
            this.Controls.Add(this.lb_obgnota1);
            this.Controls.Add(this.lb_obgProfessor);
            this.Controls.Add(this.lb_obgAluno);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_BoletimEscolar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boletim";
            this.Load += new System.EventHandler(this.F_BoletimEscolar_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox tb_Aluno;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_materia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_selecionarAluno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_selecionarProfessor;
        public System.Windows.Forms.TextBox tb_Professor;
        private System.Windows.Forms.TextBox tb_media;
        private System.Windows.Forms.Label lb_resultado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_nota1;
        private System.Windows.Forms.TextBox tb_nota3;
        private System.Windows.Forms.TextBox tb_nota2;
        private System.Windows.Forms.TextBox tb_nota4;
        public System.Windows.Forms.TextBox tb_turma;
        public System.Windows.Forms.TextBox tb_turno;
        public System.Windows.Forms.TextBox tb_sala;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_materia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.Label lb_obgnota1;
        private System.Windows.Forms.Label lb_obgnota2;
        private System.Windows.Forms.Label lb_obgnota3;
        private System.Windows.Forms.Label lb_obgnota4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_Fechar;
        private System.Windows.Forms.Button btn_Cancelar;
        public System.Windows.Forms.Label lb_obgAluno;
        public System.Windows.Forms.Label lb_obgProfessor;
    }
}