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

        //Propriedades. Cada uma corresponde a uma coluna da tabela Livro na base de dados
        public int ID 
        {
            get
            {
                return ID;
            }
            //Quando ocorre um set no ID, o resto das propriedades atualizam para que cada uma guarde o valor
            //que está na base de dados associado ao id passado.
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

        //Este método guarda este livro na base de dados
        public void AdicionaBD()
        {
            String Colunas = "Autor_ID, Editora_ID, Titulo, Edicao, ISBN, NLivrosDisp";
            String Valores = "'" + autor.ID + "','" + editora.ID + "','" + Titulo + "','" + Edicao + "','" + ISBN + "','" + NLivrosDisp + "'";
            ComunicacaoBD.Adiciona("Livro", Colunas, Valores);            
        }

        #region "Métodos estáticos"
        //Este método elimina o livro que tem o ID Livro_ID
        public static void EliminaLivro(int Livro_ID)
        {
            ComunicacaoBD.Elimina("Livro", Livro_ID);
        }

        //Este método devolve uma tabela com todos os livros
        public static DataTable ListaLivros()
        {
            return ComunicacaoBD.Lista("Livro");
        }

        //Este método devolve uma tabela com todos os livros em que Coluna = Expressao
        public static DataTable ListaLivros(String Coluna, String Expressao)
        {
            return ComunicacaoBD.Lista("Livro", Coluna, Expressao);
        }

        //Este método decrementa o número de livros que estão disponiveis na biblioteca. Este método tem que ser chamado
        //quando ocorre uma nova requisicao
        public static void DecrementaNLivrosDisp(int Livro_ID)
        {
            if(ComunicacaoBD.DevolveInteiro("Livro", "LivrosDisponiveis", Livro_ID)>0)
                ComunicacaoBD.DecrementaValor("Livro", "LivrosDisponiveis", Livro_ID);
        }

        //Este método incrementa o número de livros que estão disponiveis na biblioteca. Este método tem que ser chamado
        //quando uma requisicao muda de estado para entregue
        public static void IncrementaNLivrosDisp(int Livro_ID)
        {
            ComunicacaoBD.IncrementaValor("Livro", "LivrosDisponiveis", Livro_ID);
        }

        //Este método muda o Titulo do livro com o ID Livro_ID para NovoTitulo
        public static void MudaTitulo(int Livro_ID, String NovoTitulo)
        {
            ComunicacaoBD.AlteraValor("Livro", "Titulo", Livro_ID, NovoTitulo);
        }

        //Este método muda a Edicao do livro com o ID Livro_ID para NovaEdicao
        public static void MudaEdicao(int Livro_ID, int NovaEdicao)
        {
            ComunicacaoBD.AlteraValor("Livro", "Edicao", Livro_ID, NovaEdicao);
        }

        //Este método muda o ISBN do livro com o ID Livro_ID para NovoISBN
        public static void MudaISBN(int Livro_ID, int NovoISBN)
        {
            ComunicacaoBD.AlteraValor("Livro", "ISBN", Livro_ID, NovoISBN);
        }
        
        //Este método muda o Autor_ID do livro com o ID Livro_ID para o ID do novo autor
        public static void MudaAutor(int Livro_ID, Autor NovoAutor)
        {
            ComunicacaoBD.AlteraValor("Livro", "Autor_ID", Livro_ID, NovoAutor.ID);
        }

        //Este método muda o Editora_ID do livro com o ID Editora_ID para o ID da nova editora
        public static void MudaEditora(int Livro_ID, Editora NovaEditora)
        {
            ComunicacaoBD.AlteraValor("Livro", "Editora_ID", Livro_ID, NovaEditora.ID);
        }
        #endregion
    }
}
