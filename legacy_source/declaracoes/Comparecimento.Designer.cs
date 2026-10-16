
namespace Escolar.declaracoes
{
    partial class Comparecimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comparecimento));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_aluno = new System.Windows.Forms.TextBox();
            this.tb_resp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gerarButton = new System.Windows.Forms.Button();
            this.cb_Etapa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aluno";
            // 
            // tb_aluno
            // 
            this.tb_aluno.Enabled = false;
            this.tb_aluno.Font = new System.Drawing.Font("Verdana", 10F);
            this.tb_aluno.Location = new System.Drawing.Point(15, 30);
            this.tb_aluno.Name = "tb_aluno";
            this.tb_aluno.Size = new System.Drawing.Size(341, 24);
            this.tb_aluno.TabIndex = 1;
            // 
            // tb_resp
            // 
            this.tb_resp.Font = new System.Drawing.Font("Verdana", 10F);
            this.tb_resp.Location = new System.Drawing.Point(15, 87);
            this.tb_resp.Name = "tb_resp";
            this.tb_resp.Size = new System.Drawing.Size(341, 24);
            this.tb_resp.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Responsável";
            // 
            // gerarButton
            // 
            this.gerarButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerarButton.Location = new System.Drawing.Point(118, 183);
            this.gerarButton.Name = "gerarButton";
            this.gerarButton.Size = new System.Drawing.Size(133, 53);
            this.gerarButton.TabIndex = 5;
            this.gerarButton.Text = "Gerar";
            this.gerarButton.UseVisualStyleBackColor = true;
            this.gerarButton.Click += new System.EventHandler(this.gerarButton_Click);
            // 
            // cb_Etapa
            // 
            this.cb_Etapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Etapa.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_Etapa.FormattingEnabled = true;
            this.cb_Etapa.Location = new System.Drawing.Point(15, 142);
            this.cb_Etapa.Name = "cb_Etapa";
            this.cb_Etapa.Size = new System.Drawing.Size(341, 24);
            this.cb_Etapa.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Etapa";
            // 
            // Comparecimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 248);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_Etapa);
            this.Controls.Add(this.gerarButton);
            this.Controls.Add(this.tb_resp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_aluno);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Comparecimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparecimento";
            this.Load += new System.EventHandler(this.Comparecimento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button gerarButton;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_aluno;
        public System.Windows.Forms.TextBox tb_resp;
        public System.Windows.Forms.ComboBox cb_Etapa;
    }
}