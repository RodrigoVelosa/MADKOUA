using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA_BD
{
    static class ComunicacaoBD
    {
        private static ComunicaBD BD = new ComunicaBD();
        public static void Elimina(String Tabela, int ID)
        {
            BD.ExecutaUpdateQuery("DELETE FROM " + Tabela + "WHERE ID = " + ID);
        }
        public static DataTable Lista(String Tabela)
        {
            return BD.ExecutaQuery("SELECT * FROM " + Tabela);
        }
        public static void AdicionaRequisicao(int Livro_ID, int Requisitante_ID, DateTime Data_L, DateTime Data_E, String Estado)
        {
            BD.ExecutaUpdateQuery("INSERT INTO Requisicao(Livro_ID, Requisitante_ID, Data_L, Data_E, Estado) VALUES ('" + Livro_ID + "','" + Requisitante_ID + "','" + Data_Levantamento + "','" + Data_Entrega + "','" + Estado + "')");
        }     
    }
}
