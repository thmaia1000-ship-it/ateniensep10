
namespace Escolar.Caixa
{
    partial class F_Devolucao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Devolucao));
            this.tb_aluno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_BuscarAluno = new System.Windows.Forms.Button();
            this.dgv_Produto = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Devolucao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Produto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_aluno
            // 
            this.tb_aluno.Enabled = false;
            this.tb_aluno.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_aluno.Location = new System.Drawing.Point(12, 31);
            this.tb_aluno.Name = "tb_aluno";
            this.tb_aluno.Size = new System.Drawing.Size(427, 31);
            this.tb_aluno.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aluno(a)";
            // 
            // btn_BuscarAluno
            // 
            this.btn_BuscarAluno.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarAluno.Location = new System.Drawing.Point(445, 32);
            this.btn_BuscarAluno.Name = "btn_BuscarAluno";
            this.btn_BuscarAluno.Size = new System.Drawing.Size(47, 31);
            this.btn_BuscarAluno.TabIndex = 2;
            this.btn_BuscarAluno.Text = "...";
            this.btn_BuscarAluno.UseVisualStyleBackColor = true;
            this.btn_BuscarAluno.Click += new System.EventHandler(this.btn_BuscarAluno_Click);
            // 
            // dgv_Produto
            // 
            this.dgv_Produto.AllowUserToAddRows = false;
            this.dgv_Produto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Produto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Produto.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Produto.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Produto.EnableHeadersVisualStyles = false;
            this.dgv_Produto.Location = new System.Drawing.Point(12, 77);
            this.dgv_Produto.MultiSelect = false;
            this.dgv_Produto.Name = "dgv_Produto";
            this.dgv_Produto.ReadOnly = true;
            this.dgv_Produto.RowHeadersVisible = false;
            this.dgv_Produto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Produto.Size = new System.Drawing.Size(480, 258);
            this.dgv_Produto.TabIndex = 18;
            this.dgv_Produto.SelectionChanged += new System.EventHandler(this.dgv_Produto_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Devolucao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 352);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 74);
            this.panel1.TabIndex = 19;
            // 
            // btn_Devolucao
            // 
            this.btn_Devolucao.Location = new System.Drawing.Point(76, 16);
            this.btn_Devolucao.Name = "btn_Devolucao";
            this.btn_Devolucao.Size = new System.Drawing.Size(363, 46);
            this.btn_Devolucao.TabIndex = 0;
            this.btn_Devolucao.Text = "Devolver";
            this.btn_Devolucao.UseVisualStyleBackColor = true;
            this.btn_Devolucao.Click += new System.EventHandler(this.btn_Devolucao_Click);
            // 
            // F_Devolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 426);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_Produto);
            this.Controls.Add(this.btn_BuscarAluno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_aluno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_Devolucao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução";
            this.Load += new System.EventHandler(this.F_Devolucao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Produto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_BuscarAluno;
        public System.Windows.Forms.TextBox tb_aluno;
        public System.Windows.Forms.DataGridView dgv_Produto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Devolucao;
    }
}