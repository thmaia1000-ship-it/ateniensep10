namespace Escolar
{
    partial class F_PagarMensalidade
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_PagarMensalidade));
            this.label3 = new System.Windows.Forms.Label();
            this.lb_obgAluno = new System.Windows.Forms.Label();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.tb_Aluno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gpb_Pagamento = new System.Windows.Forms.GroupBox();
            this.cb_NParcelas = new System.Windows.Forms.NumericUpDown();
            this.lb_RS = new System.Windows.Forms.Label();
            this.lb_SubTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ValorParcela = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_ValorPago = new System.Windows.Forms.Label();
            this.lb_nParcelasPendentes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Pagamento = new System.Windows.Forms.Button();
            this.gpb_InfoAdd = new System.Windows.Forms.GroupBox();
            this.lb_carteira = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_Cursando = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_nParcelasPagas = new System.Windows.Forms.Label();
            this.lb_ResFinan = new System.Windows.Forms.Label();
            this.dgv_Parcelas = new System.Windows.Forms.DataGridView();
            this.ColNParcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValorParcelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.gpb_Pagamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_NParcelas)).BeginInit();
            this.panel1.SuspendLayout();
            this.gpb_InfoAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Parcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Aluno(a)";
            // 
            // lb_obgAluno
            // 
            this.lb_obgAluno.AutoSize = true;
            this.lb_obgAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_obgAluno.Location = new System.Drawing.Point(69, 8);
            this.lb_obgAluno.Name = "lb_obgAluno";
            this.lb_obgAluno.Size = new System.Drawing.Size(15, 20);
            this.lb_obgAluno.TabIndex = 89;
            this.lb_obgAluno.Text = "*";
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pesquisar.Location = new System.Drawing.Point(372, 24);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(32, 26);
            this.btn_Pesquisar.TabIndex = 92;
            this.btn_Pesquisar.Text = "...";
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // tb_Aluno
            // 
            this.tb_Aluno.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_Aluno.Enabled = false;
            this.tb_Aluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Aluno.Location = new System.Drawing.Point(21, 24);
            this.tb_Aluno.Name = "tb_Aluno";
            this.tb_Aluno.ReadOnly = true;
            this.tb_Aluno.Size = new System.Drawing.Size(349, 26);
            this.tb_Aluno.TabIndex = 94;
            this.tb_Aluno.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F);
            this.label2.Location = new System.Drawing.Point(213, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "SALDO DEVEDOR";
            // 
            // gpb_Pagamento
            // 
            this.gpb_Pagamento.Controls.Add(this.cb_NParcelas);
            this.gpb_Pagamento.Controls.Add(this.lb_RS);
            this.gpb_Pagamento.Controls.Add(this.lb_SubTotal);
            this.gpb_Pagamento.Controls.Add(this.label1);
            this.gpb_Pagamento.Controls.Add(this.label4);
            this.gpb_Pagamento.Controls.Add(this.tb_ValorParcela);
            this.gpb_Pagamento.Controls.Add(this.label5);
            this.gpb_Pagamento.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.gpb_Pagamento.Location = new System.Drawing.Point(21, 66);
            this.gpb_Pagamento.Name = "gpb_Pagamento";
            this.gpb_Pagamento.Size = new System.Drawing.Size(384, 284);
            this.gpb_Pagamento.TabIndex = 105;
            this.gpb_Pagamento.TabStop = false;
            this.gpb_Pagamento.Text = "Dados Pagamento";
            // 
            // cb_NParcelas
            // 
            this.cb_NParcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_NParcelas.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_NParcelas.Location = new System.Drawing.Point(15, 149);
            this.cb_NParcelas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cb_NParcelas.Name = "cb_NParcelas";
            this.cb_NParcelas.Size = new System.Drawing.Size(110, 31);
            this.cb_NParcelas.TabIndex = 124;
            this.cb_NParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cb_NParcelas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cb_NParcelas.ValueChanged += new System.EventHandler(this.cb_NParcelas_ValueChanged);
            // 
            // lb_RS
            // 
            this.lb_RS.AutoSize = true;
            this.lb_RS.Font = new System.Drawing.Font("Verdana", 33F, System.Drawing.FontStyle.Bold);
            this.lb_RS.ForeColor = System.Drawing.Color.Red;
            this.lb_RS.Location = new System.Drawing.Point(16, 215);
            this.lb_RS.Name = "lb_RS";
            this.lb_RS.Size = new System.Drawing.Size(88, 53);
            this.lb_RS.TabIndex = 108;
            this.lb_RS.Text = "R$";
            // 
            // lb_SubTotal
            // 
            this.lb_SubTotal.AutoSize = true;
            this.lb_SubTotal.Font = new System.Drawing.Font("Verdana", 33F, System.Drawing.FontStyle.Bold);
            this.lb_SubTotal.ForeColor = System.Drawing.Color.Red;
            this.lb_SubTotal.Location = new System.Drawing.Point(95, 215);
            this.lb_SubTotal.Name = "lb_SubTotal";
            this.lb_SubTotal.Size = new System.Drawing.Size(128, 53);
            this.lb_SubTotal.TabIndex = 104;
            this.lb_SubTotal.Text = "-----";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "QUANTIDADE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F);
            this.label4.Location = new System.Drawing.Point(17, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 103;
            this.label4.Text = "SUBTOTAL";
            // 
            // tb_ValorParcela
            // 
            this.tb_ValorParcela.AutoSize = true;
            this.tb_ValorParcela.Font = new System.Drawing.Font("Verdana", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ValorParcela.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_ValorParcela.Location = new System.Drawing.Point(18, 55);
            this.tb_ValorParcela.Name = "tb_ValorParcela";
            this.tb_ValorParcela.Size = new System.Drawing.Size(97, 40);
            this.tb_ValorParcela.TabIndex = 102;
            this.tb_ValorParcela.Text = "-----";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F);
            this.label5.Location = new System.Drawing.Point(9, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 17);
            this.label5.TabIndex = 99;
            this.label5.Text = "VALOR MENSALIDADE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8F);
            this.label7.Location = new System.Drawing.Point(402, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 101;
            this.label7.Text = "PARCELAS PENDENTES";
            // 
            // tb_ValorPago
            // 
            this.tb_ValorPago.AutoSize = true;
            this.tb_ValorPago.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.tb_ValorPago.ForeColor = System.Drawing.Color.MediumBlue;
            this.tb_ValorPago.Location = new System.Drawing.Point(227, 48);
            this.tb_ValorPago.Name = "tb_ValorPago";
            this.tb_ValorPago.Size = new System.Drawing.Size(43, 17);
            this.tb_ValorPago.TabIndex = 103;
            this.tb_ValorPago.Text = "-----";
            // 
            // lb_nParcelasPendentes
            // 
            this.lb_nParcelasPendentes.AutoSize = true;
            this.lb_nParcelasPendentes.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lb_nParcelasPendentes.ForeColor = System.Drawing.Color.MediumBlue;
            this.lb_nParcelasPendentes.Location = new System.Drawing.Point(457, 48);
            this.lb_nParcelasPendentes.Name = "lb_nParcelasPendentes";
            this.lb_nParcelasPendentes.Size = new System.Drawing.Size(18, 17);
            this.lb_nParcelasPendentes.TabIndex = 104;
            this.lb_nParcelasPendentes.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Cancelar);
            this.panel1.Controls.Add(this.btn_Pagamento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 442);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 66);
            this.panel1.TabIndex = 106;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Location = new System.Drawing.Point(406, 8);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_Cancelar.Size = new System.Drawing.Size(200, 46);
            this.btn_Cancelar.TabIndex = 101;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Pagamento
            // 
            this.btn_Pagamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pagamento.Location = new System.Drawing.Point(170, 8);
            this.btn_Pagamento.Name = "btn_Pagamento";
            this.btn_Pagamento.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_Pagamento.Size = new System.Drawing.Size(200, 46);
            this.btn_Pagamento.TabIndex = 100;
            this.btn_Pagamento.Text = "Receber";
            this.btn_Pagamento.UseVisualStyleBackColor = true;
            this.btn_Pagamento.Click += new System.EventHandler(this.btn_Pagamento_Click);
            // 
            // gpb_InfoAdd
            // 
            this.gpb_InfoAdd.Controls.Add(this.lb_carteira);
            this.gpb_InfoAdd.Controls.Add(this.label9);
            this.gpb_InfoAdd.Controls.Add(this.tb_ValorPago);
            this.gpb_InfoAdd.Controls.Add(this.lb_Cursando);
            this.gpb_InfoAdd.Controls.Add(this.label6);
            this.gpb_InfoAdd.Controls.Add(this.label2);
            this.gpb_InfoAdd.Controls.Add(this.lb_nParcelasPendentes);
            this.gpb_InfoAdd.Controls.Add(this.label7);
            this.gpb_InfoAdd.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.gpb_InfoAdd.Location = new System.Drawing.Point(21, 356);
            this.gpb_InfoAdd.Name = "gpb_InfoAdd";
            this.gpb_InfoAdd.Size = new System.Drawing.Size(747, 74);
            this.gpb_InfoAdd.TabIndex = 106;
            this.gpb_InfoAdd.TabStop = false;
            this.gpb_InfoAdd.Text = "Informações Adicionais";
            // 
            // lb_carteira
            // 
            this.lb_carteira.AutoSize = true;
            this.lb_carteira.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lb_carteira.ForeColor = System.Drawing.Color.MediumBlue;
            this.lb_carteira.Location = new System.Drawing.Point(621, 48);
            this.lb_carteira.Name = "lb_carteira";
            this.lb_carteira.Size = new System.Drawing.Size(43, 17);
            this.lb_carteira.TabIndex = 108;
            this.lb_carteira.Text = "-----";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8F);
            this.label9.Location = new System.Drawing.Point(607, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 107;
            this.label9.Text = "SALDO CARTEIRA";
            // 
            // lb_Cursando
            // 
            this.lb_Cursando.AutoSize = true;
            this.lb_Cursando.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lb_Cursando.ForeColor = System.Drawing.Color.MediumBlue;
            this.lb_Cursando.Location = new System.Drawing.Point(42, 48);
            this.lb_Cursando.Name = "lb_Cursando";
            this.lb_Cursando.Size = new System.Drawing.Size(43, 17);
            this.lb_Cursando.TabIndex = 106;
            this.lb_Cursando.Text = "-----";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8F);
            this.label6.Location = new System.Drawing.Point(32, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 105;
            this.label6.Text = "CURSANDO";
            // 
            // tb_nParcelasPagas
            // 
            this.tb_nParcelasPagas.AutoSize = true;
            this.tb_nParcelasPagas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tb_nParcelasPagas.ForeColor = System.Drawing.Color.MediumBlue;
            this.tb_nParcelasPagas.Location = new System.Drawing.Point(948, 207);
            this.tb_nParcelasPagas.Name = "tb_nParcelasPagas";
            this.tb_nParcelasPagas.Size = new System.Drawing.Size(0, 13);
            this.tb_nParcelasPagas.TabIndex = 106;
            // 
            // lb_ResFinan
            // 
            this.lb_ResFinan.AutoSize = true;
            this.lb_ResFinan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ResFinan.ForeColor = System.Drawing.Color.Black;
            this.lb_ResFinan.Location = new System.Drawing.Point(948, 188);
            this.lb_ResFinan.Name = "lb_ResFinan";
            this.lb_ResFinan.Size = new System.Drawing.Size(0, 13);
            this.lb_ResFinan.TabIndex = 122;
            // 
            // dgv_Parcelas
            // 
            this.dgv_Parcelas.AllowUserToAddRows = false;
            this.dgv_Parcelas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Parcelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Parcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Parcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNParcelas,
            this.ColValorParcelado,
            this.ColVencimento,
            this.Pagamento,
            this.Status,
            this.pagou});
            this.dgv_Parcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Parcelas.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Parcelas.EnableHeadersVisualStyles = false;
            this.dgv_Parcelas.Location = new System.Drawing.Point(426, 24);
            this.dgv_Parcelas.MultiSelect = false;
            this.dgv_Parcelas.Name = "dgv_Parcelas";
            this.dgv_Parcelas.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Parcelas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Parcelas.RowHeadersVisible = false;
            this.dgv_Parcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Parcelas.Size = new System.Drawing.Size(342, 298);
            this.dgv_Parcelas.TabIndex = 123;
            this.dgv_Parcelas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Parcelas_CellFormatting);
            // 
            // ColNParcelas
            // 
            dataGridViewCellStyle2.NullValue = null;
            this.ColNParcelas.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColNParcelas.FillWeight = 40.12896F;
            this.ColNParcelas.HeaderText = "N°";
            this.ColNParcelas.Name = "ColNParcelas";
            this.ColNParcelas.ReadOnly = true;
            this.ColNParcelas.Width = 30;
            // 
            // ColValorParcelado
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.ColValorParcelado.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColValorParcelado.FillWeight = 121.8274F;
            this.ColValorParcelado.HeaderText = "Valor Parcelado";
            this.ColValorParcelado.Name = "ColValorParcelado";
            this.ColValorParcelado.ReadOnly = true;
            this.ColValorParcelado.Width = 79;
            // 
            // ColVencimento
            // 
            this.ColVencimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.ColVencimento.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColVencimento.FillWeight = 138.0436F;
            this.ColVencimento.HeaderText = "Data Vencimento";
            this.ColVencimento.Name = "ColVencimento";
            this.ColVencimento.ReadOnly = true;
            this.ColVencimento.Width = 70;
            // 
            // Pagamento
            // 
            this.Pagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Pagamento.HeaderText = "Pagamento";
            this.Pagamento.Name = "Pagamento";
            this.Pagamento.ReadOnly = true;
            this.Pagamento.Width = 87;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.HeaderText = "Status Parcela";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 67;
            // 
            // pagou
            // 
            this.pagou.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pagou.HeaderText = "Pagou";
            this.pagou.Name = "pagou";
            this.pagou.ReadOnly = true;
            this.pagou.Width = 75;
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_atualizar.Location = new System.Drawing.Point(426, 328);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_atualizar.Size = new System.Drawing.Size(166, 22);
            this.btn_atualizar.TabIndex = 102;
            this.btn_atualizar.Text = "Atualizar";
            this.btn_atualizar.UseVisualStyleBackColor = true;
            this.btn_atualizar.Click += new System.EventHandler(this.btn_atualizar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Editar.Location = new System.Drawing.Point(612, 328);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_Editar.Size = new System.Drawing.Size(156, 22);
            this.btn_Editar.TabIndex = 124;
            this.btn_Editar.Text = "Gestão Mensalidade";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // F_PagarMensalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 508);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_atualizar);
            this.Controls.Add(this.gpb_InfoAdd);
            this.Controls.Add(this.dgv_Parcelas);
            this.Controls.Add(this.tb_nParcelasPagas);
            this.Controls.Add(this.lb_ResFinan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gpb_Pagamento);
            this.Controls.Add(this.tb_Aluno);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_obgAluno);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_PagarMensalidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagar Mensalidade";
            this.Load += new System.EventHandler(this.F_Caixa_Load);
            this.gpb_Pagamento.ResumeLayout(false);
            this.gpb_Pagamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_NParcelas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gpb_InfoAdd.ResumeLayout(false);
            this.gpb_InfoAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Parcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lb_obgAluno;
        public System.Windows.Forms.TextBox tb_Aluno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.GroupBox gpb_Pagamento;
        public System.Windows.Forms.Label tb_ValorParcela;
        public System.Windows.Forms.Label lb_nParcelasPendentes;
        public System.Windows.Forms.Label tb_ValorPago;
        public System.Windows.Forms.Label lb_SubTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox gpb_InfoAdd;
        public System.Windows.Forms.Label lb_RS;
        public System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Button btn_Cancelar;
        public System.Windows.Forms.Label lb_ResFinan;
        public System.Windows.Forms.Label tb_nParcelasPagas;
        public System.Windows.Forms.Label lb_Cursando;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btn_Pagamento;
        public System.Windows.Forms.DataGridView dgv_Parcelas;
        private System.Windows.Forms.Button btn_atualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNParcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValorParcelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagou;
        public System.Windows.Forms.NumericUpDown cb_NParcelas;
        public System.Windows.Forms.Label lb_carteira;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Editar;
    }
}