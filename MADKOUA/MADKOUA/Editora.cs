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
            ComunicacaoBD.AdicionaEditora(Nome, Morada);
        }



        public static void EliminaEditora(int Editora_ID)
        {
            ComunicacaoBD.Elimina("Editora", Editora_ID);
        }
        public static DataTable ListaEditoras()
        {
            return ComunicacaoBD.Lista("Editora");
        }
        public static DataTable ListaEditorasProcura(String Coluna, String Expressao)
        {
            return ComunicacaoBD.ListaProcura("Editora", Coluna, Expressao);
        }
        
    }
}
