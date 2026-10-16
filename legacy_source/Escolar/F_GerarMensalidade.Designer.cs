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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_GerarMensalidade));
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Aluno = new System.Windows.Forms.TextBox();
            this.lb_obgAluno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Parcelas = new System.Windows.Forms.DataGridView();
            this.ColNParcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValorParcelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_Valor = new System.Windows.Forms.TextBox();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dtp_Data = new System.Windows.Forms.DateTimePicker();
            this.cb_Parcelas = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.btn_Parcelas = new System.Windows.Forms.Button();
            this.tb_entrada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.lb_ObgValor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Parcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Aluno(a)";
            // 
            // tb_Aluno
            // 
            this.tb_Aluno.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Aluno.Enabled = false;
            this.tb_Aluno.Location = new System.Drawing.Point(15, 21);
            this.tb_Aluno.Name = "tb_Aluno";
            this.tb_Aluno.ReadOnly = true;
            this.tb_Aluno.Size = new System.Drawing.Size(260, 20);
            this.tb_Aluno.TabIndex = 69;
            this.tb_Aluno.Tag = "";
            // 
            // lb_obgAluno
            // 
            this.lb_obgAluno.AutoSize = true;
            this.lb_obgAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_obgAluno.Location = new System.Drawing.Point(63, 7);
            this.lb_obgAluno.Name = "lb_obgAluno";
            this.lb_obgAluno.Size = new System.Drawing.Size(15, 20);
            this.lb_obgAluno.TabIndex = 72;
            this.lb_obgAluno.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
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
            this.ColVencimento});
            this.dgv_Parcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_Parcelas.EnableHeadersVisualStyles = false;
            this.dgv_Parcelas.Location = new System.Drawing.Point(10, 131);
            this.dgv_Parcelas.MultiSelect = false;
            this.dgv_Parcelas.Name = "dgv_Parcelas";
            this.dgv_Parcelas.ReadOnly = true;
            this.dgv_Parcelas.RowHeadersVisible = false;
            this.dgv_Parcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Parcelas.Size = new System.Drawing.Size(287, 158);
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
            this.ColValorParcelado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.ColValorParcelado.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColValorParcelado.HeaderText = "Valor Parcelado";
            this.ColValorParcelado.Name = "ColValorParcelado";
            this.ColValorParcelado.ReadOnly = true;
            this.ColValorParcelado.Width = 98;
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
            // tb_Valor
            // 
            this.tb_Valor.Location = new System.Drawing.Point(15, 60);
            this.tb_Valor.Name = "tb_Valor";
            this.tb_Valor.Size = new System.Drawing.Size(74, 20);
            this.tb_Valor.TabIndex = 76;
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(206, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Parcelas";
            // 
            // dtp_Data
            // 
            this.dtp_Data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_Data.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Data.Location = new System.Drawing.Point(15, 99);
            this.dtp_Data.Name = "dtp_Data";
            this.dtp_Data.Size = new System.Drawing.Size(96, 20);
            this.dtp_Data.TabIndex = 80;
            // 
            // cb_Parcelas
            // 
            this.cb_Parcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Parcelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21"});
            this.cb_Parcelas.Location = new System.Drawing.Point(209, 60);
            this.cb_Parcelas.Name = "cb_Parcelas";
            this.cb_Parcelas.Size = new System.Drawing.Size(64, 21);
            this.cb_Parcelas.TabIndex = 85;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(274, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 86;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Cancelar);
            this.panel1.Controls.Add(this.btn_Salvar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 299);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 48);
            this.panel1.TabIndex = 87;
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Salvar.Location = new System.Drawing.Point(25, 6);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(116, 33);
            this.btn_Salvar.TabIndex = 89;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // btn_Parcelas
            // 
            this.btn_Parcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Parcelas.Location = new System.Drawing.Point(502, 163);
            this.btn_Parcelas.Name = "btn_Parcelas";
            this.btn_Parcelas.Size = new System.Drawing.Size(86, 23);
            this.btn_Parcelas.TabIndex = 88;
            this.btn_Parcelas.Text = "Gerar Parcelas";
            this.btn_Parcelas.UseVisualStyleBackColor = true;
            this.btn_Parcelas.Click += new System.EventHandler(this.btn_Parcelas_Click);
            // 
            // tb_entrada
            // 
            this.tb_entrada.Location = new System.Drawing.Point(110, 60);
            this.tb_entrada.Name = "tb_entrada";
            this.tb_entrada.Size = new System.Drawing.Size(73, 20);
            this.tb_entrada.TabIndex = 89;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label4.Location = new System.Drawing.Point(107, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Entrada";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Location = new System.Drawing.Point(159, 6);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(116, 33);
            this.btn_Cancelar.TabIndex = 90;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lb_ObgValor
            // 
            this.lb_ObgValor.AutoSize = true;
            this.lb_ObgValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_ObgValor.Location = new System.Drawing.Point(44, 44);
            this.lb_ObgValor.Name = "lb_ObgValor";
            this.lb_ObgValor.Size = new System.Drawing.Size(15, 20);
            this.lb_ObgValor.TabIndex = 90;
            this.lb_ObgValor.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label5.Location = new System.Drawing.Point(12, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 91;
            this.label5.Text = "A partir de:";
            // 
            // F_GerarMensalidade
            // 
            this.AcceptButton = this.btn_Parcelas;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 347);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_entrada);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Parcelas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cb_Parcelas);
            this.Controls.Add(this.dtp_Data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Valor);
            this.Controls.Add(this.dgv_Parcelas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Aluno);
            this.Controls.Add(this.lb_obgAluno);
            this.Controls.Add(this.lb_ObgValor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "F_GerarMensalidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Mensalidade";
            this.Load += new System.EventHandler(this.F_GerarMensalidade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Parcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_Aluno;
        public System.Windows.Forms.Label lb_obgAluno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Parcelas;
        private System.Windows.Forms.TextBox tb_Valor;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker dtp_Data;
        private System.Windows.Forms.ComboBox cb_Parcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNParcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValorParcelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVencimento;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btn_GerarParcelas;
        private System.Windows.Forms.Button btn_Parcelas;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.TextBox tb_entrada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Cancelar;
        public System.Windows.Forms.Label lb_ObgValor;
        private System.Windows.Forms.Label label5;
    }
}