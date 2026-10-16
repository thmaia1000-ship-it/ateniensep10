
namespace Escolar.Diario
{
    partial class SelecionarDiario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelecionarDiario));
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_planejamentos = new System.Windows.Forms.DataGridView();
            this.cb_etapa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_professor = new System.Windows.Forms.ComboBox();
            this.dtp_Data2 = new System.Windows.Forms.DateTimePicker();
            this.dtp_Data1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_planejamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pesquisar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pesquisar.Location = new System.Drawing.Point(530, 232);
            this.btn_Pesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(146, 65);
            this.btn_Pesquisar.TabIndex = 18;
            this.btn_Pesquisar.Text = "Buscar";
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(526, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Professor(a)";
            // 
            // dgv_planejamentos
            // 
            this.dgv_planejamentos.AllowUserToAddRows = false;
            this.dgv_planejamentos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_planejamentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_planejamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_planejamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_planejamentos.EnableHeadersVisualStyles = false;
            this.dgv_planejamentos.Location = new System.Drawing.Point(4, 11);
            this.dgv_planejamentos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgv_planejamentos.Name = "dgv_planejamentos";
            this.dgv_planejamentos.ReadOnly = true;
            this.dgv_planejamentos.RowHeadersVisible = false;
            this.dgv_planejamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_planejamentos.Size = new System.Drawing.Size(518, 286);
            this.dgv_planejamentos.TabIndex = 16;
            this.dgv_planejamentos.DoubleClick += new System.EventHandler(this.dgv_SelecionarAluno_DoubleClick);
            // 
            // cb_etapa
            // 
            this.cb_etapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_etapa.Font = new System.Drawing.Font("Verdana", 12F);
            this.cb_etapa.FormattingEnabled = true;
            this.cb_etapa.Location = new System.Drawing.Point(529, 77);
            this.cb_etapa.Name = "cb_etapa";
            this.cb_etapa.Size = new System.Drawing.Size(303, 26);
            this.cb_etapa.TabIndex = 20;
            this.cb_etapa.SelectionChangeCommitted += new System.EventHandler(this.cb_etapa_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(526, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Série";
            // 
            // cb_professor
            // 
            this.cb_professor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_professor.Font = new System.Drawing.Font("Verdana", 12F);
            this.cb_professor.FormattingEnabled = true;
            this.cb_professor.Location = new System.Drawing.Point(529, 26);
            this.cb_professor.Name = "cb_professor";
            this.cb_professor.Size = new System.Drawing.Size(303, 26);
            this.cb_professor.TabIndex = 22;
            // 
            // dtp_Data2
            // 
            this.dtp_Data2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_Data2.Font = new System.Drawing.Font("Verdana", 12F);
            this.dtp_Data2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Data2.Location = new System.Drawing.Point(695, 131);
            this.dtp_Data2.Name = "dtp_Data2";
            this.dtp_Data2.Size = new System.Drawing.Size(137, 27);
            this.dtp_Data2.TabIndex = 131;
            // 
            // dtp_Data1
            // 
            this.dtp_Data1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_Data1.Font = new System.Drawing.Font("Verdana", 12F);
            this.dtp_Data1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Data1.Location = new System.Drawing.Point(529, 131);
            this.dtp_Data1.Name = "dtp_Data1";
            this.dtp_Data1.Size = new System.Drawing.Size(136, 27);
            this.dtp_Data1.TabIndex = 130;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F);
            this.label6.Location = new System.Drawing.Point(665, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 132;
            this.label6.Text = "Até";
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_imprimir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imprimir.Location = new System.Drawing.Point(686, 232);
            this.btn_imprimir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(146, 65);
            this.btn_imprimir.TabIndex = 133;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(526, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 134;
            this.label3.Text = "Período";
            // 
            // SelecionarDiario
            // 
            this.AcceptButton = this.btn_Pesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 315);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.dtp_Data2);
            this.Controls.Add(this.dtp_Data1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_professor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_etapa);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_planejamentos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelecionarDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Diario";
            this.Load += new System.EventHandler(this.SelecionarDiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_planejamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_planejamentos;
        private System.Windows.Forms.ComboBox cb_etapa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_professor;
        private System.Windows.Forms.DateTimePicker dtp_Data2;
        private System.Windows.Forms.DateTimePicker dtp_Data1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Label label3;
    }
}