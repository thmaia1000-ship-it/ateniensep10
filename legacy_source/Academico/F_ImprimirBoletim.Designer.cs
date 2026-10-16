namespace Escolar
{
    partial class F_ImprimirBoletim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_ImprimirBoletim));
            this.tb_pesquisa = new System.Windows.Forms.TextBox();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_SelecionarAluno = new System.Windows.Forms.DataGridView();
            this.cb_FiltrarAno = new System.Windows.Forms.ComboBox();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelecionarAluno)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_pesquisa
            // 
            this.tb_pesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tb_pesquisa.Location = new System.Drawing.Point(3, 21);
            this.tb_pesquisa.Name = "tb_pesquisa";
            this.tb_pesquisa.Size = new System.Drawing.Size(299, 21);
            this.tb_pesquisa.TabIndex = 19;
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pesquisar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pesquisar.Location = new System.Drawing.Point(393, 21);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(75, 21);
            this.btn_Pesquisar.TabIndex = 18;
            this.btn_Pesquisar.Text = "Buscar";
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nome";
            // 
            // dgv_SelecionarAluno
            // 
            this.dgv_SelecionarAluno.AllowUserToAddRows = false;
            this.dgv_SelecionarAluno.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SelecionarAluno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_SelecionarAluno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SelecionarAluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_SelecionarAluno.EnableHeadersVisualStyles = false;
            this.dgv_SelecionarAluno.Location = new System.Drawing.Point(3, 49);
            this.dgv_SelecionarAluno.MultiSelect = false;
            this.dgv_SelecionarAluno.Name = "dgv_SelecionarAluno";
            this.dgv_SelecionarAluno.ReadOnly = true;
            this.dgv_SelecionarAluno.RowHeadersVisible = false;
            this.dgv_SelecionarAluno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SelecionarAluno.Size = new System.Drawing.Size(549, 357);
            this.dgv_SelecionarAluno.TabIndex = 16;
            this.dgv_SelecionarAluno.SelectionChanged += new System.EventHandler(this.dgv_SelecionarAluno_SelectionChanged);
            this.dgv_SelecionarAluno.DoubleClick += new System.EventHandler(this.dgv_SelecionarAluno_DoubleClick);
            // 
            // cb_FiltrarAno
            // 
            this.cb_FiltrarAno.AutoCompleteCustomSource.AddRange(new string[] {
            "1"});
            this.cb_FiltrarAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FiltrarAno.FormattingEnabled = true;
            this.cb_FiltrarAno.Location = new System.Drawing.Point(308, 22);
            this.cb_FiltrarAno.Name = "cb_FiltrarAno";
            this.cb_FiltrarAno.Size = new System.Drawing.Size(73, 21);
            this.cb_FiltrarAno.TabIndex = 21;
            this.cb_FiltrarAno.SelectionChangeCommitted += new System.EventHandler(this.cb_FiltrarCurso_SelectionChangeCommitted);
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Imprimir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Imprimir.Location = new System.Drawing.Point(471, 21);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(75, 21);
            this.btn_Imprimir.TabIndex = 22;
            this.btn_Imprimir.Text = "Imprimir";
            this.btn_Imprimir.UseVisualStyleBackColor = true;
            this.btn_Imprimir.Click += new System.EventHandler(this.btn_Imprimir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ano Letivo";
            // 
            // F_ImprimirBoletim
            // 
            this.AcceptButton = this.btn_Pesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 410);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Imprimir);
            this.Controls.Add(this.cb_FiltrarAno);
            this.Controls.Add(this.tb_pesquisa);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_SelecionarAluno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_ImprimirBoletim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Boletim";
            this.Load += new System.EventHandler(this.F_ImprimirBoletim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelecionarAluno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_pesquisa;
        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgv_SelecionarAluno;
        public System.Windows.Forms.ComboBox cb_FiltrarAno;
    }
}