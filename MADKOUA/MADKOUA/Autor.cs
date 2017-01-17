using MADKOUA_BD;
using MADKOUA_LOG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA
{
    public class Autor : ItemBD
    {
        private Logger FicheiroLog = new Logger(new FicheiroRecorder());

        public Autor() { }

        public Autor(int id) { ID = id; }

        private int id;

        //Propriedades da classe. Cada propriedade corresponde a uma coluna na tabela Autor da base de dados
        public int ID 
        {
            get { return id; }
            //Quando ocorre um set no ID, o resto das propriedades atualizam para que cada uma guarde o valor
            //que está na base de dados associado ao id passado.
            set
            {
                id = value;
                DataTable DT = ComunicacaoBD.Instance.Lista("Autor", "ID", value.ToString());
                try
                {
                    Nome = DT.Rows[0].Field<String>("Nome");
                    Apelido = DT.Rows[0].Field<String>("Apelido");
                }
                catch(IndexOutOfRangeException e)
                {
                    FicheiroLog.Log(DateTime.Now + ": " + e.Message + " Classe Autor. Propriedade ID (set)");
                }

            }
        }
        public String Nome {set; get;}
        public String Apelido {set; get;}

        //Este método adiciona este autor à base de dados
        public void AdicionaBD()
        {
            String Colunas = "Nome, Apelido";
            String Valores = "'" + Nome + "','" + Apelido + "'";
            ComunicacaoBD.Instance.Adiciona("Autor", Colunas, Valores);
        }

        #region "Métodos estáticos"
        //Este método elimina o autor com o ID Autor_ID
        public static void EliminaAutor(int Autor_ID)
        {
            ComunicacaoBD.Instance.Elimina("Autor", Autor_ID);
        }

        //Este método devolve uma tabela com todos os autores
        public static DataTable ListaAutores()
        {
            return ComunicacaoBD.Instance.Lista("Autor");
        }

        //Este método devolve uma tabela com todos os autores em que Coluna = Expressao
        public static DataTable ListaAutores(String Coluna, String Expressao)
        {
            return ComunicacaoBD.Instance.Lista("Autor", Coluna, Expressao);
        }

        //Este método muda o nome do Autor que tem o Autor_ID para NovoNome
        public static void MudaNome(int Autor_ID, String NovoNome)
        {
            ComunicacaoBD.Instance.AlteraValor("Autor", "Nome", Autor_ID, NovoNome);
        }

        //Este método muda o Apelido que tem o Autor_ID para NovoApelido
        public static void MudaApelido(int Autor_ID, String NovoApelido)
        {
            ComunicacaoBD.Instance.AlteraValor("Autor", "Apelido", Autor_ID, NovoApelido);
        }
        #endregion
    }
}
