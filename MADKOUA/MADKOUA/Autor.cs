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
    class Autor : ItemBD
    {
        private Logger FicheiroLog = new Logger(new FicheiroRecorder());

        public Autor() { }

        public Autor(int id) { ID = id; }

        public int ID
        {
            get { return ID; }
            set
            {
                DataTable DT = ComunicacaoBD.Lista("Autor", "ID", value.ToString());
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



        public void AdicionaBD()
        {
            String Colunas = "Nome, Apelido";
            String Valores = "'" + Nome + "','" + Apelido + "'";
            ComunicacaoBD.Adiciona("Autor", Colunas, Valores);
        }
        
        public static void EliminaAutor(int Autor_ID)
        {
            ComunicacaoBD.Elimina("Autor", Autor_ID);
        }
        public static DataTable ListaAutores()
        {
            return ComunicacaoBD.Lista("Autor");
        }

        public static DataTable ListaAutores(String Coluna, String Expressao)
        {
            return ComunicacaoBD.Lista("Autor", Coluna, Expressao);
        }
        
        public static void MudaNome(int ID, String NovoNome)
        {
            ComunicacaoBD.AlteraValor("Autor", "Nome", ID, NovoNome);
        }

        public static void MudaApelido(int ID, String NovoApelido)
        {
            ComunicacaoBD.AlteraValor("Autor", "Apelido", ID, NovoApelido);
        }
    }
}
