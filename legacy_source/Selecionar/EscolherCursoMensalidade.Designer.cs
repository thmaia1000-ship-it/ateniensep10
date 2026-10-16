
namespace Escolar.Selecionar
{
    partial class EscolherCursoMensalidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscolherCursoMensalidade));
            this.btn_geral = new System.Windows.Forms.Button();
            this.btn_judo = new System.Windows.Forms.Button();
            this.btn_danca = new System.Windows.Forms.Button();
            this.btn_futebol = new System.Windows.Forms.Button();
            this.btn_formatura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_geral
            // 
            this.btn_geral.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_geral.Location = new System.Drawing.Point(22, 12);
            this.btn_geral.Name = "btn_geral";
            this.btn_geral.Size = new System.Drawing.Size(159, 61);
            this.btn_geral.TabIndex = 9;
            this.btn_geral.Text = "GERAL";
            this.btn_geral.UseVisualStyleBackColor = true;
            this.btn_geral.Click += new System.EventHandler(this.btn_geral_Click);
            // 
            // btn_judo
            // 
            this.btn_judo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_judo.Location = new System.Drawing.Point(387, 12);
            this.btn_judo.Name = "btn_judo";
            this.btn_judo.Size = new System.Drawing.Size(159, 61);
            this.btn_judo.TabIndex = 8;
            this.btn_judo.Text = "JUDÔ";
            this.btn_judo.UseVisualStyleBackColor = true;
            this.btn_judo.Click += new System.EventHandler(this.btn_judo_Click);
            // 
            // btn_danca
            // 
            this.btn_danca.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_danca.Location = new System.Drawing.Point(211, 12);
            this.btn_danca.Name = "btn_danca";
            this.btn_danca.Size = new System.Drawing.Size(159, 61);
            this.btn_danca.TabIndex = 7;
            this.btn_danca.Text = "DANÇA";
            this.btn_danca.UseVisualStyleBackColor = true;
            this.btn_danca.Click += new System.EventHandler(this.btn_danca_Click);
            // 
            // btn_futebol
            // 
            this.btn_futebol.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_futebol.Location = new System.Drawing.Point(22, 93);
            this.btn_futebol.Name = "btn_futebol";
            this.btn_futebol.Size = new System.Drawing.Size(159, 61);
            this.btn_futebol.TabIndex = 10;
            this.btn_futebol.Text = "FUTEBOL";
            this.btn_futebol.UseVisualStyleBackColor = true;
            this.btn_futebol.Click += new System.EventHandler(this.btn_futebol_Click);
            // 
            // btn_formatura
            // 
            this.btn_formatura.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_formatura.Location = new System.Drawing.Point(211, 93);
            this.btn_formatura.Name = "btn_formatura";
            this.btn_formatura.Size = new System.Drawing.Size(159, 61);
            this.btn_formatura.TabIndex = 11;
            this.btn_formatura.Text = "FORMATURA";
            this.btn_formatura.UseVisualStyleBackColor = true;
            this.btn_formatura.Click += new System.EventHandler(this.btn_formatura_Click);
            // 
            // EscolherCursoMensalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 163);
            this.Controls.Add(this.btn_formatura);
            this.Controls.Add(this.btn_futebol);
            this.Controls.Add(this.btn_geral);
            this.Controls.Add(this.btn_judo);
            this.Controls.Add(this.btn_danca);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EscolherCursoMensalidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_geral;
        private System.Windows.Forms.Button btn_judo;
        private System.Windows.Forms.Button btn_danca;
        private System.Windows.Forms.Button btn_futebol;
        private System.Windows.Forms.Button btn_formatura;
    }
}