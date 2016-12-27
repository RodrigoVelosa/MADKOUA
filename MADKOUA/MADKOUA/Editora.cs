using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MADKOUA
{
    class Editora : ItemBD
    {
        public Editora() { }
        public String Nome { set; get; }
        public String Morada { set; get; }

        


        public void AdicionaBD()
        {
            ComunicacaoBD.ExecutaUpdateQuery("INSERT INTO Editora(Nome, Morada) VALUES ('" + Nome + "','" + Morada + "')");
        }


        private static ComunicaBD ComunicacaoBD = new ComunicaBD();
        public static void EliminaEditora(int Editora_ID)
        {
            ComunicacaoBD.ExecutaUpdateQuery("DELETE FROM Editora WHERE ID = " + Editora_ID);
        }
        public static DataTable ListaEditores()
        {
            return ComunicacaoBD.ExecutaQuery("SELECT * FROM Editora");
        }

        
    }
}
