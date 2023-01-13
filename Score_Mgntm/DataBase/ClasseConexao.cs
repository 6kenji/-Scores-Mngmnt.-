using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Connection_Class
{
    public class ClasseConexao
    {

        /// My Own DataBase instance (Only works for my computer)
        /// Minha instancia local da base de dados (Funciona somente para meu computador)
        string ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB ; Initial Catalog = StudentsDataBase; Integrated Security = True";  
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();

        public SqlConnection connection()
        {
            try
            {
                // Instanciando o objeto SqlConnection
                con = new SqlConnection(ConnectionString);
                //Verifica se a conexão esta fechada.
                if (con.State == ConnectionState.Closed)
                {
                    //Abre a conexão.
                    con.Open();
                }
                //Retorna o sqlconnection.
                return con;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// Metodo que faz a abertura da conexao
        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        /// Metodo que fecha a conexao
        public void CloseConnection()
        {
            con.Close();
        }

        /// Metodo que permite preencher uma datagridview com uma query SQL
        public void ShowDataInGridView(string Query_, DataGridView dataGridView)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            DataTable result = new DataTable();
            dr.Fill(result);
            dataGridView.DataSource = result;
        }

        ///Metodo que permite executar uma dada consulta SQL
        public DataTable ExecuteConsult(string Query_)
        {
            try
            {
                cmd.Connection = connection();
                cmd.CommandText = Query_;
                cmd.ExecuteScalar();
                IDataReader dtreader = cmd.ExecuteReader();
                DataTable dtresult = new DataTable();
                dtresult.Load(dtreader);
                CloseConnection();
                return dtresult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// Metodo que permite adicionar parametros SQL
        public void AddParam(string nome, SqlDbType tipo, object valor)
        {
            try
            {
                // Cria a instância do Parâmetro e adiciona os valores
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = nome;
                parametro.SqlDbType = tipo;
                parametro.Value = valor;
                // Adiciona ao comando SQL o parâmetro
                cmd.Parameters.Add(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// Metodo que executa uma atualizacao  SQL
        /// Este metodo retorna um valor inteiro para minhas textboxes e perimite fazer um update a cada click que afeta o mesmo componente
        public int ExecutaAtualizacao(string sql)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                //comando = new SqlCommand(sql, connection());
                cmd.Connection = connection();
                cmd.CommandText = sql;
                //Executa a query sql.
                int result = cmd.ExecuteNonQuery();
                CloseConnection();
                // Retorna a quantidade de linhas afetadas
                return result;
            }
            catch (Exception ex)
            {
                // Retorna uma exceção simples caso algum erro ocorra
                throw ex;
            }
        }

        /// Limpa os parametros do comando 
        public void LimparParametros()
        {
            cmd.Parameters.Clear();
        }

    }
} 