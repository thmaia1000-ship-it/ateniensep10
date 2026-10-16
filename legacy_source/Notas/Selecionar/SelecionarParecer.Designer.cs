
namespace Escolar.Notas.Selecionar
{
    partial class SelecionarParecer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelecionarParecer));
            this.cb_turma = new System.Windows.Forms.ComboBox();
            this.cb_ano = new System.Windows.Forms.ComboBox();
            this.tb_pesquisa = new System.Windows.Forms.TextBox();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_SelecionarParecer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelecionarParecer)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_turma
            // 
            this.cb_turma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_turma.FormattingEnabled = true;
            this.cb_turma.Location = new System.Drawing.Point(479, 16);
            this.cb_turma.Name = "cb_turma";
            this.cb_turma.Size = new System.Drawing.Size(178, 21);
            this.cb_turma.TabIndex = 31;
            this.cb_turma.SelectionChangeCommitted += new System.EventHandler(this.cb_turma_SelectionChangeCommitted);
            // 
            // cb_ano
            // 
            this.cb_ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ano.FormattingEnabled = true;
            this.cb_ano.Location = new System.Drawing.Point(663, 16);
            this.cb_ano.Name = "cb_ano";
            this.cb_ano.Size = new System.Drawing.Size(74, 21);
            this.cb_ano.TabIndex = 30;
            this.cb_ano.SelectionChangeCommitted += new System.EventHandler(this.cb_ano_SelectionChangeCommitted);
            // 
            // tb_pesquisa
            // 
            this.tb_pesquisa.Location = new System.Drawing.Point(5, 17);
            this.tb_pesquisa.Name = "tb_pesquisa";
            this.tb_pesquisa.Size = new System.Drawing.Size(378, 20);
            this.tb_pesquisa.TabIndex = 29;
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pesquisar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pesquisar.Location = new System.Drawing.Point(389, 14);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(75, 23);
            this.btn_Pesquisar.TabIndex = 28;
            this.btn_Pesquisar.Text = "Buscar";
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nome";
            // 
            // dgv_SelecionarParecer
            // 
            this.dgv_SelecionarParecer.AllowUserToAddRows = false;
            this.dgv_SelecionarParecer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SelecionarParecer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_SelecionarParecer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SelecionarParecer.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SelecionarParecer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_SelecionarParecer.EnableHeadersVisualStyles = false;
            this.dgv_SelecionarParecer.Location = new System.Drawing.Point(5, 43);
            this.dgv_SelecionarParecer.MultiSelect = false;
            this.dgv_SelecionarParecer.Name = "dgv_SelecionarParecer";
            this.dgv_SelecionarParecer.ReadOnly = true;
            this.dgv_SelecionarParecer.RowHeadersVisible = false;
            this.dgv_SelecionarParecer.RowTemplate.Height = 30;
            this.dgv_SelecionarParecer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SelecionarParecer.Size = new System.Drawing.Size(732, 357);
            this.dgv_SelecionarParecer.TabIndex = 26;
            this.dgv_SelecionarParecer.DoubleClick += new System.EventHandler(this.dgv_SelecionarParecer_DoubleClick);
            // 
            // SelecionarParecer
            // 
            this.AcceptButton = this.btn_Pesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 400);
            this.Controls.Add(this.cb_turma);
            this.Controls.Add(this.cb_ano);
            this.Controls.Add(this.tb_pesquisa);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_SelecionarParecer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelecionarParecer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar";
            this.Load += new System.EventHandler(this.SelecionarParecer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelecionarParecer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_turma;
        private System.Windows.Forms.ComboBox cb_ano;
        private System.Windows.Forms.TextBox tb_pesquisa;
        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_SelecionarParecer;
    }
}