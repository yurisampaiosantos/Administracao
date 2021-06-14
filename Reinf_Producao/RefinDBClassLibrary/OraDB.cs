using evtExclusao;
using evtFechamento;
using evtInfoContribuinte;
using evtInfoCPRB;
//using evtPagamentosDiversos_v1_03_00; retirado na versao 3
using evtReabreEvPer;
using evtTabProcesso;
using evtTomadorServicos;
using Oracle.ManagedDataAccess.Client;
using RefinDBClassLibrary;
using ReinfModelClassLibrary;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ReinfDBClassLibrary
{
    public class ComplyOraDB
    {
        //const string strconComplyHML = "User Id=LF;Password=eepSALF;Data Source=LDCDBHML01.intranet.local/CRP01HML.intranet.local";
        const string strconComplyPRD = "User Id=LF;Password=lf*enseada2014;Data Source=LDCRAC2-SCAN.intranet.local/CRP01.intranet.local";
        private OracleConnection getConn()
        {
            return new OracleConnection(strconComplyPRD);
        }

        public DataTable getDataTable(string sql)
        {
            OracleConnection oc = getConn();
            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sql, oc);
            DataSet ds = new DataSet();
            da.Fill(ds);
            oc.Close();
            return ds.Tables[0];
        }
        public DataSet getServicosTomados(string codEmpresa, string codFilial, string perApur)
        {
            string[] words = perApur.Split('-');

            DateTime dt = new DateTime(Int32.Parse(words[0]), Int32.Parse(words[1]), 1);
            string perInicial = dt.ToString("dd-MM-yyyy");
            string perFinal = dt.AddMonths(1).AddDays(-1).ToString("dd-MM-yyyy");

            String sql = " select parc.BPC_CNPJ_CPF,  " +
                         " (select ft.BFT_CNJP from BSC_FILIAL f, BSC_FILIAL_TRANSIT ft where f.CUS_ID = ST.CUS_ID and f.bus_id = st.bus_id and ft.bus_id = f.bus_id) nrInscEstab, " +
                         " st.* from " +
                         "       STD_SERVICO_TOMADO ST,                     " +
                         "       STD_SERVICO_TOMADO_ITEM i,                  " +
                         "       STD_SERVICO_TOMADO_IMPOSTO p,               " +
                         "       BSC_PARCEIRO parc                           " +
                         "     where                                         " +
                         "       ST.BST_ID = 1 and       " +
                         "       parc.BPC_ID = ST.BPC_ID and                 " +
                         "       i.SVT_ID = ST.SVT_ID and                    " +
                         "       p.SIT_ID = i.SIT_ID and                     " +
                         "       ST.CUS_ID = (select cus_id from bsc_matriz where bmz_codigo = " + codEmpresa + ") and " +
                         "       ST.BUS_ID = (select bus_id from bsc_filial where bfl_codigo = " + codFilial + ") and " +
                         "   ST.SVT_DT_EMISSAO BETWEEN '" + perInicial + "' and '" + perFinal + "' and "  +
                         "       p.BTI_ID = 69";

            OracleConnection oc = getConn();
            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sql, oc);
            DataSet ds = new DataSet();
            da.Fill(ds);
            oc.Close();
            return ds;
        }
        public DataSet getNFSs(string codEmpresa, string codFilial, string perApur, string nrInscPrestador)
        {
            string[] words = perApur.Split('-');

            DateTime dt = new DateTime(Int32.Parse(words[0]), Int32.Parse(words[1]), 1);
            string perInicial = dt.ToString("dd-MM-yyyy");
            string perFinal = dt.AddMonths(1).AddDays(-1).ToString("dd-MM-yyyy");

            String sql = " select parc.BPC_CNPJ_CPF,  " +
                         " (select ft.BFT_CNJP from BSC_FILIAL f, BSC_FILIAL_TRANSIT ft where f.CUS_ID = ST.CUS_ID and f.bus_id = st.bus_id and ft.bus_id = f.bus_id) nrInscEstab, " +
                         " st.* from " +
                         "       STD_SERVICO_TOMADO ST,                     " +
                         "       STD_SERVICO_TOMADO_ITEM i,                  " +
                         "       STD_SERVICO_TOMADO_IMPOSTO p,               " +
                         "       BSC_PARCEIRO parc                           " +
                         "     where                                         " +
                         "       ST.BST_ID = 1 and       " +
                         "       parc.BPC_ID = ST.BPC_ID and                 " +
                         "       i.SVT_ID = ST.SVT_ID and                    " +
                         "       p.SIT_ID = i.SIT_ID and                     " +
                         "       ST.CUS_ID = (select cus_id from bsc_matriz where bmz_codigo = " + codEmpresa + ") and " +
                         "       ST.BUS_ID = (select bus_id from bsc_filial where bfl_codigo = " + codFilial + ") and " +
                         "   ST.SVT_DT_EMISSAO BETWEEN '" + perInicial + "' and '" + perFinal + "' and " +
                         "       p.BTI_ID = 69";

            OracleConnection oc = getConn();
            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sql, oc);
            DataSet ds = new DataSet();
            da.Fill(ds);
            oc.Close();
            return ds;
        }
        public DataSet getItensNFSs(string codEmpresa, string codFilial, string perApur, string nrInscPrestador, string numero)
        {
            string[] words = perApur.Split('-');

            DateTime dt = new DateTime(Int32.Parse(words[0]), Int32.Parse(words[1]), 1);
            string perInicial = dt.ToString("dd-MM-yyyy");
            string perFinal = dt.AddMonths(1).AddDays(-1).ToString("dd-MM-yyyy");

            String sql = " select parc.BPC_CNPJ_CPF,  " +
                         " (select ft.BFT_CNJP from BSC_FILIAL f, BSC_FILIAL_TRANSIT ft where f.CUS_ID = ST.CUS_ID and f.bus_id = st.bus_id and ft.bus_id = f.bus_id) nrInscEstab, " +
                         " st.* from " +
                         "       STD_SERVICO_TOMADO ST,                     " +
                         "       STD_SERVICO_TOMADO_ITEM i,                  " +
                         "       STD_SERVICO_TOMADO_IMPOSTO p,               " +
                         "       BSC_PARCEIRO parc                           " +
                         "     where                                         " +
                         "       ST.BST_ID = 1 and       " +
                         "       parc.BPC_ID = ST.BPC_ID and                 " +
                         "       i.SVT_ID = ST.SVT_ID and                    " +
                         "       p.SIT_ID = i.SIT_ID and                     " +
                         "       ST.CUS_ID = (select cus_id from bsc_matriz where bmz_codigo = " + codEmpresa + ") and " +
                         "       ST.BUS_ID = (select bus_id from bsc_filial where bfl_codigo = " + codFilial + ") and " +
                         "   ST.SVT_DT_EMISSAO BETWEEN '" + perInicial + "' and '" + perFinal + "' and " +
                         "       p.BTI_ID = 69";

            OracleConnection oc = getConn();
            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sql, oc);
            DataSet ds = new DataSet();
            da.Fill(ds);
            oc.Close();
            return ds;
        }
        
    }

    public class ReinfOraDB
    {
        //const string strconReinfDEV = "User Id=EREINF;Password=ObgF$cdev17;Data Source=LDCDBDEV01.intranet.local/CRP01DEV.intranet.local";
        const string strconReinfPROD = "User Id=F_APP_EREINF;Password=rEf18uS;Data Source=LDCRAC2-SCAN.intranet.local/CRP01.intranet.local";

        public OracleConnection getConn()
        {
            return new OracleConnection(strconReinfPROD);
        }

        public DadosCabecalhoEvento getDadosCabEvento(int idRegEmpresa)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            DadosCabecalhoEvento cabEvt = new DadosCabecalhoEvento();
            cabEvt.nrInsc = cnpj;
            cabEvt.id = "ID" + cabEvt.nrInsc + DateTime.Now.ToString("yyyyMMddHHmmss") + "00001";
            return cabEvt;
        }

        public DataTable getDataTable(string sql)
        {
            OracleConnection oc = getConn();
            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sql, oc);
            DataSet ds = new DataSet();
            da.Fill(ds);
            oc.Close();
            return ds.Tables[0];
        }

        public int executeSql(string sql)
        {
            OracleConnection oc = getConn();
            oc.Open();
            OracleCommand cmd = new OracleCommand(sql, oc);
            int r = cmd.ExecuteNonQuery();
            oc.Close();
            return r;
        }


        public void incluirMensageria(string codigoEvento, string idReg, string nrRecibo, string status , string retornoXML)
        {


            string sql = "insert into mensageria_eventos (CODIGO_EVENTO,  STATUS, DATAHORA_ENVIO, NR_RECIBO, RETORNO_XML) " +
                "values (:CODIGO_EVENTO, :STATUS, :DATAHORA_ENVIO, :NR_RECIBO, :RETORNO_XML)";

            OracleConnection oc = getConn();
            oc.Open();

            DateTime agora = DateTime.Now;
            // Preencher com os dados da Carga
            OracleCommand cmd = new OracleCommand(sql, oc);
            cmd.Parameters.Add(new OracleParameter("CODIGO_EVENTO", OracleDbType.Varchar2, ParameterDirection.Input));            
            cmd.Parameters.Add(new OracleParameter("STATUS", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("DATAHORA_ENVIO", OracleDbType.Date, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NR_RECIBO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("RETORNO_XML", OracleDbType.Clob, ParameterDirection.Input));

            cmd.Parameters["CODIGO_EVENTO"].Value = codigoEvento;
            cmd.Parameters["STATUS"].Value = status; // (E)nviado
            cmd.Parameters["DATAHORA_ENVIO"].Value = agora;
            cmd.Parameters["NR_RECIBO"].Value = nrRecibo;
            cmd.Parameters["RETORNO_XML"].Value = retornoXML;

            cmd.ExecuteNonQuery();

            OracleCommand cmd2 = new OracleCommand("UPDATE R" + codigoEvento + "  SET STATUS = 'E', NR_RECIBO = '"+nrRecibo+"', DATAHORA_ENVIO = :DATAHORA_ENVIO where ID = '" + idReg + "'", oc);
            cmd2.Parameters.Add(new OracleParameter("DATAHORA_ENVIO", OracleDbType.Date, ParameterDirection.Input));
            cmd2.Parameters["DATAHORA_ENVIO"].Value = agora;
            cmd2.ExecuteNonQuery();

            oc.Close();
        }

        public bool verificarFechamentoReabertura(int codEmpresa, string perApur)
        {
            bool retorno = false;
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(codEmpresa).Rows[0]["cnpj"].ToString();
            String sql = " SELECT " +
                         "         (SELECT count(*) FROM R2099 where PERAPUR = '" + perApur + "'  and NRINSC = " + cnpj.Substring(0, 8) + "000000" + " and NR_RECIBO IS NOT NULL) as FECHAMENTO," +
                         "         (SELECT count(*) FROM R2098 where PERAPUR = '" + perApur + "' and NRINSC = " + cnpj.Substring(0, 8) + "000000" + " and NR_RECIBO IS NOT NULL) AS REABERTURA, " +
                         "         (SELECT count(*) FROM R5011 where PERAPUR = '" + perApur + "' and NRINSC = " + cnpj + " and RETORNO_XML IS NOT NULL) AS RELATORIO " +
                         "      FROM DUAL ";

            OracleConnection oc = getConn();
            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sql, oc);
            DataSet ds = new DataSet();
            da.Fill(ds);
            oc.Close();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                if (r["FECHAMENTO"].ToString() == r["REABERTURA"].ToString() && r["FECHAMENTO"].ToString() == r["RELATORIO"].ToString())
                    retorno = true;
            }

            return retorno;
        }

        public bool verificarPendencias(int codEmpresa, string perApur)
        {
            bool retorno = false;
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(codEmpresa).Rows[0]["cnpj"].ToString();
            String sql = " SELECT " +
                         "         (SELECT count(*) FROM R2010 where PERAPUR = '" + perApur + "'  and NRINSC = " + cnpj.Substring(0, 8) + "000000" + " and STATUS = 'P') as R2010," +
                         "         (SELECT count(*) FROM R2060 where PERAPUR = '" + perApur + "' and NRINSC = " + cnpj.Substring(0, 8) + "000000" + " and STATUS = 'P') AS R2060 " +
                         "      FROM DUAL ";

            OracleConnection oc = getConn();
            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sql, oc);
            DataSet ds = new DataSet();
            da.Fill(ds);
            oc.Close();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                if (r["R2010"].ToString() == "0" && r["R2060"].ToString() == "0")
                    retorno = true;
            }

            return retorno;
        }
        public bool verificaExclusaoEvento(string recibo)
        {
            bool retorno = false;
            String sql = " SELECT COUNT(*) AS TOTAL " +
                         "      FROM R9000 " +
                         "      WHERE  NRRECEVT ='" + recibo + "'";
            
            OracleConnection oc = getConn();
            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sql, oc);
            DataSet ds = new DataSet();
            da.Fill(ds);
            oc.Close();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(r["TOTAL"].ToString()) == 0)
                    retorno = true;
            }

            return retorno;
        }


    }
}





