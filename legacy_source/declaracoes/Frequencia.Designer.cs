
namespace Escolar.declaracoes
{
    partial class Frequencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frequencia));
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Etapa = new System.Windows.Forms.ComboBox();
            this.gerarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Etapa";
            // 
            // cb_Etapa
            // 
            this.cb_Etapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Etapa.Font = new System.Drawing.Font("Verdana", 10F);
            this.cb_Etapa.FormattingEnabled = true;
            this.cb_Etapa.Location = new System.Drawing.Point(18, 46);
            this.cb_Etapa.Name = "cb_Etapa";
            this.cb_Etapa.Size = new System.Drawing.Size(341, 24);
            this.cb_Etapa.TabIndex = 9;
            // 
            // gerarButton
            // 
            this.gerarButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerarButton.Location = new System.Drawing.Point(121, 87);
            this.gerarButton.Name = "gerarButton";
            this.gerarButton.Size = new System.Drawing.Size(133, 53);
            this.gerarButton.TabIndex = 8;
            this.gerarButton.Text = "Gerar";
            this.gerarButton.UseVisualStyleBackColor = true;
            this.gerarButton.Click += new System.EventHandler(this.gerarButton_Click);
            // 
            // Frequencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 151);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_Etapa);
            this.Controls.Add(this.gerarButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frequencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frequencia";
            this.Load += new System.EventHandler(this.Frequencia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cb_Etapa;
        private System.Windows.Forms.Button gerarButton;
    }
}