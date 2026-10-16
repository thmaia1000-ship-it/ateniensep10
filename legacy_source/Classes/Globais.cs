using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escolar
{
  
    internal class Globais
    {
        public class Main
        {
            public static string PassarUsuario { get; set; }

            public static string PassarAluno { get; set; }

            public static string PassarIdAluno { get; set; }
            public static string PassarIDTurma1 { get; set; }
            public static string PassarIDTurma2 { get; set; }

            public static string PassarParcelas { get; set; }

            public static string PassarCaixa { get; set; }
            public static string PassarDesc { get; set; }
            public static string PassarAno { get; set; }
            public static string PassarMes { get; set; }
            public static string PassarCurso { get; set; }
            public static string PassarForma { get; set; }
            public static string PassarForma1 { get; set; }
            public static string PassarForma2 { get; set; }
            public static string Modo { get; set; }
            public static string PassarIdCaixa { get; set; }
            public static string PassarCodigoVenda { get; set; }
            public static string PassarPagante { get; set; }
            public static string PassarObs { get; set; }
            public static string PassarData { get; set; }

            public static string PassarData1 { get; set; }

            public static string PassarData2 { get; set; }
            public static string PassarHorario { get; set; }

            public static string PassarID_Mensalidade { get; set; }
            public static string PassarIdCarteira { get; set; }
            public static string PassarMensalidades_paga { get; set; }

            public static string PassarDeclaracoes { get; set; }
            
            public static string PassarIDDiario { get; set; }

            public static string PassarPlanoContrato { get; set; }

            public static string PassarTipo { get; set; }

            public static string Estuda { get; set; }
            public static string Cursa { get; set; }

            public static string PassarEtapa { get; set; }

            //notas
            public static int PassarIDEtapa { get; set; }
            public static int PassarBimestre { get; set; }

            public static string PassarContrato { get; set; }

            public static string TipoRecibo { get; set; }

            public static string PassarRespAcad { get; set; }

            public static string PassarNomeCurso { get; set; }
        }

        public static string versao="1.0";
        public static Boolean logado=false;
        public static int nivel=0; //1 = comun // 2= gerente // 3= master
        //public static string caminho = System.Environment.CurrentDirectory;
        public static string caminho = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        //public static string nomeBanco = "banco_escolar.db";
        //public static string caminhoBanco = caminho + @"\banco\";
        //public static string caminhoFotos = caminho + @"\fotos\";
        

    }
}
