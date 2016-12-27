using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MADKOUA_BD;

namespace MADKOUA
{
    class Editora : ItemBD
    {
        public Editora() { }
        public String Nome { set; get; }
        public String Morada { set; get; }

        


        public void AdicionaBD()
        {
            ComunicacaoBD.ExecutaUpdateQuery("INSERT INTO Editora(Nome, Morada) VALUES ('" + Nome + "','" + Morada + "')");
        }


        private static ComunicaBD ComunicacaoBD = new ComunicaBD();
        public static void EliminaEditora(int Editora_ID)
        {
            ComunicacaoBD.Elimina("Editora", Editora_ID);
        }
        public static DataTable ListaEditoras()
        {
            return ComunicacaoBD.Lista("Editora");
        }

        
    }
}
