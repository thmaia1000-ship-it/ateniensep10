
namespace Escolar.Notas
{
    partial class Gerar_Boletim
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gerar_Boletim));
            this.dgv_Notas = new System.Windows.Forms.DataGridView();
            this.conceito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_aluno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bimestre1 = new System.Windows.Forms.RadioButton();
            this.bimestre2 = new System.Windows.Forms.RadioButton();
            this.bimestre3 = new System.Windows.Forms.RadioButton();
            this.bimestre4 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_conceito = new System.Windows.Forms.ComboBox();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.lb_nota = new System.Windows.Forms.Label();
            this.tb_nota = new System.Windows.Forms.TextBox();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Notas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Notas
            // 
            this.dgv_Notas.AllowUserToAddRows = false;
            this.dgv_Notas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Notas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Notas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Notas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.conceito,
            this.materia,
            this.id});
            this.dgv_Notas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Notas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Notas.EnableHeadersVisualStyles = false;
            this.dgv_Notas.Location = new System.Drawing.Point(481, 12);
            this.dgv_Notas.MultiSelect = false;
            this.dgv_Notas.Name = "dgv_Notas";
            this.dgv_Notas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Notas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Notas.RowHeadersVisible = false;
            this.dgv_Notas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Notas.Size = new System.Drawing.Size(655, 363);
            this.dgv_Notas.TabIndex = 124;
            this.dgv_Notas.SelectionChanged += new System.EventHandler(this.dgv_Notas_SelectionChanged);
            // 
            // conceito
            // 
            this.conceito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.conceito.HeaderText = "Conceito";
            this.conceito.Name = "conceito";
            this.conceito.ReadOnly = true;
            this.conceito.Width = 150;
            // 
            // materia
            // 
            this.materia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.materia.HeaderText = "Matéria";
            this.materia.Name = "materia";
            this.materia.ReadOnly = true;
            this.materia.Width = 502;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // tb_aluno
            // 
            this.tb_aluno.Enabled = false;
            this.tb_aluno.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_aluno.Location = new System.Drawing.Point(12, 33);
            this.tb_aluno.Name = "tb_aluno";
            this.tb_aluno.Size = new System.Drawing.Size(424, 27);
            this.tb_aluno.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 126;
            this.label1.Text = "Aluno(a)";
            // 
            // bimestre1
            // 
            this.bimestre1.AutoSize = true;
            this.bimestre1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bimestre1.Location = new System.Drawing.Point(12, 66);
            this.bimestre1.Name = "bimestre1";
            this.bimestre1.Size = new System.Drawing.Size(107, 20);
            this.bimestre1.TabIndex = 128;
            this.bimestre1.TabStop = true;
            this.bimestre1.Text = "1º  Bimestre";
            this.bimestre1.UseVisualStyleBackColor = true;
            this.bimestre1.CheckedChanged += new System.EventHandler(this.bimestre1_CheckedChanged);
            // 
            // bimestre2
            // 
            this.bimestre2.AutoSize = true;
            this.bimestre2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.bimestre2.Location = new System.Drawing.Point(12, 92);
            this.bimestre2.Name = "bimestre2";
            this.bimestre2.Size = new System.Drawing.Size(107, 20);
            this.bimestre2.TabIndex = 129;
            this.bimestre2.TabStop = true;
            this.bimestre2.Text = "2º  Bimestre";
            this.bimestre2.UseVisualStyleBackColor = true;
            this.bimestre2.CheckedChanged += new System.EventHandler(this.bimestre2_CheckedChanged);
            // 
            // bimestre3
            // 
            this.bimestre3.AutoSize = true;
            this.bimestre3.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.bimestre3.Location = new System.Drawing.Point(12, 118);
            this.bimestre3.Name = "bimestre3";
            this.bimestre3.Size = new System.Drawing.Size(107, 20);
            this.bimestre3.TabIndex = 130;
            this.bimestre3.TabStop = true;
            this.bimestre3.Text = "3º  Bimestre";
            this.bimestre3.UseVisualStyleBackColor = true;
            this.bimestre3.CheckedChanged += new System.EventHandler(this.bimestre3_CheckedChanged);
            // 
            // bimestre4
            // 
            this.bimestre4.AutoSize = true;
            this.bimestre4.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.bimestre4.Location = new System.Drawing.Point(12, 144);
            this.bimestre4.Name = "bimestre4";
            this.bimestre4.Size = new System.Drawing.Size(107, 20);
            this.bimestre4.TabIndex = 131;
            this.bimestre4.TabStop = true;
            this.bimestre4.Text = "4º  Bimestre";
            this.bimestre4.UseVisualStyleBackColor = true;
            this.bimestre4.CheckedChanged += new System.EventHandler(this.bimestre4_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 135;
            this.label3.Text = "Conceito";
            // 
            // cb_conceito
            // 
            this.cb_conceito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_conceito.Font = new System.Drawing.Font("Verdana", 12F);
            this.cb_conceito.FormattingEnabled = true;
            this.cb_conceito.Location = new System.Drawing.Point(12, 203);
            this.cb_conceito.Name = "cb_conceito";
            this.cb_conceito.Size = new System.Drawing.Size(217, 26);
            this.cb_conceito.TabIndex = 136;
            // 
            // btn_Editar
            // 
            this.btn_Editar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Editar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Editar.Image")));
            this.btn_Editar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Editar.Location = new System.Drawing.Point(104, 324);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(139, 51);
            this.btn_Editar.TabIndex = 137;
            this.btn_Editar.Text = "    Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // lb_nota
            // 
            this.lb_nota.AutoSize = true;
            this.lb_nota.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nota.Location = new System.Drawing.Point(9, 246);
            this.lb_nota.Name = "lb_nota";
            this.lb_nota.Size = new System.Drawing.Size(50, 18);
            this.lb_nota.TabIndex = 156;
            this.lb_nota.Text = "Nota";
            // 
            // tb_nota
            // 
            this.tb_nota.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nota.Location = new System.Drawing.Point(12, 267);
            this.tb_nota.Name = "tb_nota";
            this.tb_nota.Size = new System.Drawing.Size(110, 27);
            this.tb_nota.TabIndex = 155;
            this.tb_nota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nota_KeyPress);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Enabled = false;
            this.btn_imprimir.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimir.Image = global::Escolar.Properties.Resources.impressora;
            this.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_imprimir.Location = new System.Drawing.Point(249, 324);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(139, 51);
            this.btn_imprimir.TabIndex = 138;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Image = global::Escolar.Properties.Resources.pesquisa_de_lupa;
            this.btn_buscar.Location = new System.Drawing.Point(442, 33);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(33, 27);
            this.btn_buscar.TabIndex = 127;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // Gerar_Boletim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 391);
            this.Controls.Add(this.lb_nota);
            this.Controls.Add(this.tb_nota);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.cb_conceito);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bimestre4);
            this.Controls.Add(this.bimestre3);
            this.Controls.Add(this.bimestre2);
            this.Controls.Add(this.bimestre1);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_aluno);
            this.Controls.Add(this.dgv_Notas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Gerar_Boletim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boletim";
            this.Load += new System.EventHandler(this.Lancar_Notas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Notas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_Notas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_buscar;
        public System.Windows.Forms.TextBox tb_aluno;
        private System.Windows.Forms.RadioButton bimestre1;
        private System.Windows.Forms.RadioButton bimestre2;
        private System.Windows.Forms.RadioButton bimestre3;
        private System.Windows.Forms.RadioButton bimestre4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_conceito;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn conceito;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        public System.Windows.Forms.Button btn_imprimir;
        public System.Windows.Forms.Label lb_nota;
        public System.Windows.Forms.TextBox tb_nota;
    }
}