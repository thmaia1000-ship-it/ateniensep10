
namespace Escolar.Gestão
{
    partial class F_GestaoMensalidadeCursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_GestaoMensalidadeCursos));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nupd_parcelas = new System.Windows.Forms.NumericUpDown();
            this.tb_valor_parcela = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupd_parcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(255, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nº Parcelas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Editar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 57);
            this.panel1.TabIndex = 9;
            // 
            // btn_Editar
            // 
            this.btn_Editar.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Editar.Location = new System.Drawing.Point(130, 3);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(196, 46);
            this.btn_Editar.TabIndex = 3;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Valor Parcela";
            // 
            // nupd_parcelas
            // 
            this.nupd_parcelas.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.nupd_parcelas.Location = new System.Drawing.Point(260, 55);
            this.nupd_parcelas.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nupd_parcelas.Name = "nupd_parcelas";
            this.nupd_parcelas.Size = new System.Drawing.Size(129, 43);
            this.nupd_parcelas.TabIndex = 7;
            this.nupd_parcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupd_parcelas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tb_valor_parcela
            // 
            this.tb_valor_parcela.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_valor_parcela.Location = new System.Drawing.Point(43, 55);
            this.tb_valor_parcela.Name = "tb_valor_parcela";
            this.tb_valor_parcela.Size = new System.Drawing.Size(183, 43);
            this.tb_valor_parcela.TabIndex = 6;
            this.tb_valor_parcela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_valor_parcela_KeyPress);
            // 
            // F_GestaoMensalidadeCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 207);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nupd_parcelas);
            this.Controls.Add(this.tb_valor_parcela);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_GestaoMensalidadeCursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão Mensalidade";
            this.Load += new System.EventHandler(this.F_GestaoMensalidadeCursos_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupd_parcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupd_parcelas;
        private System.Windows.Forms.TextBox tb_valor_parcela;
    }
}