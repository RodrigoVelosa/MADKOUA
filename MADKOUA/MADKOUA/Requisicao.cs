using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MADKOUA_BD;

namespace MADKOUA
{
    class Requisicao : ItemBD
    {
        public int Livro_ID { get; set; }
        public int Requisitante_ID { get; set; }
        public DateTime Data_Levantamento { get; set; }
        public DateTime Data_Entrega { get; set; }
        public String Estado { get; set; }

        public void AdicionaBD()
        {
            ComunicacaoBD.AdicionaRequisicao(Livro_ID, Requisitante_ID, Data_Levantamento, Data_Entrega, Estado);
        }

        public static void EliminaRequisicao(int Requisicao_ID)
        {
            ComunicacaoBD.Elimina("Requisicao", Requisicao_ID);

        }

        public static DataTable ListaRequisicao()
        {
            return ComunicacaoBD.Lista("Requisicao");
        }

        public static DataTable ListaRequisicaoProcura(String Coluna, String Expressao)
        {
            return ComunicacaoBD.ListaProcura("Requisicao", Coluna, Expressao);
        }

        public static void MudaEstado(int id, String NovoEstado)
        {
            ComunicacaoBD.AlteraValorString("Requisicao", "Estado", id, NovoEstado);)
        }
    }
}
