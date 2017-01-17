using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MADKOUA_LOG;

namespace MADKOUA_BD
{
    public class ComunicacaoBD
    {

        private static ComunicacaoBD instance;

        private ComunicacaoBD() { }

        public static ComunicacaoBD Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComunicacaoBD();
                }
                return instance;
            }
        }

        private ComunicaBD BD = new ComunicaBD();
        private Logger FicheiroLog = new Logger(new FicheiroRecorder());
        private Logger BDLog = new Logger(new BDRecorder());

        public void Elimina(String Tabela, int ID)
        {
            BD.ExecutaUpdateQuery("DELETE FROM " + Tabela + " WHERE ID = " + ID);
        }
        public DataTable Lista(String Tabela)
        {
            return BD.ExecutaQuery("SELECT * FROM " + Tabela);
        }
        public DataTable Lista(String Tabela, String Coluna, String Procura)
        {
            return BD.ExecutaQuery("SELECT * FROM " + Tabela + " WHERE " + Coluna + " LIKE '" + Procura + "%'");
        }
        
        public int DevolveInteiro(String Tabela, String Coluna, int id)
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

        public String DevolveString(String Tabela, String Coluna, int id)
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

        public void DecrementaValor(String Tabela, String Coluna, int id)
        {
            int Valor = DevolveInteiro(Tabela, Coluna, id);
            int Resultado = BD.ExecutaUpdateQuery("UPDATE " + Tabela + " SET " + Coluna + " = " + --Valor + " WHERE ID = " + id);
            if(Resultado == 0)
            {
                FicheiroLog.Log(DateTime.Now + ": UPDATE na coluna " + Coluna + " da tabela " + Tabela + 
                    " com o ID " + id + " não foi realizado com sucesso. Class ComunicacaoBD. Método DecrementaValor.");
            }
            else
            {
                BDLog.Log("Decrementado o valor da " + Coluna + " da " + Tabela + " com o ID " + id);
            }
        }

        public void IncrementaValor(String Tabela, String Coluna, int id)
        {
            int Valor = DevolveInteiro(Tabela, Coluna, id);
            int Resultado = BD.ExecutaUpdateQuery("UPDATE " + Tabela + " SET " + Coluna + " = " + ++Valor + " WHERE ID = " + id);
            if(Resultado == 0)
            {
                FicheiroLog.Log(DateTime.Now + ": UPDATE na coluna " + Coluna + " da tabela " + Tabela + 
                    " com o ID " + id + " não foi realizado com sucesso. Class ComunicacaoBD. Método IncrementaValor.");
            }
            else
            {
                BDLog.Log("Incrementado o valor da " + Coluna + " da " + Tabela + " com o ID " + id);
            }
        }
      
        public void AlteraValor(String Tabela, String Coluna, int id, String NovoValor)
        {
            int Resultado = BD.ExecutaUpdateQuery("UPDATE " + Tabela + " SET " + Coluna + " = '" + NovoValor + "' WHERE ID = " + id);
            if(Resultado == 0)
            {
                FicheiroLog.Log(DateTime.Now + ": UPDATE na coluna " + Coluna + " da tabela " + Tabela + 
                    " com o ID " + id + " não foi realizado com sucesso. Class ComunicacaoBD. Método AlteraValor (String).");
            }
            else
            {
                BDLog.Log("Alterado o valor da " + Coluna + " da " + Tabela + " com o ID " + id + " para o novo valor: " + NovoValor);
            }
        }
        public void AlteraValor(String Tabela, String Coluna, int id, int NovoValor)
        {
            int Resultado = BD.ExecutaUpdateQuery("UPDATE " + Tabela + " SET " + Coluna + " = " + NovoValor + " WHERE ID = " + id);
            if (Resultado == 0)
            {
                FicheiroLog.Log(DateTime.Now + ": UPDATE na coluna " + Coluna + " da tabela " + Tabela + 
                    " com o ID " + id + " não foi realizado com sucesso. Class ComunicacaoBD. Método AlteraValor (Inteiro).");
            }
            else
            {
                BDLog.Log("Alterado o valor da " + Coluna + " da " + Tabela + " com o ID " + id + " para o novo valor: " + NovoValor);
            }
        }
        
        public void Adiciona(String Tabela, String Colunas, String Valores)
        {
            BD.ExecutaUpdateQuery("INSERT INTO " + Tabela + " (" + Colunas + ") VALUES (" + Valores + ")");
        }

    }
}
