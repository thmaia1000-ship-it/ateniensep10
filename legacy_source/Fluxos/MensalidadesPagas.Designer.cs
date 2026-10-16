
namespace Escolar.Fluxos
{
    partial class MensalidadesPagas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensalidadesPagas));
            this.tbcaixaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbatenienseDataSet = new Escolar.dbatenienseDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_caixaTableAdapter = new Escolar.dbatenienseDataSetTableAdapters.tb_caixaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbcaixaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbatenienseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcaixaBindingSource
            // 
            this.tbcaixaBindingSource.DataMember = "tb_caixa";
            this.tbcaixaBindingSource.DataSource = this.dbatenienseDataSet;
            // 
            // dbatenienseDataSet
            // 
            this.dbatenienseDataSet.DataSetName = "dbatenienseDataSet";
            this.dbatenienseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetMensalidades";
            reportDataSource1.Value = this.tbcaixaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Escolar.Relatorios.MensalidadesPagas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(582, 347);
            this.reportViewer1.TabIndex = 0;
            // 
            // tb_caixaTableAdapter
            // 
            this.tb_caixaTableAdapter.ClearBeforeFill = true;
            // 
            // MensalidadesPagas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 347);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MensalidadesPagas";
            this.Text = "Mensalidades Pagas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MensalidadesPagas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbcaixaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbatenienseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbcaixaBindingSource;
        private dbatenienseDataSet dbatenienseDataSet;
        private dbatenienseDataSetTableAdapters.tb_caixaTableAdapter tb_caixaTableAdapter;
    }
}