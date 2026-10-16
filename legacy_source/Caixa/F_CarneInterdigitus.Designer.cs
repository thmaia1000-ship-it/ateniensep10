namespace Escolar.Caixa
{
    partial class F_CarneInterdigitus
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
            this.EnfermagemDigitus = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // EnfermagemDigitus
            // 
            this.EnfermagemDigitus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnfermagemDigitus.LocalReport.ReportEmbeddedResource = "Escolar.Relatorios.CarnêInterdigitus.rdlc";
            this.EnfermagemDigitus.Location = new System.Drawing.Point(0, 0);
            this.EnfermagemDigitus.Name = "EnfermagemDigitus";
            this.EnfermagemDigitus.ServerReport.BearerToken = null;
            this.EnfermagemDigitus.Size = new System.Drawing.Size(556, 301);
            this.EnfermagemDigitus.TabIndex = 0;
            // 
            // F_CarneInterdigitus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 301);
            this.Controls.Add(this.EnfermagemDigitus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_CarneInterdigitus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carnê";
            this.Load += new System.EventHandler(this.F_CarneInterdigitus_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer EnfermagemDigitus;
    }
}