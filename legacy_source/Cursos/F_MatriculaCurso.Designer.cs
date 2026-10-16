
namespace Escolar.Cadastros
{
    partial class F_MatriculaCurso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_MatriculaCurso));
            this.cb_ano = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_BuscarAluno = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Parcelas = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.cb_Parcelas = new System.Windows.Forms.ComboBox();
            this.dtp_Data = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Valor = new System.Windows.Forms.TextBox();
            this.dgv_Parcelas = new System.Windows.Forms.DataGridView();
            this.ColNParcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValorParcelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaUtil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Aluno = new System.Windows.Forms.TextBox();
            this.lb_obgAluno = new System.Windows.Forms.Label();
            this.lb_ObgValor = new System.Windows.Forms.Label();
            this.cb_curso = new System.Windows.Forms.ComboBox();
            this.cb_respFinan = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Parcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_ano
            // 
            this.cb_ano.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ano.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_ano.FormattingEnabled = true;
            this.cb_ano.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cb_ano.Location = new System.Drawing.Point(565, 130);
            this.cb_ano.Name = "cb_ano";
            this.cb_ano.Size = new System.Drawing.Size(99, 24);
            this.cb_ano.TabIndex = 112;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(562, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 113;
            this.label4.Text = "Ano Letivo";
            // 
            // btn_BuscarAluno
            // 
            this.btn_BuscarAluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BuscarAluno.Font = new System.Drawing.Font("Verdana", 10F);
            this.btn_BuscarAluno.Location = new System.Drawing.Point(638, 33);
            this.btn_BuscarAluno.Name = "btn_BuscarAluno";
            this.btn_BuscarAluno.Size = new System.Drawing.Size(26, 23);
            this.btn_BuscarAluno.TabIndex = 96;
            this.btn_BuscarAluno.Text = "...";
            this.btn_BuscarAluno.UseVisualStyleBackColor = true;
            this.btn_BuscarAluno.Click += new System.EventHandler(this.btn_BuscarAluno_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(303, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 110;
            this.label6.Text = "Cursando";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(533, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 109;
            this.label5.Text = "A partir de:";
            // 
            // btn_Parcelas
            // 
            this.btn_Parcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Parcelas.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Parcelas.Location = new System.Drawing.Point(306, 209);
            this.btn_Parcelas.Name = "btn_Parcelas";
            this.btn_Parcelas.Size = new System.Drawing.Size(101, 23);
            this.btn_Parcelas.TabIndex = 100;
            this.btn_Parcelas.Text = "Gerar Parcelas";
            this.btn_Parcelas.UseVisualStyleBackColor = true;
            this.btn_Parcelas.Click += new System.EventHandler(this.btn_Parcelas_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(511, 260);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(142, 39);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Salvar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Salvar.Location = new System.Drawing.Point(352, 260);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(142, 39);
            this.btn_Salvar.TabIndex = 6;
            this.btn_Salvar.Text = "Gerar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // cb_Parcelas
            // 
            this.cb_Parcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Parcelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Parcelas.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_Parcelas.FormattingEnabled = true;
            this.cb_Parcelas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cb_Parcelas.Location = new System.Drawing.Point(425, 84);
            this.cb_Parcelas.Name = "cb_Parcelas";
            this.cb_Parcelas.Size = new System.Drawing.Size(97, 24);
            this.cb_Parcelas.TabIndex = 98;
            // 
            // dtp_Data
            // 
            this.dtp_Data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_Data.Font = new System.Drawing.Font("Verdana", 10F);
            this.dtp_Data.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Data.Location = new System.Drawing.Point(536, 84);
            this.dtp_Data.Name = "dtp_Data";
            this.dtp_Data.Size = new System.Drawing.Size(128, 24);
            this.dtp_Data.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(422, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 107;
            this.label2.Text = "Parcelas";
            // 
            // tb_Valor
            // 
            this.tb_Valor.Font = new System.Drawing.Font("Verdana", 10F);
            this.tb_Valor.Location = new System.Drawing.Point(306, 84);
            this.tb_Valor.Name = "tb_Valor";
            this.tb_Valor.Size = new System.Drawing.Size(101, 24);
            this.tb_Valor.TabIndex = 97;
            // 
            // dgv_Parcelas
            // 
            this.dgv_Parcelas.AllowUserToAddRows = false;
            this.dgv_Parcelas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Parcelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Parcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Parcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNParcelas,
            this.ColValorParcelado,
            this.ColVencimento,
            this.DiaUtil});
            this.dgv_Parcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Parcelas.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Parcelas.EnableHeadersVisualStyles = false;
            this.dgv_Parcelas.Location = new System.Drawing.Point(10, 12);
            this.dgv_Parcelas.MultiSelect = false;
            this.dgv_Parcelas.Name = "dgv_Parcelas";
            this.dgv_Parcelas.ReadOnly = true;
            this.dgv_Parcelas.RowHeadersVisible = false;
            this.dgv_Parcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Parcelas.Size = new System.Drawing.Size(287, 295);
            this.dgv_Parcelas.TabIndex = 106;
            // 
            // ColNParcelas
            // 
            this.ColNParcelas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.NullValue = null;
            this.ColNParcelas.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColNParcelas.HeaderText = "N° Parcelas";
            this.ColNParcelas.Name = "ColNParcelas";
            this.ColNParcelas.ReadOnly = true;
            this.ColNParcelas.Width = 81;
            // 
            // ColValorParcelado
            // 
            this.ColValorParcelado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.ColValorParcelado.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColValorParcelado.HeaderText = "Valor Parcelado";
            this.ColValorParcelado.Name = "ColValorParcelado";
            this.ColValorParcelado.ReadOnly = true;
            this.ColValorParcelado.Width = 98;
            // 
            // ColVencimento
            // 
            this.ColVencimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.ColVencimento.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColVencimento.HeaderText = "Data Vencimento";
            this.ColVencimento.Name = "ColVencimento";
            this.ColVencimento.ReadOnly = true;
            this.ColVencimento.Width = 105;
            // 
            // DiaUtil
            // 
            this.DiaUtil.HeaderText = "Pagamento";
            this.DiaUtil.Name = "DiaUtil";
            this.DiaUtil.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(303, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 105;
            this.label1.Text = "Valor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(303, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 103;
            this.label3.Text = "Aluno(a)";
            // 
            // tb_Aluno
            // 
            this.tb_Aluno.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Aluno.Enabled = false;
            this.tb_Aluno.Font = new System.Drawing.Font("Verdana", 10F);
            this.tb_Aluno.Location = new System.Drawing.Point(306, 32);
            this.tb_Aluno.Name = "tb_Aluno";
            this.tb_Aluno.ReadOnly = true;
            this.tb_Aluno.Size = new System.Drawing.Size(329, 24);
            this.tb_Aluno.TabIndex = 102;
            this.tb_Aluno.Tag = "";
            // 
            // lb_obgAluno
            // 
            this.lb_obgAluno.AutoSize = true;
            this.lb_obgAluno.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lb_obgAluno.Location = new System.Drawing.Point(377, 12);
            this.lb_obgAluno.Name = "lb_obgAluno";
            this.lb_obgAluno.Size = new System.Drawing.Size(18, 17);
            this.lb_obgAluno.TabIndex = 104;
            this.lb_obgAluno.Text = "*";
            // 
            // lb_ObgValor
            // 
            this.lb_ObgValor.AutoSize = true;
            this.lb_ObgValor.Font = new System.Drawing.Font("Verdana", 10F);
            this.lb_ObgValor.Location = new System.Drawing.Point(335, 68);
            this.lb_ObgValor.Name = "lb_ObgValor";
            this.lb_ObgValor.Size = new System.Drawing.Size(17, 17);
            this.lb_ObgValor.TabIndex = 108;
            this.lb_ObgValor.Text = "*";
            // 
            // cb_curso
            // 
            this.cb_curso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_curso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_curso.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_curso.FormattingEnabled = true;
            this.cb_curso.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cb_curso.Location = new System.Drawing.Point(306, 130);
            this.cb_curso.Name = "cb_curso";
            this.cb_curso.Size = new System.Drawing.Size(238, 24);
            this.cb_curso.TabIndex = 114;
            // 
            // cb_respFinan
            // 
            this.cb_respFinan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_respFinan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_respFinan.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_respFinan.FormattingEnabled = true;
            this.cb_respFinan.Location = new System.Drawing.Point(306, 179);
            this.cb_respFinan.Name = "cb_respFinan";
            this.cb_respFinan.Size = new System.Drawing.Size(366, 24);
            this.cb_respFinan.TabIndex = 135;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(303, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 17);
            this.label8.TabIndex = 136;
            this.label8.Text = "Resp. Financeiro";
            // 
            // F_MatriculaCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 312);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Salvar);
            this.Controls.Add(this.cb_respFinan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cb_curso);
            this.Controls.Add(this.cb_ano);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_BuscarAluno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Parcelas);
            this.Controls.Add(this.cb_Parcelas);
            this.Controls.Add(this.dtp_Data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Valor);
            this.Controls.Add(this.dgv_Parcelas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Aluno);
            this.Controls.Add(this.lb_obgAluno);
            this.Controls.Add(this.lb_ObgValor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_MatriculaCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrícula Curso";
            this.Load += new System.EventHandler(this.F_MatriculaCurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Parcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_ano;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_BuscarAluno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Parcelas;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.ComboBox cb_Parcelas;
        private System.Windows.Forms.DateTimePicker dtp_Data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Valor;
        private System.Windows.Forms.DataGridView dgv_Parcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNParcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValorParcelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaUtil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_Aluno;
        public System.Windows.Forms.Label lb_obgAluno;
        public System.Windows.Forms.Label lb_ObgValor;
        private System.Windows.Forms.ComboBox cb_curso;
        public System.Windows.Forms.ComboBox cb_respFinan;
        private System.Windows.Forms.Label label8;
    }
}