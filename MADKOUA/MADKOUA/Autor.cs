﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MADKOUA
{
    class Autor
    {
        public Autor() { }
        public String Nome {set; get;}
        public String Apelido {set; get;}
        private static ComunicaBD ComunicacaoBD = new ComunicaBD("Data Source=RODRIGOVELOSA\\RODRIGOVELOSA;Initial Catalog=MADKOUADB;Integrated Security=True");

        public void AdicionaABaseDados()
        {
            ComunicacaoBD.ExecutaUpdateQuery("INSERT INTO Autor(Nome, Apelido) VALUES ('" + Nome + "','" + Apelido + "')");
        }

        public static DataTable ListaAutores()
        {
            return ComunicacaoBD.ExecutaQuery("SELECT * FROM Autor");
        }
    }
}
