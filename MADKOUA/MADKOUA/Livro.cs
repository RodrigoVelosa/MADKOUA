using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA
{
    class Livro
    {
        public Livro() { }
        public String Titulo { get; set; }
        public int Edicao { get; set; }
        public String ISBN { get; set; }
        public int NLivrosDisp { get; set; }

        private static ComunicaBD ComunicacaoBD = new ComunicaBD();

        public static void EliminaLivro(int Livro_ID)
        {
            ComunicacaoBD.ExecutaUpdateQuery("DELETE FROM Livro WHERE ID = " + Livro_ID);
        }
        public void AdicionaABaseDados(int ID_Autor, int ID_Editora)
        {
            ComunicacaoBD.ExecutaUpdateQuery("INSERT INTO Livro(Autor_ID, Editora_ID, Titulo, Edicao, ISBN, NLivrosDisp) VALUES ('" + ID_Autor + "','" + ID_Editora + "','" + Titulo + "','" + Edicao + "','" + ISBN + "','" + NLivrosDisp +"')");
        }
        public static DataTable ListaLivros()
        {
            return ComunicacaoBD.ExecutaQuery("SELECT * FROM Livro");
        }

    }
}
