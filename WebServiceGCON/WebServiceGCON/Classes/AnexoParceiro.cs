using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceGCON
{
    public class AnexoParceiro
    {
        private static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=EGCON;Password=Contract14";

        private decimal _id;

        public decimal Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private decimal _contratoId;

        public decimal ContratoId
        {
            get { return _contratoId; }
            set { _contratoId = value; }
        }
        private string _nomeArquivo;

        public string NomeArquivo
        {
            get { return _nomeArquivo; }
            set { _nomeArquivo = value; }
        }
        private decimal _ano;

        public decimal Ano
        {
            get { return _ano; }
            set { _ano = value; }
        }
        private decimal _mes;

        public decimal Mes
        {
            get { return _mes; }
            set { _mes = value; }
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

        //referente ao parceiro
        public void SelecionarAnexoParceiro(decimal anexoId)
        {
            string sql = "";

            sql += " SELECT GCO_ANEXO_CON_PARC_MENSAL.ID,  GCO_CONTRATO_MENSAL.ID AS CONTRATO_ID, GCO_ANEXO_CON_PARC_MENSAL.BLOB_CONTENT,  GCO_ANEXO_CON_PARC_MENSAL.FILENAME,";
            sql += " GCO_CONTRATO_MENSAL.MES,  GCO_CONTRATO_MENSAL.ANO, GCO_ANEXO_CON_PARC_MENSAL.DIRETORIO";
            sql += " FROM GCO_ANEXO_CON_PARC_MENSAL,  GCO_CONTRATO_MENSAL , GCO_PARCEIRO_CONT_MENSAL";
            sql += " WHERE GCO_PARCEIRO_CONT_MENSAL.ID = GCO_ANEXO_CON_PARC_MENSAL.PARCEIRO_CONTRATO_MENSAL_ID";
            sql += " AND GCO_PARCEIRO_CONT_MENSAL.CONTRATO_MENSAL_ID = GCO_CONTRATO_MENSAL.ID";
            sql += " AND GCO_ANEXO_CON_PARC_MENSAL.ID = " + anexoId;

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
                            ContratoId = (decimal)dataReader["CONTRATO_ID"];
                            NomeArquivo = (string)dataReader["FILENAME"];
                            Mes = (decimal)dataReader["MES"];
                            Ano = (decimal)dataReader["ANO"];
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
        public void AtualizarAnexoParceiro(decimal anexoId, string diretorio)
        {
            string sql = "";
            sql += " UPDATE GCO_ANEXO_CON_PARC_MENSAL SET ";
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