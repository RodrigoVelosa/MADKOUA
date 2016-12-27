using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA
{
    class Requisicao : ItemBD
    {
        public int Livro_ID { get; set; }
        public int Requisitante_ID { get; set; }
        public DateTime Data_Levantamento { get; set; }
        public DateTime Data_Entrega { get; set; }
        public String Estado { get; set; }

        private static ComunicaBD ComunicacaoBD = new ComunicaBD();

        public void AdicionaBD()
        {
            ComunicacaoBD.ExecutaUpdateQuery("INSERT INTO Requisicao(Livro_ID, Requisitante_ID, Data_L, Data_E, Estado) VALUES ('" + Livro_ID + "','" + Requisitante_ID + "','" + Data_Levantamento + "','" + Data_Entrega + "','" +  Estado + "')");
        }

        public static void EliminaRequisitante(int Requisicao_ID)
        {
            ComunicacaoBD.ExecutaUpdateQuery("DELETE FROM Requisicao WHERE ID = " + Requisicao_ID);
        }

        public static DataTable ListaRequisitantes()
        {
            return ComunicacaoBD.ExecutaQuery("SELECT * FROM Requisicao");
        }
    }
}
