﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MADKOUA_BD;
using MADKOUA_LOG;

namespace MADKOUA
{
    class Requisicao : ItemBD
    {
        private Logger FicheiroLog = new Logger(new FicheiroRecorder());

        public Requisicao() { }

        public Requisicao(int id) { ID = id; }

        //Propriedades. Cada uma corresponde a uma coluna da tabela Requisicao na base de dados.
        public int ID 
        {
            get { return ID; }
            //Quando ocorre um set no ID, o resto das propriedades atualizam para que cada uma guarde o valor
            //que está na base de dados associado ao id passado.
            set
            {
                DataTable DT = ComunicacaoBD.Lista("Requisicao", "ID", value.ToString());
                try
                {
                    livro = new Livro(DT.Rows[0].Field<Int32>("Livro_ID"));
                    requisitante = new Requisitante(DT.Rows[0].Field<Int32>("Requisitante_ID"));
                    Data_Levantamento = DT.Rows[0].Field<DateTime>("Data_L");
                    Data_Entrega = DT.Rows[0].Field<DateTime>("Data_E");
                    Estado = DT.Rows[0].Field<String>("Estado");
                }
                catch(IndexOutOfRangeException e)
                {
                    FicheiroLog.Log(DateTime.Now + ": " + e.Message + " Classe Requisicao. Propriedade ID (set)");
                }
            }
        }
        public Livro livro { get; set; }
        public Requisitante requisitante { get; set; }
        public DateTime Data_Levantamento { get; set; }
        public DateTime Data_Entrega { get; set; }
        public String Estado { get; set; }

        //Este método adiciona esta requisicao a base de dados.
        public void AdicionaBD()
        {
            String Colunas = "Livro_ID, Requisitante_ID, Data_L, Data_E, Estado";
            String Valores = "'" + livro.ID + "','" + requisitante.ID + "','" + Data_Levantamento + "','" + Data_Entrega + "','" + Estado + "'";
            ComunicacaoBD.Adiciona("Requisicao", Colunas, Valores);
        }

        #region "Métodos estáticos"
        //Este método elimina a Requisicao com o ID Requisicao_ID
        public static void EliminaRequisicao(int Requisicao_ID)
        {
            ComunicacaoBD.Elimina("Requisicao", Requisicao_ID);
        }

        //Este método devolve uma tabela com todas as requisicoes
        public static DataTable ListaRequisicao()
        {
            return ComunicacaoBD.Lista("Requisicao");
        }

        //Este método devolve uma tabela com todas as requisicoes em que Coluna = Expressao
        public static DataTable ListaRequisicao(String Coluna, String Expressao)
        {
            return ComunicacaoBD.Lista("Requisicao", Coluna, Expressao);
        }
        //Este método muda o estado da requisicao com o ID Requisicao_ID para novo estado
        public static void MudaEstado(int Requisicao_ID, String NovoEstado)
        {
            ComunicacaoBD.AlteraValor("Requisicao", "Estado", Requisicao_ID, NovoEstado);
        }

        //Este método muda a data de entrega da requisicao com o ID Requisicao_ID para a NovaData
        public static void MudaDataEntrega(int Requisicao_ID, DateTime NovaData)
        {
            ComunicacaoBD.AlteraValor("Requisicao", "Data_E", Requisicao_ID, NovaData.ToString());
        }

        //Este método muda a data de levantamento da requisicao com o ID Requisicao_ID para a NovaData
        public static void MudaDataLevantamento(int Requisicao_ID, DateTime NovaData)
        {
            ComunicacaoBD.AlteraValor("Requisicao", "Data_L", Requisicao_ID, NovaData.ToString());
        }
        #endregion
    }
}
