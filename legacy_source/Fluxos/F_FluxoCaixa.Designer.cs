
namespace Escolar
{
    partial class F_Fluxo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Fluxo));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dbatenienseDataSet = new Escolar.dbatenienseDataSet();
            this.tbcaixa1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_caixa1TableAdapter = new Escolar.dbatenienseDataSetTableAdapters.tb_caixa1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dbatenienseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcaixa1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetCaixa";
            reportDataSource1.Value = this.tbcaixa1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Escolar.Relatorios.FluxoCaixa.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(417, 219);
            this.reportViewer1.TabIndex = 0;
            // 
            // dbatenienseDataSet
            // 
            this.dbatenienseDataSet.DataSetName = "dbatenienseDataSet";
            this.dbatenienseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbcaixa1BindingSource
            // 
            this.tbcaixa1BindingSource.DataMember = "tb_caixa1";
            this.tbcaixa1BindingSource.DataSource = this.dbatenienseDataSet;
            // 
            // tb_caixa1TableAdapter
            // 
            this.tb_caixa1TableAdapter.ClearBeforeFill = true;
            // 
            // F_Fluxo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 219);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_Fluxo";
            this.Text = "Fluxo Caixa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_Fluxo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbatenienseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcaixa1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbcaixa1BindingSource;
        private dbatenienseDataSet dbatenienseDataSet;
        private dbatenienseDataSetTableAdapters.tb_caixa1TableAdapter tb_caixa1TableAdapter;
    }
}