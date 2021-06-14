using System;
using System.Collections.Generic;
using System.Text;
using WebServicePBI.Modelo;
using System.Data.SqlClient;
using System.Data;

namespace WebServicePBI.DAL
{
    public class PBI_SqlServerDAL
    {
        public List<PBI_SqlServer> Listagem()
        {
            ///Metodo para Listar todos no banco
            ///
            SqlConnection con = new SqlConnection(Dados.StringDeConexaoSqlServer);
            SqlCommand cmd = new SqlCommand("Select * from VW_USER_DISC_01 ", con);

            cmd.CommandType = CommandType.Text;
            List<PBI_SqlServer> results = new List<PBI_SqlServer>();
            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //Verificando se retornou algum registro
                while (reader.Read())
                {
                    //Gerar informacoes
                    PBI_SqlServer resultPBI_SqlServer = new PBI_SqlServer();
                    if (reader["NOME COMPLETO"] != DBNull.Value)
                        resultPBI_SqlServer.Nome_Completo = (string)reader["NOME COMPLETO"].ToString();
                    if (reader["Domain"] != DBNull.Value)
                        resultPBI_SqlServer.Domain = (string)reader["Domain"].ToString();
                    if (reader["Login"] != DBNull.Value)
                        resultPBI_SqlServer.Login = (string)reader["Login"].ToString();
                    if (reader["Ou"] != DBNull.Value)
                        resultPBI_SqlServer.Ou = (string)reader["Ou"].ToString();
                    if (reader["Cpf"] != DBNull.Value)
                        resultPBI_SqlServer.Cpf = (string)reader["Cpf"].ToString();
                    if (reader["Cc"] != DBNull.Value)
                        resultPBI_SqlServer.Cc = (string)reader["Cc"].ToString();
                    if (reader["Matricula"] != DBNull.Value)
                        resultPBI_SqlServer.Matricula = (string)reader["Matricula"].ToString();
                    if (reader["E-Mail"] != DBNull.Value)
                        resultPBI_SqlServer.EMail = (string)reader["E-Mail"].ToString();
                    if (reader["Empresa"] != DBNull.Value)
                        resultPBI_SqlServer.Empresa = (string)reader["Empresa"].ToString();
                    if (reader["Departamento"] != DBNull.Value)
                        resultPBI_SqlServer.Departamento = (string)reader["Departamento"].ToString();
                    if (reader["Descrição"] != DBNull.Value)
                        resultPBI_SqlServer.Descricao = (string)reader["Descrição"].ToString();
                    if (reader["Escritório"] != DBNull.Value)
                        resultPBI_SqlServer.Escritorio = (string)reader["Escritório"].ToString();
                    if (reader["Gerente"] != DBNull.Value)
                        resultPBI_SqlServer.Gerente = (string)reader["Gerente"].ToString();
                    results.Add(resultPBI_SqlServer);
                }
                con.Close();

                return results;
            }
        }
    }
}
