namespace Escolar
{
    partial class F_GerarMensalidade
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_GerarMensalidade));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Parcelas = new System.Windows.Forms.DataGridView();
            this.ColNParcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValorParcelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaUtil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_Valor = new System.Windows.Forms.TextBox();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dtp_Data = new System.Windows.Forms.DateTimePicker();
            this.cb_Parcelas = new System.Windows.Forms.ComboBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.btn_Parcelas = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Aluno = new System.Windows.Forms.TextBox();
            this.tb_curso = new System.Windows.Forms.TextBox();
            this.cb_contrato = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_BuscarAluno = new System.Windows.Forms.Button();
            this.cb_turma = new System.Windows.Forms.ComboBox();
            this.cb_Turno = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_respFinan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Parcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(325, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 70;
            this.label3.Text = "Aluno(a)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(325, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 74;
            this.label1.Text = "Valor";
            // 
            // dgv_Parcelas
            // 
            this.dgv_Parcelas.AllowUserToAddRows = false;
            this.dgv_Parcelas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Parcelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Parcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Parcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNParcelas,
            this.ColValorParcelado,
            this.ColVencimento,
            this.DiaUtil});
            this.dgv_Parcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Parcelas.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Parcelas.EnableHeadersVisualStyles = false;
            this.dgv_Parcelas.Location = new System.Drawing.Point(12, 12);
            this.dgv_Parcelas.MultiSelect = false;
            this.dgv_Parcelas.Name = "dgv_Parcelas";
            this.dgv_Parcelas.ReadOnly = true;
            this.dgv_Parcelas.RowHeadersVisible = false;
            this.dgv_Parcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Parcelas.Size = new System.Drawing.Size(296, 386);
            this.dgv_Parcelas.TabIndex = 75;
            // 
            // ColNParcelas
            // 
            this.ColNParcelas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.NullValue = null;
            this.ColNParcelas.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColNParcelas.HeaderText = "N° Parcelas";
            this.ColNParcelas.Name = "ColNParcelas";
            this.ColNParcelas.ReadOnly = true;
            this.ColNParcelas.Width = 81;
            // 
            // ColValorParcelado
            // 
            this.ColValorParcelado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.ColValorParcelado.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColValorParcelado.HeaderText = "Valor Parcelado";
            this.ColValorParcelado.Name = "ColValorParcelado";
            this.ColValorParcelado.ReadOnly = true;
            this.ColValorParcelado.Width = 108;
            // 
            // ColVencimento
            // 
            this.ColVencimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.ColVencimento.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColVencimento.HeaderText = "Data Vencimento";
            this.ColVencimento.Name = "ColVencimento";
            this.ColVencimento.ReadOnly = true;
            this.ColVencimento.Width = 105;
            // 
            // DiaUtil
            // 
            this.DiaUtil.HeaderText = "Pagamento";
            this.DiaUtil.Name = "DiaUtil";
            this.DiaUtil.ReadOnly = true;
            // 
            // tb_Valor
            // 
            this.tb_Valor.Font = new System.Drawing.Font("Verdana", 10F);
            this.tb_Valor.Location = new System.Drawing.Point(328, 228);
            this.tb_Valor.Name = "tb_Valor";
            this.tb_Valor.Size = new System.Drawing.Size(206, 24);
            this.tb_Valor.TabIndex = 1;
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(547, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 78;
            this.label2.Text = "Parcelas";
            // 
            // dtp_Data
            // 
            this.dtp_Data.CalendarFont = new System.Drawing.Font("Verdana", 10F);
            this.dtp_Data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_Data.Font = new System.Drawing.Font("Verdana", 10F);
            this.dtp_Data.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Data.Location = new System.Drawing.Point(555, 127);
            this.dtp_Data.Name = "dtp_Data";
            this.dtp_Data.Size = new System.Drawing.Size(103, 24);
            this.dtp_Data.TabIndex = 4;
            this.dtp_Data.ValueChanged += new System.EventHandler(this.dtp_Data_ValueChanged);
            // 
            // cb_Parcelas
            // 
            this.cb_Parcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Parcelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Parcelas.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_Parcelas.FormattingEnabled = true;
            this.cb_Parcelas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cb_Parcelas.Location = new System.Drawing.Point(550, 228);
            this.cb_Parcelas.Name = "cb_Parcelas";
            this.cb_Parcelas.Size = new System.Drawing.Size(107, 24);
            this.cb_Parcelas.TabIndex = 3;
            this.cb_Parcelas.SelectionChangeCommitted += new System.EventHandler(this.cb_Parcelas_SelectionChangeCommitted);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btn_Cancelar.Location = new System.Drawing.Point(519, 352);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(133, 46);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Salvar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btn_Salvar.Location = new System.Drawing.Point(359, 352);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(133, 46);
            this.btn_Salvar.TabIndex = 6;
            this.btn_Salvar.Text = "Gerar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // btn_Parcelas
            // 
            this.btn_Parcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Parcelas.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Parcelas.Location = new System.Drawing.Point(328, 311);
            this.btn_Parcelas.Name = "btn_Parcelas";
            this.btn_Parcelas.Size = new System.Drawing.Size(104, 27);
            this.btn_Parcelas.TabIndex = 5;
            this.btn_Parcelas.Text = "Gerar Parcelas";
            this.btn_Parcelas.UseVisualStyleBackColor = true;
            this.btn_Parcelas.Click += new System.EventHandler(this.btn_Parcelas_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(554, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 91;
            this.label5.Text = "A partir de:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label6.Location = new System.Drawing.Point(747, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "Cursando";
            this.label6.Visible = false;
            // 
            // tb_Aluno
            // 
            this.tb_Aluno.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Aluno.Enabled = false;
            this.tb_Aluno.Font = new System.Drawing.Font("Verdana", 10F);
            this.tb_Aluno.Location = new System.Drawing.Point(328, 29);
            this.tb_Aluno.Name = "tb_Aluno";
            this.tb_Aluno.ReadOnly = true;
            this.tb_Aluno.Size = new System.Drawing.Size(291, 24);
            this.tb_Aluno.TabIndex = 69;
            this.tb_Aluno.Tag = "";
            // 
            // tb_curso
            // 
            this.tb_curso.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_curso.Enabled = false;
            this.tb_curso.Location = new System.Drawing.Point(750, 126);
            this.tb_curso.Name = "tb_curso";
            this.tb_curso.ReadOnly = true;
            this.tb_curso.Size = new System.Drawing.Size(24, 20);
            this.tb_curso.TabIndex = 93;
            this.tb_curso.Tag = "";
            this.tb_curso.Visible = false;
            // 
            // cb_contrato
            // 
            this.cb_contrato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_contrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_contrato.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_contrato.FormattingEnabled = true;
            this.cb_contrato.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cb_contrato.Location = new System.Drawing.Point(328, 127);
            this.cb_contrato.Name = "cb_contrato";
            this.cb_contrato.Size = new System.Drawing.Size(217, 24);
            this.cb_contrato.TabIndex = 96;
            this.cb_contrato.SelectionChangeCommitted += new System.EventHandler(this.cb_contrato_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(325, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 97;
            this.label7.Text = "Contrato";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(325, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 17);
            this.label9.TabIndex = 121;
            this.label9.Text = "Turma";
            // 
            // btn_BuscarAluno
            // 
            this.btn_BuscarAluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BuscarAluno.Font = new System.Drawing.Font("Verdana", 10F);
            this.btn_BuscarAluno.Location = new System.Drawing.Point(625, 29);
            this.btn_BuscarAluno.Name = "btn_BuscarAluno";
            this.btn_BuscarAluno.Size = new System.Drawing.Size(32, 24);
            this.btn_BuscarAluno.TabIndex = 0;
            this.btn_BuscarAluno.Text = "...";
            this.btn_BuscarAluno.UseVisualStyleBackColor = true;
            this.btn_BuscarAluno.Click += new System.EventHandler(this.btn_BuscarAluno_Click);
            // 
            // cb_turma
            // 
            this.cb_turma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_turma.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_turma.FormattingEnabled = true;
            this.cb_turma.Location = new System.Drawing.Point(328, 80);
            this.cb_turma.Name = "cb_turma";
            this.cb_turma.Size = new System.Drawing.Size(329, 24);
            this.cb_turma.TabIndex = 122;
            // 
            // cb_Turno
            // 
            this.cb_Turno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Turno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Turno.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_Turno.FormattingEnabled = true;
            this.cb_Turno.Location = new System.Drawing.Point(328, 174);
            this.cb_Turno.Name = "cb_Turno";
            this.cb_Turno.Size = new System.Drawing.Size(329, 24);
            this.cb_Turno.TabIndex = 123;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(325, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 17);
            this.label10.TabIndex = 124;
            this.label10.Text = "Turno";
            // 
            // cb_respFinan
            // 
            this.cb_respFinan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_respFinan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_respFinan.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_respFinan.FormattingEnabled = true;
            this.cb_respFinan.Location = new System.Drawing.Point(328, 281);
            this.cb_respFinan.Name = "cb_respFinan";
            this.cb_respFinan.Size = new System.Drawing.Size(329, 24);
            this.cb_respFinan.TabIndex = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(325, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 17);
            this.label4.TabIndex = 126;
            this.label4.Text = "Resp. Financeiro";
            // 
            // F_GerarMensalidade
            // 
            this.AcceptButton = this.btn_Parcelas;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 409);
            this.Controls.Add(this.cb_respFinan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_Turno);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_turma);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Salvar);
            this.Controls.Add(this.cb_contrato);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_BuscarAluno);
            this.Controls.Add(this.tb_curso);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Parcelas);
            this.Controls.Add(this.cb_Parcelas);
            this.Controls.Add(this.dtp_Data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Valor);
            this.Controls.Add(this.dgv_Parcelas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Aluno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_GerarMensalidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Mensalidade";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.F_GerarMensalidade_FormClosed);
            this.Load += new System.EventHandler(this.F_GerarMensalidade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Parcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Parcelas;
        private System.Windows.Forms.TextBox tb_Valor;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker dtp_Data;
        private System.Windows.Forms.ComboBox cb_Parcelas;
        //private System.Windows.Forms.PictureBox btn_GerarParcelas;
        private System.Windows.Forms.Button btn_Parcelas;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox tb_Aluno;
        public System.Windows.Forms.TextBox tb_curso;
        private System.Windows.Forms.ComboBox cb_contrato;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNParcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValorParcelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaUtil;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_BuscarAluno;
        public System.Windows.Forms.ComboBox cb_turma;
        private System.Windows.Forms.ComboBox cb_Turno;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cb_respFinan;
        private System.Windows.Forms.Label label4;
    }
}