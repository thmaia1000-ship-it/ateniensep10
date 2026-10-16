namespace Escolar
{
    partial class F_FormaPagamento
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
            this.lb_FormaPagamento = new System.Windows.Forms.Label();
            this.tb_Valor = new System.Windows.Forms.TextBox();
            this.btn_Dinheiro = new System.Windows.Forms.Button();
            this.gpb_FormaPag = new System.Windows.Forms.GroupBox();
            this.tb_Troco = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_Total = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Desconto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_Rs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Pix = new System.Windows.Forms.Button();
            this.btn_Debito = new System.Windows.Forms.Button();
            this.btn_Calc = new System.Windows.Forms.Button();
            this.btn_Credito = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Imprimir = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.lb_nomeUsuario = new System.Windows.Forms.Label();
            this.gpb_FormaPag.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_FormaPagamento
            // 
            this.lb_FormaPagamento.AutoSize = true;
            this.lb_FormaPagamento.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_FormaPagamento.Location = new System.Drawing.Point(7, 17);
            this.lb_FormaPagamento.Name = "lb_FormaPagamento";
            this.lb_FormaPagamento.Size = new System.Drawing.Size(77, 14);
            this.lb_FormaPagamento.TabIndex = 0;
            this.lb_FormaPagamento.Text = "DINHEIRO";
            // 
            // tb_Valor
            // 
            this.tb_Valor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Valor.Font = new System.Drawing.Font("Verdana", 24.75F, System.Drawing.FontStyle.Bold);
            this.tb_Valor.Location = new System.Drawing.Point(54, 62);
            this.tb_Valor.Name = "tb_Valor";
            this.tb_Valor.Size = new System.Drawing.Size(170, 41);
            this.tb_Valor.TabIndex = 1;
            this.tb_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Dinheiro
            // 
            this.btn_Dinheiro.Location = new System.Drawing.Point(54, 12);
            this.btn_Dinheiro.Name = "btn_Dinheiro";
            this.btn_Dinheiro.Size = new System.Drawing.Size(75, 23);
            this.btn_Dinheiro.TabIndex = 2;
            this.btn_Dinheiro.Text = "DINHEIRO";
            this.btn_Dinheiro.UseVisualStyleBackColor = true;
            this.btn_Dinheiro.Click += new System.EventHandler(this.btn_Dinheiro_Click);
            // 
            // gpb_FormaPag
            // 
            this.gpb_FormaPag.Controls.Add(this.tb_Troco);
            this.gpb_FormaPag.Controls.Add(this.label3);
            this.gpb_FormaPag.Controls.Add(this.lb_Total);
            this.gpb_FormaPag.Controls.Add(this.label6);
            this.gpb_FormaPag.Controls.Add(this.label4);
            this.gpb_FormaPag.Controls.Add(this.tb_Desconto);
            this.gpb_FormaPag.Controls.Add(this.label2);
            this.gpb_FormaPag.Controls.Add(this.lb_FormaPagamento);
            this.gpb_FormaPag.Controls.Add(this.tb_Valor);
            this.gpb_FormaPag.Controls.Add(this.label7);
            this.gpb_FormaPag.Controls.Add(this.label5);
            this.gpb_FormaPag.Controls.Add(this.lb_Rs);
            this.gpb_FormaPag.Controls.Add(this.label1);
            this.gpb_FormaPag.Location = new System.Drawing.Point(2, 47);
            this.gpb_FormaPag.Name = "gpb_FormaPag";
            this.gpb_FormaPag.Size = new System.Drawing.Size(489, 230);
            this.gpb_FormaPag.TabIndex = 3;
            this.gpb_FormaPag.TabStop = false;
            this.gpb_FormaPag.Text = "Forma de Pagamento";
            // 
            // tb_Troco
            // 
            this.tb_Troco.AutoSize = true;
            this.tb_Troco.BackColor = System.Drawing.Color.Teal;
            this.tb_Troco.Font = new System.Drawing.Font("Verdana", 23F, System.Drawing.FontStyle.Bold);
            this.tb_Troco.ForeColor = System.Drawing.Color.White;
            this.tb_Troco.Location = new System.Drawing.Point(69, 162);
            this.tb_Troco.Name = "tb_Troco";
            this.tb_Troco.Size = new System.Drawing.Size(92, 38);
            this.tb_Troco.TabIndex = 115;
            this.tb_Troco.Text = "-----";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.Location = new System.Drawing.Point(244, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 111;
            this.label3.Text = "TOTAL";
            // 
            // lb_Total
            // 
            this.lb_Total.AutoSize = true;
            this.lb_Total.Font = new System.Drawing.Font("Verdana", 23F, System.Drawing.FontStyle.Bold);
            this.lb_Total.ForeColor = System.Drawing.Color.Red;
            this.lb_Total.Location = new System.Drawing.Point(314, 162);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(92, 38);
            this.lb_Total.TabIndex = 109;
            this.lb_Total.Text = "-----";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F);
            this.label6.Location = new System.Drawing.Point(335, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Desconto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F);
            this.label4.Location = new System.Drawing.Point(75, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Troco ao cliente:";
            // 
            // tb_Desconto
            // 
            this.tb_Desconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Desconto.Font = new System.Drawing.Font("Verdana", 24.75F, System.Drawing.FontStyle.Bold);
            this.tb_Desconto.Location = new System.Drawing.Point(307, 62);
            this.tb_Desconto.Name = "tb_Desconto";
            this.tb_Desconto.Size = new System.Drawing.Size(126, 41);
            this.tb_Desconto.TabIndex = 4;
            this.tb_Desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Desconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Desconto_KeyPress);
            this.tb_Desconto.Leave += new System.EventHandler(this.tb_Desconto_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F);
            this.label2.Location = new System.Drawing.Point(97, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor Pago";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(9, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 23);
            this.label7.TabIndex = 113;
            this.label7.Text = "R$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(264, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 23);
            this.label5.TabIndex = 112;
            this.label5.Text = "R$";
            // 
            // lb_Rs
            // 
            this.lb_Rs.AutoSize = true;
            this.lb_Rs.Font = new System.Drawing.Font("Verdana", 23F, System.Drawing.FontStyle.Bold);
            this.lb_Rs.ForeColor = System.Drawing.Color.Red;
            this.lb_Rs.Location = new System.Drawing.Point(255, 162);
            this.lb_Rs.Name = "lb_Rs";
            this.lb_Rs.Size = new System.Drawing.Size(63, 38);
            this.lb_Rs.TabIndex = 116;
            this.lb_Rs.Text = "R$";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("Verdana", 23F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 38);
            this.label1.TabIndex = 117;
            this.label1.Text = "R$";
            // 
            // btn_Pix
            // 
            this.btn_Pix.Location = new System.Drawing.Point(151, 12);
            this.btn_Pix.Name = "btn_Pix";
            this.btn_Pix.Size = new System.Drawing.Size(75, 23);
            this.btn_Pix.TabIndex = 4;
            this.btn_Pix.Text = "PIX";
            this.btn_Pix.UseVisualStyleBackColor = true;
            this.btn_Pix.Click += new System.EventHandler(this.btn_Pix_Click);
            // 
            // btn_Debito
            // 
            this.btn_Debito.Location = new System.Drawing.Point(245, 12);
            this.btn_Debito.Name = "btn_Debito";
            this.btn_Debito.Size = new System.Drawing.Size(75, 23);
            this.btn_Debito.TabIndex = 5;
            this.btn_Debito.Text = "DÉBITO";
            this.btn_Debito.UseVisualStyleBackColor = true;
            this.btn_Debito.Click += new System.EventHandler(this.btn_Debito_Click);
            // 
            // btn_Calc
            // 
            this.btn_Calc.Location = new System.Drawing.Point(678, 132);
            this.btn_Calc.Name = "btn_Calc";
            this.btn_Calc.Size = new System.Drawing.Size(75, 23);
            this.btn_Calc.TabIndex = 0;
            this.btn_Calc.Text = "Calcular";
            this.btn_Calc.UseVisualStyleBackColor = true;
            this.btn_Calc.Click += new System.EventHandler(this.btn_Calc_Click);
            // 
            // btn_Credito
            // 
            this.btn_Credito.Location = new System.Drawing.Point(354, 12);
            this.btn_Credito.Name = "btn_Credito";
            this.btn_Credito.Size = new System.Drawing.Size(75, 23);
            this.btn_Credito.TabIndex = 7;
            this.btn_Credito.Text = "CRÉDITO";
            this.btn_Credito.UseVisualStyleBackColor = true;
            this.btn_Credito.Click += new System.EventHandler(this.btn_Credito_Click);
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Salvar.Location = new System.Drawing.Point(17, 3);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_Salvar.Size = new System.Drawing.Size(170, 41);
            this.btn_Salvar.TabIndex = 117;
            this.btn_Salvar.Text = "Receber";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Imprimir);
            this.panel1.Controls.Add(this.btn_Cancelar);
            this.panel1.Controls.Add(this.btn_Salvar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 291);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 50);
            this.panel1.TabIndex = 8;
            // 
            // Imprimir
            // 
            this.Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Imprimir.Location = new System.Drawing.Point(369, 3);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Imprimir.Size = new System.Drawing.Size(108, 41);
            this.Imprimir.TabIndex = 119;
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Location = new System.Drawing.Point(193, 3);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_Cancelar.Size = new System.Drawing.Size(170, 41);
            this.btn_Cancelar.TabIndex = 118;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lb_nomeUsuario
            // 
            this.lb_nomeUsuario.AutoSize = true;
            this.lb_nomeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nomeUsuario.ForeColor = System.Drawing.Color.Black;
            this.lb_nomeUsuario.Location = new System.Drawing.Point(717, 158);
            this.lb_nomeUsuario.Name = "lb_nomeUsuario";
            this.lb_nomeUsuario.Size = new System.Drawing.Size(19, 13);
            this.lb_nomeUsuario.TabIndex = 120;
            this.lb_nomeUsuario.Text = "---";
            // 
            // F_FormaPagamento
            // 
            this.AcceptButton = this.btn_Calc;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 341);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Credito);
            this.Controls.Add(this.lb_nomeUsuario);
            this.Controls.Add(this.btn_Calc);
            this.Controls.Add(this.btn_Debito);
            this.Controls.Add(this.btn_Pix);
            this.Controls.Add(this.gpb_FormaPag);
            this.Controls.Add(this.btn_Dinheiro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_FormaPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forma de Pagamento";
            this.Load += new System.EventHandler(this.F_FormaPagamento_Load);
            this.gpb_FormaPag.ResumeLayout(false);
            this.gpb_FormaPag.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Dinheiro;
        private System.Windows.Forms.GroupBox gpb_FormaPag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Pix;
        private System.Windows.Forms.Button btn_Debito;
        private System.Windows.Forms.Button btn_Calc;
        public System.Windows.Forms.TextBox tb_Valor;
        public System.Windows.Forms.TextBox tb_Desconto;
        public System.Windows.Forms.Label lb_Total;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Credito;
        public System.Windows.Forms.Label tb_Troco;
        public System.Windows.Forms.Label lb_Rs;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancelar;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lb_nomeUsuario;
        private System.Windows.Forms.Button Imprimir;
        public System.Windows.Forms.Label lb_FormaPagamento;
    }
}