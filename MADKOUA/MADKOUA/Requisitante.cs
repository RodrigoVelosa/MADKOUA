using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA
{
    class Requisitante
    {
        public Requisitante() { }

        public String Nome { set; get; }
        public String CodigoUtilizador { set; get; }
        public String Password { set; get; }
        private static ComunicaBD ComunicacaoBD = new ComunicaBD("Data Source=RODRIGOVELOSA\\RODRIGOVELOSA;Initial Catalog=MADKOUADB;Integrated Security=True");

        public void AdicionaABaseDados()
        {
            ComunicacaoBD.ExecutaUpdateQuery("INSERT INTO Autor(Nome, CodigoUtilizador, Password) VALUES ('" + Nome + "','" + CodigoUtilizador + "','" + Password + "')");
        }

        public static DataTable ListaRequisitantes()
        {
            return ComunicacaoBD.ExecutaQuery("SELECT * FROM Requisitante");
        }

    }
}
