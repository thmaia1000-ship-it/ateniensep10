namespace Escolar
{
    partial class F_Caixa
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
            this.label3 = new System.Windows.Forms.Label();
            this.lb_obgAluno = new System.Windows.Forms.Label();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.tb_Aluno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_NParcelas = new System.Windows.Forms.ComboBox();
            this.gpb_Pagamento = new System.Windows.Forms.GroupBox();
            this.lb_RS = new System.Windows.Forms.Label();
            this.lb_SubTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ValorParcela = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_ValorPago = new System.Windows.Forms.Label();
            this.tb_nParcelasPendentes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Pagamento = new System.Windows.Forms.Button();
            this.gpb_InfoAdd = new System.Windows.Forms.GroupBox();
            this.tb_nParcelasPagas = new System.Windows.Forms.Label();
            this.lb_ResFinan = new System.Windows.Forms.Label();
            this.gpb_Pagamento.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gpb_InfoAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Aluno(a)";
            // 
            // lb_obgAluno
            // 
            this.lb_obgAluno.AutoSize = true;
            this.lb_obgAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_obgAluno.Location = new System.Drawing.Point(81, 9);
            this.lb_obgAluno.Name = "lb_obgAluno";
            this.lb_obgAluno.Size = new System.Drawing.Size(15, 20);
            this.lb_obgAluno.TabIndex = 89;
            this.lb_obgAluno.Text = "*";
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pesquisar.Location = new System.Drawing.Point(393, 25);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(32, 26);
            this.btn_Pesquisar.TabIndex = 92;
            this.btn_Pesquisar.Text = "...";
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // tb_Aluno
            // 
            this.tb_Aluno.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Aluno.Enabled = false;
            this.tb_Aluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Aluno.Location = new System.Drawing.Point(33, 25);
            this.tb_Aluno.Name = "tb_Aluno";
            this.tb_Aluno.ReadOnly = true;
            this.tb_Aluno.Size = new System.Drawing.Size(349, 26);
            this.tb_Aluno.TabIndex = 94;
            this.tb_Aluno.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F);
            this.label2.Location = new System.Drawing.Point(87, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 96;
            this.label2.Text = "SALDO DEVEDOR";
            // 
            // cb_NParcelas
            // 
            this.cb_NParcelas.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.cb_NParcelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_NParcelas.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_NParcelas.FormattingEnabled = true;
            this.cb_NParcelas.Items.AddRange(new object[] {
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
            this.cb_NParcelas.Location = new System.Drawing.Point(14, 141);
            this.cb_NParcelas.Name = "cb_NParcelas";
            this.cb_NParcelas.Size = new System.Drawing.Size(73, 24);
            this.cb_NParcelas.TabIndex = 100;
            this.cb_NParcelas.SelectionChangeCommitted += new System.EventHandler(this.cb_NParcelas_SelectionChangeCommitted);
            // 
            // gpb_Pagamento
            // 
            this.gpb_Pagamento.Controls.Add(this.lb_RS);
            this.gpb_Pagamento.Controls.Add(this.lb_SubTotal);
            this.gpb_Pagamento.Controls.Add(this.label1);
            this.gpb_Pagamento.Controls.Add(this.label4);
            this.gpb_Pagamento.Controls.Add(this.tb_ValorParcela);
            this.gpb_Pagamento.Controls.Add(this.label5);
            this.gpb_Pagamento.Controls.Add(this.cb_NParcelas);
            this.gpb_Pagamento.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.gpb_Pagamento.Location = new System.Drawing.Point(21, 66);
            this.gpb_Pagamento.Name = "gpb_Pagamento";
            this.gpb_Pagamento.Size = new System.Drawing.Size(352, 284);
            this.gpb_Pagamento.TabIndex = 105;
            this.gpb_Pagamento.TabStop = false;
            this.gpb_Pagamento.Text = "Dados Pagamento";
            // 
            // lb_RS
            // 
            this.lb_RS.AutoSize = true;
            this.lb_RS.Font = new System.Drawing.Font("Verdana", 33F, System.Drawing.FontStyle.Bold);
            this.lb_RS.ForeColor = System.Drawing.Color.Red;
            this.lb_RS.Location = new System.Drawing.Point(16, 215);
            this.lb_RS.Name = "lb_RS";
            this.lb_RS.Size = new System.Drawing.Size(88, 53);
            this.lb_RS.TabIndex = 108;
            this.lb_RS.Text = "R$";
            // 
            // lb_SubTotal
            // 
            this.lb_SubTotal.AutoSize = true;
            this.lb_SubTotal.Font = new System.Drawing.Font("Verdana", 33F, System.Drawing.FontStyle.Bold);
            this.lb_SubTotal.ForeColor = System.Drawing.Color.Red;
            this.lb_SubTotal.Location = new System.Drawing.Point(95, 215);
            this.lb_SubTotal.Name = "lb_SubTotal";
            this.lb_SubTotal.Size = new System.Drawing.Size(128, 53);
            this.lb_SubTotal.TabIndex = 104;
            this.lb_SubTotal.Text = "-----";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "QUANTIDADE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F);
            this.label4.Location = new System.Drawing.Point(17, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 103;
            this.label4.Text = "SUBTOTAL";
            // 
            // tb_ValorParcela
            // 
            this.tb_ValorParcela.AutoSize = true;
            this.tb_ValorParcela.Font = new System.Drawing.Font("Verdana", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ValorParcela.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_ValorParcela.Location = new System.Drawing.Point(18, 55);
            this.tb_ValorParcela.Name = "tb_ValorParcela";
            this.tb_ValorParcela.Size = new System.Drawing.Size(97, 40);
            this.tb_ValorParcela.TabIndex = 102;
            this.tb_ValorParcela.Text = "-----";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F);
            this.label5.Location = new System.Drawing.Point(9, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 17);
            this.label5.TabIndex = 99;
            this.label5.Text = "VALOR MENSALIDADE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10F);
            this.label7.Location = new System.Drawing.Point(75, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 17);
            this.label7.TabIndex = 101;
            this.label7.Text = "PARCELAS PENDENTES";
            // 
            // tb_ValorPago
            // 
            this.tb_ValorPago.AutoSize = true;
            this.tb_ValorPago.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.tb_ValorPago.ForeColor = System.Drawing.Color.MediumBlue;
            this.tb_ValorPago.Location = new System.Drawing.Point(73, 83);
            this.tb_ValorPago.Name = "tb_ValorPago";
            this.tb_ValorPago.Size = new System.Drawing.Size(73, 29);
            this.tb_ValorPago.TabIndex = 103;
            this.tb_ValorPago.Text = "-----";
            // 
            // tb_nParcelasPendentes
            // 
            this.tb_nParcelasPendentes.AutoSize = true;
            this.tb_nParcelasPendentes.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.tb_nParcelasPendentes.ForeColor = System.Drawing.Color.MediumBlue;
            this.tb_nParcelasPendentes.Location = new System.Drawing.Point(113, 177);
            this.tb_nParcelasPendentes.Name = "tb_nParcelasPendentes";
            this.tb_nParcelasPendentes.Size = new System.Drawing.Size(73, 29);
            this.tb_nParcelasPendentes.TabIndex = 104;
            this.tb_nParcelasPendentes.Text = "-----";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Cancelar);
            this.panel1.Controls.Add(this.btn_Pagamento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 368);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 66);
            this.panel1.TabIndex = 106;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Location = new System.Drawing.Point(165, 13);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_Cancelar.Size = new System.Drawing.Size(107, 41);
            this.btn_Cancelar.TabIndex = 101;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Pagamento
            // 
            this.btn_Pagamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pagamento.Location = new System.Drawing.Point(29, 13);
            this.btn_Pagamento.Name = "btn_Pagamento";
            this.btn_Pagamento.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_Pagamento.Size = new System.Drawing.Size(107, 41);
            this.btn_Pagamento.TabIndex = 100;
            this.btn_Pagamento.Text = "Pagamento";
            this.btn_Pagamento.UseVisualStyleBackColor = true;
            this.btn_Pagamento.Click += new System.EventHandler(this.btn_Pagamento_Click);
            // 
            // gpb_InfoAdd
            // 
            this.gpb_InfoAdd.Controls.Add(this.label2);
            this.gpb_InfoAdd.Controls.Add(this.tb_nParcelasPendentes);
            this.gpb_InfoAdd.Controls.Add(this.tb_ValorPago);
            this.gpb_InfoAdd.Controls.Add(this.label7);
            this.gpb_InfoAdd.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.gpb_InfoAdd.Location = new System.Drawing.Point(393, 66);
            this.gpb_InfoAdd.Name = "gpb_InfoAdd";
            this.gpb_InfoAdd.Size = new System.Drawing.Size(293, 284);
            this.gpb_InfoAdd.TabIndex = 106;
            this.gpb_InfoAdd.TabStop = false;
            this.gpb_InfoAdd.Text = "Informações Adicionais";
            // 
            // tb_nParcelasPagas
            // 
            this.tb_nParcelasPagas.AutoSize = true;
            this.tb_nParcelasPagas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tb_nParcelasPagas.ForeColor = System.Drawing.Color.MediumBlue;
            this.tb_nParcelasPagas.Location = new System.Drawing.Point(948, 207);
            this.tb_nParcelasPagas.Name = "tb_nParcelasPagas";
            this.tb_nParcelasPagas.Size = new System.Drawing.Size(27, 13);
            this.tb_nParcelasPagas.TabIndex = 106;
            this.tb_nParcelasPagas.Text = "-----";
            // 
            // lb_ResFinan
            // 
            this.lb_ResFinan.AutoSize = true;
            this.lb_ResFinan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ResFinan.ForeColor = System.Drawing.Color.Black;
            this.lb_ResFinan.Location = new System.Drawing.Point(948, 188);
            this.lb_ResFinan.Name = "lb_ResFinan";
            this.lb_ResFinan.Size = new System.Drawing.Size(19, 13);
            this.lb_ResFinan.TabIndex = 122;
            this.lb_ResFinan.Text = "---";
            // 
            // F_Caixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 434);
            this.Controls.Add(this.tb_nParcelasPagas);
            this.Controls.Add(this.lb_ResFinan);
            this.Controls.Add(this.gpb_InfoAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gpb_Pagamento);
            this.Controls.Add(this.tb_Aluno);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_obgAluno);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Caixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caixa";
            this.Load += new System.EventHandler(this.F_Caixa_Load);
            this.gpb_Pagamento.ResumeLayout(false);
            this.gpb_Pagamento.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gpb_InfoAdd.ResumeLayout(false);
            this.gpb_InfoAdd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lb_obgAluno;
        public System.Windows.Forms.TextBox tb_Aluno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.GroupBox gpb_Pagamento;
        public System.Windows.Forms.Label tb_ValorParcela;
        public System.Windows.Forms.Label tb_nParcelasPendentes;
        public System.Windows.Forms.Label tb_ValorPago;
        public System.Windows.Forms.Label lb_SubTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox cb_NParcelas;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox gpb_InfoAdd;
        private System.Windows.Forms.Button btn_Pagamento;
        public System.Windows.Forms.Label lb_RS;
        public System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Button btn_Cancelar;
        public System.Windows.Forms.Label lb_ResFinan;
        public System.Windows.Forms.Label tb_nParcelasPagas;
    }
}