
namespace Escolar.Gestão
{
    partial class DocumentosAluno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentosAluno));
            this.dgvContratos = new System.Windows.Forms.DataGridView();
            this.voltarButton = new System.Windows.Forms.Button();
            this.lbAno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.contratosADDButton = new System.Windows.Forms.Button();
            this.DocumentosADDButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContratos
            // 
            this.dgvContratos.AllowUserToAddRows = false;
            this.dgvContratos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContratos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvContratos.EnableHeadersVisualStyles = false;
            this.dgvContratos.Location = new System.Drawing.Point(12, 46);
            this.dgvContratos.MultiSelect = false;
            this.dgvContratos.Name = "dgvContratos";
            this.dgvContratos.ReadOnly = true;
            this.dgvContratos.RowHeadersVisible = false;
            this.dgvContratos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContratos.Size = new System.Drawing.Size(512, 309);
            this.dgvContratos.TabIndex = 27;
            this.dgvContratos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContratos_CellClick);
            this.dgvContratos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContratos_CellDoubleClick);
            this.dgvContratos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvContratos_CellPainting);
            // 
            // voltarButton
            // 
            this.voltarButton.Font = new System.Drawing.Font("Verdana", 13F);
            this.voltarButton.Location = new System.Drawing.Point(12, 361);
            this.voltarButton.Name = "voltarButton";
            this.voltarButton.Size = new System.Drawing.Size(74, 37);
            this.voltarButton.TabIndex = 29;
            this.voltarButton.Text = "Voltar";
            this.voltarButton.UseVisualStyleBackColor = true;
            this.voltarButton.Click += new System.EventHandler(this.voltarButton_Click);
            // 
            // lbAno
            // 
            this.lbAno.AutoSize = true;
            this.lbAno.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAno.Location = new System.Drawing.Point(8, 9);
            this.lbAno.Name = "lbAno";
            this.lbAno.Size = new System.Drawing.Size(102, 23);
            this.lbAno.TabIndex = 30;
            this.lbAno.Text = "Contratos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(540, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 32;
            this.label1.Text = "Documentos";
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocumentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.Location = new System.Drawing.Point(544, 46);
            this.dgvDocumentos.MultiSelect = false;
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.RowHeadersVisible = false;
            this.dgvDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocumentos.Size = new System.Drawing.Size(512, 309);
            this.dgvDocumentos.TabIndex = 31;
            this.dgvDocumentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellClick);
            this.dgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellDoubleClick);
            this.dgvDocumentos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDocumentos_CellPainting);
            // 
            // contratosADDButton
            // 
            this.contratosADDButton.Font = new System.Drawing.Font("Verdana", 13F);
            this.contratosADDButton.Location = new System.Drawing.Point(92, 361);
            this.contratosADDButton.Name = "contratosADDButton";
            this.contratosADDButton.Size = new System.Drawing.Size(107, 37);
            this.contratosADDButton.TabIndex = 33;
            this.contratosADDButton.Text = "Adicionar";
            this.contratosADDButton.UseVisualStyleBackColor = true;
            this.contratosADDButton.Click += new System.EventHandler(this.contratosADDButton_Click);
            // 
            // DocumentosADDButton
            // 
            this.DocumentosADDButton.Font = new System.Drawing.Font("Verdana", 13F);
            this.DocumentosADDButton.Location = new System.Drawing.Point(949, 361);
            this.DocumentosADDButton.Name = "DocumentosADDButton";
            this.DocumentosADDButton.Size = new System.Drawing.Size(107, 37);
            this.DocumentosADDButton.TabIndex = 34;
            this.DocumentosADDButton.Text = "Adicionar";
            this.DocumentosADDButton.UseVisualStyleBackColor = true;
            this.DocumentosADDButton.Click += new System.EventHandler(this.DocumentosADDButton_Click);
            // 
            // DocumentosAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 411);
            this.Controls.Add(this.DocumentosADDButton);
            this.Controls.Add(this.contratosADDButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDocumentos);
            this.Controls.Add(this.lbAno);
            this.Controls.Add(this.voltarButton);
            this.Controls.Add(this.dgvContratos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DocumentosAluno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentos";
            this.Load += new System.EventHandler(this.DocumentosAluno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContratos;
        private System.Windows.Forms.Button voltarButton;
        private System.Windows.Forms.Label lbAno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        private System.Windows.Forms.Button contratosADDButton;
        private System.Windows.Forms.Button DocumentosADDButton;
    }
}