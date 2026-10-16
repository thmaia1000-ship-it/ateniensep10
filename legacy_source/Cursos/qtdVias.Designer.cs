
namespace Escolar.Cursos
{
    partial class qtdVias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(qtdVias));
            this.btn_Recibo = new System.Windows.Forms.Button();
            this.btn_Cupom = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Recibo
            // 
            this.btn_Recibo.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_Recibo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Recibo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Recibo.FlatAppearance.BorderSize = 3;
            this.btn_Recibo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Recibo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.btn_Recibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Recibo.Font = new System.Drawing.Font("Verdana", 27.75F);
            this.btn_Recibo.ForeColor = System.Drawing.Color.Snow;
            this.btn_Recibo.Location = new System.Drawing.Point(310, 20);
            this.btn_Recibo.Name = "btn_Recibo";
            this.btn_Recibo.Size = new System.Drawing.Size(270, 72);
            this.btn_Recibo.TabIndex = 9;
            this.btn_Recibo.Text = "Uma Via";
            this.btn_Recibo.UseVisualStyleBackColor = false;
            this.btn_Recibo.Click += new System.EventHandler(this.btn_Recibo_Click);
            this.btn_Recibo.Enter += new System.EventHandler(this.btn_Recibo_Enter);
            this.btn_Recibo.Leave += new System.EventHandler(this.btn_Recibo_Leave);
            // 
            // btn_Cupom
            // 
            this.btn_Cupom.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Cupom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cupom.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Cupom.FlatAppearance.BorderSize = 3;
            this.btn_Cupom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Cupom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.btn_Cupom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cupom.Font = new System.Drawing.Font("Verdana", 27.75F);
            this.btn_Cupom.ForeColor = System.Drawing.Color.Snow;
            this.btn_Cupom.Location = new System.Drawing.Point(12, 20);
            this.btn_Cupom.Name = "btn_Cupom";
            this.btn_Cupom.Size = new System.Drawing.Size(270, 72);
            this.btn_Cupom.TabIndex = 8;
            this.btn_Cupom.Text = "Duas Vias";
            this.btn_Cupom.UseVisualStyleBackColor = false;
            this.btn_Cupom.Click += new System.EventHandler(this.btn_Cupom_Click);
            this.btn_Cupom.Enter += new System.EventHandler(this.btn_Cupom_Enter);
            this.btn_Cupom.Leave += new System.EventHandler(this.btn_Cupom_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(729, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // qtdVias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 104);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Recibo);
            this.Controls.Add(this.btn_Cupom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "qtdVias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantas Vias?";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Recibo;
        private System.Windows.Forms.Button btn_Cupom;
        private System.Windows.Forms.Button button1;
    }
}