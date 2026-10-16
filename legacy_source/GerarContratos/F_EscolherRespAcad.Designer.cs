
namespace Escolar.GerarContratos
{
    partial class F_EscolherRespAcad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_EscolherRespAcad));
            this.cb_respAcad = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_respAcad
            // 
            this.cb_respAcad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_respAcad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_respAcad.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_respAcad.FormattingEnabled = true;
            this.cb_respAcad.Location = new System.Drawing.Point(12, 67);
            this.cb_respAcad.Name = "cb_respAcad";
            this.cb_respAcad.Size = new System.Drawing.Size(352, 26);
            this.cb_respAcad.TabIndex = 410;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(40, 8);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(305, 23);
            this.label32.TabIndex = 408;
            this.label32.Text = "RESPONSÁVEL ACADÊMICO";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(9, 46);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 18);
            this.label33.TabIndex = 409;
            this.label33.Text = "Nome";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(101, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 37);
            this.button1.TabIndex = 411;
            this.button1.Text = "Gerar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // F_EscolherRespAcad
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 150);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_respAcad);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_EscolherRespAcad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escolher Responsáel";
            this.Load += new System.EventHandler(this.F_EscolherRespAcad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_respAcad;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button button1;
    }
}