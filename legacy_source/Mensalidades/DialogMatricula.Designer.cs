
namespace Escolar.Mensalidades
{
    partial class DialogMatricula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogMatricula));
            this.matriculaButton = new System.Windows.Forms.Button();
            this.rematriculaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // matriculaButton
            // 
            this.matriculaButton.Font = new System.Drawing.Font("Verdana", 18F);
            this.matriculaButton.Location = new System.Drawing.Point(12, 18);
            this.matriculaButton.Name = "matriculaButton";
            this.matriculaButton.Size = new System.Drawing.Size(210, 90);
            this.matriculaButton.TabIndex = 0;
            this.matriculaButton.Text = "Matrícula";
            this.matriculaButton.UseVisualStyleBackColor = true;
            this.matriculaButton.Click += new System.EventHandler(this.matriculaButton_Click);
            // 
            // rematriculaButton
            // 
            this.rematriculaButton.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rematriculaButton.Location = new System.Drawing.Point(246, 18);
            this.rematriculaButton.Name = "rematriculaButton";
            this.rematriculaButton.Size = new System.Drawing.Size(210, 90);
            this.rematriculaButton.TabIndex = 1;
            this.rematriculaButton.Text = "Rematrícula";
            this.rematriculaButton.UseVisualStyleBackColor = true;
            this.rematriculaButton.Click += new System.EventHandler(this.rematriculaButton_Click);
            // 
            // DialogMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 126);
            this.Controls.Add(this.rematriculaButton);
            this.Controls.Add(this.matriculaButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogMatricula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DialogMatricula_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button matriculaButton;
        private System.Windows.Forms.Button rematriculaButton;
    }
}