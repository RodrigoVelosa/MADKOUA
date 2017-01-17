using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MADKOUA_BD;
using MADKOUA_LOG;

namespace MADKOUA
{
    public class Editora : ItemBD
    {

        private Logger FicheiroLog = new Logger(new FicheiroRecorder());
        
        public Editora() { }

        public Editora(int id) { ID = id; }

        private int id;

        //Propriedades. Cada uma corresponde a uma coluna da tabela Editora na base de dados.
        public int ID 
        {
            get
            {
                return id;
            }
            //Quando ocorre um set no ID, o resto das propriedades atualizam para que cada uma guarde o valor
            //que está na base de dados associado ao id passado.
            set
            {
                id = value;
                DataTable DT = ComunicacaoBD.Instance.Lista("Editora", "ID", value.ToString());
                try
                {
                    Nome = DT.Rows[0].Field<String>("Nome");
                    Morada = DT.Rows[0].Field<String>("Morada");
                }
                catch(IndexOutOfRangeException e)
                {
                    FicheiroLog.Log(DateTime.Now + ": " + e.Message + " Classe Editora. Propriedade ID (set)");
                }
            }
        }
        public String Nome { set; get; }
        public String Morada { set; get; }


        public static readonly String ColunaNome = "Nome";
        public static readonly String ColunaMorada = "Morada";


        //Este método adiciona esta editora a base de dados
        public void AdicionaBD()
        {
            String Colunas = "Nome, Morada";
            String Valores = "'" + Nome + "', '" + Morada + "'";
            ComunicacaoBD.Instance.Adiciona("Editora", Colunas, Valores);
        }

        #region "Métodos estáticos"
        //Este método elimina a editora que tem o id Editora_ID
        public static void EliminaEditora(int Editora_ID)
        {
            ComunicacaoBD.Instance.Elimina("Editora", Editora_ID);
        }

        //Este método devolve uma tabela com todas Editoras que tem na base de dados
        public static DataTable ListaEditoras()
        {
            return ComunicacaoBD.Instance.Lista("Editora");
        }
        
        //Este método devolve uma tabela com todas as Editoras em que Coluna = Expressao
        public static DataTable ListaEditoras(String Coluna, String Expressao)
        {
            return ComunicacaoBD.Instance.Lista("Editora", Coluna, Expressao);
        }

        //Este método muda o nome da Editora que tem o ID Editora_ID para NovoNome
        public static void MudaNome(int Editora_ID, String NovoNome)
        {
            ComunicacaoBD.Instance.AlteraValor("Editora", "Nome", Editora_ID, NovoNome);
        }

        //Este método muda a morada da Editora que tem o id Editora_ID para NovaMorada
        public static void MudaMorada(int Editora_ID, String NovaMorada)
        {
            ComunicacaoBD.Instance.AlteraValor("Editora", "Morada", Editora_ID, NovaMorada);
        }
        #endregion
    }
}
