using MADKOUA_BD;
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
        public Autor() { }

        public Autor(int id) { ID = id; }

        public int ID
        {
            get { return ID; }
            set
            {
                DataTable DT = ComunicacaoBD.ListaProcura("Autor", "ID", value.ToString());
                Nome = DT.Rows[0].Field<String>("Nome");
                Apelido = DT.Rows[0].Field<String>("Apelido");
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
            return ComunicacaoBD.ListaProcura("Autor", Coluna, Expressao);
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
