using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceSC
{
    public class AnexoRequest
    {
        private decimal _id;

        public decimal Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private decimal _requestId;

        public decimal RequestId
        {
            get { return _requestId; }
            set { _requestId = value; }
        }
        private string _nomeArquivo;

        public string NomeArquivo
        {
            get { return _nomeArquivo; }
            set { _nomeArquivo = value; }
        }

        private string _diretorio;

        public string Diretorio
        {
            get { return _diretorio; }
            set { _diretorio = value; }
        }
        private byte[] _anexo;

        public byte[] Anexo
        {
            get { return _anexo; }
            set { _anexo = value; }
        }
        //referente ao contrato
        public void SelecionarAnexo(decimal anexoId)
        {
            string sql = "";
            sql += " SELECT ID,  REQUEST_ID, BLOB_CONTENT, DIRETORIO, FILENAME";
            sql += " FROM EAC.SC_REQUEST_ANEXO";
            sql += " WHERE ID = " + anexoId;

            using (OleDbConnection conn = new OleDbConnection(Dados.StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                    {
                        if (dataReader.Read())
                        {
                            Id = (decimal)dataReader["ID"];
                            RequestId = (decimal)dataReader["REQUEST_ID"];
                            NomeArquivo = (string)dataReader["FILENAME"];
                            if (dataReader["DIRETORIO"] != DBNull.Value)
                            {
                                Diretorio = (string)dataReader["DIRETORIO"];
                            }
                            if (dataReader["BLOB_CONTENT"] != DBNull.Value)
                            {
                                Anexo = (Byte[])dataReader["BLOB_CONTENT"];
                            }
                        }
                    }
                }
                conn.Close();
            }            
        }
        public void AtualizarAnexo(decimal anexoId, string diretorio)
        {
            string sql = "";
            sql += " UPDATE EAC.SC_REQUEST_ANEXO SET  ";
            sql += " BLOB_CONTENT = NULL ,";
            sql += " DIRETORIO = '" + diretorio + "'";
            sql += " WHERE ID = " + anexoId;

            using (OleDbConnection conn = new OleDbConnection(Dados.StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}