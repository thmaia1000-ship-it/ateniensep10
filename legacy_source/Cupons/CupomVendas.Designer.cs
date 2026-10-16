namespace Escolar.Caixa
{
    partial class CupomVendas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CupomVendas));
            this.tbvendasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbatenienseVendas = new Escolar.dbatenienseVendas();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_vendasTableAdapter = new Escolar.dbatenienseVendasTableAdapters.tb_vendasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbvendasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbatenienseVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // tbvendasBindingSource
            // 
            this.tbvendasBindingSource.DataMember = "tb_vendas";
            this.tbvendasBindingSource.DataSource = this.dbatenienseVendas;
            // 
            // dbatenienseVendas
            // 
            this.dbatenienseVendas.DataSetName = "dbatenienseVendas";
            this.dbatenienseVendas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Escolar.Cupons.reportviewer.CupomVenda.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(471, 286);
            this.reportViewer1.TabIndex = 0;
            // 
            // tb_vendasTableAdapter
            // 
            this.tb_vendasTableAdapter.ClearBeforeFill = true;
            // 
            // CupomVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 286);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CupomVendas";
            this.Text = "CUPOM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CupomVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbvendasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbatenienseVendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dbatenienseVendas dbatenienseVendas;
        private System.Windows.Forms.BindingSource tbvendasBindingSource;
        private dbatenienseVendasTableAdapters.tb_vendasTableAdapter tb_vendasTableAdapter;
    }
}