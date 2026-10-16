
namespace Escolar.Fluxos
{
    partial class SelecionarDatas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelecionarDatas));
            this.btn_fechar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_Data1 = new System.Windows.Forms.DateTimePicker();
            this.dtp_Data2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_fechar
            // 
            this.btn_fechar.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fechar.Location = new System.Drawing.Point(174, 104);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(202, 51);
            this.btn_fechar.TabIndex = 135;
            this.btn_fechar.Text = "Imprimir";
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(169, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 29);
            this.label7.TabIndex = 134;
            this.label7.Text = "Filtrar por Data";
            // 
            // dtp_Data1
            // 
            this.dtp_Data1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_Data1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Data1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Data1.Location = new System.Drawing.Point(12, 52);
            this.dtp_Data1.Name = "dtp_Data1";
            this.dtp_Data1.Size = new System.Drawing.Size(235, 46);
            this.dtp_Data1.TabIndex = 133;
            // 
            // dtp_Data2
            // 
            this.dtp_Data2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_Data2.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Data2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Data2.Location = new System.Drawing.Point(294, 52);
            this.dtp_Data2.Name = "dtp_Data2";
            this.dtp_Data2.Size = new System.Drawing.Size(235, 46);
            this.dtp_Data2.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(249, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 22);
            this.label1.TabIndex = 137;
            this.label1.Text = "Até";
            // 
            // SelecionarDatas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 164);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_Data2);
            this.Controls.Add(this.btn_fechar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtp_Data1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelecionarDatas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Datas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_Data1;
        private System.Windows.Forms.DateTimePicker dtp_Data2;
        private System.Windows.Forms.Label label1;
    }
}