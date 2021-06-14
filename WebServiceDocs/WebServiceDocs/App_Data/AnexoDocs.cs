using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceDocs
{
    public class AnexoDocs
    {
        private decimal _id;

        public decimal Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private decimal _documentoId;

        public decimal DocumentoId
        {
            get { return _documentoId; }
            set { _documentoId = value; }
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
            sql += " SELECT ID,  DOCUMENTOS_ID, BLOB_CONTENT_FILE, DIRETORIO_FILE_SERVER, FILENAME_FILE";
            sql += " FROM EDOCS.DOCS_DOCUMENTOS_ANEXOS";
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
                            DocumentoId = (decimal)dataReader["DOCUMENTOS_ID"];
                            NomeArquivo = (string)dataReader["FILENAME_FILE"];
                            if (dataReader["DIRETORIO_FILE_SERVER"] != DBNull.Value)
                            {
                                Diretorio = (string)dataReader["DIRETORIO_FILE_SERVER"];
                            }
                            if (dataReader["BLOB_CONTENT_FILE"] != DBNull.Value)
                            {
                                Anexo = (Byte[])dataReader["BLOB_CONTENT_FILE"];
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
            sql += " UPDATE EDOCS.DOCS_DOCUMENTOS_ANEXOS SET  ";
            sql += " BLOB_CONTENT_FILE = NULL ,";
            sql += " DIRETORIO_FILE_SERVER = '" + diretorio + "'";
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