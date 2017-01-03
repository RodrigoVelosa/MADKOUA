using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MADKOUA_BD;

namespace MADKOUA
{
    class Editora : ItemBD
    {
        public Editora() { }

        public Editora(int id) { ID = id; }

        public int ID
        {
            get
            {
                return ID;
            }
            set
            {
                DataTable DT = ComunicacaoBD.ListaProcura("Editora", "ID", value.ToString());
                Nome = DT.Rows[0].Field<String>("Nome");
                Morada = DT.Rows[0].Field<String>("Morada");
            }
        }

        public String Nome { set; get; }
        public String Morada { set; get; }


        public void AdicionaBD()
        {
            String Colunas = "Nome, Morada";
            String Valores = "'" + Nome + "', '" + Morada + "'";
            ComunicacaoBD.Adiciona("Editora", Colunas, Valores);
        }


        public static void EliminaEditora(int Editora_ID)
        {
            ComunicacaoBD.Elimina("Editora", Editora_ID);
        }
        public static DataTable ListaEditoras()
        {
            return ComunicacaoBD.Lista("Editora");
        }
        public static DataTable ListaEditoras(String Coluna, String Expressao)
        {
            return ComunicacaoBD.ListaProcura("Editora", Coluna, Expressao);
        }

        public static void MudaNome(int ID, String NovoNome)
        {
            ComunicacaoBD.AlteraValor("Editora", "Nome", ID, NovoNome);
        }

        public static void MudaMorada(int ID, String NovaMorada)
        {
            ComunicacaoBD.AlteraValor("Editora", "Morada", ID, NovaMorada);
        }
    }
}
