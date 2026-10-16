namespace Escolar
{
    partial class F_GestaoTurmas
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
            this.dgv_turmas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_impTurma = new System.Windows.Forms.Button();
            this.btn_excluirTurma = new System.Windows.Forms.Button();
            this.btn_novaTurma = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.btn_salvarTurma = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.n_maxAlunos = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Status = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Turno = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_dscTurmas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_vagas = new System.Windows.Forms.TextBox();
            this.tb_Sala = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turmas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_maxAlunos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_turmas
            // 
            this.dgv_turmas.AllowUserToAddRows = false;
            this.dgv_turmas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_turmas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_turmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_turmas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_turmas.EnableHeadersVisualStyles = false;
            this.dgv_turmas.Location = new System.Drawing.Point(8, 12);
            this.dgv_turmas.MultiSelect = false;
            this.dgv_turmas.Name = "dgv_turmas";
            this.dgv_turmas.ReadOnly = true;
            this.dgv_turmas.RowHeadersVisible = false;
            this.dgv_turmas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_turmas.Size = new System.Drawing.Size(301, 334);
            this.dgv_turmas.TabIndex = 11;
            this.dgv_turmas.SelectionChanged += new System.EventHandler(this.dgv_turmas_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_impTurma);
            this.panel1.Controls.Add(this.btn_excluirTurma);
            this.panel1.Controls.Add(this.btn_novaTurma);
            this.panel1.Controls.Add(this.btn_fechar);
            this.panel1.Controls.Add(this.btn_salvarTurma);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 354);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 39);
            this.panel1.TabIndex = 12;
            // 
            // btn_impTurma
            // 
            this.btn_impTurma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_impTurma.Location = new System.Drawing.Point(321, 9);
            this.btn_impTurma.Name = "btn_impTurma";
            this.btn_impTurma.Size = new System.Drawing.Size(91, 23);
            this.btn_impTurma.TabIndex = 9;
            this.btn_impTurma.Text = "Imprimir";
            this.btn_impTurma.UseVisualStyleBackColor = true;
            this.btn_impTurma.Click += new System.EventHandler(this.btn_impTurma_Click);
            // 
            // btn_excluirTurma
            // 
            this.btn_excluirTurma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_excluirTurma.Location = new System.Drawing.Point(224, 9);
            this.btn_excluirTurma.Name = "btn_excluirTurma";
            this.btn_excluirTurma.Size = new System.Drawing.Size(91, 23);
            this.btn_excluirTurma.TabIndex = 8;
            this.btn_excluirTurma.Text = "Excluir Turma";
            this.btn_excluirTurma.UseVisualStyleBackColor = true;
            this.btn_excluirTurma.Click += new System.EventHandler(this.btn_excluirTurma_Click);
            // 
            // btn_novaTurma
            // 
            this.btn_novaTurma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_novaTurma.Location = new System.Drawing.Point(30, 9);
            this.btn_novaTurma.Name = "btn_novaTurma";
            this.btn_novaTurma.Size = new System.Drawing.Size(91, 23);
            this.btn_novaTurma.TabIndex = 4;
            this.btn_novaTurma.Text = "Nova Turma";
            this.btn_novaTurma.UseVisualStyleBackColor = true;
            this.btn_novaTurma.Click += new System.EventHandler(this.btn_novaTurma_Click);
            // 
            // btn_fechar
            // 
            this.btn_fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fechar.Location = new System.Drawing.Point(418, 9);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(91, 23);
            this.btn_fechar.TabIndex = 7;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // btn_salvarTurma
            // 
            this.btn_salvarTurma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salvarTurma.Location = new System.Drawing.Point(127, 9);
            this.btn_salvarTurma.Name = "btn_salvarTurma";
            this.btn_salvarTurma.Size = new System.Drawing.Size(91, 23);
            this.btn_salvarTurma.TabIndex = 6;
            this.btn_salvarTurma.Text = "Salvar Turma";
            this.btn_salvarTurma.UseVisualStyleBackColor = true;
            this.btn_salvarTurma.Click += new System.EventHandler(this.btn_salvarTurma_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sala";
            // 
            // n_maxAlunos
            // 
            this.n_maxAlunos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.n_maxAlunos.Location = new System.Drawing.Point(315, 149);
            this.n_maxAlunos.Name = "n_maxAlunos";
            this.n_maxAlunos.Size = new System.Drawing.Size(98, 20);
            this.n_maxAlunos.TabIndex = 2;
            this.n_maxAlunos.ValueChanged += new System.EventHandler(this.n_maxAlunos_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Máximo Alunos";
            // 
            // cb_Status
            // 
            this.cb_Status.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Status.FormattingEnabled = true;
            this.cb_Status.Location = new System.Drawing.Point(427, 148);
            this.cb_Status.Name = "cb_Status";
            this.cb_Status.Size = new System.Drawing.Size(99, 21);
            this.cb_Status.TabIndex = 3;
            this.cb_Status.SelectedIndexChanged += new System.EventHandler(this.cb_Status_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Status";
            // 
            // cb_Turno
            // 
            this.cb_Turno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Turno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Turno.FormattingEnabled = true;
            this.cb_Turno.Location = new System.Drawing.Point(315, 202);
            this.cb_Turno.Name = "cb_Turno";
            this.cb_Turno.Size = new System.Drawing.Size(211, 21);
            this.cb_Turno.TabIndex = 4;
            this.cb_Turno.SelectedIndexChanged += new System.EventHandler(this.cb_Horário_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Turno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Nome Turma";
            // 
            // tb_dscTurmas
            // 
            this.tb_dscTurmas.Location = new System.Drawing.Point(315, 46);
            this.tb_dscTurmas.Name = "tb_dscTurmas";
            this.tb_dscTurmas.Size = new System.Drawing.Size(211, 20);
            this.tb_dscTurmas.TabIndex = 0;
            this.tb_dscTurmas.SizeChanged += new System.EventHandler(this.tb_dscTurmas_SizeChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 230);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Vagas";
            // 
            // tb_vagas
            // 
            this.tb_vagas.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_vagas.Location = new System.Drawing.Point(315, 247);
            this.tb_vagas.Name = "tb_vagas";
            this.tb_vagas.ReadOnly = true;
            this.tb_vagas.Size = new System.Drawing.Size(211, 20);
            this.tb_vagas.TabIndex = 22;
            this.tb_vagas.TabStop = false;
            // 
            // tb_Sala
            // 
            this.tb_Sala.Location = new System.Drawing.Point(315, 94);
            this.tb_Sala.Name = "tb_Sala";
            this.tb_Sala.Size = new System.Drawing.Size(211, 20);
            this.tb_Sala.TabIndex = 23;
            // 
            // F_GestaoTurmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 393);
            this.Controls.Add(this.tb_vagas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_dscTurmas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_Turno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_Status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.n_maxAlunos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_turmas);
            this.Controls.Add(this.tb_Sala);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_GestaoTurmas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_GestaoTurmas";
            this.Load += new System.EventHandler(this.F_GestaoTurmas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turmas)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.n_maxAlunos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_turmas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_excluirTurma;
        private System.Windows.Forms.Button btn_novaTurma;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Button btn_salvarTurma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown n_maxAlunos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Turno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_dscTurmas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_vagas;
        private System.Windows.Forms.Button btn_impTurma;
        private System.Windows.Forms.TextBox tb_Sala;
    }
}