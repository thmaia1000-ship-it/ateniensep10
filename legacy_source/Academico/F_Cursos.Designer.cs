namespace Escolar
{
    partial class F_Cursos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Cursos));
            this.tb_Curso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_excluirCurso = new System.Windows.Forms.Button();
            this.btn_novoCurso = new System.Windows.Forms.Button();
            this.btn_salvarCurso = new System.Windows.Forms.Button();
            this.dgv_cursos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cursos)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Curso
            // 
            this.tb_Curso.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Curso.Location = new System.Drawing.Point(8, 29);
            this.tb_Curso.Name = "tb_Curso";
            this.tb_Curso.Size = new System.Drawing.Size(397, 27);
            this.tb_Curso.TabIndex = 24;
            this.tb_Curso.TextChanged += new System.EventHandler(this.tb_Curso_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Curso";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_editar);
            this.panel1.Controls.Add(this.btn_excluirCurso);
            this.panel1.Controls.Add(this.btn_novoCurso);
            this.panel1.Controls.Add(this.btn_salvarCurso);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 50);
            this.panel1.TabIndex = 29;
            // 
            // btn_editar
            // 
            this.btn_editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_editar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.Location = new System.Drawing.Point(214, 9);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(96, 34);
            this.btn_editar.TabIndex = 9;
            this.btn_editar.Text = "Editar Curso";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_excluirCurso
            // 
            this.btn_excluirCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_excluirCurso.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excluirCurso.Location = new System.Drawing.Point(317, 9);
            this.btn_excluirCurso.Name = "btn_excluirCurso";
            this.btn_excluirCurso.Size = new System.Drawing.Size(96, 34);
            this.btn_excluirCurso.TabIndex = 8;
            this.btn_excluirCurso.Text = "Excluir Curso";
            this.btn_excluirCurso.UseVisualStyleBackColor = true;
            this.btn_excluirCurso.Click += new System.EventHandler(this.btn_excluirCurso_Click);
            // 
            // btn_novoCurso
            // 
            this.btn_novoCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_novoCurso.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_novoCurso.Location = new System.Drawing.Point(112, 9);
            this.btn_novoCurso.Name = "btn_novoCurso";
            this.btn_novoCurso.Size = new System.Drawing.Size(96, 34);
            this.btn_novoCurso.TabIndex = 4;
            this.btn_novoCurso.Text = "Novo Curso";
            this.btn_novoCurso.UseVisualStyleBackColor = true;
            this.btn_novoCurso.Click += new System.EventHandler(this.btn_novoCurso_Click);
            // 
            // btn_salvarCurso
            // 
            this.btn_salvarCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salvarCurso.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salvarCurso.Location = new System.Drawing.Point(10, 9);
            this.btn_salvarCurso.Name = "btn_salvarCurso";
            this.btn_salvarCurso.Size = new System.Drawing.Size(96, 34);
            this.btn_salvarCurso.TabIndex = 6;
            this.btn_salvarCurso.Text = "Salvar";
            this.btn_salvarCurso.UseVisualStyleBackColor = true;
            this.btn_salvarCurso.Click += new System.EventHandler(this.btn_salvarCurso_Click);
            // 
            // dgv_cursos
            // 
            this.dgv_cursos.AllowUserToAddRows = false;
            this.dgv_cursos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_cursos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_cursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cursos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_cursos.EnableHeadersVisualStyles = false;
            this.dgv_cursos.Location = new System.Drawing.Point(5, 63);
            this.dgv_cursos.MultiSelect = false;
            this.dgv_cursos.Name = "dgv_cursos";
            this.dgv_cursos.ReadOnly = true;
            this.dgv_cursos.RowHeadersVisible = false;
            this.dgv_cursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cursos.Size = new System.Drawing.Size(403, 213);
            this.dgv_cursos.TabIndex = 28;
            this.dgv_cursos.SelectionChanged += new System.EventHandler(this.dgv_cursos_SelectionChanged);
            // 
            // F_Cursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 330);
            this.Controls.Add(this.tb_Curso);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_cursos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Cursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cursos";
            this.Load += new System.EventHandler(this.F_Cursos_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cursos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_Curso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_excluirCurso;
        private System.Windows.Forms.Button btn_novoCurso;
        private System.Windows.Forms.Button btn_salvarCurso;
        private System.Windows.Forms.DataGridView dgv_cursos;
        private System.Windows.Forms.Button btn_editar;
    }
}