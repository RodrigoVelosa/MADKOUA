using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MADKOUA_BD;
using MADKOUA_LOG;

namespace MADKOUA
{
    class Requisitante : ItemBD
    {
        private Logger FicheiroLog = new Logger(new FicheiroRecorder());

        public Requisitante() { }

        public Requisitante(int id) { ID = id; }

        //Propriedades. Cada uma corresponde a uma coluna na tabela Requisitante da base de dados
        public int ID 
        {
            get { return ID; }
            //Quando ocorre um set no ID, o resto das propriedades atualizam para que cada uma guarde o valor
            //que está na base de dados associado ao id passado.
            set
            {
                DataTable DT = ComunicacaoBD.Lista("Requisitante", "ID", value.ToString());
                try
                {
                    Nome = DT.Rows[0].Field<String>("Nome");
                    CodigoUtilizador = DT.Rows[0].Field<String>("CodigoUtilizador");
                    Password = DT.Rows[0].Field<String>("Password");
                }
                catch(IndexOutOfRangeException e)
                {
                    FicheiroLog.Log(DateTime.Now + ": " + e.Message + " Classe Requisitante. Propriedade ID (set)");
                }

            }
        }
        public String Nome { set; get; }
        public String CodigoUtilizador { set; get; }
        public String Password { set; get; }

        //Método que adiciona este requisitante a base de dados
        public void AdicionaBD()
        {
            String Colunas = "Nome, CodigoUtilizador, Password";
            String Valores = "'" + Nome + "','" + CodigoUtilizador + "','" + Password + "'";
            ComunicacaoBD.Adiciona("Requisitante", Colunas, Valores);
        }

        public void SetByCodigoUtilizador(String CodigoUtilizador)
        {
            DataTable DT = ComunicacaoBD.Lista("Requisitante", "CodigoUtilizador", CodigoUtilizador);
            try
            {
                ID = DT.Rows[0].Field<Int32>("ID");
                Nome = DT.Rows[0].Field<String>("Nome");
                Password = DT.Rows[0].Field<String>("Password");
            }
            catch (IndexOutOfRangeException e)
            {
                FicheiroLog.Log(DateTime.Now + ": " + e.Message + " Classe Requisitante. Propriedade CodigoUtilizador (set)");
            }
        }

        #region "Métodos estáticos"
        //Este método elimina o requisitante com o ID Requisitante_ID
        public static void EliminaRequisitante(int Requisitante_ID)
        {
            ComunicacaoBD.Elimina("Requisitante", Requisitante_ID);
        }

        //Este método devolve uma tabela com todos os requisitantes
        public static DataTable ListaRequisitantes()
        {
            return ComunicacaoBD.Lista("Requisitante");
        }

        //Este método devolve uma tabela com todos os requisitantes em que Coluna = Expressao
        public static DataTable ListaRequisitantes(String Coluna, String Expressao)
        {
            return ComunicacaoBD.Lista("Requisitante", Coluna, Expressao);
        }

        //Este método muda o nome do requisitante com Requisitante_ID para novo nome
        public static void MudaNome(int Requisitante_ID, String NovoNome)
        {
            ComunicacaoBD.AlteraValor("Requisitante", "Nome", Requisitante_ID, NovoNome);
        }

        //Este método muda o CodigoUtilizador do Requisitante com Requisitante_ID para NovoCodigoUtilizador
        public static void MudaCodigoUtilizador(int Requisitante_ID, String NovoCodigoUtilizador)
        {
            ComunicacaoBD.AlteraValor("Requisitante", "CodigoUtilizador", Requisitante_ID, NovoCodigoUtilizador);
        }

        //Este método muda a password do requisitante com Requisitante_ID para NovaPassword
        public static void MudaPassword(int Requisitante_ID, String NovaPassword)
        {
            ComunicacaoBD.AlteraValor("Requisitante", "Password", Requisitante_ID, NovaPassword);
        }

        public static bool Verifica(String CodigoUtilizador, String Password)
        {
            DataTable DT = ListaRequisitantes("CodigoUtilizador", CodigoUtilizador);
            return Password == DT.Rows[0].Field<String>("Password");
        }
        #endregion
    }
}
