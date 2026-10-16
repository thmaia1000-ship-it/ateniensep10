namespace Escolar
{
    partial class F_Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Principal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_nomeUsuario = new System.Windows.Forms.Label();
            this.lb_acesso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Acessos = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestãoDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secretariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mátriculaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarMatrículasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turmasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matériasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadeEscolarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.professoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.academicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boletimEscolarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.financeiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarMensalidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contratosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_gestaoalunos = new System.Windows.Forms.PictureBox();
            this.btn_alunos = new System.Windows.Forms.PictureBox();
            this.btn_Turmas = new System.Windows.Forms.PictureBox();
            this.btn_Professores = new System.Windows.Forms.PictureBox();
            this.btn_horarios = new System.Windows.Forms.PictureBox();
            this.caixaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_gestaoalunos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_alunos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Turmas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Professores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_horarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.lb_nomeUsuario);
            this.panel1.Controls.Add(this.lb_acesso);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Acessos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 339);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 28);
            this.panel1.TabIndex = 0;
            // 
            // lb_nomeUsuario
            // 
            this.lb_nomeUsuario.AutoSize = true;
            this.lb_nomeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nomeUsuario.ForeColor = System.Drawing.Color.LawnGreen;
            this.lb_nomeUsuario.Location = new System.Drawing.Point(175, 8);
            this.lb_nomeUsuario.Name = "lb_nomeUsuario";
            this.lb_nomeUsuario.Size = new System.Drawing.Size(19, 13);
            this.lb_nomeUsuario.TabIndex = 4;
            this.lb_nomeUsuario.Text = "---";
            // 
            // lb_acesso
            // 
            this.lb_acesso.AutoSize = true;
            this.lb_acesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_acesso.ForeColor = System.Drawing.Color.LawnGreen;
            this.lb_acesso.Location = new System.Drawing.Point(96, 8);
            this.lb_acesso.Name = "lb_acesso";
            this.lb_acesso.Size = new System.Drawing.Size(14, 13);
            this.lb_acesso.TabIndex = 3;
            this.lb_acesso.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(115, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuário:";
            // 
            // Acessos
            // 
            this.Acessos.AutoSize = true;
            this.Acessos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Acessos.ForeColor = System.Drawing.Color.White;
            this.Acessos.Location = new System.Drawing.Point(3, 8);
            this.Acessos.Name = "Acessos";
            this.Acessos.Size = new System.Drawing.Size(87, 13);
            this.Acessos.TabIndex = 2;
            this.Acessos.Text = "Nível Acesso:";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuáriosToolStripMenuItem,
            this.lToolStripMenuItem,
            this.secretariaToolStripMenuItem,
            this.unidadeEscolarToolStripMenuItem,
            this.academicoToolStripMenuItem,
            this.financeiroToolStripMenuItem,
            this.contratosToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(662, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoUsuárioToolStripMenuItem,
            this.gestãoDeToolStripMenuItem});
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            // 
            // novoUsuárioToolStripMenuItem
            // 
            this.novoUsuárioToolStripMenuItem.Name = "novoUsuárioToolStripMenuItem";
            this.novoUsuárioToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.novoUsuárioToolStripMenuItem.Text = "Novo Usuário";
            this.novoUsuárioToolStripMenuItem.Click += new System.EventHandler(this.novoUsuárioToolStripMenuItem_Click);
            // 
            // gestãoDeToolStripMenuItem
            // 
            this.gestãoDeToolStripMenuItem.Name = "gestãoDeToolStripMenuItem";
            this.gestãoDeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.gestãoDeToolStripMenuItem.Text = "Gestão de Usuários";
            this.gestãoDeToolStripMenuItem.Click += new System.EventHandler(this.gestãoDeToolStripMenuItem_Click);
            // 
            // lToolStripMenuItem
            // 
            this.lToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logonToolStripMenuItem,
            this.logoffToolStripMenuItem});
            this.lToolStripMenuItem.Name = "lToolStripMenuItem";
            this.lToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.lToolStripMenuItem.Text = "Login";
            // 
            // logonToolStripMenuItem
            // 
            this.logonToolStripMenuItem.Name = "logonToolStripMenuItem";
            this.logonToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.logonToolStripMenuItem.Text = "Logar";
            this.logonToolStripMenuItem.Click += new System.EventHandler(this.logonToolStripMenuItem_Click);
            // 
            // logoffToolStripMenuItem
            // 
            this.logoffToolStripMenuItem.Name = "logoffToolStripMenuItem";
            this.logoffToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.logoffToolStripMenuItem.Text = "Sair";
            this.logoffToolStripMenuItem.Click += new System.EventHandler(this.logoffToolStripMenuItem_Click);
            // 
            // secretariaToolStripMenuItem
            // 
            this.secretariaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mátriculaToolStripMenuItem,
            this.consultarMatrículasToolStripMenuItem,
            this.cursoToolStripMenuItem,
            this.turmasToolStripMenuItem,
            this.matériasToolStripMenuItem});
            this.secretariaToolStripMenuItem.Name = "secretariaToolStripMenuItem";
            this.secretariaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.secretariaToolStripMenuItem.Text = "Secretaria";
            // 
            // mátriculaToolStripMenuItem
            // 
            this.mátriculaToolStripMenuItem.Name = "mátriculaToolStripMenuItem";
            this.mátriculaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.mátriculaToolStripMenuItem.Text = "Matrícula";
            this.mátriculaToolStripMenuItem.Click += new System.EventHandler(this.mátriculaToolStripMenuItem_Click);
            // 
            // consultarMatrículasToolStripMenuItem
            // 
            this.consultarMatrículasToolStripMenuItem.Name = "consultarMatrículasToolStripMenuItem";
            this.consultarMatrículasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.consultarMatrículasToolStripMenuItem.Text = "Consultar Matrículas";
            this.consultarMatrículasToolStripMenuItem.Click += new System.EventHandler(this.consultarMatrículasToolStripMenuItem_Click);
            // 
            // cursoToolStripMenuItem
            // 
            this.cursoToolStripMenuItem.Name = "cursoToolStripMenuItem";
            this.cursoToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cursoToolStripMenuItem.Text = "Curso";
            this.cursoToolStripMenuItem.Click += new System.EventHandler(this.cursoToolStripMenuItem_Click);
            // 
            // turmasToolStripMenuItem
            // 
            this.turmasToolStripMenuItem.Name = "turmasToolStripMenuItem";
            this.turmasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.turmasToolStripMenuItem.Text = "Turmas";
            this.turmasToolStripMenuItem.Click += new System.EventHandler(this.turmasToolStripMenuItem_Click);
            // 
            // matériasToolStripMenuItem
            // 
            this.matériasToolStripMenuItem.Name = "matériasToolStripMenuItem";
            this.matériasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.matériasToolStripMenuItem.Text = "Matérias";
            this.matériasToolStripMenuItem.Click += new System.EventHandler(this.matériasToolStripMenuItem_Click);
            // 
            // unidadeEscolarToolStripMenuItem
            // 
            this.unidadeEscolarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.professoresToolStripMenuItem});
            this.unidadeEscolarToolStripMenuItem.Name = "unidadeEscolarToolStripMenuItem";
            this.unidadeEscolarToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.unidadeEscolarToolStripMenuItem.Text = "Unidade Escolar";
            // 
            // professoresToolStripMenuItem
            // 
            this.professoresToolStripMenuItem.Name = "professoresToolStripMenuItem";
            this.professoresToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.professoresToolStripMenuItem.Text = "Professores";
            this.professoresToolStripMenuItem.Click += new System.EventHandler(this.professoresToolStripMenuItem_Click);
            // 
            // academicoToolStripMenuItem
            // 
            this.academicoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boletimEscolarToolStripMenuItem});
            this.academicoToolStripMenuItem.Name = "academicoToolStripMenuItem";
            this.academicoToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.academicoToolStripMenuItem.Text = "Academico";
            // 
            // boletimEscolarToolStripMenuItem
            // 
            this.boletimEscolarToolStripMenuItem.Name = "boletimEscolarToolStripMenuItem";
            this.boletimEscolarToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.boletimEscolarToolStripMenuItem.Text = "Boletim Escolar";
            this.boletimEscolarToolStripMenuItem.Click += new System.EventHandler(this.boletimEscolarToolStripMenuItem_Click);
            // 
            // financeiroToolStripMenuItem
            // 
            this.financeiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caixaToolStripMenuItem1,
            this.gerarMensalidadeToolStripMenuItem,
            this.caixaToolStripMenuItem});
            this.financeiroToolStripMenuItem.Name = "financeiroToolStripMenuItem";
            this.financeiroToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.financeiroToolStripMenuItem.Text = "Financeiro";
            // 
            // gerarMensalidadeToolStripMenuItem
            // 
            this.gerarMensalidadeToolStripMenuItem.Name = "gerarMensalidadeToolStripMenuItem";
            this.gerarMensalidadeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gerarMensalidadeToolStripMenuItem.Text = "Gerar Mensalidade";
            this.gerarMensalidadeToolStripMenuItem.Click += new System.EventHandler(this.gerarMensalidadeToolStripMenuItem_Click);
            // 
            // caixaToolStripMenuItem
            // 
            this.caixaToolStripMenuItem.Name = "caixaToolStripMenuItem";
            this.caixaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.caixaToolStripMenuItem.Text = "Pagar Mensalidade";
            this.caixaToolStripMenuItem.Click += new System.EventHandler(this.caixaToolStripMenuItem_Click);
            // 
            // contratosToolStripMenuItem
            // 
            this.contratosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem});
            this.contratosToolStripMenuItem.Name = "contratosToolStripMenuItem";
            this.contratosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.contratosToolStripMenuItem.Text = "Contratos";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // btn_gestaoalunos
            // 
            this.btn_gestaoalunos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_gestaoalunos.Image = ((System.Drawing.Image)(resources.GetObject("btn_gestaoalunos.Image")));
            this.btn_gestaoalunos.Location = new System.Drawing.Point(360, 46);
            this.btn_gestaoalunos.Name = "btn_gestaoalunos";
            this.btn_gestaoalunos.Size = new System.Drawing.Size(115, 112);
            this.btn_gestaoalunos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_gestaoalunos.TabIndex = 7;
            this.btn_gestaoalunos.TabStop = false;
            // 
            // btn_alunos
            // 
            this.btn_alunos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_alunos.Image = ((System.Drawing.Image)(resources.GetObject("btn_alunos.Image")));
            this.btn_alunos.Location = new System.Drawing.Point(33, 46);
            this.btn_alunos.Name = "btn_alunos";
            this.btn_alunos.Size = new System.Drawing.Size(115, 112);
            this.btn_alunos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_alunos.TabIndex = 6;
            this.btn_alunos.TabStop = false;
            // 
            // btn_Turmas
            // 
            this.btn_Turmas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Turmas.Image = ((System.Drawing.Image)(resources.GetObject("btn_Turmas.Image")));
            this.btn_Turmas.Location = new System.Drawing.Point(203, 189);
            this.btn_Turmas.Name = "btn_Turmas";
            this.btn_Turmas.Size = new System.Drawing.Size(115, 112);
            this.btn_Turmas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Turmas.TabIndex = 5;
            this.btn_Turmas.TabStop = false;
            // 
            // btn_Professores
            // 
            this.btn_Professores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Professores.Image = ((System.Drawing.Image)(resources.GetObject("btn_Professores.Image")));
            this.btn_Professores.Location = new System.Drawing.Point(203, 46);
            this.btn_Professores.Name = "btn_Professores";
            this.btn_Professores.Size = new System.Drawing.Size(115, 112);
            this.btn_Professores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Professores.TabIndex = 4;
            this.btn_Professores.TabStop = false;
            // 
            // btn_horarios
            // 
            this.btn_horarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_horarios.Image = ((System.Drawing.Image)(resources.GetObject("btn_horarios.Image")));
            this.btn_horarios.Location = new System.Drawing.Point(33, 189);
            this.btn_horarios.Name = "btn_horarios";
            this.btn_horarios.Size = new System.Drawing.Size(115, 112);
            this.btn_horarios.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_horarios.TabIndex = 3;
            this.btn_horarios.TabStop = false;
            // 
            // caixaToolStripMenuItem1
            // 
            this.caixaToolStripMenuItem1.Name = "caixaToolStripMenuItem1";
            this.caixaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.caixaToolStripMenuItem1.Text = "Caixa";
            this.caixaToolStripMenuItem1.Click += new System.EventHandler(this.caixaToolStripMenuItem1_Click);
            // 
            // F_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 367);
            this.Controls.Add(this.btn_gestaoalunos);
            this.Controls.Add(this.btn_alunos);
            this.Controls.Add(this.btn_Turmas);
            this.Controls.Add(this.btn_Professores);
            this.Controls.Add(this.btn_horarios);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masters Escolar - v1.0";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_gestaoalunos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_alunos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Turmas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Professores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_horarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Acessos;
        public System.Windows.Forms.Label lb_nomeUsuario;
        public System.Windows.Forms.Label lb_acesso;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem lToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestãoDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoUsuárioToolStripMenuItem;
        private System.Windows.Forms.PictureBox btn_horarios;
        private System.Windows.Forms.PictureBox btn_Professores;
        private System.Windows.Forms.PictureBox btn_Turmas;
        private System.Windows.Forms.PictureBox btn_alunos;
        private System.Windows.Forms.PictureBox btn_gestaoalunos;
        private System.Windows.Forms.ToolStripMenuItem secretariaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mátriculaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarMatrículasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turmasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadeEscolarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem professoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem academicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boletimEscolarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem financeiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarMensalidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matériasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contratosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caixaToolStripMenuItem1;
    }
}

