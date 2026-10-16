
namespace Escolar.Caixa
{
    partial class F_Vendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Vendas));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_desconto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_nome_produto = new System.Windows.Forms.Label();
            this.lb_estoque = new System.Windows.Forms.Label();
            this.lb_ValorVenda = new System.Windows.Forms.Label();
            this.btn_Adicionar = new System.Windows.Forms.Button();
            this.npd_quantidade = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_desc = new System.Windows.Forms.Label();
            this.dgv_Produto = new System.Windows.Forms.DataGridView();
            this.nome_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_ValorDesconto = new System.Windows.Forms.Label();
            this.lb_ValorTotal = new System.Windows.Forms.Label();
            this.btn_Remover = new System.Windows.Forms.Button();
            this.lb_IDProduto = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Receber = new System.Windows.Forms.Button();
            this.btn_Aluno = new System.Windows.Forms.Button();
            this.tb_nome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lb_IDRespFinan = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lb_NomeResp = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lb_cpf = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Descontar = new System.Windows.Forms.Button();
            this.tb_Produto = new System.Windows.Forms.ComboBox();
            this.tb_pagador = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_acrescimo = new System.Windows.Forms.Button();
            this.tb_acrescimo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lb_ValorAcrescimo = new System.Windows.Forms.Label();
            this.lb_acresc = new System.Windows.Forms.Label();
            this.lb_SaldoCarteira = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.npd_quantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Produto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Produto";
            // 
            // tb_desconto
            // 
            this.tb_desconto.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_desconto.Location = new System.Drawing.Point(1126, 298);
            this.tb_desconto.Name = "tb_desconto";
            this.tb_desconto.Size = new System.Drawing.Size(105, 31);
            this.tb_desconto.TabIndex = 8;
            this.tb_desconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_desconto_KeyPress);
            this.tb_desconto.Leave += new System.EventHandler(this.tb_desconto_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.Location = new System.Drawing.Point(1123, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "% Desconto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Quantidade";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Navy;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(28, 212);
            this.textBox3.MaxLength = 0;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(513, 27);
            this.textBox3.TabIndex = 19;
            this.textBox3.Text = " Dados do Produto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "Produto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 23);
            this.label7.TabIndex = 23;
            this.label7.Text = "Valor venda:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(69, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "Estoque:";
            // 
            // lb_nome_produto
            // 
            this.lb_nome_produto.AutoSize = true;
            this.lb_nome_produto.BackColor = System.Drawing.Color.White;
            this.lb_nome_produto.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nome_produto.Location = new System.Drawing.Point(170, 270);
            this.lb_nome_produto.Name = "lb_nome_produto";
            this.lb_nome_produto.Size = new System.Drawing.Size(161, 23);
            this.lb_nome_produto.TabIndex = 27;
            this.lb_nome_produto.Text = "?Nome_Produto";
            // 
            // lb_estoque
            // 
            this.lb_estoque.AutoSize = true;
            this.lb_estoque.BackColor = System.Drawing.Color.White;
            this.lb_estoque.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_estoque.Location = new System.Drawing.Point(170, 293);
            this.lb_estoque.Name = "lb_estoque";
            this.lb_estoque.Size = new System.Drawing.Size(96, 23);
            this.lb_estoque.TabIndex = 28;
            this.lb_estoque.Text = "?Estoque";
            // 
            // lb_ValorVenda
            // 
            this.lb_ValorVenda.AutoSize = true;
            this.lb_ValorVenda.BackColor = System.Drawing.Color.White;
            this.lb_ValorVenda.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ValorVenda.Location = new System.Drawing.Point(170, 320);
            this.lb_ValorVenda.Name = "lb_ValorVenda";
            this.lb_ValorVenda.Size = new System.Drawing.Size(127, 23);
            this.lb_ValorVenda.TabIndex = 30;
            this.lb_ValorVenda.Text = "?ValorVenda";
            // 
            // btn_Adicionar
            // 
            this.btn_Adicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Adicionar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Adicionar.Location = new System.Drawing.Point(736, 276);
            this.btn_Adicionar.Name = "btn_Adicionar";
            this.btn_Adicionar.Size = new System.Drawing.Size(158, 40);
            this.btn_Adicionar.TabIndex = 6;
            this.btn_Adicionar.Text = "Pré Venda";
            this.btn_Adicionar.UseVisualStyleBackColor = true;
            this.btn_Adicionar.Click += new System.EventHandler(this.btn_Adicionar_Click);
            // 
            // npd_quantidade
            // 
            this.npd_quantidade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.npd_quantidade.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npd_quantidade.Location = new System.Drawing.Point(28, 139);
            this.npd_quantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.npd_quantidade.Name = "npd_quantidade";
            this.npd_quantidade.Size = new System.Drawing.Size(110, 31);
            this.npd_quantidade.TabIndex = 2;
            this.npd_quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.npd_quantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(572, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 42);
            this.label5.TabIndex = 34;
            this.label5.Text = "TOTAL";
            // 
            // lb_desc
            // 
            this.lb_desc.AutoSize = true;
            this.lb_desc.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.lb_desc.ForeColor = System.Drawing.Color.Navy;
            this.lb_desc.Location = new System.Drawing.Point(731, 365);
            this.lb_desc.Name = "lb_desc";
            this.lb_desc.Size = new System.Drawing.Size(114, 29);
            this.lb_desc.TabIndex = 37;
            this.lb_desc.Text = "DESC%";
            this.lb_desc.Visible = false;
            // 
            // dgv_Produto
            // 
            this.dgv_Produto.AllowUserToAddRows = false;
            this.dgv_Produto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Produto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Produto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nome_produto,
            this.quantida,
            this.valor_venda,
            this.id});
            this.dgv_Produto.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Produto.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Produto.EnableHeadersVisualStyles = false;
            this.dgv_Produto.Location = new System.Drawing.Point(736, 12);
            this.dgv_Produto.MultiSelect = false;
            this.dgv_Produto.Name = "dgv_Produto";
            this.dgv_Produto.ReadOnly = true;
            this.dgv_Produto.RowHeadersVisible = false;
            this.dgv_Produto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Produto.Size = new System.Drawing.Size(616, 258);
            this.dgv_Produto.TabIndex = 17;
            this.dgv_Produto.SelectionChanged += new System.EventHandler(this.dgv_Produto_SelectionChanged);
            // 
            // nome_produto
            // 
            this.nome_produto.HeaderText = "Produto";
            this.nome_produto.Name = "nome_produto";
            this.nome_produto.ReadOnly = true;
            this.nome_produto.Width = 424;
            // 
            // quantida
            // 
            this.quantida.HeaderText = "Qte";
            this.quantida.Name = "quantida";
            this.quantida.ReadOnly = true;
            this.quantida.Width = 60;
            // 
            // valor_venda
            // 
            this.valor_venda.HeaderText = "Valor";
            this.valor_venda.Name = "valor_venda";
            this.valor_venda.ReadOnly = true;
            this.valor_venda.Width = 130;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // lb_ValorDesconto
            // 
            this.lb_ValorDesconto.AutoSize = true;
            this.lb_ValorDesconto.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ValorDesconto.ForeColor = System.Drawing.Color.Red;
            this.lb_ValorDesconto.Location = new System.Drawing.Point(882, 365);
            this.lb_ValorDesconto.Name = "lb_ValorDesconto";
            this.lb_ValorDesconto.Size = new System.Drawing.Size(179, 29);
            this.lb_ValorDesconto.TabIndex = 39;
            this.lb_ValorDesconto.Text = "?Valor_Desc";
            this.lb_ValorDesconto.Visible = false;
            // 
            // lb_ValorTotal
            // 
            this.lb_ValorTotal.AutoSize = true;
            this.lb_ValorTotal.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ValorTotal.ForeColor = System.Drawing.Color.Red;
            this.lb_ValorTotal.Location = new System.Drawing.Point(723, 438);
            this.lb_ValorTotal.Name = "lb_ValorTotal";
            this.lb_ValorTotal.Size = new System.Drawing.Size(490, 78);
            this.lb_ValorTotal.TabIndex = 40;
            this.lb_ValorTotal.Text = "?Valor_Total";
            // 
            // btn_Remover
            // 
            this.btn_Remover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Remover.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Remover.Location = new System.Drawing.Point(910, 276);
            this.btn_Remover.Name = "btn_Remover";
            this.btn_Remover.Size = new System.Drawing.Size(158, 40);
            this.btn_Remover.TabIndex = 7;
            this.btn_Remover.Text = "Remover";
            this.btn_Remover.UseVisualStyleBackColor = true;
            this.btn_Remover.Click += new System.EventHandler(this.btn_Remover_Click);
            // 
            // lb_IDProduto
            // 
            this.lb_IDProduto.AutoSize = true;
            this.lb_IDProduto.BackColor = System.Drawing.Color.White;
            this.lb_IDProduto.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_IDProduto.Location = new System.Drawing.Point(170, 247);
            this.lb_IDProduto.Name = "lb_IDProduto";
            this.lb_IDProduto.Size = new System.Drawing.Size(129, 23);
            this.lb_IDProduto.TabIndex = 43;
            this.lb_IDProduto.Text = "?ID_Produto";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(122, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 23);
            this.label11.TabIndex = 42;
            this.label11.Text = "ID:";
            // 
            // btn_Receber
            // 
            this.btn_Receber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Receber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Receber.Location = new System.Drawing.Point(453, 622);
            this.btn_Receber.Name = "btn_Receber";
            this.btn_Receber.Size = new System.Drawing.Size(242, 71);
            this.btn_Receber.TabIndex = 4;
            this.btn_Receber.Text = "Receber";
            this.btn_Receber.UseVisualStyleBackColor = true;
            this.btn_Receber.Click += new System.EventHandler(this.btn_Receber_Click);
            // 
            // btn_Aluno
            // 
            this.btn_Aluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Aluno.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Aluno.Location = new System.Drawing.Point(503, 75);
            this.btn_Aluno.Name = "btn_Aluno";
            this.btn_Aluno.Size = new System.Drawing.Size(38, 33);
            this.btn_Aluno.TabIndex = 1;
            this.btn_Aluno.Text = "F2";
            this.btn_Aluno.UseVisualStyleBackColor = true;
            this.btn_Aluno.Click += new System.EventHandler(this.btn_Aluno_Click);
            // 
            // tb_nome
            // 
            this.tb_nome.Enabled = false;
            this.tb_nome.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nome.Location = new System.Drawing.Point(28, 75);
            this.tb_nome.Name = "tb_nome";
            this.tb_nome.Size = new System.Drawing.Size(469, 31);
            this.tb_nome.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 18);
            this.label6.TabIndex = 46;
            this.label6.Text = "Aluno";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Escolar.Properties.Resources.fundo_branco;
            this.pictureBox2.Location = new System.Drawing.Point(28, 238);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(513, 284);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Escolar.Properties.Resources.LOGO_BR3__SEM_FUNDO;
            this.pictureBox1.Location = new System.Drawing.Point(547, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Navy;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(28, 354);
            this.textBox1.MaxLength = 0;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(513, 27);
            this.textBox1.TabIndex = 48;
            this.textBox1.Text = " Dados do Resp. Financeiro";
            // 
            // lb_IDRespFinan
            // 
            this.lb_IDRespFinan.AutoSize = true;
            this.lb_IDRespFinan.BackColor = System.Drawing.Color.White;
            this.lb_IDRespFinan.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.lb_IDRespFinan.Location = new System.Drawing.Point(170, 389);
            this.lb_IDRespFinan.Name = "lb_IDRespFinan";
            this.lb_IDRespFinan.Size = new System.Drawing.Size(144, 23);
            this.lb_IDRespFinan.TabIndex = 50;
            this.lb_IDRespFinan.Text = "?ID_respfinan";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.label12.Location = new System.Drawing.Point(122, 389);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 23);
            this.label12.TabIndex = 49;
            this.label12.Text = "ID:";
            // 
            // lb_NomeResp
            // 
            this.lb_NomeResp.AutoSize = true;
            this.lb_NomeResp.BackColor = System.Drawing.Color.White;
            this.lb_NomeResp.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.lb_NomeResp.Location = new System.Drawing.Point(170, 412);
            this.lb_NomeResp.Name = "lb_NomeResp";
            this.lb_NomeResp.Size = new System.Drawing.Size(133, 23);
            this.lb_NomeResp.TabIndex = 52;
            this.lb_NomeResp.Text = "?Nome_Resp";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.label13.Location = new System.Drawing.Point(90, 412);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 23);
            this.label13.TabIndex = 51;
            this.label13.Text = "Nome:";
            // 
            // lb_cpf
            // 
            this.lb_cpf.AutoSize = true;
            this.lb_cpf.BackColor = System.Drawing.Color.White;
            this.lb_cpf.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.lb_cpf.Location = new System.Drawing.Point(170, 438);
            this.lb_cpf.Name = "lb_cpf";
            this.lb_cpf.Size = new System.Drawing.Size(55, 23);
            this.lb_cpf.TabIndex = 54;
            this.lb_cpf.Text = "?CPF";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.label14.Location = new System.Drawing.Point(111, 438);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 23);
            this.label14.TabIndex = 53;
            this.label14.Text = "CPF:";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(710, 622);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(242, 71);
            this.btn_Cancelar.TabIndex = 5;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Descontar
            // 
            this.btn_Descontar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Descontar.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_Descontar.Location = new System.Drawing.Point(1125, 335);
            this.btn_Descontar.Name = "btn_Descontar";
            this.btn_Descontar.Size = new System.Drawing.Size(105, 46);
            this.btn_Descontar.TabIndex = 9;
            this.btn_Descontar.Text = "Aplicar";
            this.btn_Descontar.UseVisualStyleBackColor = true;
            this.btn_Descontar.Click += new System.EventHandler(this.btn_Descontar_Click);
            // 
            // tb_Produto
            // 
            this.tb_Produto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tb_Produto.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.tb_Produto.FormattingEnabled = true;
            this.tb_Produto.Location = new System.Drawing.Point(28, 23);
            this.tb_Produto.Name = "tb_Produto";
            this.tb_Produto.Size = new System.Drawing.Size(513, 31);
            this.tb_Produto.TabIndex = 0;
            this.tb_Produto.SelectionChangeCommitted += new System.EventHandler(this.tb_Produto_SelectionChangeCommitted);
            // 
            // tb_pagador
            // 
            this.tb_pagador.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pagador.Location = new System.Drawing.Point(28, 549);
            this.tb_pagador.Name = "tb_pagador";
            this.tb_pagador.Size = new System.Drawing.Size(513, 31);
            this.tb_pagador.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 528);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 18);
            this.label10.TabIndex = 61;
            this.label10.Text = "Pagador";
            // 
            // btn_acrescimo
            // 
            this.btn_acrescimo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_acrescimo.Font = new System.Drawing.Font("Verdana", 12F);
            this.btn_acrescimo.Location = new System.Drawing.Point(1247, 335);
            this.btn_acrescimo.Name = "btn_acrescimo";
            this.btn_acrescimo.Size = new System.Drawing.Size(105, 46);
            this.btn_acrescimo.TabIndex = 11;
            this.btn_acrescimo.Text = "Aplicar";
            this.btn_acrescimo.UseVisualStyleBackColor = true;
            this.btn_acrescimo.Click += new System.EventHandler(this.btn_acrescimo_Click);
            // 
            // tb_acrescimo
            // 
            this.tb_acrescimo.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_acrescimo.Location = new System.Drawing.Point(1247, 298);
            this.tb_acrescimo.Name = "tb_acrescimo";
            this.tb_acrescimo.Size = new System.Drawing.Size(105, 31);
            this.tb_acrescimo.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1244, 276);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 18);
            this.label15.TabIndex = 63;
            this.label15.Text = "% Acréscimo";
            // 
            // lb_ValorAcrescimo
            // 
            this.lb_ValorAcrescimo.AutoSize = true;
            this.lb_ValorAcrescimo.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ValorAcrescimo.ForeColor = System.Drawing.Color.Red;
            this.lb_ValorAcrescimo.Location = new System.Drawing.Point(882, 551);
            this.lb_ValorAcrescimo.Name = "lb_ValorAcrescimo";
            this.lb_ValorAcrescimo.Size = new System.Drawing.Size(204, 29);
            this.lb_ValorAcrescimo.TabIndex = 66;
            this.lb_ValorAcrescimo.Text = "?Valor_Acresc";
            this.lb_ValorAcrescimo.Visible = false;
            // 
            // lb_acresc
            // 
            this.lb_acresc.AutoSize = true;
            this.lb_acresc.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.lb_acresc.ForeColor = System.Drawing.Color.Navy;
            this.lb_acresc.Location = new System.Drawing.Point(731, 551);
            this.lb_acresc.Name = "lb_acresc";
            this.lb_acresc.Size = new System.Drawing.Size(149, 29);
            this.lb_acresc.TabIndex = 65;
            this.lb_acresc.Text = "ACRESC%";
            this.lb_acresc.Visible = false;
            // 
            // lb_SaldoCarteira
            // 
            this.lb_SaldoCarteira.AutoSize = true;
            this.lb_SaldoCarteira.BackColor = System.Drawing.Color.White;
            this.lb_SaldoCarteira.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.lb_SaldoCarteira.Location = new System.Drawing.Point(170, 494);
            this.lb_SaldoCarteira.Name = "lb_SaldoCarteira";
            this.lb_SaldoCarteira.Size = new System.Drawing.Size(158, 23);
            this.lb_SaldoCarteira.TabIndex = 70;
            this.lb_SaldoCarteira.Text = "?Saldo_carteira";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.label20.Location = new System.Drawing.Point(78, 493);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 23);
            this.label20.TabIndex = 69;
            this.label20.Text = "SALDO:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Navy;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(28, 464);
            this.textBox2.MaxLength = 0;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(513, 27);
            this.textBox2.TabIndex = 68;
            this.textBox2.Text = " Dados Carteira";
            // 
            // F_Vendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 742);
            this.Controls.Add(this.lb_SaldoCarteira);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lb_ValorAcrescimo);
            this.Controls.Add(this.lb_acresc);
            this.Controls.Add(this.btn_acrescimo);
            this.Controls.Add(this.tb_acrescimo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tb_pagador);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tb_Produto);
            this.Controls.Add(this.btn_Descontar);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.lb_cpf);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lb_NomeResp);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lb_IDRespFinan);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_Aluno);
            this.Controls.Add(this.tb_nome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Receber);
            this.Controls.Add(this.lb_IDProduto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_Remover);
            this.Controls.Add(this.lb_ValorTotal);
            this.Controls.Add(this.lb_ValorDesconto);
            this.Controls.Add(this.lb_desc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.npd_quantidade);
            this.Controls.Add(this.btn_Adicionar);
            this.Controls.Add(this.lb_ValorVenda);
            this.Controls.Add(this.lb_estoque);
            this.Controls.Add(this.lb_nome_produto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dgv_Produto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_desconto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "F_Vendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frente Caixa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_Vendas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F_Vendas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.npd_quantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Produto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox tb_desconto;
        public System.Windows.Forms.Label lb_nome_produto;
        public System.Windows.Forms.Label lb_estoque;
        public System.Windows.Forms.Label lb_ValorVenda;
        private System.Windows.Forms.Button btn_Adicionar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_desc;
        public System.Windows.Forms.DataGridView dgv_Produto;
        private System.Windows.Forms.Button btn_Remover;
        public System.Windows.Forms.Label lb_IDProduto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_Receber;
        private System.Windows.Forms.Button btn_Aluno;
        public System.Windows.Forms.TextBox tb_nome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label lb_IDRespFinan;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label lb_NomeResp;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label lb_cpf;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Descontar;
        public System.Windows.Forms.Label lb_ValorTotal;
        public System.Windows.Forms.NumericUpDown npd_quantidade;
        public System.Windows.Forms.TextBox tb_pagador;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantida;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_venda;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        public System.Windows.Forms.ComboBox tb_Produto;
        public System.Windows.Forms.Label lb_ValorDesconto;
        private System.Windows.Forms.Button btn_acrescimo;
        public System.Windows.Forms.TextBox tb_acrescimo;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label lb_ValorAcrescimo;
        private System.Windows.Forms.Label lb_acresc;
        public System.Windows.Forms.Label lb_SaldoCarteira;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox2;
    }
}