using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MADKOUA_BD;

namespace MADKOUA
{
    class Requisitante : ItemBD
    {
        public Requisitante() { }

        public Requisitante(int id) { ID = id; }

        public int ID
        {
            get { return ID; }

            set
            {
                DataTable DT = ComunicacaoBD.ListaProcura("Requisitante", "ID", value.ToString());
                Nome = DT.Rows[0].Field<String>("Nome");
                CodigoUtilizador = DT.Rows[0].Field<String>("CodigoUtilizador");
                Password = DT.Rows[0].Field<String>("Password");
            }
        }
        public String Nome { set; get; }
        public String CodigoUtilizador { set; get; }
        public String Password { set; get; }

        public void AdicionaBD()
        {
            String Colunas = "Nome, CodigoUtilizador, Password";
            String Valores = "'" + Nome + "','" + CodigoUtilizador + "','" + Password + "'";
            ComunicacaoBD.Adiciona("Requisitante", Colunas, Valores);
        }

        public static void EliminaRequisitante(int Requisitante_ID)
        {
            ComunicacaoBD.Elimina("Requisitante", Requisitante_ID);
        }

        public static DataTable ListaRequisitantes()
        {
            return ComunicacaoBD.Lista("Requisitante");
        }

        public static DataTable ListaRequisitantes(String Coluna, String Expressao)
        {
            return ComunicacaoBD.ListaProcura("Requisitante", Coluna, Expressao);
        }


        public static void MudaNome(int ID, String NovoNome)
        {
            ComunicacaoBD.AlteraValor("Requisitante", "Nome", ID, NovoNome);
        }

        public static void MudaCodigoUtilizador(int ID, String NovoCodigoUtilizador)
        {
            ComunicacaoBD.AlteraValor("Requisitante", "CodigoUtilizador", ID, NovoCodigoUtilizador);
        }

        public static void MudaPassword(int ID, String NovaPassword)
        {
            ComunicacaoBD.AlteraValor("Requisitante", "Password", ID, NovaPassword);
        }
    }
}
