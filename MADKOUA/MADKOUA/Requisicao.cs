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

        public Requisicao() { }

        public Requisicao(int id) { ID = id; }

        public int ID
        {
            get { return ID; }
            set
            {
                DataTable DT = ComunicacaoBD.ListaProcura("Requisicao", "ID", value.ToString());
                livro = new Livro(DT.Rows[0].Field<Int32>("Livro_ID"));
                requisitante = new Requisitante(DT.Rows[0].Field<Int32>("Requisitante_ID"));
                Data_Levantamento = DT.Rows[0].Field<DateTime>("Data_L");
                Data_Entrega = DT.Rows[0].Field<DateTime>("Data_E");
                Estado = DT.Rows[0].Field<String>("Estado");
            }
        }
        public Livro livro { get; set; }
        public Requisitante requisitante { get; set; }
        public DateTime Data_Levantamento { get; set; }
        public DateTime Data_Entrega { get; set; }
        public String Estado { get; set; }

        public void AdicionaBD()
        {
            String Colunas = "Livro_ID, Requisitante_ID, Data_L, Data_E, Estado";
            String Valores = "'" + livro.ID + "','" + requisitante.ID + "','" + Data_Levantamento + "','" + Data_Entrega + "','" + Estado + "'";
            ComunicacaoBD.Adiciona("Requisicao", Colunas, Valores);
        }

        public static void EliminaRequisicao(int Requisicao_ID)
        {
            ComunicacaoBD.Elimina("Requisicao", Requisicao_ID);

        }

        public static DataTable ListaRequisicao()
        {
            return ComunicacaoBD.Lista("Requisicao");
        }

        public static DataTable ListaRequisicao(String Coluna, String Expressao)
        {
            return ComunicacaoBD.ListaProcura("Requisicao", Coluna, Expressao);
        }

        public static void MudaEstado(int id, String NovoEstado)
        {
            ComunicacaoBD.AlteraValorString("Requisicao", "Estado", id, NovoEstado);
        }
    }
}
