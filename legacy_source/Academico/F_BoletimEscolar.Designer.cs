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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_BoletimEscolar));
            this.tb_Aluno = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_selecionarAluno = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_selecionarProfessor = new System.Windows.Forms.Button();
            this.tb_Professor = new System.Windows.Forms.TextBox();
            this.tb_nota1 = new System.Windows.Forms.TextBox();
            this.tb_nota2 = new System.Windows.Forms.TextBox();
            this.tb_media = new System.Windows.Forms.TextBox();
            this.lb_resultado = new System.Windows.Forms.Label();
            this.lb_media2 = new System.Windows.Forms.Label();
            this.lb_media1 = new System.Windows.Forms.Label();
            this.lb_mediaparcial = new System.Windows.Forms.Label();
            this.cb_materia = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_obgnota1 = new System.Windows.Forms.Label();
            this.lb_obgnota2 = new System.Windows.Forms.Label();
            this.lb_obgAluno = new System.Windows.Forms.Label();
            this.lb_obgProfessor = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_cursos = new System.Windows.Forms.ComboBox();
            this.btn_Calc = new System.Windows.Forms.Button();
            this.lb_materia = new System.Windows.Forms.TextBox();
            this.dgv_Notas = new System.Windows.Forms.DataGridView();
            this.lb_obgnota4 = new System.Windows.Forms.Label();
            this.lb_media3 = new System.Windows.Forms.Label();
            this.lb_media4 = new System.Windows.Forms.Label();
            this.tb_nota4 = new System.Windows.Forms.TextBox();
            this.tb_nota3 = new System.Windows.Forms.TextBox();
            this.lb_obgnota3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_AnoLetivo = new System.Windows.Forms.ComboBox();
            this.lb_recup = new System.Windows.Forms.Label();
            this.tb_recup = new System.Windows.Forms.TextBox();
            this.lb_mediafinal = new System.Windows.Forms.Label();
            this.lb_resultadoFinal = new System.Windows.Forms.Label();
            this.tb_MediaFinal = new System.Windows.Forms.TextBox();
            this.btn_faltas = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Notas)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Aluno
            // 
            this.tb_Aluno.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Aluno.Enabled = false;
            this.tb_Aluno.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Aluno.Location = new System.Drawing.Point(12, 37);
            this.tb_Aluno.Name = "tb_Aluno";
            this.tb_Aluno.ReadOnly = true;
            this.tb_Aluno.Size = new System.Drawing.Size(256, 21);
            this.tb_Aluno.TabIndex = 19;
            this.tb_Aluno.Tag = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Editar);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btn_imprimir);
            this.panel2.Controls.Add(this.btn_Cancelar);
            this.panel2.Controls.Add(this.btn_Salvar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 453);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(923, 55);
            this.panel2.TabIndex = 16;
            // 
            // btn_Editar
            // 
            this.btn_Editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Editar.Location = new System.Drawing.Point(393, 5);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(152, 42);
            this.btn_Editar.TabIndex = 4;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(568, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Excluir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_imprimir.Location = new System.Drawing.Point(744, 5);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(152, 42);
            this.btn_imprimir.TabIndex = 3;
            this.btn_imprimir.Text = "Gerar Boletim";
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Location = new System.Drawing.Point(216, 5);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(152, 42);
            this.btn_Cancelar.TabIndex = 2;
            this.btn_Cancelar.Text = "Limpar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Salvar.Location = new System.Drawing.Point(39, 5);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(152, 42);
            this.btn_Salvar.TabIndex = 1;
            this.btn_Salvar.Text = "Lançar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Aluno(a)";
            // 
            // btn_selecionarAluno
            // 
            this.btn_selecionarAluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selecionarAluno.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selecionarAluno.Location = new System.Drawing.Point(274, 37);
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
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Professor(a)";
            // 
            // btn_selecionarProfessor
            // 
            this.btn_selecionarProfessor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selecionarProfessor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selecionarProfessor.Location = new System.Drawing.Point(274, 118);
            this.btn_selecionarProfessor.Name = "btn_selecionarProfessor";
            this.btn_selecionarProfessor.Size = new System.Drawing.Size(30, 21);
            this.btn_selecionarProfessor.TabIndex = 2;
            this.btn_selecionarProfessor.Text = "...";
            this.btn_selecionarProfessor.UseVisualStyleBackColor = true;
            this.btn_selecionarProfessor.Click += new System.EventHandler(this.btn_selecionarProfessor_Click);
            // 
            // tb_Professor
            // 
            this.tb_Professor.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Professor.Enabled = false;
            this.tb_Professor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Professor.Location = new System.Drawing.Point(12, 118);
            this.tb_Professor.Name = "tb_Professor";
            this.tb_Professor.ReadOnly = true;
            this.tb_Professor.Size = new System.Drawing.Size(256, 21);
            this.tb_Professor.TabIndex = 34;
            this.tb_Professor.Tag = "";
            // 
            // tb_nota1
            // 
            this.tb_nota1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_nota1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nota1.Location = new System.Drawing.Point(12, 310);
            this.tb_nota1.MaxLength = 5;
            this.tb_nota1.Name = "tb_nota1";
            this.tb_nota1.Size = new System.Drawing.Size(65, 32);
            this.tb_nota1.TabIndex = 5;
            this.tb_nota1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nota1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nota1_KeyPress);
            // 
            // tb_nota2
            // 
            this.tb_nota2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_nota2.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nota2.Location = new System.Drawing.Point(87, 310);
            this.tb_nota2.Name = "tb_nota2";
            this.tb_nota2.Size = new System.Drawing.Size(65, 32);
            this.tb_nota2.TabIndex = 6;
            this.tb_nota2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nota2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nota2_KeyPress);
            // 
            // tb_media
            // 
            this.tb_media.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_media.Enabled = false;
            this.tb_media.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_media.Location = new System.Drawing.Point(12, 362);
            this.tb_media.Name = "tb_media";
            this.tb_media.Size = new System.Drawing.Size(80, 32);
            this.tb_media.TabIndex = 14;
            this.tb_media.TabStop = false;
            this.tb_media.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_resultado
            // 
            this.lb_resultado.AutoSize = true;
            this.lb_resultado.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.lb_resultado.Location = new System.Drawing.Point(98, 364);
            this.lb_resultado.Name = "lb_resultado";
            this.lb_resultado.Size = new System.Drawing.Size(37, 23);
            this.lb_resultado.TabIndex = 43;
            this.lb_resultado.Text = "---";
            // 
            // lb_media2
            // 
            this.lb_media2.AutoSize = true;
            this.lb_media2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_media2.Location = new System.Drawing.Point(84, 294);
            this.lb_media2.Name = "lb_media2";
            this.lb_media2.Size = new System.Drawing.Size(47, 13);
            this.lb_media2.TabIndex = 44;
            this.lb_media2.Text = "Média2";
            // 
            // lb_media1
            // 
            this.lb_media1.AutoSize = true;
            this.lb_media1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_media1.Location = new System.Drawing.Point(11, 294);
            this.lb_media1.Name = "lb_media1";
            this.lb_media1.Size = new System.Drawing.Size(47, 13);
            this.lb_media1.TabIndex = 45;
            this.lb_media1.Text = "Média1";
            // 
            // lb_mediaparcial
            // 
            this.lb_mediaparcial.AutoSize = true;
            this.lb_mediaparcial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mediaparcial.Location = new System.Drawing.Point(32, 346);
            this.lb_mediaparcial.Name = "lb_mediaparcial";
            this.lb_mediaparcial.Size = new System.Drawing.Size(40, 13);
            this.lb_mediaparcial.TabIndex = 46;
            this.lb_mediaparcial.Text = "Média";
            // 
            // cb_materia
            // 
            this.cb_materia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_materia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_materia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_materia.FormattingEnabled = true;
            this.cb_materia.Location = new System.Drawing.Point(12, 160);
            this.cb_materia.Name = "cb_materia";
            this.cb_materia.Size = new System.Drawing.Size(292, 21);
            this.cb_materia.TabIndex = 3;
            this.cb_materia.SelectedIndexChanged += new System.EventHandler(this.cb_materia_SelectedIndexChanged);
            this.cb_materia.SelectionChangeCommitted += new System.EventHandler(this.cb_materia_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Matéria";
            // 
            // lb_obgnota1
            // 
            this.lb_obgnota1.AutoSize = true;
            this.lb_obgnota1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_obgnota1.Location = new System.Drawing.Point(61, 294);
            this.lb_obgnota1.Name = "lb_obgnota1";
            this.lb_obgnota1.Size = new System.Drawing.Size(14, 13);
            this.lb_obgnota1.TabIndex = 63;
            this.lb_obgnota1.Text = "*";
            // 
            // lb_obgnota2
            // 
            this.lb_obgnota2.AutoSize = true;
            this.lb_obgnota2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_obgnota2.Location = new System.Drawing.Point(130, 294);
            this.lb_obgnota2.Name = "lb_obgnota2";
            this.lb_obgnota2.Size = new System.Drawing.Size(14, 13);
            this.lb_obgnota2.TabIndex = 64;
            this.lb_obgnota2.Text = "*";
            // 
            // lb_obgAluno
            // 
            this.lb_obgAluno.AutoSize = true;
            this.lb_obgAluno.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_obgAluno.Location = new System.Drawing.Point(69, 21);
            this.lb_obgAluno.Name = "lb_obgAluno";
            this.lb_obgAluno.Size = new System.Drawing.Size(14, 13);
            this.lb_obgAluno.TabIndex = 68;
            this.lb_obgAluno.Text = "*";
            // 
            // lb_obgProfessor
            // 
            this.lb_obgProfessor.AutoSize = true;
            this.lb_obgProfessor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_obgProfessor.Location = new System.Drawing.Point(98, 101);
            this.lb_obgProfessor.Name = "lb_obgProfessor";
            this.lb_obgProfessor.Size = new System.Drawing.Size(14, 13);
            this.lb_obgProfessor.TabIndex = 69;
            this.lb_obgProfessor.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 71;
            this.label13.Text = "Curso";
            // 
            // cb_cursos
            // 
            this.cb_cursos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_cursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cursos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cursos.FormattingEnabled = true;
            this.cb_cursos.Location = new System.Drawing.Point(12, 77);
            this.cb_cursos.Name = "cb_cursos";
            this.cb_cursos.Size = new System.Drawing.Size(292, 21);
            this.cb_cursos.TabIndex = 1;
            this.cb_cursos.SelectionChangeCommitted += new System.EventHandler(this.cb_cursos_SelectionChangeCommitted);
            // 
            // btn_Calc
            // 
            this.btn_Calc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Calc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Calc.Location = new System.Drawing.Point(943, 117);
            this.btn_Calc.Name = "btn_Calc";
            this.btn_Calc.Size = new System.Drawing.Size(27, 21);
            this.btn_Calc.TabIndex = 72;
            this.btn_Calc.Text = "...";
            this.btn_Calc.UseVisualStyleBackColor = true;
            this.btn_Calc.Click += new System.EventHandler(this.btn_Calc_Click);
            // 
            // lb_materia
            // 
            this.lb_materia.BackColor = System.Drawing.SystemColors.Control;
            this.lb_materia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_materia.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_materia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_materia.ForeColor = System.Drawing.Color.Green;
            this.lb_materia.Location = new System.Drawing.Point(12, 239);
            this.lb_materia.Multiline = true;
            this.lb_materia.Name = "lb_materia";
            this.lb_materia.Size = new System.Drawing.Size(292, 35);
            this.lb_materia.TabIndex = 73;
            this.lb_materia.TabStop = false;
            // 
            // dgv_Notas
            // 
            this.dgv_Notas.AllowUserToAddRows = false;
            this.dgv_Notas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Notas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Notas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Notas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Notas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Notas.EnableHeadersVisualStyles = false;
            this.dgv_Notas.Location = new System.Drawing.Point(312, 25);
            this.dgv_Notas.MultiSelect = false;
            this.dgv_Notas.Name = "dgv_Notas";
            this.dgv_Notas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Notas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Notas.RowHeadersVisible = false;
            this.dgv_Notas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Notas.Size = new System.Drawing.Size(611, 421);
            this.dgv_Notas.TabIndex = 124;
            this.dgv_Notas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Notas_CellFormatting);
            this.dgv_Notas.SelectionChanged += new System.EventHandler(this.dgv_Notas_SelectionChanged);
            // 
            // lb_obgnota4
            // 
            this.lb_obgnota4.AutoSize = true;
            this.lb_obgnota4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_obgnota4.Location = new System.Drawing.Point(278, 294);
            this.lb_obgnota4.Name = "lb_obgnota4";
            this.lb_obgnota4.Size = new System.Drawing.Size(14, 13);
            this.lb_obgnota4.TabIndex = 130;
            this.lb_obgnota4.Text = "*";
            // 
            // lb_media3
            // 
            this.lb_media3.AutoSize = true;
            this.lb_media3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_media3.Location = new System.Drawing.Point(157, 294);
            this.lb_media3.Name = "lb_media3";
            this.lb_media3.Size = new System.Drawing.Size(47, 13);
            this.lb_media3.TabIndex = 128;
            this.lb_media3.Text = "Média3";
            // 
            // lb_media4
            // 
            this.lb_media4.AutoSize = true;
            this.lb_media4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_media4.Location = new System.Drawing.Point(232, 294);
            this.lb_media4.Name = "lb_media4";
            this.lb_media4.Size = new System.Drawing.Size(47, 13);
            this.lb_media4.TabIndex = 127;
            this.lb_media4.Text = "Média4";
            // 
            // tb_nota4
            // 
            this.tb_nota4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_nota4.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nota4.Location = new System.Drawing.Point(235, 310);
            this.tb_nota4.Name = "tb_nota4";
            this.tb_nota4.Size = new System.Drawing.Size(65, 32);
            this.tb_nota4.TabIndex = 8;
            this.tb_nota4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nota4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nota4_KeyPress);
            // 
            // tb_nota3
            // 
            this.tb_nota3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_nota3.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nota3.Location = new System.Drawing.Point(160, 310);
            this.tb_nota3.MaxLength = 5;
            this.tb_nota3.Name = "tb_nota3";
            this.tb_nota3.Size = new System.Drawing.Size(65, 32);
            this.tb_nota3.TabIndex = 7;
            this.tb_nota3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nota3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nota3_KeyPress);
            // 
            // lb_obgnota3
            // 
            this.lb_obgnota3.AutoSize = true;
            this.lb_obgnota3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_obgnota3.Location = new System.Drawing.Point(209, 294);
            this.lb_obgnota3.Name = "lb_obgnota3";
            this.lb_obgnota3.Size = new System.Drawing.Size(14, 13);
            this.lb_obgnota3.TabIndex = 129;
            this.lb_obgnota3.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 132;
            this.label1.Text = "Ano Letivo";
            // 
            // cb_AnoLetivo
            // 
            this.cb_AnoLetivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_AnoLetivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AnoLetivo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_AnoLetivo.FormattingEnabled = true;
            this.cb_AnoLetivo.Location = new System.Drawing.Point(12, 200);
            this.cb_AnoLetivo.Name = "cb_AnoLetivo";
            this.cb_AnoLetivo.Size = new System.Drawing.Size(100, 21);
            this.cb_AnoLetivo.TabIndex = 4;
            // 
            // lb_recup
            // 
            this.lb_recup.AutoSize = true;
            this.lb_recup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_recup.Location = new System.Drawing.Point(11, 294);
            this.lb_recup.Name = "lb_recup";
            this.lb_recup.Size = new System.Drawing.Size(81, 13);
            this.lb_recup.TabIndex = 134;
            this.lb_recup.Text = "Recuperação";
            // 
            // tb_recup
            // 
            this.tb_recup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_recup.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_recup.Location = new System.Drawing.Point(12, 310);
            this.tb_recup.MaxLength = 5;
            this.tb_recup.Name = "tb_recup";
            this.tb_recup.Size = new System.Drawing.Size(80, 32);
            this.tb_recup.TabIndex = 9;
            this.tb_recup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_mediafinal
            // 
            this.lb_mediafinal.AutoSize = true;
            this.lb_mediafinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mediafinal.Location = new System.Drawing.Point(17, 398);
            this.lb_mediafinal.Name = "lb_mediafinal";
            this.lb_mediafinal.Size = new System.Drawing.Size(70, 13);
            this.lb_mediafinal.TabIndex = 137;
            this.lb_mediafinal.Text = "Média Final";
            // 
            // lb_resultadoFinal
            // 
            this.lb_resultadoFinal.AutoSize = true;
            this.lb_resultadoFinal.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.lb_resultadoFinal.Location = new System.Drawing.Point(98, 416);
            this.lb_resultadoFinal.Name = "lb_resultadoFinal";
            this.lb_resultadoFinal.Size = new System.Drawing.Size(37, 23);
            this.lb_resultadoFinal.TabIndex = 136;
            this.lb_resultadoFinal.Text = "---";
            // 
            // tb_MediaFinal
            // 
            this.tb_MediaFinal.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_MediaFinal.Enabled = false;
            this.tb_MediaFinal.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MediaFinal.Location = new System.Drawing.Point(12, 414);
            this.tb_MediaFinal.Name = "tb_MediaFinal";
            this.tb_MediaFinal.Size = new System.Drawing.Size(80, 32);
            this.tb_MediaFinal.TabIndex = 15;
            this.tb_MediaFinal.TabStop = false;
            this.tb_MediaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_faltas
            // 
            this.btn_faltas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_faltas.Location = new System.Drawing.Point(205, 198);
            this.btn_faltas.Name = "btn_faltas";
            this.btn_faltas.Size = new System.Drawing.Size(99, 23);
            this.btn_faltas.TabIndex = 6;
            this.btn_faltas.Text = "Lançar Faltas";
            this.btn_faltas.UseVisualStyleBackColor = true;
            this.btn_faltas.Click += new System.EventHandler(this.btn_faltas_Click);
            // 
            // F_BoletimEscolar
            // 
            this.AcceptButton = this.btn_Calc;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 508);
            this.Controls.Add(this.btn_faltas);
            this.Controls.Add(this.lb_mediafinal);
            this.Controls.Add(this.lb_resultadoFinal);
            this.Controls.Add(this.tb_MediaFinal);
            this.Controls.Add(this.lb_recup);
            this.Controls.Add(this.tb_recup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_AnoLetivo);
            this.Controls.Add(this.lb_obgnota4);
            this.Controls.Add(this.lb_media3);
            this.Controls.Add(this.lb_media4);
            this.Controls.Add(this.tb_nota4);
            this.Controls.Add(this.tb_nota3);
            this.Controls.Add(this.lb_obgnota3);
            this.Controls.Add(this.dgv_Notas);
            this.Controls.Add(this.lb_materia);
            this.Controls.Add(this.lb_obgnota2);
            this.Controls.Add(this.btn_Calc);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cb_cursos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_materia);
            this.Controls.Add(this.lb_mediaparcial);
            this.Controls.Add(this.lb_media1);
            this.Controls.Add(this.lb_media2);
            this.Controls.Add(this.lb_resultado);
            this.Controls.Add(this.tb_media);
            this.Controls.Add(this.tb_nota2);
            this.Controls.Add(this.btn_selecionarProfessor);
            this.Controls.Add(this.tb_Professor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_selecionarAluno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tb_Aluno);
            this.Controls.Add(this.tb_nota1);
            this.Controls.Add(this.lb_obgnota1);
            this.Controls.Add(this.lb_obgProfessor);
            this.Controls.Add(this.lb_obgAluno);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_BoletimEscolar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boletim";
            this.Load += new System.EventHandler(this.F_BoletimEscolar_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Notas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox tb_Aluno;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_selecionarAluno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_selecionarProfessor;
        public System.Windows.Forms.TextBox tb_Professor;
        private System.Windows.Forms.TextBox tb_media;
        private System.Windows.Forms.Label lb_resultado;
        private System.Windows.Forms.Label lb_media2;
        private System.Windows.Forms.Label lb_media1;
        private System.Windows.Forms.Label lb_mediaparcial;
        private System.Windows.Forms.ComboBox cb_materia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.Label lb_obgnota1;
        private System.Windows.Forms.Label lb_obgnota2;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_Cancelar;
        public System.Windows.Forms.Label lb_obgAluno;
        public System.Windows.Forms.Label lb_obgProfessor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_Calc;
        private System.Windows.Forms.TextBox lb_materia;
        public System.Windows.Forms.DataGridView dgv_Notas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_obgnota4;
        private System.Windows.Forms.Label lb_media3;
        private System.Windows.Forms.Label lb_media4;
        private System.Windows.Forms.Label lb_obgnota3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tb_nota1;
        public System.Windows.Forms.TextBox tb_nota2;
        public System.Windows.Forms.TextBox tb_nota4;
        public System.Windows.Forms.TextBox tb_nota3;
        public System.Windows.Forms.ComboBox cb_cursos;
        public System.Windows.Forms.TextBox tb_recup;
        public System.Windows.Forms.Label lb_recup;
        private System.Windows.Forms.Button btn_Editar;
        public System.Windows.Forms.Label lb_resultadoFinal;
        public System.Windows.Forms.TextBox tb_MediaFinal;
        public System.Windows.Forms.Label lb_mediafinal;
        public System.Windows.Forms.ComboBox cb_AnoLetivo;
        public System.Windows.Forms.Button btn_faltas;
    }
}