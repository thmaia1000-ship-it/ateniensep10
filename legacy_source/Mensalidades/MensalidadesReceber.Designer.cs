
namespace Escolar.Caixa
{
    partial class MensalidadesReceber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensalidadesReceber));
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_TOTAL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_inadimplentes = new System.Windows.Forms.DataGridView();
            this.cb_Filtrar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ano = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inadimplentes)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Imprimir.Location = new System.Drawing.Point(473, 325);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(182, 60);
            this.btn_Imprimir.TabIndex = 138;
            this.btn_Imprimir.Text = "Relatório";
            this.btn_Imprimir.UseVisualStyleBackColor = true;
            this.btn_Imprimir.Click += new System.EventHandler(this.btn_Imprimir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_TOTAL);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 66);
            this.groupBox2.TabIndex = 140;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
            // 
            // lb_TOTAL
            // 
            this.lb_TOTAL.AutoSize = true;
            this.lb_TOTAL.BackColor = System.Drawing.Color.Navy;
            this.lb_TOTAL.Font = new System.Drawing.Font("Verdana", 25F, System.Drawing.FontStyle.Bold);
            this.lb_TOTAL.ForeColor = System.Drawing.Color.White;
            this.lb_TOTAL.Location = new System.Drawing.Point(6, 17);
            this.lb_TOTAL.Name = "lb_TOTAL";
            this.lb_TOTAL.Size = new System.Drawing.Size(165, 41);
            this.lb_TOTAL.TabIndex = 135;
            this.lb_TOTAL.Text = "R$ 0,00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(240, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 23);
            this.label4.TabIndex = 139;
            this.label4.Text = "A RECEBER";
            // 
            // dgv_inadimplentes
            // 
            this.dgv_inadimplentes.AllowUserToAddRows = false;
            this.dgv_inadimplentes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_inadimplentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_inadimplentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inadimplentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_inadimplentes.EnableHeadersVisualStyles = false;
            this.dgv_inadimplentes.Location = new System.Drawing.Point(4, 58);
            this.dgv_inadimplentes.MultiSelect = false;
            this.dgv_inadimplentes.Name = "dgv_inadimplentes";
            this.dgv_inadimplentes.ReadOnly = true;
            this.dgv_inadimplentes.RowHeadersVisible = false;
            this.dgv_inadimplentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_inadimplentes.Size = new System.Drawing.Size(651, 255);
            this.dgv_inadimplentes.TabIndex = 137;
            // 
            // cb_Filtrar
            // 
            this.cb_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Filtrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Filtrar.FormattingEnabled = true;
            this.cb_Filtrar.Location = new System.Drawing.Point(534, 31);
            this.cb_Filtrar.Name = "cb_Filtrar";
            this.cb_Filtrar.Size = new System.Drawing.Size(121, 21);
            this.cb_Filtrar.TabIndex = 141;
            this.cb_Filtrar.SelectionChangeCommitted += new System.EventHandler(this.cb_Filtrar_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(531, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 142;
            this.label1.Text = "Turma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(395, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 152;
            this.label2.Text = "Ano";
            // 
            // cb_ano
            // 
            this.cb_ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ano.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ano.FormattingEnabled = true;
            this.cb_ano.Location = new System.Drawing.Point(398, 31);
            this.cb_ano.Name = "cb_ano";
            this.cb_ano.Size = new System.Drawing.Size(121, 21);
            this.cb_ano.TabIndex = 151;
            this.cb_ano.SelectionChangeCommitted += new System.EventHandler(this.cb_ano_SelectionChangeCommitted);
            // 
            // MensalidadesReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 401);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_ano);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Filtrar);
            this.Controls.Add(this.btn_Imprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_inadimplentes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MensalidadesReceber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensalidades Receber";
            this.Load += new System.EventHandler(this.MensalidadesReceber_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inadimplentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_TOTAL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_inadimplentes;
        private System.Windows.Forms.ComboBox cb_Filtrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ano;
    }
}