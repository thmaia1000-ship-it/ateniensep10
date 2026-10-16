namespace Escolar.Caixa
{
    partial class F_Entrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Entrada));
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Forma = new System.Windows.Forms.ComboBox();
            this.lb_atendente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Limpar = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_valor = new System.Windows.Forms.TextBox();
            this.lb_DATA = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_descricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_nome = new System.Windows.Forms.TextBox();
            this.btn_BuscarAluno = new System.Windows.Forms.Button();
            this.chk_outros = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label6.Location = new System.Drawing.Point(199, 73);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 137;
            this.label6.Text = "Forma";
            // 
            // cb_Forma
            // 
            this.cb_Forma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Forma.FormattingEnabled = true;
            this.cb_Forma.Location = new System.Drawing.Point(199, 89);
            this.cb_Forma.Name = "cb_Forma";
            this.cb_Forma.Size = new System.Drawing.Size(90, 21);
            this.cb_Forma.TabIndex = 2;
            // 
            // lb_atendente
            // 
            this.lb_atendente.AutoSize = true;
            this.lb_atendente.Font = new System.Drawing.Font("Verdana", 14F);
            this.lb_atendente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lb_atendente.Location = new System.Drawing.Point(348, 81);
            this.lb_atendente.Name = "lb_atendente";
            this.lb_atendente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_atendente.Size = new System.Drawing.Size(106, 23);
            this.lb_atendente.TabIndex = 135;
            this.lb_atendente.Text = "Atendente";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Limpar);
            this.panel1.Controls.Add(this.btn_Salvar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 47);
            this.panel1.TabIndex = 4;
            // 
            // btn_Limpar
            // 
            this.btn_Limpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpar.Location = new System.Drawing.Point(258, 6);
            this.btn_Limpar.Name = "btn_Limpar";
            this.btn_Limpar.Size = new System.Drawing.Size(212, 32);
            this.btn_Limpar.TabIndex = 2;
            this.btn_Limpar.Text = "Limpar";
            this.btn_Limpar.UseVisualStyleBackColor = true;
            this.btn_Limpar.Click += new System.EventHandler(this.btn_Limpar_Click);
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Salvar.Location = new System.Drawing.Point(22, 6);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(212, 32);
            this.btn_Salvar.TabIndex = 1;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(139, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 23);
            this.label4.TabIndex = 132;
            this.label4.Text = "ENTRADA DE CAIXA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 131;
            this.label3.Text = "Valor";
            // 
            // tb_valor
            // 
            this.tb_valor.BackColor = System.Drawing.SystemColors.Window;
            this.tb_valor.Font = new System.Drawing.Font("Verdana", 20F);
            this.tb_valor.ForeColor = System.Drawing.SystemColors.InfoText;
            this.tb_valor.Location = new System.Drawing.Point(12, 89);
            this.tb_valor.Name = "tb_valor";
            this.tb_valor.Size = new System.Drawing.Size(181, 40);
            this.tb_valor.TabIndex = 1;
            this.tb_valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_valor.Enter += new System.EventHandler(this.tb_valor_Enter);
            this.tb_valor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_valor_KeyPress);
            // 
            // lb_DATA
            // 
            this.lb_DATA.AutoSize = true;
            this.lb_DATA.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lb_DATA.Location = new System.Drawing.Point(376, 12);
            this.lb_DATA.Name = "lb_DATA";
            this.lb_DATA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_DATA.Size = new System.Drawing.Size(37, 13);
            this.lb_DATA.TabIndex = 129;
            this.lb_DATA.Text = "DATA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 128;
            this.label2.Text = "Descrição";
            // 
            // tb_descricao
            // 
            this.tb_descricao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_descricao.Location = new System.Drawing.Point(12, 148);
            this.tb_descricao.Multiline = true;
            this.tb_descricao.Name = "tb_descricao";
            this.tb_descricao.Size = new System.Drawing.Size(473, 52);
            this.tb_descricao.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Nome";
            // 
            // tb_nome
            // 
            this.tb_nome.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_nome.Enabled = false;
            this.tb_nome.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nome.Location = new System.Drawing.Point(11, 45);
            this.tb_nome.Name = "tb_nome";
            this.tb_nome.Size = new System.Drawing.Size(438, 21);
            this.tb_nome.TabIndex = 0;
            // 
            // btn_BuscarAluno
            // 
            this.btn_BuscarAluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BuscarAluno.Location = new System.Drawing.Point(455, 45);
            this.btn_BuscarAluno.Name = "btn_BuscarAluno";
            this.btn_BuscarAluno.Size = new System.Drawing.Size(41, 21);
            this.btn_BuscarAluno.TabIndex = 3;
            this.btn_BuscarAluno.Text = "...";
            this.btn_BuscarAluno.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_BuscarAluno.UseVisualStyleBackColor = true;
            this.btn_BuscarAluno.Click += new System.EventHandler(this.btn_BuscarAluno_Click);
            // 
            // chk_outros
            // 
            this.chk_outros.AutoSize = true;
            this.chk_outros.Enabled = false;
            this.chk_outros.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_outros.Location = new System.Drawing.Point(199, 113);
            this.chk_outros.Name = "chk_outros";
            this.chk_outros.Size = new System.Drawing.Size(185, 17);
            this.chk_outros.TabIndex = 138;
            this.chk_outros.Text = "Duas formas de pagamento";
            this.chk_outros.UseVisualStyleBackColor = true;
            this.chk_outros.CheckedChanged += new System.EventHandler(this.chk_outros_CheckedChanged);
            // 
            // F_Entrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 276);
            this.Controls.Add(this.chk_outros);
            this.Controls.Add(this.btn_BuscarAluno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_Forma);
            this.Controls.Add(this.lb_atendente);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_valor);
            this.Controls.Add(this.lb_DATA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_descricao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_nome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_Entrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada";
            this.Load += new System.EventHandler(this.F_Entrada_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_atendente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Limpar;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_DATA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tb_nome;
        public System.Windows.Forms.ComboBox cb_Forma;
        public System.Windows.Forms.TextBox tb_valor;
        public System.Windows.Forms.TextBox tb_descricao;
        private System.Windows.Forms.Button btn_BuscarAluno;
        public System.Windows.Forms.CheckBox chk_outros;
    }
}