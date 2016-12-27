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
        public String Nome {set; get;}
        public String Apelido {set; get;}



        public void AdicionaBD()
        {
            ComunicacaoBD.ExecutaUpdateQuery("INSERT INTO Autor(Nome, Apelido) VALUES ('" + Nome + "','" + Apelido + "')");
        }


        private static ComunicaBD ComunicacaoBD = new ComunicaBD();
        public static void EliminaAutor(int Autor_ID)
        {
            ComunicacaoBD.ExecutaUpdateQuery("DELETE FROM Autor WHERE ID = " + Autor_ID);
        }
        public static DataTable ListaAutores()
        {
            return ComunicacaoBD.ExecutaQuery("SELECT * FROM Autor");
        }

    }
}
