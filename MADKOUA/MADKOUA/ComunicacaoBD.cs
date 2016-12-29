using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MADKOUA_LOG;

namespace MADKOUA_BD
{
    static class ComunicacaoBD
    {
        private static ComunicaBD BD = new ComunicaBD();
        private static Logger FicheiroLog = new Logger(new FicheiroRecorder());
        private static Logger BDLog = new Logger(new BDRecorder());

        public static void Elimina(String Tabela, int ID)
        {
            BD.ExecutaUpdateQuery("DELETE FROM " + Tabela + "WHERE ID = " + ID);
        }
        public static DataTable Lista(String Tabela)
        {
            return BD.ExecutaQuery("SELECT * FROM " + Tabela);
        }
        public static DataTable ListaProcura(String Tabela, String Coluna, String Procura)
        {
            return BD.ExecutaQuery("SELECT * FROM " + Tabela + " WHERE " + Coluna + " LIKE '" + Procura + "%'");
        }
        
        public static int DevolveInteiro(String Tabela, String Coluna, int id)
        {
            int Resultado = 0;
            DataTable dt = BD.ExecutaQuery("SELECT " + Coluna + " FROM " + Tabela + " WHERE ID = " + id);
            try
            {
                Resultado = dt.Rows[0].Field<Int32>(0);
            }
            catch(Exception e)
            {
                FicheiroLog.Log(DateTime.Now + ": " + e.Message);
            }
            return Resultado;
        }

        public static String DevolveString(String Tabela, String Coluna, int id)
        {
            String Resultado = "";
            DataTable dt = BD.ExecutaQuery("SELECT " + Coluna + " FROM " + Tabela + " WHERE ID = " + id);
            try
            {
                Resultado = dt.Rows[0].Field<String>(0);
            }
            catch(Exception e)
            {
                FicheiroLog.Log(DateTime.Now + ": " + e.Message);
            }
            return Resultado;
        }

        public static void DecrementaValor(String Tabela, String Coluna, int id)
        {
            int Valor = DevolveInteiro(Tabela, Coluna, id);
            BD.ExecutaUpdateQuery("UPDATE " + Tabela + " SET " + Coluna + " = " + --Valor + " WHERE ID = " + id);
            BDLog.Log("Decrementado o valor da " + Coluna + " da " + Tabela + " com o ID " + id);
        }

        public static void IncrementaValor(String Tabela, String Coluna, int id)
        {
            int Valor = DevolveInteiro(Tabela, Coluna, id);
            BD.ExecutaUpdateQuery("UPDATE " + Tabela + " SET " + Coluna + " = " + ++Valor + " WHERE ID = " + id);
            BDLog.Log("Incrementado o valor da " + Coluna + " da " + Tabela + " com o ID " + id);
        }
      
        public static void AlteraValorString(String Tabela, String Coluna, int id, String NovoValor)
        {
            BD.ExecutaUpdateQuery("UPDATE " + Tabela + " SET " + Coluna + " = '" + NovoValor + "' WHERE ID = " + id);
            BDLog.Log("Alterado o valor da " + Coluna + " da " + Tabela + " com o ID " + id + " para o novo valor: " + NovoValor);
        }
        public static void AlteraValorInteiro(String Tabela, String Coluna, int id, int NovoValor)
        {
            BD.ExecutaUpdateQuery("UPDATE " + Tabela + " SET " + Coluna + " = " + NovoValor + " WHERE ID = " + id);
            BDLog.Log("Alterado o valor da " + Coluna + " da " + Tabela + " com o ID " + id + " para o novo valor: " + NovoValor);
        }

        #region "Adicionas"
        public static void AdicionaRequisicao(int Livro_ID, int Requisitante_ID, DateTime Data_Levantamento, DateTime Data_Entrega, String Estado)
        {
            BD.ExecutaUpdateQuery("INSERT INTO Requisicao(Livro_ID, Requisitante_ID, Data_L, Data_E, Estado) VALUES ('" + Livro_ID + "','" + Requisitante_ID + "','" + Data_Levantamento + "','" + Data_Entrega + "','" + Estado + "')");
            BDLog.Log("Adicionado nova requisição à base de dados");
        }
        public static void AdicionaAutor(String Nome, String Apelido)
        {
            BD.ExecutaUpdateQuery("INSERT INTO Autor(Nome, Apelido) VALUES ('" + Nome + "','" + Apelido + "')");
            BDLog.Log("Adicionado novo autor à base de dados");
        }
        public static void AdicionaRequisitante(String Nome, String CodigoUtilizador, String Password)
        {
            BD.ExecutaUpdateQuery("INSERT INTO Autor(Nome, CodigoUtilizador, Password) VALUES ('" + Nome + "','" + CodigoUtilizador + "','" + Password + "')");
            BDLog.Log("Adicionado novo requisitante à base de dados");
        }

        public static void AdicionaEditora(string Nome, string Morada)
        {
            BD.ExecutaUpdateQuery("INSERT INTO Editora(Nome, Morada) VALUES ('" + Nome + "','" + Morada + "')");
            BDLog.Log("Adicionado nova editora à base de dados");
        }
        public static void AdicionaLivro(int ID_Autor, int ID_Editora, string Titulo, int Edicao, string ISBN, int NLivrosDisp)
        {
            BD.ExecutaUpdateQuery("INSERT INTO Livro(Autor_ID, Editora_ID, Titulo, Edicao, ISBN, NLivrosDisp) VALUES ('" + ID_Autor + "','" + ID_Editora + "','" + Titulo + "','" + Edicao + "','" + ISBN + "','" + NLivrosDisp + "')");
            BDLog.Log("Adicionado novo livro à base de dados");
        }
        #endregion
        
    }
}
