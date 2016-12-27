﻿using System;
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
        public String Titulo { get; set; }
        public int Edicao { get; set; }
        public String ISBN { get; set; }
        public int NLivrosDisp { get; set; }
        public int ID_Autor { get; set; }
        public int ID_Editora { get; set; }


        public void AdicionaBD()
        {
            ComunicacaoBD.AdicionaLivro(ID_Autor, ID_Editora, Titulo, Edicao, ISBN, NLivrosDisp);            
        }



        public static void EliminaLivro(int Livro_ID)
        {
            ComunicacaoBD.Elimina("Livro", Livro_ID);
        }
        public static DataTable ListaLivros()
        {
            return ComunicacaoBD.Lista("Livro");
        }
    }
}
