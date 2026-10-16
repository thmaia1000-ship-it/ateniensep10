
namespace Escolar.Turmas
{
    partial class AdicionarAluno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarAluno));
            this.dgv_Turmas = new System.Windows.Forms.DataGridView();
            this.nome_aluno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_aluno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Aluno = new System.Windows.Forms.Button();
            this.tb_nome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_turma = new System.Windows.Forms.ComboBox();
            this.btn_nova_turma = new System.Windows.Forms.Button();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.btn_remover = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lb_turno = new System.Windows.Forms.Label();
            this.lb_professor = new System.Windows.Forms.Label();
            this.cb_ano = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_editar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Turmas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Turmas
            // 
            this.dgv_Turmas.AllowUserToAddRows = false;
            this.dgv_Turmas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Turmas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Turmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Turmas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nome_aluno,
            this.turma,
            this.id_aluno});
            this.dgv_Turmas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Turmas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Turmas.EnableHeadersVisualStyles = false;
            this.dgv_Turmas.Location = new System.Drawing.Point(461, 24);
            this.dgv_Turmas.MultiSelect = false;
            this.dgv_Turmas.Name = "dgv_Turmas";
            this.dgv_Turmas.ReadOnly = true;
            this.dgv_Turmas.RowHeadersVisible = false;
            this.dgv_Turmas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Turmas.Size = new System.Drawing.Size(457, 258);
            this.dgv_Turmas.TabIndex = 18;
            // 
            // nome_aluno
            // 
            this.nome_aluno.HeaderText = "Aluno(a)";
            this.nome_aluno.Name = "nome_aluno";
            this.nome_aluno.ReadOnly = true;
            this.nome_aluno.Width = 324;
            // 
            // turma
            // 
            this.turma.HeaderText = "Turma";
            this.turma.Name = "turma";
            this.turma.ReadOnly = true;
            this.turma.Width = 130;
            // 
            // id_aluno
            // 
            this.id_aluno.HeaderText = "ID";
            this.id_aluno.Name = "id_aluno";
            this.id_aluno.ReadOnly = true;
            // 
            // btn_Aluno
            // 
            this.btn_Aluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Aluno.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Aluno.Location = new System.Drawing.Point(417, 24);
            this.btn_Aluno.Name = "btn_Aluno";
            this.btn_Aluno.Size = new System.Drawing.Size(38, 27);
            this.btn_Aluno.TabIndex = 47;
            this.btn_Aluno.Text = "...";
            this.btn_Aluno.UseVisualStyleBackColor = true;
            this.btn_Aluno.Click += new System.EventHandler(this.btn_Aluno_Click);
            // 
            // tb_nome
            // 
            this.tb_nome.Enabled = false;
            this.tb_nome.Font = new System.Drawing.Font("Verdana", 12.25F);
            this.tb_nome.Location = new System.Drawing.Point(12, 24);
            this.tb_nome.Name = "tb_nome";
            this.tb_nome.Size = new System.Drawing.Size(399, 27);
            this.tb_nome.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 18);
            this.label6.TabIndex = 49;
            this.label6.Text = "Aluno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "Turma";
            // 
            // cb_turma
            // 
            this.cb_turma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_turma.Font = new System.Drawing.Font("Verdana", 12.25F);
            this.cb_turma.FormattingEnabled = true;
            this.cb_turma.Location = new System.Drawing.Point(12, 82);
            this.cb_turma.Name = "cb_turma";
            this.cb_turma.Size = new System.Drawing.Size(443, 26);
            this.cb_turma.TabIndex = 50;
            this.cb_turma.SelectionChangeCommitted += new System.EventHandler(this.cb_turma_SelectionChangeCommitted);
            // 
            // btn_nova_turma
            // 
            this.btn_nova_turma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nova_turma.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nova_turma.Location = new System.Drawing.Point(117, 133);
            this.btn_nova_turma.Name = "btn_nova_turma";
            this.btn_nova_turma.Size = new System.Drawing.Size(71, 26);
            this.btn_nova_turma.TabIndex = 52;
            this.btn_nova_turma.Text = "Nova";
            this.btn_nova_turma.UseVisualStyleBackColor = true;
            this.btn_nova_turma.Click += new System.EventHandler(this.btn_nova_turma_Click);
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_adicionar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionar.Location = new System.Drawing.Point(461, 288);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(90, 31);
            this.btn_adicionar.TabIndex = 53;
            this.btn_adicionar.Text = "Adicionar";
            this.btn_adicionar.UseVisualStyleBackColor = true;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // btn_remover
            // 
            this.btn_remover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_remover.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remover.Location = new System.Drawing.Point(557, 288);
            this.btn_remover.Name = "btn_remover";
            this.btn_remover.Size = new System.Drawing.Size(90, 31);
            this.btn_remover.TabIndex = 54;
            this.btn_remover.Text = "Remover";
            this.btn_remover.UseVisualStyleBackColor = true;
            this.btn_remover.Click += new System.EventHandler(this.btn_remover_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 23);
            this.label8.TabIndex = 58;
            this.label8.Text = "Professor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 57;
            this.label4.Text = "Turno:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Navy;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(12, 171);
            this.textBox3.MaxLength = 0;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(443, 27);
            this.textBox3.TabIndex = 56;
            this.textBox3.Text = " Dados da Turma";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Escolar.Properties.Resources.fundo_branco;
            this.pictureBox2.Location = new System.Drawing.Point(12, 197);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(443, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 55;
            this.pictureBox2.TabStop = false;
            // 
            // lb_turno
            // 
            this.lb_turno.AutoSize = true;
            this.lb_turno.BackColor = System.Drawing.Color.White;
            this.lb_turno.Font = new System.Drawing.Font("Verdana", 12F);
            this.lb_turno.Location = new System.Drawing.Point(120, 206);
            this.lb_turno.Name = "lb_turno";
            this.lb_turno.Size = new System.Drawing.Size(61, 18);
            this.lb_turno.TabIndex = 59;
            this.lb_turno.Text = "?Turno";
            // 
            // lb_professor
            // 
            this.lb_professor.AutoSize = true;
            this.lb_professor.BackColor = System.Drawing.Color.White;
            this.lb_professor.Font = new System.Drawing.Font("Verdana", 12F);
            this.lb_professor.Location = new System.Drawing.Point(120, 231);
            this.lb_professor.Name = "lb_professor";
            this.lb_professor.Size = new System.Drawing.Size(93, 18);
            this.lb_professor.TabIndex = 60;
            this.lb_professor.Text = "?Professor";
            // 
            // cb_ano
            // 
            this.cb_ano.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ano.Font = new System.Drawing.Font("Verdana", 12.25F);
            this.cb_ano.FormattingEnabled = true;
            this.cb_ano.Location = new System.Drawing.Point(12, 133);
            this.cb_ano.Name = "cb_ano";
            this.cb_ano.Size = new System.Drawing.Size(99, 26);
            this.cb_ano.TabIndex = 102;
            this.cb_ano.SelectionChangeCommitted += new System.EventHandler(this.cb_ano_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.label2.Location = new System.Drawing.Point(9, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 103;
            this.label2.Text = "Ano Letivo";
            // 
            // btn_editar
            // 
            this.btn_editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_editar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.Location = new System.Drawing.Point(194, 133);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(76, 26);
            this.btn_editar.TabIndex = 104;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // AdicionarAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 345);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.cb_ano);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_professor);
            this.Controls.Add(this.lb_turno);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_remover);
            this.Controls.Add(this.btn_adicionar);
            this.Controls.Add(this.btn_nova_turma);
            this.Controls.Add(this.cb_turma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Aluno);
            this.Controls.Add(this.tb_nome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv_Turmas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdicionarAluno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão Turma";
            this.Load += new System.EventHandler(this.GestaoTurmas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Turmas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_Turmas;
        private System.Windows.Forms.Button btn_Aluno;
        public System.Windows.Forms.TextBox tb_nome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cb_turma;
        private System.Windows.Forms.Button btn_nova_turma;
        private System.Windows.Forms.Button btn_adicionar;
        private System.Windows.Forms.Button btn_remover;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lb_turno;
        private System.Windows.Forms.Label lb_professor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_aluno;
        private System.Windows.Forms.DataGridViewTextBoxColumn turma;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_aluno;
        private System.Windows.Forms.ComboBox cb_ano;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_editar;
    }
}