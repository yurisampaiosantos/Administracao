using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceGPEND
{
    public class AnexoPendencia
    {
        private static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=EGPEND;Password=gEpEND15";

        private decimal _id;

        public decimal Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private decimal _pendenciaId;

        public decimal PendenciaId
        {
            get { return _pendenciaId; }
            set { _pendenciaId = value; }
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
        public void SelecionarAnexoContrato(decimal anexoId)
        {
            string sql = "";
            sql += " SELECT ID,  PENDENCIA_ID, BLOB_CONTENT, DIRETORIO, FILENAME";
            sql += " FROM GP_ANEXO";
            sql += " WHERE ID = " + anexoId;
            try
            {
                using (OleDbConnection conn = new OleDbConnection(StringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            if (dataReader.Read())
                            {
                                Id = (decimal)dataReader["ID"];
                                PendenciaId = (decimal)dataReader["PENDENCIA_ID"];
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
            catch (Exception ex)
            {
            }
        }
        public void AtualizarAnexoContato(decimal anexoId, string diretorio)
        {
            string sql = "";
            sql += " UPDATE GP_ANEXO SET  ";
            sql += " BLOB_CONTENT = NULL ,";
            sql += " DIRETORIO = '" + diretorio + "'";
            sql += " WHERE ID = " + anexoId;

            using (OleDbConnection conn = new OleDbConnection(StringDeConexao))
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