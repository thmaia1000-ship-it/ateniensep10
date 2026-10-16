
namespace Escolar.Gestão
{
    partial class F_GestaoMensalidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_GestaoMensalidade));
            this.cb_Etapa = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cb_Turno = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_Aluno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nupd_parcelas = new System.Windows.Forms.NumericUpDown();
            this.tb_valor_parcela = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupd_parcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_Etapa
            // 
            this.cb_Etapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Etapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Etapa.Font = new System.Drawing.Font("Verdana", 13F);
            this.cb_Etapa.FormattingEnabled = true;
            this.cb_Etapa.Location = new System.Drawing.Point(168, 81);
            this.cb_Etapa.Name = "cb_Etapa";
            this.cb_Etapa.Size = new System.Drawing.Size(138, 28);
            this.cb_Etapa.TabIndex = 181;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 13F);
            this.label17.Location = new System.Drawing.Point(164, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 22);
            this.label17.TabIndex = 183;
            this.label17.Text = "Etapa";
            // 
            // cb_Turno
            // 
            this.cb_Turno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Turno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Turno.Font = new System.Drawing.Font("Verdana", 13F);
            this.cb_Turno.FormattingEnabled = true;
            this.cb_Turno.Items.AddRange(new object[] {
            "MANHÃ",
            "TARDE",
            "NOITE"});
            this.cb_Turno.Location = new System.Drawing.Point(12, 81);
            this.cb_Turno.Name = "cb_Turno";
            this.cb_Turno.Size = new System.Drawing.Size(150, 28);
            this.cb_Turno.TabIndex = 180;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 13F);
            this.label7.Location = new System.Drawing.Point(12, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 22);
            this.label7.TabIndex = 182;
            this.label7.Text = "Turno";
            // 
            // tb_Aluno
            // 
            this.tb_Aluno.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Aluno.Enabled = false;
            this.tb_Aluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.tb_Aluno.Location = new System.Drawing.Point(12, 29);
            this.tb_Aluno.Name = "tb_Aluno";
            this.tb_Aluno.ReadOnly = true;
            this.tb_Aluno.Size = new System.Drawing.Size(294, 23);
            this.tb_Aluno.TabIndex = 179;
            this.tb_Aluno.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 13F);
            this.label3.Location = new System.Drawing.Point(8, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 178;
            this.label3.Text = "Aluno(a)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 13F);
            this.label2.Location = new System.Drawing.Point(173, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 177;
            this.label2.Text = "Nº Parcelas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_cancelar);
            this.panel1.Controls.Add(this.btn_Editar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 57);
            this.panel1.TabIndex = 176;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Font = new System.Drawing.Font("Verdana", 13F);
            this.btn_cancelar.Location = new System.Drawing.Point(168, 5);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(115, 46);
            this.btn_cancelar.TabIndex = 13;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.Font = new System.Drawing.Font("Verdana", 13F);
            this.btn_Editar.Location = new System.Drawing.Point(32, 5);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(115, 46);
            this.btn_Editar.TabIndex = 3;
            this.btn_Editar.Text = "Salvar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13F);
            this.label1.Location = new System.Drawing.Point(8, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 22);
            this.label1.TabIndex = 175;
            this.label1.Text = "Valor Parcela";
            // 
            // nupd_parcelas
            // 
            this.nupd_parcelas.Font = new System.Drawing.Font("Verdana", 13F);
            this.nupd_parcelas.Location = new System.Drawing.Point(168, 137);
            this.nupd_parcelas.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nupd_parcelas.Name = "nupd_parcelas";
            this.nupd_parcelas.Size = new System.Drawing.Size(138, 29);
            this.nupd_parcelas.TabIndex = 174;
            this.nupd_parcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupd_parcelas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tb_valor_parcela
            // 
            this.tb_valor_parcela.Font = new System.Drawing.Font("Verdana", 13F);
            this.tb_valor_parcela.Location = new System.Drawing.Point(12, 137);
            this.tb_valor_parcela.Name = "tb_valor_parcela";
            this.tb_valor_parcela.Size = new System.Drawing.Size(150, 29);
            this.tb_valor_parcela.TabIndex = 173;
            this.tb_valor_parcela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_valor_parcela_KeyPress);
            // 
            // F_GestaoMensalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 247);
            this.Controls.Add(this.cb_Etapa);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cb_Turno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_Aluno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nupd_parcelas);
            this.Controls.Add(this.tb_valor_parcela);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_GestaoMensalidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão Mensalidade";
            this.Load += new System.EventHandler(this.F_GestaoMensalidade_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupd_parcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Etapa;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cb_Turno;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tb_Aluno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupd_parcelas;
        private System.Windows.Forms.TextBox tb_valor_parcela;
    }
}