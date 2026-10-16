namespace Escolar
{
    partial class F_ReciboInterdigitus
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
            this.lb_vencimento = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.n_parcelas = new System.Windows.Forms.Label();
            this.lb_SaldoDevedor = new System.Windows.Forms.Label();
            this.lb_mes = new System.Windows.Forms.Label();
            this.lb_Anovencimento = new System.Windows.Forms.Label();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_vencimento
            // 
            this.lb_vencimento.AutoSize = true;
            this.lb_vencimento.Location = new System.Drawing.Point(809, 114);
            this.lb_vencimento.Name = "lb_vencimento";
            this.lb_vencimento.Size = new System.Drawing.Size(35, 13);
            this.lb_vencimento.TabIndex = 0;
            this.lb_vencimento.Text = "label1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Escolar.Relatorios.ReciboDigitus.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(393, 297);
            this.reportViewer1.TabIndex = 1;
            // 
            // n_parcelas
            // 
            this.n_parcelas.AutoSize = true;
            this.n_parcelas.Location = new System.Drawing.Point(809, 155);
            this.n_parcelas.Name = "n_parcelas";
            this.n_parcelas.Size = new System.Drawing.Size(35, 13);
            this.n_parcelas.TabIndex = 2;
            this.n_parcelas.Text = "label1";
            // 
            // lb_SaldoDevedor
            // 
            this.lb_SaldoDevedor.AutoSize = true;
            this.lb_SaldoDevedor.Location = new System.Drawing.Point(809, 191);
            this.lb_SaldoDevedor.Name = "lb_SaldoDevedor";
            this.lb_SaldoDevedor.Size = new System.Drawing.Size(35, 13);
            this.lb_SaldoDevedor.TabIndex = 3;
            this.lb_SaldoDevedor.Text = "label1";
            // 
            // lb_mes
            // 
            this.lb_mes.AutoSize = true;
            this.lb_mes.Location = new System.Drawing.Point(809, 224);
            this.lb_mes.Name = "lb_mes";
            this.lb_mes.Size = new System.Drawing.Size(35, 13);
            this.lb_mes.TabIndex = 4;
            this.lb_mes.Text = "label1";
            // 
            // lb_Anovencimento
            // 
            this.lb_Anovencimento.AutoSize = true;
            this.lb_Anovencimento.Location = new System.Drawing.Point(809, 252);
            this.lb_Anovencimento.Name = "lb_Anovencimento";
            this.lb_Anovencimento.Size = new System.Drawing.Size(35, 13);
            this.lb_Anovencimento.TabIndex = 5;
            this.lb_Anovencimento.Text = "label1";
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.Location = new System.Drawing.Point(796, 69);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(75, 23);
            this.btn_Imprimir.TabIndex = 6;
            this.btn_Imprimir.Text = "button1";
            this.btn_Imprimir.UseVisualStyleBackColor = true;
            this.btn_Imprimir.Click += new System.EventHandler(this.btn_Imprimir_Click);
            // 
            // F_ReciboInterdigitus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(393, 297);
            this.Controls.Add(this.btn_Imprimir);
            this.Controls.Add(this.lb_Anovencimento);
            this.Controls.Add(this.lb_mes);
            this.Controls.Add(this.lb_SaldoDevedor);
            this.Controls.Add(this.n_parcelas);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.lb_vencimento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_ReciboInterdigitus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibo";
            this.Load += new System.EventHandler(this.F_ReciboInterdigitus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_vencimento;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label n_parcelas;
        private System.Windows.Forms.Label lb_SaldoDevedor;
        private System.Windows.Forms.Label lb_mes;
        private System.Windows.Forms.Label lb_Anovencimento;
        private System.Windows.Forms.Button btn_Imprimir;
    }
}