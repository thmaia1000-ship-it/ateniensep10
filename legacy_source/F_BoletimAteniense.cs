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
    public partial class F_BoletimAteniense : Form
    {
        F_ImprimirBoletim f_ImprimirBoletim; 
        public F_BoletimAteniense(F_ImprimirBoletim f)
        {
            InitializeComponent();
            f_ImprimirBoletim = f;
        }

        private void F_BoletimAteniense_Load_1(object sender, EventArgs e)
        {
            Globais.Main.PassarIdAluno = f_ImprimirBoletim.dgv_SelecionarAluno.Rows[0].Cells[0].Value.ToString();
            Globais.Main.PassarAno = f_ImprimirBoletim.dgv_SelecionarAluno.Rows[0].Cells[2].Value.ToString();
            var vcon = Banco.ConexaoBanco();
            string Aluno = String.Format(@"
            SELECT 
            tba.nome_aluno,
            tba.turno,
            tba.etapa,
            tbn.ano_letivo,
            tbn.professor
            FROM tb_alunos as tba, tb_notas as tbn 
            WHERE tbn.idaluno={0} AND tba.ID_aluno={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarIdAluno);

            DataTable aluno = Banco.dql(Aluno);
            vcon.Close();

            string Nome_aluno = aluno.Rows[0].Field<string>("nome_aluno");
            string turno = aluno.Rows[0].Field<string>("turno");
            string serie = aluno.Rows[0].Field<string>("etapa");
            string ano_letivo = aluno.Rows[0].Field<string>("ano_letivo");
            string nome_professor = aluno.Rows[0].Field<string>("professor");

            Boletim_Ateniense1.SetParameterValue("nome_aluno", Nome_aluno.ToUpper());
            Boletim_Ateniense1.SetParameterValue("turno", turno.ToUpper());
            Boletim_Ateniense1.SetParameterValue("serie", serie.ToUpper());
            Boletim_Ateniense1.SetParameterValue("ano_letivo", ano_letivo);
            Boletim_Ateniense1.SetParameterValue("professor", nome_professor);

            vcon = Banco.ConexaoBanco();
            string Portugues = String.Format(@"
            SELECT 
            nota1,
            nota2,
            nota3,
            nota4,
            recuperacao,
            media_final
            FROM tb_notas
            WHERE idmateria = 1 AND idaluno={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable portugues = Banco.dql(Portugues);
            vcon.Close();

            if(portugues.Rows.Count > 0)
            {
                string PortuguesMedia1 = portugues.Rows[0].Field<string>("nota1");
                string PortuguesMedia2 = portugues.Rows[0].Field<string>("nota2");
                string PortuguesMedia3 = portugues.Rows[0].Field<string>("nota3");
                string PortuguesMedia4 = portugues.Rows[0].Field<string>("nota4");
                string PortuguesRecuperacao = portugues.Rows[0].Field<string>("recuperacao");
                string PortuguesMediaFinal = portugues.Rows[0].Field<string>("media_final");

                if (PortuguesMedia1 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Portugues_media1", Convert.ToDecimal(PortuguesMedia1).ToString("F"));
                }
                if (PortuguesMedia2 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Portugues_media2", Convert.ToDecimal(PortuguesMedia2).ToString("F"));
                }
                if (PortuguesMedia3 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Portugues_media3", Convert.ToDecimal(PortuguesMedia3).ToString("F"));
                }
                if (PortuguesMedia4 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Portugues_media4", Convert.ToDecimal(PortuguesMedia4).ToString("F"));
                }
                if (PortuguesRecuperacao != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Portugues_rec", Convert.ToDecimal(PortuguesRecuperacao).ToString("F"));
                }
                if (PortuguesMediaFinal != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Portugues_mediaFinal", Convert.ToDecimal(PortuguesMediaFinal).ToString("F"));
                }
            }

            vcon = Banco.ConexaoBanco();
            string Historia = String.Format(@"
            SELECT 
            nota1,
            nota2,
            nota3,
            nota4,
            recuperacao,
            media_final
            FROM tb_notas
            WHERE idmateria = 2 AND idaluno={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable historia = Banco.dql(Historia);
            vcon.Close();

            if (historia.Rows.Count > 0)
            {
                string HistoriaMedia1 = historia.Rows[0].Field<string>("nota1");
                string HistoriaMedia2 = historia.Rows[0].Field<string>("nota2");
                string HistoriaMedia3 = historia.Rows[0].Field<string>("nota3");
                string HistoriaMedia4 = historia.Rows[0].Field<string>("nota4");
                string HistoriaRecuperacao = historia.Rows[0].Field<string>("recuperacao");
                string HistoriaMediaFinal = historia.Rows[0].Field<string>("media_final");

                if (HistoriaMedia1 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Historia_media1", Convert.ToDecimal(HistoriaMedia1).ToString("F"));
                }
                if (HistoriaMedia2 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Historia_media2", Convert.ToDecimal(HistoriaMedia2).ToString("F"));
                }
                if (HistoriaMedia3 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Historia_media3", Convert.ToDecimal(HistoriaMedia3).ToString("F"));
                }
                if (HistoriaMedia4 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Historia_media4", Convert.ToDecimal(HistoriaMedia4).ToString("F"));
                }
                if (HistoriaRecuperacao != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Historia_rec", Convert.ToDecimal(HistoriaRecuperacao).ToString("F"));
                }
                if (HistoriaMediaFinal != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Historia_mediaFinal", Convert.ToDecimal(HistoriaMediaFinal).ToString("F"));
                }

            }

            vcon = Banco.ConexaoBanco();
            string Geografia = String.Format(@"
            SELECT 
            nota1,
            nota2,
            nota3,
            nota4,
            recuperacao,
            media_final
            FROM tb_notas
            WHERE idmateria = 3 AND idaluno={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable geografia = Banco.dql(Geografia);
            vcon.Close();

            if (geografia.Rows.Count > 0)
            {

                string GeografiaMedia1 = geografia.Rows[0].Field<string>("nota1");
                string GeografiaMedia2 = geografia.Rows[0].Field<string>("nota2");
                string GeografiaMedia3 = geografia.Rows[0].Field<string>("nota3");
                string GeografiaMedia4 = geografia.Rows[0].Field<string>("nota4");
                string GeografiaRecuperacao = geografia.Rows[0].Field<string>("recuperacao");
                string GeografiaMediaFinal = geografia.Rows[0].Field<string>("media_final");

                if (GeografiaMedia1 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Geografia_media1", Convert.ToDecimal(GeografiaMedia1).ToString("F"));
                }
                if (GeografiaMedia2 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Geografia_media2", Convert.ToDecimal(GeografiaMedia2).ToString("F"));
                }
                if (GeografiaMedia3 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Geografia_media3", Convert.ToDecimal(GeografiaMedia3).ToString("F"));
                }
                if (GeografiaMedia4 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Geografia_media4", Convert.ToDecimal(GeografiaMedia4).ToString("F"));
                }
                if (GeografiaRecuperacao != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Geografia_rec", Convert.ToDecimal(GeografiaRecuperacao).ToString("F"));
                }
                if (GeografiaMediaFinal != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Geografia_mediaFinal", Convert.ToDecimal(GeografiaMediaFinal).ToString("F"));
                }
            }
            vcon = Banco.ConexaoBanco();
            string Ciencias = String.Format(@"
            SELECT 
            nota1,
            nota2,
            nota3,
            nota4,
            recuperacao,
            media_final
            FROM tb_notas
            WHERE idmateria = 4 AND idaluno={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable ciencias = Banco.dql(Ciencias);
            vcon.Close();

            if (ciencias.Rows.Count > 0)
            {

                string CienciasMedia1 = ciencias.Rows[0].Field<string>("nota1");
                string CienciasMedia2 = ciencias.Rows[0].Field<string>("nota2");
                string CienciasMedia3 = ciencias.Rows[0].Field<string>("nota3");
                string CienciasMedia4 = ciencias.Rows[0].Field<string>("nota4");
                string CienciasRecuperacao = ciencias.Rows[0].Field<string>("recuperacao");
                string CienciasMediaFinal = ciencias.Rows[0].Field<string>("media_final");

                if (CienciasMedia1 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Ciencias_media1", Convert.ToDecimal(CienciasMedia1).ToString("F"));
                }
                if (CienciasMedia2 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Ciencias_media2", Convert.ToDecimal(CienciasMedia2).ToString("F"));
                }
                if (CienciasMedia3 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Ciencias_media3", Convert.ToDecimal(CienciasMedia3).ToString("F"));
                }
                if (CienciasMedia4 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Ciencias_media4", Convert.ToDecimal(CienciasMedia4).ToString("F"));
                }
                if (CienciasRecuperacao != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Ciencias_rec", Convert.ToDecimal(CienciasRecuperacao).ToString("F"));
                }
                if (CienciasMediaFinal != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Ciencias_mediaFinal", Convert.ToDecimal(CienciasMediaFinal).ToString("F"));
                }
            }
            vcon = Banco.ConexaoBanco();
            string Matematica = String.Format(@"
            SELECT 
            nota1,
            nota2,
            nota3,
            nota4,
            recuperacao,
            media_final
            FROM tb_notas
            WHERE idmateria = 5 AND idaluno={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable matematica = Banco.dql(Matematica);
            vcon.Close();

            if (matematica.Rows.Count > 0)
            {
                string MatematicaMedia1 = matematica.Rows[0].Field<string>("nota1");
                string MatematicaMedia2 = matematica.Rows[0].Field<string>("nota2");
                string MatematicaMedia3 = matematica.Rows[0].Field<string>("nota3");
                string MatematicaMedia4 = matematica.Rows[0].Field<string>("nota4");
                string MatematicaRecuperacao = matematica.Rows[0].Field<string>("recuperacao");
                string MatematicaMediaFinal = matematica.Rows[0].Field<string>("media_final");

                if (MatematicaMedia1 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Matematica_media1", Convert.ToDecimal(MatematicaMedia1).ToString("F"));
                }
                if (MatematicaMedia2 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Matematica_media2", Convert.ToDecimal(MatematicaMedia2).ToString("F"));
                }
                if (MatematicaMedia3 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Matematica_media3", Convert.ToDecimal(MatematicaMedia3).ToString("F"));
                }
                if (MatematicaMedia4 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Matematica_media4", Convert.ToDecimal(MatematicaMedia4).ToString("F"));
                }
                if (MatematicaRecuperacao != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Matematica_rec", Convert.ToDecimal(MatematicaRecuperacao).ToString("F"));
                }
                if (MatematicaMediaFinal != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Matematica_mediaFinal", Convert.ToDecimal(MatematicaMediaFinal).ToString("F"));
                }
            }
            vcon = Banco.ConexaoBanco();
            string Artes = String.Format(@"
            SELECT 
            nota1,
            nota2,
            nota3,
            nota4,
            recuperacao,
            media_final
            FROM tb_notas
            WHERE idmateria = 6 AND idaluno={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable artes = Banco.dql(Artes);
            vcon.Close();

            if (artes.Rows.Count > 0)
            {
                string ArtesMedia1 = artes.Rows[0].Field<string>("nota1");
                string ArtesMedia2 = artes.Rows[0].Field<string>("nota2");
                string ArtesMedia3 = artes.Rows[0].Field<string>("nota3");
                string ArtesMedia4 = artes.Rows[0].Field<string>("nota4");
                string ArtesRecuperacao = artes.Rows[0].Field<string>("recuperacao");
                string ArtesMediaFinal = artes.Rows[0].Field<string>("media_final");

                if (ArtesMedia1 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Artes_media1", Convert.ToDecimal(ArtesMedia1).ToString("F"));
                }
                if (ArtesMedia2 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Artes_media2", Convert.ToDecimal(ArtesMedia2).ToString("F"));
                }
                if (ArtesMedia3 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Artes_media3", Convert.ToDecimal(ArtesMedia3).ToString("F"));
                }
                if (ArtesMedia4 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Artes_media4", Convert.ToDecimal(ArtesMedia4).ToString("F"));
                }
                if (ArtesRecuperacao != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Artes_rec", Convert.ToDecimal(ArtesRecuperacao).ToString("F"));
                }
                if (ArtesMediaFinal != "")
                {
                    Boletim_Ateniense1.SetParameterValue("Artes_mediaFinal", Convert.ToDecimal(ArtesMediaFinal).ToString("F"));
                }

            }

            vcon = Banco.ConexaoBanco();
            string EdFisica = String.Format(@"
            SELECT 
            nota1,
            nota2,
            nota3,
            nota4,
            recuperacao,
            media_final
            FROM tb_notas
            WHERE idmateria = 7 AND idaluno={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable edFisica = Banco.dql(EdFisica);
            vcon.Close();

            if (edFisica.Rows.Count > 0)
            {

                string EdFisicaMedia1 = edFisica.Rows[0].Field<string>("nota1");
                string EdFisicaMedia2 = edFisica.Rows[0].Field<string>("nota2");
                string EdFisicaMedia3 = edFisica.Rows[0].Field<string>("nota3");
                string EdFisicaMedia4 = edFisica.Rows[0].Field<string>("nota4");
                string EdFisicaRecuperacao = edFisica.Rows[0].Field<string>("recuperacao");
                string EdFisicaMediaFinal = edFisica.Rows[0].Field<string>("media_final");

                if (EdFisicaMedia1 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("EdFisica_media1", Convert.ToDecimal(EdFisicaMedia1).ToString("F"));
                }
                if (EdFisicaMedia2 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("EdFisica_media2", Convert.ToDecimal(EdFisicaMedia2).ToString("F"));
                }
                if (EdFisicaMedia3 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("EdFisica_media3", Convert.ToDecimal(EdFisicaMedia3).ToString("F"));
                }
                if (EdFisicaMedia4 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("EdFisica_media4", Convert.ToDecimal(EdFisicaMedia4).ToString("F"));
                }
                if (EdFisicaRecuperacao != "")
                {
                    Boletim_Ateniense1.SetParameterValue("EdFisica_rec", Convert.ToDecimal(EdFisicaRecuperacao).ToString("F"));
                }
                if (EdFisicaMediaFinal != "")
                {
                    Boletim_Ateniense1.SetParameterValue("EdFisica_mediaFinal", Convert.ToDecimal(EdFisicaMediaFinal).ToString("F"));
                }
            }
            vcon = Banco.ConexaoBanco();
            string LiEstrangeira = String.Format(@"
            SELECT 
            nota1,
            nota2,
            nota3,
            nota4,
            recuperacao,
            media_final
            FROM tb_notas
            WHERE idmateria = 8 AND idaluno={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable liEstrangeira = Banco.dql(LiEstrangeira);
            vcon.Close();

            if (liEstrangeira.Rows.Count > 0)
            {

                string LiEstrangeiraMedia1 = liEstrangeira.Rows[0].Field<string>("nota1");
                string LiEstrangeiraMedia2 = liEstrangeira.Rows[0].Field<string>("nota2");
                string LiEstrangeiraMedia3 = liEstrangeira.Rows[0].Field<string>("nota3");
                string LiEstrangeiraMedia4 = liEstrangeira.Rows[0].Field<string>("nota4");
                string LiEstrangeiraRecuperacao = liEstrangeira.Rows[0].Field<string>("recuperacao");
                string LiEstrangeiraMediaFinal = liEstrangeira.Rows[0].Field<string>("media_final");

                if (LiEstrangeiraMedia1 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("LiEstrangeira_media1", Convert.ToDecimal(LiEstrangeiraMedia1).ToString("F"));
                }
                if (LiEstrangeiraMedia2 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("LiEstrangeira_media2", Convert.ToDecimal(LiEstrangeiraMedia2).ToString("F"));
                }
                if (LiEstrangeiraMedia3 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("LiEstrangeira_media3", Convert.ToDecimal(LiEstrangeiraMedia3).ToString("F"));
                }
                if (LiEstrangeiraMedia4 != "")
                {
                    Boletim_Ateniense1.SetParameterValue("LiEstrangeira_media4", Convert.ToDecimal(LiEstrangeiraMedia4).ToString("F"));
                }
                if (LiEstrangeiraRecuperacao != "")
                {
                    Boletim_Ateniense1.SetParameterValue("LiEstrangeira_rec", Convert.ToDecimal(LiEstrangeiraRecuperacao).ToString("F"));
                }
                if (LiEstrangeiraMediaFinal != "")
                {
                    Boletim_Ateniense1.SetParameterValue("LiEstrangeira_mediaFinal", Convert.ToDecimal(LiEstrangeiraMediaFinal).ToString("F"));
                }
            }

            vcon = Banco.ConexaoBanco();
            string Faltas = String.Format(@"
            SELECT 
            IFNULL(NULLIF(faltas1, '' ), 0) as faltas1,
            IFNULL(NULLIF(faltas2, '' ), 0) as faltas2,
            IFNULL(NULLIF(faltas3, '' ), 0) as faltas3,
            IFNULL(NULLIF(faltas4, '' ), 0) as faltas4
            FROM tb_faltas
            WHERE idaluno={0} AND ano_letivo={1}", Globais.Main.PassarIdAluno, Globais.Main.PassarAno);

            DataTable faltas = Banco.dql(Faltas);
            vcon.Close();
            


            if (faltas.Rows.Count > 0)
            {
                string Falta1 = faltas.Rows[0].Field<string>("faltas1");
                string Falta2 = faltas.Rows[0].Field<string>("faltas2");
                string Falta3 = faltas.Rows[0].Field<string>("faltas3");
                string Falta4 = faltas.Rows[0].Field<string>("faltas4");

               
                   
                    int n_Faltas1 = Convert.ToInt32(Falta1);
                    int n_Faltas2 = Convert.ToInt32(Falta2);
                    int n_Faltas3 = Convert.ToInt32(Falta3);
                    int n_Faltas4 = Convert.ToInt32(Falta4);
                    int TotalFaltas = n_Faltas1 + n_Faltas2 + n_Faltas3 + n_Faltas4;


                Boletim_Ateniense1.SetParameterValue("Faltas1", Falta1.ToString());
                Boletim_Ateniense1.SetParameterValue("Faltas2", Falta2.ToString());
                Boletim_Ateniense1.SetParameterValue("Faltas3", Falta3.ToString());
                Boletim_Ateniense1.SetParameterValue("Faltas4", Falta4.ToString());
                Boletim_Ateniense1.SetParameterValue("Total_Faltas", TotalFaltas.ToString());
                
                

            }

        }

       
    }
}
