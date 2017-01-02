using MADKOUA_BD;
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

        public int ID { set; get; }
        public String Nome {set; get;}
        public String Apelido {set; get;}



        public void AdicionaBD()
        {
            String Colunas = "Nome, Apelido";
            String Valores = "'" + Nome + "','" + Apelido + "'";
            ComunicacaoBD.Adiciona("Autor", Colunas, Valores);
        }
        
        public static void EliminaAutor(int Autor_ID)
        {
            ComunicacaoBD.Elimina("Autor", Autor_ID);
        }
        public static DataTable ListaAutores()
        {
            return ComunicacaoBD.Lista("Autor");
        }

        public static DataTable ListaAutoresProcura(String Coluna, String Expressao)
        {
            return ComunicacaoBD.ListaProcura("Autor", Coluna, Expressao);
        }
    }
}
