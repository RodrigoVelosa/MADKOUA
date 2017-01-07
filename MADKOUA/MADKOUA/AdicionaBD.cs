using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA
{
    //Padrão de desenho Facade. Esta classe simplifica a adição de novos elementos a base de dados.
    class AdicionaBD
    {
        private Autor autor;
        private Livro livro;
        private Editora editora;
        private Requisitante requisitante;
        private Requisicao requisicao;

        public AdicionaBD ()
        {
            autor = new Autor();
            livro = new Livro();
            editora = new Editora();
            requisitante = new Requisitante();
            requisicao = new Requisicao();
        }

        public void AdicionaAutor(String nome, String apelido)
        {
            autor.Nome = nome;
            autor.Apelido = apelido;
            autor.AdicionaBD();
        }

        public void AdicionaLivro(Autor aAutor, Editora aEditora, String titulo, int edicao, String ISBN, int NLivrosDisp)
        {
            livro.autor = aAutor;
            livro.editora = aEditora;
            livro.Titulo = titulo;
            livro.Edicao = edicao;
            livro.ISBN = ISBN;
            livro.NLivrosDisp = NLivrosDisp;
            livro.AdicionaBD();
        }

        public void AdicionaEditora(String nome, String morada)
        {
            editora.Nome = nome;
            editora.Morada = morada;
            editora.AdicionaBD();
        }

        public void AdicionaRequisitante(String nome, String codigoUtilizador, String password)
        {
            requisitante.Nome = nome;
            requisitante.CodigoUtilizador = codigoUtilizador;
            requisitante.Password = password;
            requisitante.AdicionaBD();
        }

        public void AdicionaRequisicao(Livro aLivro, Requisitante aRequisitante, DateTime Data_Levantamento, DateTime Data_Entrega, String estado)
        {
            requisicao.livro = aLivro;
            requisicao.requisitante = aRequisitante;
            requisicao.Data_Levantamento = Data_Levantamento;
            requisicao.Data_Entrega = Data_Entrega;
            requisicao.Estado = estado;
            requisicao.AdicionaBD();
        }
    }
}
