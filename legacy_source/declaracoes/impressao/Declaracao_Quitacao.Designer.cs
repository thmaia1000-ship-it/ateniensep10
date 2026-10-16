
namespace Escolar.declaracoes
{
    partial class Declaracao_Quitacao
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Declaracao_Quitacao));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dbatenienseDataSet = new Escolar.dbatenienseDataSet();
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable1TableAdapter = new Escolar.dbatenienseDataSetTableAdapters.DataTable1TableAdapter();
            this.tbcaixa2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_caixa2TableAdapter = new Escolar.dbatenienseDataSetTableAdapters.tb_caixa2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dbatenienseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcaixa2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ValorPago";
            reportDataSource1.Value = this.dataTable1BindingSource;
            reportDataSource2.Name = "DatasPagas";
            reportDataSource2.Value = this.tbcaixa2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Escolar.Relatorios.quitacao.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(545, 337);
            this.reportViewer1.TabIndex = 0;
            // 
            // dbatenienseDataSet
            // 
            this.dbatenienseDataSet.DataSetName = "dbatenienseDataSet";
            this.dbatenienseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this.dbatenienseDataSet;
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // tbcaixa2BindingSource
            // 
            this.tbcaixa2BindingSource.DataMember = "tb_caixa2";
            this.tbcaixa2BindingSource.DataSource = this.dbatenienseDataSet;
            // 
            // tb_caixa2TableAdapter
            // 
            this.tb_caixa2TableAdapter.ClearBeforeFill = true;
            // 
            // Declaracao_Quitacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 337);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Declaracao_Quitacao";
            this.Text = "Declaração Quitação";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Declaracao_Quitacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbatenienseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcaixa2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private dbatenienseDataSet dbatenienseDataSet;
        private System.Windows.Forms.BindingSource tbcaixa2BindingSource;
        private dbatenienseDataSetTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private dbatenienseDataSetTableAdapters.tb_caixa2TableAdapter tb_caixa2TableAdapter;
    }
}