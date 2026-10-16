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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tb_pesquisa = new System.Windows.Forms.TextBox();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_SelecionarAluno = new System.Windows.Forms.DataGridView();
            this.cb_FiltrarData = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelecionarAluno)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_pesquisa
            // 
            this.tb_pesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tb_pesquisa.Location = new System.Drawing.Point(292, 11);
            this.tb_pesquisa.Name = "tb_pesquisa";
            this.tb_pesquisa.Size = new System.Drawing.Size(199, 21);
            this.tb_pesquisa.TabIndex = 19;
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pesquisar.Location = new System.Drawing.Point(564, 11);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nome";
            // 
            // dgv_SelecionarAluno
            // 
            this.dgv_SelecionarAluno.AllowUserToAddRows = false;
            this.dgv_SelecionarAluno.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SelecionarAluno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_SelecionarAluno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SelecionarAluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_SelecionarAluno.EnableHeadersVisualStyles = false;
            this.dgv_SelecionarAluno.Location = new System.Drawing.Point(3, 43);
            this.dgv_SelecionarAluno.MultiSelect = false;
            this.dgv_SelecionarAluno.Name = "dgv_SelecionarAluno";
            this.dgv_SelecionarAluno.ReadOnly = true;
            this.dgv_SelecionarAluno.RowHeadersVisible = false;
            this.dgv_SelecionarAluno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SelecionarAluno.Size = new System.Drawing.Size(871, 357);
            this.dgv_SelecionarAluno.TabIndex = 16;
            this.dgv_SelecionarAluno.DoubleClick += new System.EventHandler(this.dgv_SelecionarAluno_DoubleClick);
            // 
            // cb_FiltrarData
            // 
            this.cb_FiltrarData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FiltrarData.FormattingEnabled = true;
            this.cb_FiltrarData.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040",
            "2041",
            "2042",
            "2043",
            "2044",
            "2045",
            "2046",
            "2047",
            "2048",
            "2049",
            "2050",
            "2051",
            "2052",
            "2053",
            "2054",
            "2055",
            "2056",
            "2057",
            "2058",
            "2059",
            "2060",
            "2061",
            "2062",
            "2063",
            "2064",
            "2065",
            "2066",
            "2067",
            "2068",
            "2069",
            "2070",
            "2071",
            "2072",
            "2073",
            "2074",
            "2075",
            "2076",
            "2077",
            "2078",
            "2079",
            "2080"});
            this.cb_FiltrarData.Location = new System.Drawing.Point(497, 11);
            this.cb_FiltrarData.Name = "cb_FiltrarData";
            this.cb_FiltrarData.Size = new System.Drawing.Size(61, 21);
            this.cb_FiltrarData.TabIndex = 21;
            // 
            // F_ImprimirBoletim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 405);
            this.Controls.Add(this.cb_FiltrarData);
            this.Controls.Add(this.tb_pesquisa);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_SelecionarAluno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_ImprimirBoletim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Boletim";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelecionarAluno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_pesquisa;
        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_SelecionarAluno;
        private System.Windows.Forms.ComboBox cb_FiltrarData;
    }
}