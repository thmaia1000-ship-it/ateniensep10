using Escolar.Caixa;
using Escolar.Gestão;
using Escolar.Selecionar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escolar
{
    public partial class F_Principal : Form
    {

        public F_Principal()
        {
            InitializeComponent();
            F_Login f_Login = new F_Login(this);
            f_Login.ShowDialog();

        }

        private void abreForm(int nivel, Form f)
        {
            if (Globais.logado)
            {

                if (Globais.nivel >= nivel)
                //Procedimentos
                {

                    f.Show();
                }
                else
                {
                    MessageBox.Show("Acesso não permitido","Mensagem do Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }
        private void gestãoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gestão.GestaoUsuarios f_GestaoUsuarios = new Gestão.GestaoUsuarios();
            abreForm(5, f_GestaoUsuarios);
        }


        private void novoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_NovoUsuario f_NovoUsuario = new F_NovoUsuario();
            f_NovoUsuario.Show();
        }



        private void mátriculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarTipo = "Matricula";
            F_NovoAluno f_NovoAluno = new F_NovoAluno();
            abreForm(1, f_NovoAluno);
        }

        private void consultarMatrículasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GestaoAlunos f_GestaoAlunos = new F_GestaoAlunos();
            abreForm(1, f_GestaoAlunos);
        }


        private void professoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GestaoProfessores f_GestaoProfessores = new F_GestaoProfessores();
            abreForm(1, f_GestaoProfessores);
        }


        private void gerarMensalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarTipo = "Matricula";
            F_GerarMensalidade f_GerarMensalidade = new F_GerarMensalidade();
            abreForm(1, f_GerarMensalidade);
        }

        private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_PagarMensalidade f_Caixa = new F_PagarMensalidade();
            abreForm(2, f_Caixa);
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Cursos f_Cursos = new F_Cursos();
            abreForm(1, f_Cursos);
        }

        private void matériasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Materias f_materias = new F_Materias();
            abreForm(1, f_materias);
        }


        private void caixaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_Caixa f_Caixa = new F_Caixa();
            abreForm(2, f_Caixa);
        }

        private void F_Principal_Load(object sender, EventArgs e)
        {
            if (Globais.nivel == 1)
            {
                contábilToolStripMenuItem.Visible = false;
                relatóriosToolStripMenuItem.Visible = false;
                declaraçõesToolStripMenuItem.Visible = false;
                configsToolStripMenuItem.Visible = false;
            }
            else if (Globais.nivel == 2)
            {
                contábilToolStripMenuItem.Visible = false;
                relatóriosToolStripMenuItem.Visible = false;
                declaraçõesToolStripMenuItem.Visible = false;
                configsToolStripMenuItem.Visible = false;
            } 
        }

        private void tardeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //F_FluxoCaixa f_FluxoCaixa = new F_FluxoCaixa();
            //abreForm(2, f_FluxoCaixa);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inadimplênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Inadimplencia f_Inadimplencia = new F_Inadimplencia();
            abreForm(2, f_Inadimplencia);
        }

        private void novoUsuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_NovoUsuario f_NovoUsuario = new F_NovoUsuario();
            abreForm(5, f_NovoUsuario);
        }

        private void gestãoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gestão.GestaoUsuarios f_GestaoUsuarios = new Gestão.GestaoUsuarios();
            abreForm(5, f_GestaoUsuarios);
        }

        private void logarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Login f_Login = new F_Login(this);
            f_Login.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lb_nomeUsuario.Text = "---";
            //pb_ledLogado.Image = Properties.Resources.png_transparent_light_computer_icons_menu_bar_button_macos_light_light_mac_led;
            Globais.nivel = 0;
            Globais.logado = false;
        }

        private void respFinanceiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_ResponsavelFinanceiro f_ResponsavelFinanceiro = new F_ResponsavelFinanceiro();
            abreForm(1, f_ResponsavelFinanceiro);
        }

        private void professorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GestaoProfessores f_GestaoProfessores = new F_GestaoProfessores();
            abreForm(1, f_GestaoProfessores);
        }

        private void respAcademicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_ResponsavelAcademico f_ResponsavelAcademico = new F_ResponsavelAcademico();
            abreForm(1, f_ResponsavelAcademico);
        }

        private void contratoperiodonormalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GerarContratos.F_GerarContratoNormal f_GerarContratoNormal = new GerarContratos.F_GerarContratoNormal();
            abreForm(1, f_GerarContratoNormal);
        }

        private void contratoMeioPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarContratos.F_GerarContratoMeioPeriodo f_GerarContratoMeioPeriodo = new GerarContratos.F_GerarContratoMeioPeriodo();
            abreForm(1, f_GerarContratoMeioPeriodo);
        }

        private void contratoIntegralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarContratos.F_GerarContratoIntegral f_GerarContratoIntegral = new GerarContratos.F_GerarContratoIntegral();
            abreForm(1, f_GerarContratoIntegral);
        }

        private void gerarCarnêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarContratos.F_GerarCarne f_GerarCarne = new GerarContratos.F_GerarCarne();
            abreForm(1, f_GerarCarne);
        }

        private void frenteCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Vendas f_Vendas = new F_Vendas();
            abreForm(2, f_Vendas);
        }

        private void cadastrarProdutoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            F_CadastroProdutos f_CadastroProdutos = new F_CadastroProdutos();
            abreForm(2, f_CadastroProdutos);
        }

        private void gestãoProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_GestaoProdutos f_GestaoProdutos = new F_GestaoProdutos();
            abreForm(5, f_GestaoProdutos);
        }


        private void entradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_SelecionarReciboEntrada2Via f_SelecionarReciboEntrada2Via = new F_SelecionarReciboEntrada2Via();
            abreForm(2, f_SelecionarReciboEntrada2Via);
        }

        private void saídaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_SelecionarReciboSaida2Via f_SelecionarReciboSaida2Via = new F_SelecionarReciboSaida2Via();
            abreForm(2, f_SelecionarReciboSaida2Via);
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Vendas f_Vendas = new F_Vendas();
            abreForm(2, f_Vendas);
        }

        private void alunosMatriculadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Academico.AlunosMatriculados alunosMatriculados = new Academico.AlunosMatriculados();
            abreForm(2, alunosMatriculados);
        }

        private void inadimplênciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EscolherInadimplencia f_EscolherInadimplencia = new EscolherInadimplencia();
            abreForm(2, f_EscolherInadimplencia);
        }

        private void cadastrarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_CadastroProdutos f_CadastroProdutos = new F_CadastroProdutos();
            abreForm(5, f_CadastroProdutos);
        }

        private void devoluçãoTrocaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Devolucao f_Devolucao = new F_Devolucao();
            abreForm(2, f_Devolucao);
        }

        private void mensalidadesPagasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EscolherMesMensalidadesPagas f_EscolherMesMensalidadesPagas = new EscolherMesMensalidadesPagas();
            abreForm(2, f_EscolherMesMensalidadesPagas);
        }

        private void gestãoCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gestão.F_GestaoCursos f_GestaoCursos = new Gestão.F_GestaoCursos();
            abreForm(2, f_GestaoCursos);
        }

        private void matrículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.F_MatriculaCurso f_MatriculaCurso = new Cadastros.F_MatriculaCurso();
            abreForm(2, f_MatriculaCurso);
        }

        private void receberMensalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos.F_PagarMensalidadeCurso f_PagarMensalidadeCurso = new Cursos.F_PagarMensalidadeCurso();
            abreForm(2, f_PagarMensalidadeCurso);
        }

        private void alunosMatrículadosCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Academico.F_AlunosMatriculadosCursos f_AlunosMatriculadosCursos = new Academico.F_AlunosMatriculadosCursos();
            abreForm(2, f_AlunosMatriculadosCursos);
        }

        private void aReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Mensalidades Receber";
            Selecionar.MensalidadeOuCurso mensalidades = new MensalidadeOuCurso();
            abreForm(2, mensalidades);
        }

        private void alterarRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarRegistroCaixa alterarRegistroCaixa = new AlterarRegistroCaixa();
            abreForm(5, alterarRegistroCaixa);
        }

        private void declaraçãoQuitaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarDeclaracoes = "Quitação";
            Selecionar.SelecionarAlunoDeclaracao SelecionarAluno = new Selecionar.SelecionarAlunoDeclaracao();
            abreForm(1, SelecionarAluno);
        }

        private void declaraçãoMatrículaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gerarBoletimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notas.Gerar_Boletim gerar_Boletim = new Notas.Gerar_Boletim();
            abreForm(1, gerar_Boletim);
        }

        private void lançarNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notas.Lancar_notas lancar_Notas = new Notas.Lancar_notas();
            abreForm(1, lancar_Notas);
        }


        private void declaraçãoMatrículaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Globais.Main.PassarDeclaracoes = "Matrícula";
            Selecionar.SelecionarAlunoDeclaracao SelecionarAluno = new Selecionar.SelecionarAlunoDeclaracao();
            abreForm(1, SelecionarAluno);
        }

        private void diárioOnlneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diario.SelecionarDiario Diario_online = new Diario.SelecionarDiario();
            abreForm(1, Diario_online);
        }

        private void fluxoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarTipo = "CAIXA";
            Fluxos.SelecionarDatas selecionarDatas = new Fluxos.SelecionarDatas();
            abreForm(1, selecionarDatas);
        }

        private void fluxoVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarTipo = "VENDA";
            Fluxos.SelecionarDatas selecionarDatas = new Fluxos.SelecionarDatas();
            abreForm(1, selecionarDatas);
        }

        private void adicionarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void novaTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turmas.CadastroTurma cadastroTurma = new Turmas.CadastroTurma();
            abreForm(1, cadastroTurma);
        }

        private void gestãoTurmasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }
        private void definirBimestreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bimestre.Definir_Bimestre definir_Bimestre = new Bimestre.Definir_Bimestre();
            abreForm(5, definir_Bimestre);
        }

        private void btn_professor_Click(object sender, EventArgs e)
        {
            F_GestaoProfessores f_GestaoProfessores = new F_GestaoProfessores();
            abreForm(1, f_GestaoProfessores);
        }

        private void btn_rematricula_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_matricula_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "Matricula";

            F_NovoAluno f_NovoAluno = new F_NovoAluno();
            abreForm(1, f_NovoAluno);


        }


        private void diarioDeClasseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Faltas.GerarDiarioClasse gerarDiarioClasse = new Faltas.GerarDiarioClasse();
            abreForm(1, gerarDiarioClasse);
        }

        private void despesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DRE.Despesas despesas = new DRE.Despesas();
            abreForm(5, despesas);
        }

        private void relatórioDREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DRE.Relatorio_DRE relatorio_DRE = new DRE.Relatorio_DRE();
            relatorio_DRE.Show();
        }

        private void despesasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DRE.Despesas despesas = new DRE.Despesas();
            abreForm(3, despesas);
        }

        private void dREGerencialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DRE.Relatorio_DRE dre = new DRE.Relatorio_DRE();
            abreForm(3, dre);
        }

        private void gestãoDiárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Faltas.GestaoFaltas gestaoFaltas = new Faltas.GestaoFaltas();
            abreForm(2, gestaoFaltas);
        }

        private void guiaTransferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "TRANSF";
            declaracoes.selecionar.selecionarAluno transferencia = new declaracoes.selecionar.selecionarAluno();
            abreForm(2, transferencia);
        }

        private void matriculaButton_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarPlanoContrato = "Matricula2026";
            Mensalidades.DialogMatricula  dialog= new Mensalidades.DialogMatricula();
            abreForm(1, dialog);

        }

        private void rematriculaButton_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarPlanoContrato = "Rematricula";
            F_GerarMensalidade rematricula = new F_GerarMensalidade();
            abreForm(2, rematricula);
        }

        private void declaraçãoComparecimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Globais.Main.Modo = "COMP";
            declaracoes.selecionar.selecionarAluno comp = new declaracoes.selecionar.selecionarAluno();
            abreForm(2, comp);

        }

        private void declaraçãoFrequênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globais.Main.Modo = "FREQ";
            declaracoes.selecionar.selecionarAluno freq = new declaracoes.selecionar.selecionarAluno();
            abreForm(2, freq);
        }

        private void termoDeRespToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarContratos.F_GerarTermo termo = new GerarContratos.F_GerarTermo();
            abreForm(2, termo);
        }

        private void gestãoTurmasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turmas.AdicionarAluno adicionarAluno = new Turmas.AdicionarAluno();
            abreForm(1, adicionarAluno);
        }

        private void Button2027_Click(object sender, EventArgs e)
        {
            Globais.Main.PassarPlanoContrato = "Matricula2027";
            Mensalidades.DialogMatricula dialog = new Mensalidades.DialogMatricula();
            abreForm(1, dialog);
        }

        private void recisãoContratualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            declaracoes.selecionar.SelecionarAlunoRecisao selecionar = new declaracoes.selecionar.SelecionarAlunoRecisao();
            abreForm(1, selecionar);
        }

        private void parecerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notas.Selecionar.SelecionarParecer selecionar = new Notas.Selecionar.SelecionarParecer();
            abreForm(1, selecionar);
        }
    }
}
