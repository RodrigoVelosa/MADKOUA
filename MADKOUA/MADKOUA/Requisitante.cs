using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA
{
    class Requisitante : ItemBD
    {
        public Requisitante() { }

        public String Nome { set; get; }
        public String CodigoUtilizador { set; get; }
        public String Password { set; get; }
        private static ComunicaBD ComunicacaoBD = new ComunicaBD();

        public void AdicionaBD()
        {
            ComunicacaoBD.ExecutaUpdateQuery("INSERT INTO Autor(Nome, CodigoUtilizador, Password) VALUES ('" + Nome + "','" + CodigoUtilizador + "','" + Password + "')");
        }

        public static void EliminaRequisitante(int Requisitante_ID)
        {
            ComunicacaoBD.ExecutaUpdateQuery("DELETE FROM Requisitante WHERE ID = " + Requisitante_ID);
        }

        public static DataTable ListaRequisitantes()
        {
            return ComunicacaoBD.ExecutaQuery("SELECT * FROM Requisitante");
        }

    }
}
