
namespace Escolar.Fluxos
{
    partial class FluxoProdutos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FluxoProdutos));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dbatenienseVendas = new Escolar.dbatenienseVendas();
            this.tbprodutosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_produtosTableAdapter = new Escolar.dbatenienseVendasTableAdapters.tb_produtosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dbatenienseVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbprodutosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Vendas";
            reportDataSource1.Value = this.tbprodutosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Escolar.Fluxos.Relatórios.FluxoProdutos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(433, 243);
            this.reportViewer1.TabIndex = 1;
            // 
            // dbatenienseVendas
            // 
            this.dbatenienseVendas.DataSetName = "dbatenienseVendas";
            this.dbatenienseVendas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbprodutosBindingSource
            // 
            this.tbprodutosBindingSource.DataMember = "tb_produtos";
            this.tbprodutosBindingSource.DataSource = this.dbatenienseVendas;
            // 
            // tb_produtosTableAdapter
            // 
            this.tb_produtosTableAdapter.ClearBeforeFill = true;
            // 
            // FluxoProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 243);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FluxoProdutos";
            this.Text = "Fluxo Vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FluxoProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbatenienseVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbprodutosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbprodutosBindingSource;
        private dbatenienseVendas dbatenienseVendas;
        private dbatenienseVendasTableAdapters.tb_produtosTableAdapter tb_produtosTableAdapter;
    }
}