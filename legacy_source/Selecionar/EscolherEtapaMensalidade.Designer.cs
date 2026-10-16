
namespace Escolar.Selecionar
{
    partial class EscolherEtapaMensalidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscolherEtapaMensalidade));
            this.btn_maternal1 = new System.Windows.Forms.Button();
            this.btn_maternal2 = new System.Windows.Forms.Button();
            this.btn_jardim2 = new System.Windows.Forms.Button();
            this.btn_jardim1 = new System.Windows.Forms.Button();
            this.btn_1ano = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_maternal1
            // 
            this.btn_maternal1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_maternal1.Location = new System.Drawing.Point(216, 32);
            this.btn_maternal1.Name = "btn_maternal1";
            this.btn_maternal1.Size = new System.Drawing.Size(159, 61);
            this.btn_maternal1.TabIndex = 1;
            this.btn_maternal1.Text = "MATERNAL I";
            this.btn_maternal1.UseVisualStyleBackColor = true;
            this.btn_maternal1.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_maternal2
            // 
            this.btn_maternal2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_maternal2.Location = new System.Drawing.Point(392, 32);
            this.btn_maternal2.Name = "btn_maternal2";
            this.btn_maternal2.Size = new System.Drawing.Size(159, 61);
            this.btn_maternal2.TabIndex = 2;
            this.btn_maternal2.Text = "MATERNAL II";
            this.btn_maternal2.UseVisualStyleBackColor = true;
            this.btn_maternal2.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_jardim2
            // 
            this.btn_jardim2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_jardim2.Location = new System.Drawing.Point(216, 123);
            this.btn_jardim2.Name = "btn_jardim2";
            this.btn_jardim2.Size = new System.Drawing.Size(159, 61);
            this.btn_jardim2.TabIndex = 4;
            this.btn_jardim2.Text = "JARDIM II";
            this.btn_jardim2.UseVisualStyleBackColor = true;
            this.btn_jardim2.Click += new System.EventHandler(this.btn_jardim2_Click);
            // 
            // btn_jardim1
            // 
            this.btn_jardim1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_jardim1.Location = new System.Drawing.Point(27, 123);
            this.btn_jardim1.Name = "btn_jardim1";
            this.btn_jardim1.Size = new System.Drawing.Size(159, 61);
            this.btn_jardim1.TabIndex = 3;
            this.btn_jardim1.Text = "JARDIM I";
            this.btn_jardim1.UseVisualStyleBackColor = true;
            this.btn_jardim1.Click += new System.EventHandler(this.btn_jardim1_Click);
            // 
            // btn_1ano
            // 
            this.btn_1ano.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_1ano.Location = new System.Drawing.Point(392, 123);
            this.btn_1ano.Name = "btn_1ano";
            this.btn_1ano.Size = new System.Drawing.Size(159, 61);
            this.btn_1ano.TabIndex = 5;
            this.btn_1ano.Text = "1º ANO";
            this.btn_1ano.UseVisualStyleBackColor = true;
            this.btn_1ano.Click += new System.EventHandler(this.btn_1ano_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(27, 32);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 61);
            this.button6.TabIndex = 6;
            this.button6.Text = "GERAL";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // EscolherEtapaMensalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 200);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btn_1ano);
            this.Controls.Add(this.btn_jardim2);
            this.Controls.Add(this.btn_jardim1);
            this.Controls.Add(this.btn_maternal2);
            this.Controls.Add(this.btn_maternal1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EscolherEtapaMensalidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_maternal1;
        private System.Windows.Forms.Button btn_maternal2;
        private System.Windows.Forms.Button btn_jardim2;
        private System.Windows.Forms.Button btn_jardim1;
        private System.Windows.Forms.Button btn_1ano;
        private System.Windows.Forms.Button button6;
    }
}