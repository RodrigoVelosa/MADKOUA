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
            BD.ExecutaUpdateQuery("DELETE FROM " + Tabela + " WHERE ID = " + ID);
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
      
        public static void AlteraValor(String Tabela, String Coluna, int id, String NovoValor)
        {
            BD.ExecutaUpdateQuery("UPDATE " + Tabela + " SET " + Coluna + " = '" + NovoValor + "' WHERE ID = " + id);
            BDLog.Log("Alterado o valor da " + Coluna + " da " + Tabela + " com o ID " + id + " para o novo valor: " + NovoValor);
        }
        public static void AlteraValor(String Tabela, String Coluna, int id, int NovoValor)
        {
            BD.ExecutaUpdateQuery("UPDATE " + Tabela + " SET " + Coluna + " = " + NovoValor + " WHERE ID = " + id);
            BDLog.Log("Alterado o valor da " + Coluna + " da " + Tabela + " com o ID " + id + " para o novo valor: " + NovoValor);
        }
        
        public static void Adiciona(String Tabela, String Colunas, String Valores)
        {
            BD.ExecutaUpdateQuery("INSERT INTO " + Tabela + " (" + Colunas + ") VALUES (" + Valores + ")");
        }

    }
}
