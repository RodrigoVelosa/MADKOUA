using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MADKOUA
{
    class Editora
    {
        public Editora() { }
        public String Nome { set; get; }
        public String Morada { set; get; }

        public void AdicionaABaseDados()
        {
            ComunicacaoBD.ExecutaUpdateQuery("INSERT INTO Editora(Nome, Morada) VALUES ('" + Nome + "','" + Morada + "')");
        }

        private static ComunicaBD ComunicacaoBD = new ComunicaBD("Data Source=RODRIGOVELOSA\\RODRIGOVELOSA;Initial Catalog=MADKOUADB;Integrated Security=True");

        public static DataTable ListaEditores()
        {
            return ComunicacaoBD.ExecutaQuery("SELECT * FROM Editora");
        }
    }
}
