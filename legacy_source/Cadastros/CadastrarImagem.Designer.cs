
namespace Escolar.Cadastros
{
    partial class CadastrarImagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastrarImagem));
            this.foto_aluno = new System.Windows.Forms.PictureBox();
            this.btn_capturar = new System.Windows.Forms.Button();
            this.camera = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.foto_aluno)).BeginInit();
            this.SuspendLayout();
            // 
            // foto_aluno
            // 
            this.foto_aluno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foto_aluno.Location = new System.Drawing.Point(12, 12);
            this.foto_aluno.Name = "foto_aluno";
            this.foto_aluno.Size = new System.Drawing.Size(610, 393);
            this.foto_aluno.TabIndex = 0;
            this.foto_aluno.TabStop = false;
            // 
            // btn_capturar
            // 
            this.btn_capturar.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_capturar.Location = new System.Drawing.Point(228, 463);
            this.btn_capturar.Name = "btn_capturar";
            this.btn_capturar.Size = new System.Drawing.Size(164, 57);
            this.btn_capturar.TabIndex = 2;
            this.btn_capturar.Text = "Capturar";
            this.btn_capturar.UseVisualStyleBackColor = true;
            this.btn_capturar.Click += new System.EventHandler(this.btn_capturar_Click);
            // 
            // camera
            // 
            this.camera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camera.Font = new System.Drawing.Font("Verdana", 12F);
            this.camera.FormattingEnabled = true;
            this.camera.Location = new System.Drawing.Point(106, 419);
            this.camera.Name = "camera";
            this.camera.Size = new System.Drawing.Size(197, 26);
            this.camera.TabIndex = 3;
            this.camera.SelectionChangeCommitted += new System.EventHandler(this.camera_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Câmera";
            // 
            // CadastrarImagem
            // 
            this.AcceptButton = this.btn_capturar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 532);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.camera);
            this.Controls.Add(this.btn_capturar);
            this.Controls.Add(this.foto_aluno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CadastrarImagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Imagem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadastrarImagem_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CadastrarImagem_FormClosed);
            this.Load += new System.EventHandler(this.CadastrarImagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.foto_aluno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox foto_aluno;
        private System.Windows.Forms.Button btn_capturar;
        private System.Windows.Forms.ComboBox camera;
        private System.Windows.Forms.Label label1;
    }
}