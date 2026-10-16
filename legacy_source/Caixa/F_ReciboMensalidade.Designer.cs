namespace Escolar
{
    partial class F_ReciboMensalidade
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.parcelas_pagas = new System.Windows.Forms.Label();
            this.Imprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Escolar.Relatorios.ReciboAteniense.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(643, 415);
            this.reportViewer1.TabIndex = 0;
            // 
            // parcelas_pagas
            // 
            this.parcelas_pagas.AutoSize = true;
            this.parcelas_pagas.Location = new System.Drawing.Point(800, 334);
            this.parcelas_pagas.Name = "parcelas_pagas";
            this.parcelas_pagas.Size = new System.Drawing.Size(35, 13);
            this.parcelas_pagas.TabIndex = 1;
            this.parcelas_pagas.Text = "label1";
            // 
            // Imprimir
            // 
            this.Imprimir.Location = new System.Drawing.Point(765, 54);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(75, 23);
            this.Imprimir.TabIndex = 2;
            this.Imprimir.Text = "button1";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // F_ReciboMensalidade
            // 
            this.AcceptButton = this.Imprimir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 415);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.parcelas_pagas);
            this.Controls.Add(this.Imprimir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_ReciboMensalidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibo";
            this.Load += new System.EventHandler(this.F_ReciboMensalidade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.Label parcelas_pagas;
        private System.Windows.Forms.Button Imprimir;
    }
}