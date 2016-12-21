using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA
{
    class Autor
    {
        public Autor() { }
        public string Nome {set; get;}
        public string Apelido {set; get;}


        public void AdicionaABaseDados()
        {
            ComunicacaoBD.ExecutaUpdateQuery("INSERT INTO Autor(Nome, Apelido) VALUES ('" + Nome + "','" + Apelido + "')");
        }
        private static ComunicaBD ComunicacaoBD = new ComunicaBD("Data Source=RODRIGOVELOSA\\RODRIGOVELOSA;Initial Catalog=MADKOUADB;Integrated Security=True");
        public static DataTable ListaAutores()
        {
            return ComunicacaoBD.ExecutaQuery("SELECT * FROM Autor");
        }
    }
}
