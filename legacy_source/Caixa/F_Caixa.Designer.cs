namespace Escolar.Caixa
{
    partial class F_Caixa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Caixa));
            this.cb_Forma = new System.Windows.Forms.ComboBox();
            this.Permitir_FiltroForma = new System.Windows.Forms.CheckBox();
            this.dtp_Data1 = new System.Windows.Forms.DateTimePicker();
            this.dtp_Data2 = new System.Windows.Forms.DateTimePicker();
            this.dgv_FluxoCaixa = new System.Windows.Forms.DataGridView();
            this.lb_EntradaTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_TotalPIX = new System.Windows.Forms.Label();
            this.lb_TotalCredito = new System.Windows.Forms.Label();
            this.lb_TotalDebito = new System.Windows.Forms.Label();
            this.lb_TotalDinheiro = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_SubtotalSaida = new System.Windows.Forms.Label();
            this.cb_tipo = new System.Windows.Forms.ComboBox();
            this.Permitir_FiltroTipo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Saida = new System.Windows.Forms.Button();
            this.btn_Entrada = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_SubtotalSaidas = new System.Windows.Forms.Label();
            this.lb_TOTAL = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.btn_corrigir = new System.Windows.Forms.Button();
            this.btn_2via = new System.Windows.Forms.Button();
            this.btn_2viasaida = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FluxoCaixa)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_Forma
            // 
            this.cb_Forma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_Forma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Forma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Forma.Font = new System.Drawing.Font("Verdana", 18F);
            this.cb_Forma.FormattingEnabled = true;
            this.cb_Forma.Location = new System.Drawing.Point(466, 35);
            this.cb_Forma.Name = "cb_Forma";
            this.cb_Forma.Size = new System.Drawing.Size(176, 37);
            this.cb_Forma.TabIndex = 0;
            this.cb_Forma.SelectionChangeCommitted += new System.EventHandler(this.cb_Forma_SelectionChangeCommitted);
            // 
            // Permitir_FiltroForma
            // 
            this.Permitir_FiltroForma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Permitir_FiltroForma.AutoSize = true;
            this.Permitir_FiltroForma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Permitir_FiltroForma.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.Permitir_FiltroForma.Location = new System.Drawing.Point(466, 7);
            this.Permitir_FiltroForma.Name = "Permitir_FiltroForma";
            this.Permitir_FiltroForma.Size = new System.Drawing.Size(125, 27);
            this.Permitir_FiltroForma.TabIndex = 110;
            this.Permitir_FiltroForma.Text = "Filtrar por";
            this.Permitir_FiltroForma.UseVisualStyleBackColor = true;
            this.Permitir_FiltroForma.CheckedChanged += new System.EventHandler(this.Liberar_ComboBox_CheckedChanged);
            // 
            // dtp_Data1
            // 
            this.dtp_Data1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtp_Data1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_Data1.Font = new System.Drawing.Font("Verdana", 18F);
            this.dtp_Data1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Data1.Location = new System.Drawing.Point(11, 35);
            this.dtp_Data1.Name = "dtp_Data1";
            this.dtp_Data1.Size = new System.Drawing.Size(181, 37);
            this.dtp_Data1.TabIndex = 111;
            this.dtp_Data1.ValueChanged += new System.EventHandler(this.dtp_Data1_ValueChanged);
            // 
            // dtp_Data2
            // 
            this.dtp_Data2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtp_Data2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_Data2.Font = new System.Drawing.Font("Verdana", 18F);
            this.dtp_Data2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Data2.Location = new System.Drawing.Point(273, 35);
            this.dtp_Data2.Name = "dtp_Data2";
            this.dtp_Data2.Size = new System.Drawing.Size(187, 37);
            this.dtp_Data2.TabIndex = 112;
            this.dtp_Data2.ValueChanged += new System.EventHandler(this.dtp_Data2_ValueChanged);
            // 
            // dgv_FluxoCaixa
            // 
            this.dgv_FluxoCaixa.AllowUserToAddRows = false;
            this.dgv_FluxoCaixa.AllowUserToDeleteRows = false;
            this.dgv_FluxoCaixa.Anchor = System.Windows.Forms.AnchorStyles.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FluxoCaixa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_FluxoCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_FluxoCaixa.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_FluxoCaixa.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_FluxoCaixa.EnableHeadersVisualStyles = false;
            this.dgv_FluxoCaixa.Location = new System.Drawing.Point(3, 75);
            this.dgv_FluxoCaixa.MultiSelect = false;
            this.dgv_FluxoCaixa.Name = "dgv_FluxoCaixa";
            this.dgv_FluxoCaixa.ReadOnly = true;
            this.dgv_FluxoCaixa.RowHeadersVisible = false;
            this.dgv_FluxoCaixa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_FluxoCaixa.Size = new System.Drawing.Size(1361, 246);
            this.dgv_FluxoCaixa.TabIndex = 114;
            this.dgv_FluxoCaixa.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_FluxoCaixa_CellFormatting);
            // 
            // lb_EntradaTotal
            // 
            this.lb_EntradaTotal.AutoSize = true;
            this.lb_EntradaTotal.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lb_EntradaTotal.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.lb_EntradaTotal.ForeColor = System.Drawing.Color.White;
            this.lb_EntradaTotal.Location = new System.Drawing.Point(130, 218);
            this.lb_EntradaTotal.Name = "lb_EntradaTotal";
            this.lb_EntradaTotal.Size = new System.Drawing.Size(117, 29);
            this.lb_EntradaTotal.TabIndex = 115;
            this.lb_EntradaTotal.Text = "R$ 0,00";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.lb_TotalPIX);
            this.groupBox1.Controls.Add(this.lb_TotalCredito);
            this.groupBox1.Controls.Add(this.lb_TotalDebito);
            this.groupBox1.Controls.Add(this.lb_TotalDinheiro);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lb_EntradaTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.groupBox1.Location = new System.Drawing.Point(12, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 278);
            this.groupBox1.TabIndex = 116;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrada";
            // 
            // lb_TotalPIX
            // 
            this.lb_TotalPIX.AutoSize = true;
            this.lb_TotalPIX.BackColor = System.Drawing.Color.Teal;
            this.lb_TotalPIX.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.lb_TotalPIX.ForeColor = System.Drawing.Color.White;
            this.lb_TotalPIX.Location = new System.Drawing.Point(228, 135);
            this.lb_TotalPIX.Name = "lb_TotalPIX";
            this.lb_TotalPIX.Size = new System.Drawing.Size(103, 25);
            this.lb_TotalPIX.TabIndex = 124;
            this.lb_TotalPIX.Text = "R$ 0,00";
            // 
            // lb_TotalCredito
            // 
            this.lb_TotalCredito.AutoSize = true;
            this.lb_TotalCredito.BackColor = System.Drawing.Color.Teal;
            this.lb_TotalCredito.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.lb_TotalCredito.ForeColor = System.Drawing.Color.White;
            this.lb_TotalCredito.Location = new System.Drawing.Point(228, 35);
            this.lb_TotalCredito.Name = "lb_TotalCredito";
            this.lb_TotalCredito.Size = new System.Drawing.Size(103, 25);
            this.lb_TotalCredito.TabIndex = 123;
            this.lb_TotalCredito.Text = "R$ 0,00";
            // 
            // lb_TotalDebito
            // 
            this.lb_TotalDebito.AutoSize = true;
            this.lb_TotalDebito.BackColor = System.Drawing.Color.Teal;
            this.lb_TotalDebito.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.lb_TotalDebito.ForeColor = System.Drawing.Color.White;
            this.lb_TotalDebito.Location = new System.Drawing.Point(228, 70);
            this.lb_TotalDebito.Name = "lb_TotalDebito";
            this.lb_TotalDebito.Size = new System.Drawing.Size(103, 25);
            this.lb_TotalDebito.TabIndex = 122;
            this.lb_TotalDebito.Text = "R$ 0,00";
            // 
            // lb_TotalDinheiro
            // 
            this.lb_TotalDinheiro.AutoSize = true;
            this.lb_TotalDinheiro.BackColor = System.Drawing.Color.Teal;
            this.lb_TotalDinheiro.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.lb_TotalDinheiro.ForeColor = System.Drawing.Color.White;
            this.lb_TotalDinheiro.Location = new System.Drawing.Point(228, 103);
            this.lb_TotalDinheiro.Name = "lb_TotalDinheiro";
            this.lb_TotalDinheiro.Size = new System.Drawing.Size(103, 25);
            this.lb_TotalDinheiro.TabIndex = 121;
            this.lb_TotalDinheiro.Text = "R$ 0,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(164, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 25);
            this.label5.TabIndex = 120;
            this.label5.Text = "SUBTOTAL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(13, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 119;
            this.label4.Text = "CRÉDITO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 118;
            this.label3.Text = "DINHEIRO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 117;
            this.label2.Text = "PIX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 116;
            this.label1.Text = "DÉBITO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(20, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 18);
            this.label10.TabIndex = 120;
            this.label10.Text = "SUBTOTAL";
            // 
            // lb_SubtotalSaida
            // 
            this.lb_SubtotalSaida.AutoSize = true;
            this.lb_SubtotalSaida.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lb_SubtotalSaida.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lb_SubtotalSaida.ForeColor = System.Drawing.Color.White;
            this.lb_SubtotalSaida.Location = new System.Drawing.Point(1199, 6);
            this.lb_SubtotalSaida.Name = "lb_SubtotalSaida";
            this.lb_SubtotalSaida.Size = new System.Drawing.Size(76, 18);
            this.lb_SubtotalSaida.TabIndex = 115;
            this.lb_SubtotalSaida.Text = "R$ 0,00";
            // 
            // cb_tipo
            // 
            this.cb_tipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_tipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tipo.Font = new System.Drawing.Font("Verdana", 18F);
            this.cb_tipo.FormattingEnabled = true;
            this.cb_tipo.Location = new System.Drawing.Point(657, 35);
            this.cb_tipo.Name = "cb_tipo";
            this.cb_tipo.Size = new System.Drawing.Size(175, 37);
            this.cb_tipo.TabIndex = 126;
            this.cb_tipo.SelectionChangeCommitted += new System.EventHandler(this.cb_tipo_SelectionChangeCommitted);
            // 
            // Permitir_FiltroTipo
            // 
            this.Permitir_FiltroTipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Permitir_FiltroTipo.AutoSize = true;
            this.Permitir_FiltroTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Permitir_FiltroTipo.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.Permitir_FiltroTipo.Location = new System.Drawing.Point(657, 7);
            this.Permitir_FiltroTipo.Name = "Permitir_FiltroTipo";
            this.Permitir_FiltroTipo.Size = new System.Drawing.Size(125, 27);
            this.Permitir_FiltroTipo.TabIndex = 127;
            this.Permitir_FiltroTipo.Text = "Filtrar por";
            this.Permitir_FiltroTipo.UseVisualStyleBackColor = true;
            this.Permitir_FiltroTipo.CheckedChanged += new System.EventHandler(this.Permitir_FiltroTipo_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 15F);
            this.label6.Location = new System.Drawing.Point(213, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 25);
            this.label6.TabIndex = 128;
            this.label6.Text = "Até";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(158, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 25);
            this.label7.TabIndex = 129;
            this.label7.Text = "Filtrar por Data";
            // 
            // btn_Saida
            // 
            this.btn_Saida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Saida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Saida.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.btn_Saida.Location = new System.Drawing.Point(1018, 25);
            this.btn_Saida.Name = "btn_Saida";
            this.btn_Saida.Size = new System.Drawing.Size(162, 47);
            this.btn_Saida.TabIndex = 130;
            this.btn_Saida.Text = "Saída";
            this.btn_Saida.UseVisualStyleBackColor = true;
            this.btn_Saida.Click += new System.EventHandler(this.btn_Saida_Click);
            // 
            // btn_Entrada
            // 
            this.btn_Entrada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Entrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Entrada.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.btn_Entrada.Location = new System.Drawing.Point(850, 25);
            this.btn_Entrada.Name = "btn_Entrada";
            this.btn_Entrada.Size = new System.Drawing.Size(162, 47);
            this.btn_Entrada.TabIndex = 131;
            this.btn_Entrada.Text = "Entrada";
            this.btn_Entrada.UseVisualStyleBackColor = true;
            this.btn_Entrada.Click += new System.EventHandler(this.btn_Entrada_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.lb_SubtotalSaidas);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lb_SubtotalSaida);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.groupBox2.Location = new System.Drawing.Point(518, 327);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 95);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saída";
            // 
            // lb_SubtotalSaidas
            // 
            this.lb_SubtotalSaidas.AutoSize = true;
            this.lb_SubtotalSaidas.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lb_SubtotalSaidas.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.lb_SubtotalSaidas.ForeColor = System.Drawing.Color.White;
            this.lb_SubtotalSaidas.Location = new System.Drawing.Point(167, 41);
            this.lb_SubtotalSaidas.Name = "lb_SubtotalSaidas";
            this.lb_SubtotalSaidas.Size = new System.Drawing.Size(117, 29);
            this.lb_SubtotalSaidas.TabIndex = 125;
            this.lb_SubtotalSaidas.Text = "R$ 0,00";
            // 
            // lb_TOTAL
            // 
            this.lb_TOTAL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_TOTAL.AutoSize = true;
            this.lb_TOTAL.BackColor = System.Drawing.Color.Navy;
            this.lb_TOTAL.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold);
            this.lb_TOTAL.ForeColor = System.Drawing.Color.White;
            this.lb_TOTAL.Location = new System.Drawing.Point(632, 491);
            this.lb_TOTAL.Name = "lb_TOTAL";
            this.lb_TOTAL.Size = new System.Drawing.Size(170, 42);
            this.lb_TOTAL.TabIndex = 121;
            this.lb_TOTAL.Text = "R$ 0,00";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(538, 470);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 18);
            this.label9.TabIndex = 121;
            this.label9.Text = "TOTAL";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.btn_Imprimir);
            this.panel1.Location = new System.Drawing.Point(0, 611);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 72);
            this.panel1.TabIndex = 132;
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Imprimir.Location = new System.Drawing.Point(466, 6);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(437, 66);
            this.btn_Imprimir.TabIndex = 133;
            this.btn_Imprimir.Text = "Fechamento CAIXA";
            this.btn_Imprimir.UseVisualStyleBackColor = true;
            this.btn_Imprimir.Click += new System.EventHandler(this.btn_Imprimir_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(1199, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 45);
            this.label8.TabIndex = 133;
            this.label8.Text = "CAIXA";
            // 
            // sqLiteCommandBuilder1
            // 
            this.sqLiteCommandBuilder1.DataAdapter = null;
            this.sqLiteCommandBuilder1.QuoteSuffix = "]";
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_atualizar.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.btn_atualizar.Location = new System.Drawing.Point(1122, 327);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Size = new System.Drawing.Size(230, 65);
            this.btn_atualizar.TabIndex = 134;
            this.btn_atualizar.Text = "Atualizar";
            this.btn_atualizar.UseVisualStyleBackColor = true;
            this.btn_atualizar.Click += new System.EventHandler(this.btn_atualizar_Click);
            // 
            // btn_corrigir
            // 
            this.btn_corrigir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_corrigir.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.btn_corrigir.Location = new System.Drawing.Point(1122, 398);
            this.btn_corrigir.Name = "btn_corrigir";
            this.btn_corrigir.Size = new System.Drawing.Size(230, 38);
            this.btn_corrigir.TabIndex = 135;
            this.btn_corrigir.Text = "Corrigir";
            this.btn_corrigir.UseVisualStyleBackColor = true;
            this.btn_corrigir.Click += new System.EventHandler(this.btn_Corrigir_Click);
            // 
            // btn_2via
            // 
            this.btn_2via.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_2via.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.btn_2via.Location = new System.Drawing.Point(1122, 451);
            this.btn_2via.Name = "btn_2via";
            this.btn_2via.Size = new System.Drawing.Size(230, 38);
            this.btn_2via.TabIndex = 136;
            this.btn_2via.Text = "2° Via Entrada";
            this.btn_2via.UseVisualStyleBackColor = true;
            this.btn_2via.Click += new System.EventHandler(this.btn_2via_Click);
            // 
            // btn_2viasaida
            // 
            this.btn_2viasaida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_2viasaida.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.btn_2viasaida.Location = new System.Drawing.Point(1122, 505);
            this.btn_2viasaida.Name = "btn_2viasaida";
            this.btn_2viasaida.Size = new System.Drawing.Size(230, 38);
            this.btn_2viasaida.TabIndex = 137;
            this.btn_2viasaida.Text = "2° Via Saída";
            this.btn_2viasaida.UseVisualStyleBackColor = true;
            this.btn_2viasaida.Click += new System.EventHandler(this.btn_2viasaida_Click);
            // 
            // F_Caixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 683);
            this.Controls.Add(this.btn_2viasaida);
            this.Controls.Add(this.btn_2via);
            this.Controls.Add(this.btn_corrigir);
            this.Controls.Add(this.btn_atualizar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_TOTAL);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Entrada);
            this.Controls.Add(this.btn_Saida);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_tipo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_FluxoCaixa);
            this.Controls.Add(this.dtp_Data2);
            this.Controls.Add(this.dtp_Data1);
            this.Controls.Add(this.cb_Forma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Permitir_FiltroForma);
            this.Controls.Add(this.Permitir_FiltroTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_Caixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caixa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_Caixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FluxoCaixa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Forma;
        private System.Windows.Forms.CheckBox Permitir_FiltroForma;
        private System.Windows.Forms.DateTimePicker dtp_Data1;
        private System.Windows.Forms.DateTimePicker dtp_Data2;
        private System.Windows.Forms.DataGridView dgv_FluxoCaixa;
        private System.Windows.Forms.Label lb_EntradaTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_TotalPIX;
        private System.Windows.Forms.Label lb_TotalCredito;
        private System.Windows.Forms.Label lb_TotalDebito;
        private System.Windows.Forms.Label lb_TotalDinheiro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_SubtotalSaida;
        private System.Windows.Forms.ComboBox cb_tipo;
        private System.Windows.Forms.CheckBox Permitir_FiltroTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Saida;
        private System.Windows.Forms.Button btn_Entrada;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_TOTAL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Label label8;
        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private System.Windows.Forms.Button btn_atualizar;
        private System.Windows.Forms.Button btn_corrigir;
        private System.Windows.Forms.Label lb_SubtotalSaidas;
        private System.Windows.Forms.Button btn_2via;
        private System.Windows.Forms.Button btn_2viasaida;
    }
}