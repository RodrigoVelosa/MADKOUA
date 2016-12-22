using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using MADKOUA;

namespace MADKOUA
{
    class ComunicaBD
    {

        private SqlConnection Conexao;
        
        public ComunicaBD()
        {
            String StringDeConexao = "";
            switch (System.Environment.MachineName)
            {
                case "RODRIGOVELOSA":
                    StringDeConexao = "Data Source=RODRIGOVELOSA\\RODRIGOVELOSA;Initial Catalog=MADKOUADB;Integrated Security=True";
                    break;
                case "DESKTOP-J1G74PJ":
                    StringDeConexao = "Data Source = DESKTOP - J1G74PJ\\SQLEXPRESS; Initial Catalog = MADKOUADB; Integrated Security = True";
                    break;
            }
            Conexao = new SqlConnection();
            try
            {
                Conexao.ConnectionString = StringDeConexao;
                Conexao.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro na ligação à base de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //O construtor já abre a ligação com a base de dados.
        public ComunicaBD(string StringDeConexao)
        {
            Conexao = new SqlConnection();
            try
            {
                Conexao.ConnectionString = StringDeConexao;
                Conexao.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro na ligação à base de dados", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //Método responsável por fechar a ligação com a base de dados para não deixar uma ligação pendurada
        public void FechaConexao()
        {
            try
            {
                Conexao.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro ao se desligar da base de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
        }

        //Este método executa a query 'query' e devolve uma DataTable com o resultado
        public DataTable ExecutaQuery(String query)
        {
            DataTable DT = new DataTable();
            SqlDataAdapter DA;
            try
            {
                SqlCommand comand = new SqlCommand(query, Conexao);
                DA = new SqlDataAdapter(comand);
                DA.Fill(DT);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro ao executar query na base de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(query, "Query passada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(e.Message);
            }

            return DT;
        }


        public int ExecutaUpdateQuery(String query)
        {
            int count = 0;

            try
            {
                SqlCommand comand = new SqlCommand(query, Conexao);
                count = comand.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro ao atualizar a base de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(query, "Query passada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return count;
        }

    }
}
