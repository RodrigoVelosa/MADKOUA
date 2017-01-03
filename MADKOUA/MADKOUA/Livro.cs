using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MADKOUA_BD;
using MADKOUA_LOG;

namespace MADKOUA
{
    class Livro : ItemBD
    {
        private Logger FicheiroLog = new Logger(new FicheiroRecorder());

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
                DataTable DT = ComunicacaoBD.Lista("Livro", "ID", value.ToString());
                try
                {
                    Titulo = DT.Rows[0].Field<String>("Titulo");
                    Edicao = DT.Rows[0].Field<Int32>("Edicao");
                    ISBN = DT.Rows[0].Field<String>("ISBN");
                    NLivrosDisp = DT.Rows[0].Field<Int32>("LivrosDisponiveis");
                    autor = new Autor(DT.Rows[0].Field<Int32>("Autor_ID"));
                    editora = new Editora(DT.Rows[0].Field<Int32>("Editora_ID"));
                }
                catch(IndexOutOfRangeException e)
                {
                    FicheiroLog.Log(DateTime.Now + ": " + e.Message + " Classe Livro. Propriedade ID (set)");
                }
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
            return ComunicacaoBD.Lista("Livro", Coluna, Expressao);
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

        public static void MudaTitulo(int ID, String NovoTitulo)
        {
            ComunicacaoBD.AlteraValor("Livro", "Titulo", ID, NovoTitulo);
        }

        public static void MudaEdicao(int ID, int NovaEdicao)
        {
            ComunicacaoBD.AlteraValor("Livro", "Edicao", ID, NovaEdicao);
        }

        public static void MudaISBN(int ID, int NovoISBN)
        {
            ComunicacaoBD.AlteraValor("Livro", "ISBN", ID, NovoISBN);
        }
        
        public static void MudaAutor(int ID, Autor NovoAutor)
        {
            ComunicacaoBD.AlteraValor("Livro", "Autor_ID", ID, NovoAutor.ID);
        }

        public static void MudaEditora(int ID, Editora NovaEditora)
        {
            ComunicacaoBD.AlteraValor("Livro", "Editora_ID", ID, NovaEditora.ID);
        }
    }
}
