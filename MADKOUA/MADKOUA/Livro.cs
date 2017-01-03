using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MADKOUA_BD;

namespace MADKOUA
{
    class Livro : ItemBD
    {
        public Livro() { }

        public Livro(int id) { ID = id; }

        public int ID
        {
            get
            {
                return ID;
            }
            set
            {
                DataTable DT = ComunicacaoBD.ListaProcura("Livro", "ID", value.ToString());
                Titulo = DT.Rows[0].Field<String>("Titulo");
                Edicao = DT.Rows[0].Field<Int32>("Edicao");
                ISBN = DT.Rows[0].Field<String>("ISBN");
                NLivrosDisp = DT.Rows[0].Field<Int32>("LivrosDisponiveis");
                autor = new Autor(DT.Rows[0].Field<Int32>("Autor_ID"));
                editora = new Editora(DT.Rows[0].Field<Int32>("Editora_ID"));
            }
        }
        public String Titulo { get; set; }
        public int Edicao { get; set; }
        public String ISBN { get; set; }
        public int NLivrosDisp { get; set; }
        public Autor autor { set; get; }
        public Editora editora { set; get; }


        public void AdicionaBD()
        {
            String Colunas = "Autor_ID, Editora_ID, Titulo, Edicao, ISBN, NLivrosDisp";
            String Valores = "'" + autor.ID + "','" + editora.ID + "','" + Titulo + "','" + Edicao + "','" + ISBN + "','" + NLivrosDisp + "'";
            ComunicacaoBD.Adiciona("Livro", Colunas, Valores);            
        }
        
        public static void EliminaLivro(int Livro_ID)
        {
            ComunicacaoBD.Elimina("Livro", Livro_ID);
        }
        public static DataTable ListaLivros()
        {
            return ComunicacaoBD.Lista("Livro");
        }
        public static DataTable ListaLivros(String Coluna, String Expressao)
        {
            return ComunicacaoBD.ListaProcura("Livro", Coluna, Expressao);
        }
        public static void DecrementaNLivrosDisp(int id)
        {
            if(ComunicacaoBD.DevolveInteiro("Livro", "LivrosDisponiveis", id)>0)
                ComunicacaoBD.DecrementaValor("Livro", "LivrosDisponiveis", id);
        }
        
        public static void IncrementaNLivrosDisp(int id)
        {
            ComunicacaoBD.IncrementaValor("Livro", "LivrosDisponiveis", id);
        }
    }
}
