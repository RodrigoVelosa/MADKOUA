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
        public String Nome {set; get;}
        public String Apelido {set; get;}



        public void AdicionaBD()
        {
            ComunicacaoBD.AdicionaAutor(Nome, Apelido);
        }
        
        public static void EliminaAutor(int Autor_ID)
        {
            ComunicacaoBD.Elimina("Autor", Autor_ID);
        }
        public static DataTable ListaAutores()
        {
            return ComunicacaoBD.Lista("Autor");
        }

    }
}
