
namespace Escolar.Notas
{
    partial class Lancar_notas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lancar_notas));
            this.btn_lancar = new System.Windows.Forms.Button();
            this.cb_conceito = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_observacao = new System.Windows.Forms.TextBox();
            this.bimestre4 = new System.Windows.Forms.RadioButton();
            this.bimestre3 = new System.Windows.Forms.RadioButton();
            this.bimestre2 = new System.Windows.Forms.RadioButton();
            this.bimestre1 = new System.Windows.Forms.RadioButton();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_aluno = new System.Windows.Forms.TextBox();
            this.dgv_Notas = new System.Windows.Forms.DataGridView();
            this.conceito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_materia = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_professor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Notas)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_lancar
            // 
            this.btn_lancar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lancar.Location = new System.Drawing.Point(159, 435);
            this.btn_lancar.Name = "btn_lancar";
            this.btn_lancar.Size = new System.Drawing.Size(147, 51);
            this.btn_lancar.TabIndex = 151;
            this.btn_lancar.Text = "Lançar";
            this.btn_lancar.UseVisualStyleBackColor = true;
            this.btn_lancar.Click += new System.EventHandler(this.btn_lancar_Click);
            // 
            // cb_conceito
            // 
            this.cb_conceito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_conceito.Font = new System.Drawing.Font("Verdana", 12F);
            this.cb_conceito.FormattingEnabled = true;
            this.cb_conceito.Location = new System.Drawing.Point(9, 299);
            this.cb_conceito.Name = "cb_conceito";
            this.cb_conceito.Size = new System.Drawing.Size(217, 26);
            this.cb_conceito.TabIndex = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 149;
            this.label3.Text = "Conceito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 18);
            this.label2.TabIndex = 148;
            this.label2.Text = "Observação";
            // 
            // tb_observacao
            // 
            this.tb_observacao.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_observacao.Location = new System.Drawing.Point(9, 358);
            this.tb_observacao.Multiline = true;
            this.tb_observacao.Name = "tb_observacao";
            this.tb_observacao.Size = new System.Drawing.Size(463, 55);
            this.tb_observacao.TabIndex = 147;
            // 
            // bimestre4
            // 
            this.bimestre4.AutoSize = true;
            this.bimestre4.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.bimestre4.Location = new System.Drawing.Point(9, 139);
            this.bimestre4.Name = "bimestre4";
            this.bimestre4.Size = new System.Drawing.Size(107, 20);
            this.bimestre4.TabIndex = 146;
            this.bimestre4.TabStop = true;
            this.bimestre4.Text = "4º  Bimestre";
            this.bimestre4.UseVisualStyleBackColor = true;
            this.bimestre4.Click += new System.EventHandler(this.bimestre4_Click);
            // 
            // bimestre3
            // 
            this.bimestre3.AutoSize = true;
            this.bimestre3.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.bimestre3.Location = new System.Drawing.Point(9, 113);
            this.bimestre3.Name = "bimestre3";
            this.bimestre3.Size = new System.Drawing.Size(107, 20);
            this.bimestre3.TabIndex = 145;
            this.bimestre3.TabStop = true;
            this.bimestre3.Text = "3º  Bimestre";
            this.bimestre3.UseVisualStyleBackColor = true;
            this.bimestre3.Click += new System.EventHandler(this.bimestre3_Click);
            // 
            // bimestre2
            // 
            this.bimestre2.AutoSize = true;
            this.bimestre2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.bimestre2.Location = new System.Drawing.Point(9, 87);
            this.bimestre2.Name = "bimestre2";
            this.bimestre2.Size = new System.Drawing.Size(107, 20);
            this.bimestre2.TabIndex = 144;
            this.bimestre2.TabStop = true;
            this.bimestre2.Text = "2º  Bimestre";
            this.bimestre2.UseVisualStyleBackColor = true;
            this.bimestre2.Click += new System.EventHandler(this.bimestre2_Click);
            // 
            // bimestre1
            // 
            this.bimestre1.AutoSize = true;
            this.bimestre1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bimestre1.Location = new System.Drawing.Point(9, 61);
            this.bimestre1.Name = "bimestre1";
            this.bimestre1.Size = new System.Drawing.Size(107, 20);
            this.bimestre1.TabIndex = 143;
            this.bimestre1.TabStop = true;
            this.bimestre1.Text = "1º  Bimestre";
            this.bimestre1.UseVisualStyleBackColor = true;
            this.bimestre1.Click += new System.EventHandler(this.bimestre1_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(409, 28);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(63, 27);
            this.btn_buscar.TabIndex = 142;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 141;
            this.label1.Text = "Aluno(a)";
            // 
            // tb_aluno
            // 
            this.tb_aluno.Enabled = false;
            this.tb_aluno.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_aluno.Location = new System.Drawing.Point(9, 28);
            this.tb_aluno.Name = "tb_aluno";
            this.tb_aluno.Size = new System.Drawing.Size(394, 27);
            this.tb_aluno.TabIndex = 140;
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
            this.idmateria});
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
            this.dgv_Notas.Location = new System.Drawing.Point(478, 7);
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
            this.dgv_Notas.Size = new System.Drawing.Size(655, 479);
            this.dgv_Notas.TabIndex = 139;
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
            // idmateria
            // 
            this.idmateria.HeaderText = "idmateria";
            this.idmateria.Name = "idmateria";
            this.idmateria.ReadOnly = true;
            this.idmateria.Visible = false;
            // 
            // cb_materia
            // 
            this.cb_materia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_materia.Font = new System.Drawing.Font("Verdana", 12F);
            this.cb_materia.FormattingEnabled = true;
            this.cb_materia.Location = new System.Drawing.Point(9, 240);
            this.cb_materia.Name = "cb_materia";
            this.cb_materia.Size = new System.Drawing.Size(463, 26);
            this.cb_materia.TabIndex = 154;
            this.cb_materia.SelectionChangeCommitted += new System.EventHandler(this.cb_materia_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 153;
            this.label4.Text = "Matéria";
            // 
            // cb_professor
            // 
            this.cb_professor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_professor.Font = new System.Drawing.Font("Verdana", 12F);
            this.cb_professor.FormattingEnabled = true;
            this.cb_professor.Location = new System.Drawing.Point(9, 185);
            this.cb_professor.Name = "cb_professor";
            this.cb_professor.Size = new System.Drawing.Size(463, 26);
            this.cb_professor.TabIndex = 156;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 155;
            this.label5.Text = "Professor";
            // 
            // Lancar_notas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 498);
            this.Controls.Add(this.cb_professor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_materia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_lancar);
            this.Controls.Add(this.cb_conceito);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_observacao);
            this.Controls.Add(this.bimestre4);
            this.Controls.Add(this.bimestre3);
            this.Controls.Add(this.bimestre2);
            this.Controls.Add(this.bimestre1);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_aluno);
            this.Controls.Add(this.dgv_Notas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Lancar_notas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançar notas";
            this.Load += new System.EventHandler(this.Lancar_notas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Notas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tb_observacao;
        private System.Windows.Forms.RadioButton bimestre4;
        private System.Windows.Forms.RadioButton bimestre3;
        private System.Windows.Forms.RadioButton bimestre2;
        private System.Windows.Forms.RadioButton bimestre1;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tb_aluno;
        public System.Windows.Forms.DataGridView dgv_Notas;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cb_materia;
        public System.Windows.Forms.Button btn_lancar;
        private System.Windows.Forms.DataGridViewTextBoxColumn conceito;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmateria;
        public System.Windows.Forms.ComboBox cb_professor;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cb_conceito;
    }
}