using evtInfoCPRB;
using evtTomadorServicos;
using Oracle.ManagedDataAccess.Client;
using RefinDBClassLibrary;
using ReinfDBClassLibrary;
using ReinfModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ReinfDBClassLibrary
{
    public class R2060DAL : RBASEDAL
    {

        ComplyOraDB c_odb = new ComplyOraDB();

        public void gerarR2060Comply(int idRegEmpresa, string perApur)
        {
            string sdtIni = "01/" + perApur.Substring(5, 2) + "/" + perApur.Substring(0, 4);
            DateTime dtIni = Convert.ToDateTime(sdtIni);
            DateTime dtFim = dtIni.AddMonths(1).AddDays(-1);
            string sdtFim = dtFim.ToString("dd-MM-yyyy");

            //
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("perapur"));
            dt.Columns.Add(new DataColumn("empresa"));
            dt.Columns.Add(new DataColumn("filial"));
            dt.Columns.Add(new DataColumn("VLRRECBRUTATOTAL"));
            dt.Columns.Add(new DataColumn("CODATIVECON"));
            dt.Columns.Add(new DataColumn("VLRRECBRUTAATIV"));
            dt.Columns.Add(new DataColumn("VLREXCRECBRUTA"));
            dt.Columns.Add(new DataColumn("VLRADICRECBRUTA"));
            dt.Columns.Add(new DataColumn("VLRBCCPRB"));
            dt.Columns.Add(new DataColumn("VLRCPRBAPUR"));
            dt.Columns.Add(new DataColumn("TPAJUSTE"));
            dt.Columns.Add(new DataColumn("CODAJUSTE"));
            dt.Columns.Add(new DataColumn("VLRAJUSTE"));
            dt.Columns.Add(new DataColumn("DESCAJUSTE"));
            dt.Columns.Add(new DataColumn("DTAJUSTE"));
           
            
            DataTable dtEst = (new EstabelecimentoDAL()).getEstabelecimentosDaEmpresa(idRegEmpresa);
            EmpresaDAL eDLL = new EmpresaDAL();
            string empresa = eDLL.getEmpresa(Convert.ToInt32(idRegEmpresa)).Rows[0]["CODIGO"].ToString();
            string sqlF100 = "";
            string sqlNFS = "";
            DataTable dtF100;
            DataTable dtNFS;

            // Para cada estabelecimento             
            for (int i = 0; i < dtEst.Rows.Count; i++)
            {
                sqlF100 = " select                                " +
                  " to_char(c.OGC_DT_OPER, 'YYYY-MM') perApur,   " +
                  "  (select m.bmz_codigo from bsc_matriz m where m.cus_id = (select f.cus_id from bsc_filial f where f.bus_id = c.BUS_ID)) empresa," +
                  "  (select f.BFL_CODIGO from bsc_filial f where f.bus_id = c.BUS_ID) filial, " +
                  "  0 vlrrecbrutatotal," +
                  "  '99990025' codAtvEcon,                       " +
                  "  sum(C.OGC_VLR_OPER) vlrRecBrutaAtiv,         " +
                  "  sum(C.OGC_VLR_OPER) vlrExcRecBruta,          " +
                  "  0 vlrAdicRecBruta,                           " +
                  "  0 vlrBcCPRB,                                 " +
                  "  null vlrCPRBapur,                            " +
                  "  '0' TPAJUSTE,                                " +
                  "  '4' CODAJUSTE,                               " +
                  "  sum(C.OGC_VLR_OPER) VLRAJUSTE,               " +
                  "  'Exportação mês' DESCAJUSTE,                 " +
                  "  to_char(c.OGC_DT_OPER, 'YYYY-MM') DTAJUSTE   " +
                  " from                                          " +
                  "   SPP_OPER_GER_CONTRIBUICAO C                 " +
                  " WHERE                                         " +
                  "   exists(select 1 from SPP_OPER_GER_LANCTO L  " +
                  "           where                               " +
                  "             L.OGC_ID = C.OGC_ID AND           " +
                  "             L.BSR_ID = (select z.BSR_ID from BSC_SIT_TRIBUT z where z.bti_id = L.BTI_ID and z.bsr_codigo = '08')) and " +
                  "   C.OGC_DT_OPER BETWEEN '" + sdtIni + "' and '" + sdtFim + "' and " +
                  "   C.BUS_ID = (select distinct f.bus_id from BSC_FILIAL f, BSC_FILIAL_TRANSIT t where f.BUS_ID = t.BUS_ID and t.BFT_CNJP = '" + dtEst.Rows[i]["cnpj"].ToString() + "') and " +
                  "   C.OGC_TP_MOVIMENTO = 1 " +
                  "   group by c.BUS_ID, to_char(c.OGC_DT_OPER, 'YYYY-MM')"; 
                dtF100 = c_odb.getDataTable(sqlF100);
                if (dtF100.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtF100.Rows)
                    {
                        dt.Rows.Add(dr.ItemArray);
                    }
                }

                sqlNFS =
                    "select " +
                    " to_char(c.NCP_DT_LANCTO, 'YYYY-MM') perApur, " +
                    " (select m.bmz_codigo from bsc_matriz m where m.cus_id = (select f.cus_id from bsc_filial f where f.bus_id = c.BUS_ID)) empresa," +
                    " (select f.BFL_CODIGO from bsc_filial f where f.bus_id = c.BUS_ID) filial, " +
                    " 0 vlrrecbrutatotal," +
                    " '00000080' codAtvEcon," +
                    " sum(c.NCP_VL_TOTAL_NF) vlrRecBrutaAtiv," +
                    " 0 vlrExcRecBruta," +
                    " 0 vlrAdicRecBruta," +
                    " sum(c.NCP_VL_TOTAL_NF) vlrBcCPRB," +
                    " sum(p.NIP_VL_IMPOSTO) vlrCPRBapur," +
                    " '' TPAJUSTE, " +
                    " '' CODAJUSTE, " +
                    " '' VLRAJUSTE, " +
                    " '' DESCAJUSTE, " +
                    " '' DTAJUSTE " +
                    "from" +
                    "  bsc_nf_capa c," +
                    "  BSC_NF_ITEM i, " +
                    "  BSC_NF_IMPOSTO p, " +
                    "  BSC_TP_IMPOSTO ti " +
                    "where " +
                    "  p.NIT_ID = i.nit_id and " +
                    "  i.NCP_ID = c.ncp_id and " +
                    "  ti.BTI_ID = p.bti_id and " +
                    "  ti.BTI_CODIGO = 'IP' and " +
                    "  p.NIP_VL_IMPOSTO > 0 and " +
                    "  c.BST_ID = 1 and " +
                    "  C.BUS_ID = (select distinct f.bus_id from BSC_FILIAL f, BSC_FILIAL_TRANSIT t where f.BUS_ID = t.BUS_ID and t.BFT_CNJP = '" + dtEst.Rows[i]["cnpj"].ToString() + "') and " +
                    "  c.NCP_DT_LANCTO BETWEEN '" + sdtIni + "' and '" + sdtFim + "' " +
                    "group by c.BUS_ID, to_char(c.NCP_DT_LANCTO, 'YYYY-MM')";
                dtNFS = c_odb.getDataTable(sqlNFS);
                if (dtNFS.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtNFS.Rows)
                    {
                        dt.Rows.Add(dr.ItemArray);
                    }
                }
                decimal vlTotRec = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    vlTotRec = vlTotRec + Convert.ToDecimal(dt.Rows[j]["vlrRecBrutaAtiv"].ToString());// + Convert.ToDecimal(dt.Rows[j]["vlrAdicRecBruta"].ToString()) - Convert.ToDecimal(dt.Rows[j]["vlrExcRecBruta"].ToString());
                }
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    dt.Rows[j]["vlrrecbrutatotal"] = vlTotRec;                    
                }
            }
            ds.Tables.Add(dt);
            carregaR2060Temp(ds);
            preencherR2060();
            //verificarSeReenvioFornecedor(empresa, perApur);
        }

        public void limparR2060Temp()
        {
            string sqlDelete = "delete from r2060_temp";
            odb.executeSql(sqlDelete);

        }
        public void carregaR2060Temp(DataSet ds)
        {

            string sql = "insert into r2060_temp (perapur, empresa, filial, VLRRECBRUTATOTAL, CODATIVECON, VLRRECBRUTAATIV, VLREXCRECBRUTA, VLRADICRECBRUTA, VLRBCCPRB, VLRCPRBAPUR, TPAJUSTE, CODAJUSTE, VLRAJUSTE, DESCAJUSTE, DTAJUSTE) " +
                "values (:perapur, :empresa, :filial, :VLRRECBRUTATOTAL, :CODATIVECON, :VLRRECBRUTAATIV, :VLREXCRECBRUTA, :VLRADICRECBRUTA, :VLRBCCPRB, :VLRCPRBAPUR, :TPAJUSTE, :CODAJUSTE, :VLRAJUSTE, :DESCAJUSTE, :DTAJUSTE)";
            
            oc.Open();

            // Preencher com os dados da Carga
            OracleCommand cmd = new OracleCommand(sql, oc);

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("empresa", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("filial", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("VLRRECBRUTATOTAL", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("CODATIVECON", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("VLRRECBRUTAATIV", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("VLREXCRECBRUTA", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("VLRADICRECBRUTA", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("VLRBCCPRB", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("VLRCPRBAPUR", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("TPAJUSTE", OracleDbType.Int16, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("CODAJUSTE", OracleDbType.Int16, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("VLRAJUSTE", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("DESCAJUSTE", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("DTAJUSTE", OracleDbType.Varchar2, ParameterDirection.Input));

                if (getVerificaExistencia(r["filial"].ToString(), r["perapur"].ToString()).Rows.Count == 0)
                {
                    cmd.Parameters["perapur"].Value = r["perapur"].ToString();
                    cmd.Parameters["empresa"].Value = r["empresa"].ToString();
                    cmd.Parameters["filial"].Value = r["filial"].ToString();
                    if (r["VLRRECBRUTATOTAL"].ToString() != "")
                    {
                        cmd.Parameters["VLRRECBRUTATOTAL"].Value = Convert.ToDecimal(r["VLRRECBRUTATOTAL"].ToString());
                    }
                    if (r["CODATIVECON"].ToString() != "")
                    {
                        cmd.Parameters["CODATIVECON"].Value = Convert.ToInt32(r["CODATIVECON"].ToString()).ToString("00000000");
                    }
                    cmd.Parameters["VLRRECBRUTAATIV"].Value = Convert.ToDecimal(r["VLRRECBRUTAATIV"].ToString());
                    cmd.Parameters["VLREXCRECBRUTA"].Value = Convert.ToDecimal(r["VLREXCRECBRUTA"].ToString());
                    cmd.Parameters["VLRADICRECBRUTA"].Value = Convert.ToDecimal(r["VLRADICRECBRUTA"].ToString());
                    cmd.Parameters["VLRBCCPRB"].Value = Convert.ToDecimal(r["VLRBCCPRB"].ToString());
                    if (r["VLRCPRBAPUR"].ToString() != "")
                    {
                        cmd.Parameters["VLRCPRBAPUR"].Value = Convert.ToDecimal(r["VLRCPRBAPUR"].ToString());
                    }
                    if (r["TPAJUSTE"].ToString() != "")
                    {
                        cmd.Parameters["TPAJUSTE"].Value = Convert.ToInt16(r["TPAJUSTE"].ToString());
                        cmd.Parameters["CODAJUSTE"].Value = Convert.ToInt16(r["CODAJUSTE"].ToString());
                        cmd.Parameters["VLRAJUSTE"].Value = Convert.ToDecimal(r["VLRAJUSTE"].ToString());
                        cmd.Parameters["DESCAJUSTE"].Value = r["DESCAJUSTE"].ToString();
                        cmd.Parameters["DTAJUSTE"].Value = r["DTAJUSTE"].ToString();
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            oc.Close();
        }
        public void preencherR2060()
        {
            EmpresaDAL empDLL = new EmpresaDAL();
            EstabelecimentoDAL estDLL = new EstabelecimentoDAL();
            int i = 0;

            string sqlEventos = "select distinct perapur, " +
                                  "empresa, filial, VLRRECBRUTATOTAL " +
                                  " from " +
                                  " r2060_temp";
            
            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sqlEventos, oc);
            DataSet ds2060 = new DataSet();
            da.Fill(ds2060);

            // Preencher com os dados da Carga
            string sqlInsR2060 = "insert into r2060 (id, indretif, perapur, tpamb, procemi, verproc, tpinsc, nrinsc, tpinscestab, nrinscestab, VLRRECBRUTATOTAL, VLRCPAPURTOTAL, VLRCPRBSUSPTOTAL, STATUS ) " +
                " values (:id, :indretif, :perapur, :tpamb, :procemi, :verproc, :tpinsc, :nrinsc, :tpinscestab, :nrinscestab, :VLRRECBRUTATOTAL, :VLRCPAPURTOTAL, :VLRCPRBSUSPTOTAL, :STATUS) " +
                 " RETURNING idReg INTO :idReg";

            OracleCommand cmd = new OracleCommand(sqlInsR2060, oc);

            // Inserir no Evento R2060
            foreach (DataRow r in ds2060.Tables[0].Rows)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("indretif", OracleDbType.Int16, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("tpamb", OracleDbType.Int16));
                cmd.Parameters.Add(new OracleParameter("procemi", OracleDbType.Int16, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("verproc", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("tpinscestab", OracleDbType.Int16, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("nrinscestab", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("VLRRECBRUTATOTAL", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("VLRCPAPURTOTAL", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("VLRCPRBSUSPTOTAL", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("STATUS", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("idReg", OracleDbType.Int64, ParameterDirection.Output));
                i++;
                string cnpjEmpresa = empDLL.getEmpresaByCodigo(r["empresa"].ToString()).Rows[0]["cnpj"].ToString();
                cmd.Parameters["id"].Value = "ID1" + cnpjEmpresa + DateTime.Now.ToString("yyyyMMddHHmmss") + i.ToString("00000");
                cmd.Parameters["indretif"].Value = 1;
                cmd.Parameters["perapur"].Value = r["perapur"].ToString();
                cmd.Parameters["tpamb"].Value = DadosCabecalhoEventoConst.tpAmb;
                cmd.Parameters["procemi"].Value = DadosCabecalhoEventoConst.procEmi;
                cmd.Parameters["verproc"].Value = DadosCabecalhoEventoConst.verProc;
                cmd.Parameters["tpinsc"].Value = DadosCabecalhoEventoConst.tpInsc;
                cmd.Parameters["nrinsc"].Value = cnpjEmpresa;
                cmd.Parameters["tpinscestab"].Value = DadosCabecalhoEventoConst.tpInsc;
                cmd.Parameters["nrinscestab"].Value = estDLL.getEstabelecimentoByCodigo(r["filial"].ToString()).Rows[0]["cnpj"].ToString();

                cmd.Parameters["VLRRECBRUTATOTAL"].Value = Convert.ToDecimal(r["VLRRECBRUTATOTAL"].ToString());
                cmd.Parameters["VLRCPAPURTOTAL"].Value = 0; // Convert.ToDecimal(r["VLRCPAPURTOTAL"].ToString());
                cmd.Parameters["VLRCPRBSUSPTOTAL"].Value = 0; //Convert.ToDecimal(r["VLRCPRBSUSPTOTAL"].ToString());
                cmd.Parameters["STATUS"].Value = "P";

                cmd.ExecuteNonQuery();
                int idReg2060 = Convert.ToInt16(cmd.Parameters["idReg"].Value.ToString());

                // Inserir no Evento R2060_TIPOCOD
                string sql2060_TIPOCOD = "select CODATIVECON,  sum(VLRRECBRUTAATIV) VLRRECBRUTAATIV_T, sum(VLREXCRECBRUTA) VLREXCRECBRUTA_T, sum(VLRADICRECBRUTA) VLRADICRECBRUTA_T, sum(VLRBCCPRB) VLRBCCPRB_T, sum(VLRCPRBAPUR) VLRCPRBAPUR_T  " +
                                        " from R2060_TEMP where empresa = '" + r["empresa"].ToString() + "' and filial = '" + r["filial"].ToString() + "' and PERAPUR = '" + r["perapur"].ToString() + "' " +
                                        " group by CODATIVECON";
                da = new OracleDataAdapter(sql2060_TIPOCOD, oc);
                DataSet ds2060TIPOCOD = new DataSet();
                da.Fill(ds2060TIPOCOD);


                string sqlInsR2060_TIPOCOD = "insert into r2060_TIPOCOD (CODATIVECON,VLRRECBRUTAATIV,VLREXCRECBRUTA,VLRADICRECBRUTA,VLRBCCPRB, VLRCPRBAPUR ,r2060_idreg) " +
                    " values (:CODATIVECON, :VLRRECBRUTAATIV, :VLREXCRECBRUTA, :VLRADICRECBRUTA, :VLRBCCPRB, :VLRCPRBAPUR , :r2060_idreg) " +
                     " RETURNING idReg INTO :idRegTipoCod";
                OracleCommand cmdTipoCod = new OracleCommand(sqlInsR2060_TIPOCOD, oc);
                foreach (DataRow rTipoCod in ds2060TIPOCOD.Tables[0].Rows)
                {
                    cmdTipoCod.Parameters.Clear();
                    cmdTipoCod.Parameters.Add(new OracleParameter("CODATIVECON", OracleDbType.Varchar2, ParameterDirection.Input));
                    cmdTipoCod.Parameters.Add(new OracleParameter("VLRRECBRUTAATIV", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdTipoCod.Parameters.Add(new OracleParameter("VLREXCRECBRUTA", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdTipoCod.Parameters.Add(new OracleParameter("VLRADICRECBRUTA", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdTipoCod.Parameters.Add(new OracleParameter("VLRBCCPRB", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdTipoCod.Parameters.Add(new OracleParameter("VLRCPRBAPUR", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdTipoCod.Parameters.Add(new OracleParameter("r2060_idreg", OracleDbType.Int16, ParameterDirection.Input));
                    cmdTipoCod.Parameters.Add(new OracleParameter("idRegTipoCod", OracleDbType.Int64, ParameterDirection.Output));

                    cmdTipoCod.Parameters["CODATIVECON"].Value = rTipoCod["CODATIVECON"].ToString();
                    cmdTipoCod.Parameters["VLRRECBRUTAATIV"].Value = Convert.ToDecimal(rTipoCod["VLRRECBRUTAATIV_T"].ToString());
                    cmdTipoCod.Parameters["VLREXCRECBRUTA"].Value = Convert.ToDecimal(rTipoCod["VLREXCRECBRUTA_T"].ToString());
                    cmdTipoCod.Parameters["VLRADICRECBRUTA"].Value = Convert.ToDecimal(rTipoCod["VLRADICRECBRUTA_T"].ToString());
                    cmdTipoCod.Parameters["VLRBCCPRB"].Value = Convert.ToDecimal(rTipoCod["VLRBCCPRB_T"].ToString());
                    if (rTipoCod["VLRCPRBAPUR_T"].ToString() != "")
                    {
                        cmdTipoCod.Parameters["VLRCPRBAPUR"].Value = Convert.ToDecimal(rTipoCod["VLRCPRBAPUR_T"].ToString());
                    }
                    else
                    {
                        cmdTipoCod.Parameters["VLRCPRBAPUR"].Value = 0;
                    }
                    cmdTipoCod.Parameters["r2060_idreg"].Value = idReg2060;
                    cmdTipoCod.ExecuteNonQuery();
                    int idRegTIPOCOD = Convert.ToInt16(cmdTipoCod.Parameters["idRegTipoCod"].Value.ToString());

                    // Inserir no Evento R2060_TIPOAJUSTE
                    string sql2060_TIPOAJUSTE = "select * from R2060_TEMP where empresa = '" + r["empresa"].ToString() + "' and filial = '" + r["filial"].ToString() + "' and PERAPUR = '" + r["perapur"].ToString() + "' " +
                                         " and CODATIVECON = '" + rTipoCod["CODATIVECON"].ToString() + "' and TPAJUSTE is not null";
                    da = new OracleDataAdapter(sql2060_TIPOAJUSTE, oc);
                    DataSet ds2010TIPOAJUSTE = new DataSet();
                    da.Fill(ds2010TIPOAJUSTE);

                    string sqlInsR2060_TipoAjuste = "insert into r2060_TIPOAJUSTE (TPAJUSTE,CODAJUSTE,VLRAJUSTE,DESCAJUSTE, DTAJUSTE, R2060_TIPOCOD_IDREG) " +
                        " values (:TPAJUSTE, :CODAJUSTE, :VLRAJUSTE, :DESCAJUSTE, :DTAJUSTE, :R2060_TIPOCOD_IDREG) ";
                    OracleCommand cmdNFS = new OracleCommand(sqlInsR2060_TipoAjuste, oc);
                    foreach (DataRow rTipoAjuste in ds2010TIPOAJUSTE.Tables[0].Rows)
                    {
                        cmdNFS.Parameters.Clear();
                        cmdNFS.Parameters.Add(new OracleParameter("TPAJUSTE", OracleDbType.Int16, ParameterDirection.Input));
                        cmdNFS.Parameters.Add(new OracleParameter("CODAJUSTE", OracleDbType.Int16, ParameterDirection.Input));
                        cmdNFS.Parameters.Add(new OracleParameter("VLRAJUSTE", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdNFS.Parameters.Add(new OracleParameter("DESCAJUSTE", OracleDbType.Varchar2, ParameterDirection.Input));
                        cmdNFS.Parameters.Add(new OracleParameter("DTAJUSTE", OracleDbType.Varchar2, ParameterDirection.Input));
                        cmdNFS.Parameters.Add(new OracleParameter("R2060_TIPOCOD_IDREG", OracleDbType.Int64, ParameterDirection.Input));

                        if (rTipoAjuste["VLRAJUSTE"].ToString() != "")
                        {
                            cmdNFS.Parameters["TPAJUSTE"].Value = rTipoAjuste["TPAJUSTE"].ToString();
                            cmdNFS.Parameters["CODAJUSTE"].Value = rTipoAjuste["CODAJUSTE"].ToString();
                            cmdNFS.Parameters["VLRAJUSTE"].Value = Convert.ToDecimal(rTipoAjuste["VLRAJUSTE"].ToString());
                            cmdNFS.Parameters["DESCAJUSTE"].Value = rTipoAjuste["DESCAJUSTE"].ToString();
                            cmdNFS.Parameters["DTAJUSTE"].Value = rTipoAjuste["DTAJUSTE"].ToString();
                            cmdNFS.Parameters["R2060_TIPOCOD_IDREG"].Value = idRegTIPOCOD;
                            cmdNFS.ExecuteNonQuery();
                        }
                    }
                }
            }
            oc.Close();
            atualizavlrCPApurTotal();
            limparR2060Temp();
        }

        public void incluir(int idRegEmpresa, string indretif, string perapur, string numeroRecibo, int idRegEstabelecimento, decimal VLRRECBRUTATOTAL, decimal VLRCPAPURTOTAL, decimal VLRCPRBSUSPTOTAL)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            EstabelecimentoDAL estabDLL = new EstabelecimentoDAL();
            String cnpjEstab = estabDLL.getEstabelecimento(idRegEstabelecimento).Rows[0]["cnpj"].ToString();

            // Preencher com os dados da Carga
            string sqlInsR2060 = "insert into r2060 (id, indretif, perapur, tpamb, procemi, verproc, tpinsc, nrinsc, tpinscestab, nrinscestab, VLRRECBRUTATOTAL, VLRCPAPURTOTAL, VLRCPRBSUSPTOTAL, STATUS ) " +
                " values (:id, :indretif, :perapur, :NRRECIBO,  :tpamb, :procemi, :verproc, :tpinsc, :nrinsc, :tpinscestab, :nrinscestab, :VLRRECBRUTATOTAL, :VLRCPAPURTOTAL, :VLRCPRBSUSPTOTAL, :STATUS) " +
                 " RETURNING idReg INTO :idReg";

            OracleCommand cmd = new OracleCommand(sqlInsR2060, oc);
            cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("indretif", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NRRECIBO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpamb", OracleDbType.Int16));
            cmd.Parameters.Add(new OracleParameter("procemi", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("verproc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpinscestab", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinscestab", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRRECBRUTATOTAL", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRCPAPURTOTAL", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRCPRBSUSPTOTAL", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("STATUS", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters.Add(new OracleParameter("idReg", OracleDbType.Int64, ParameterDirection.Output));

            cmd.Parameters["id"].Value = "ID1" + cnpj.Substring(0, 8) + "000000" + DateTime.Now.ToString("yyyyMMddHHmmss") + 1.ToString("00000");
            cmd.Parameters["indretif"].Value = indretif;
            cmd.Parameters["perapur"].Value = perapur;
            cmd.Parameters["NRRECIBO"].Value = numeroRecibo;
            cmd.Parameters["tpamb"].Value = DadosCabecalhoEventoConst.tpAmb;
            cmd.Parameters["procemi"].Value = DadosCabecalhoEventoConst.procEmi;
            cmd.Parameters["verproc"].Value = DadosCabecalhoEventoConst.verProc;
            cmd.Parameters["tpinsc"].Value = DadosCabecalhoEventoConst.tpInsc;
            cmd.Parameters["nrinsc"].Value = cnpj.Substring(0, 8) + "000000"; 
            cmd.Parameters["tpinscestab"].Value = DadosCabecalhoEventoConst.tpInsc;
            cmd.Parameters["nrinscestab"].Value = cnpjEstab;

            cmd.Parameters["VLRRECBRUTATOTAL"].Value = VLRRECBRUTATOTAL;
            cmd.Parameters["VLRCPAPURTOTAL"].Value = VLRCPAPURTOTAL;
            cmd.Parameters["VLRCPRBSUSPTOTAL"].Value = VLRCPRBSUSPTOTAL;
            cmd.Parameters["STATUS"].Value = "P";
            if (oc.State != ConnectionState.Open)
            {
                oc.Open();
            }
            cmd.ExecuteNonQuery();

            oc.Close();

        }

        public void atualiza(int idReg, int idRegEmpresa, string indretif, string perapur, string numeroRecibo, int idRegEstabelecimento, decimal VLRRECBRUTATOTAL, decimal VLRCPAPURTOTAL, decimal VLRCPRBSUSPTOTAL)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            EstabelecimentoDAL estabDLL = new EstabelecimentoDAL();
            String cnpjEstab = estabDLL.getEstabelecimento(idRegEstabelecimento).Rows[0]["cnpj"].ToString();


            string sqlUpdR2060 = "update r2060 set indretif = :indretif, perapur = :perapur, NRRECIBO = :NRRECIBO , nrinsc = :nrinsc, nrinscestab = :nrinscestab, VLRRECBRUTATOTAL = :VLRRECBRUTATOTAL, VLRCPAPURTOTAL = :VLRCPAPURTOTAL, VLRCPRBSUSPTOTAL = :VLRCPRBSUSPTOTAL where idReg = " + idReg.ToString();

            OracleCommand cmd = new OracleCommand(sqlUpdR2060, oc);            
            cmd.Parameters.Add(new OracleParameter("indretif", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NRRECIBO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinscestab", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRRECBRUTATOTAL", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRCPAPURTOTAL", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRCPRBSUSPTOTAL", OracleDbType.Decimal, ParameterDirection.Input));

            cmd.Parameters["indretif"].Value = indretif;
            cmd.Parameters["perapur"].Value = perapur;
            cmd.Parameters["NRRECIBO"].Value = numeroRecibo;
            cmd.Parameters["nrinsc"].Value = cnpj.Substring(0, 8) + "000000";
            cmd.Parameters["nrinscestab"].Value = cnpjEstab;

            cmd.Parameters["VLRRECBRUTATOTAL"].Value = VLRRECBRUTATOTAL;
            cmd.Parameters["VLRCPAPURTOTAL"].Value = VLRCPAPURTOTAL;
            cmd.Parameters["VLRCPRBSUSPTOTAL"].Value = VLRCPRBSUSPTOTAL;


            if (oc.State != ConnectionState.Open)
            {
                oc.Open();
            }
            cmd.ExecuteNonQuery();

            oc.Close();
        }
        public void atualizavlrCPApurTotal()
        {
            string sql = "update R2060 set VLRCPAPURTOTAL = (SELECT SUM(VLRCPRBAPUR) FROM R2060_TIPOCOD WHERE R2060_IDREG = R2060.IDREG) where STATUS = 'P'";

            oc.Open();
            OracleCommand cmd = new OracleCommand(sql, oc);
            cmd.ExecuteNonQuery();
            oc.Close();
        }
        public void incluirTipoCod(Int32 codAtivEcon, decimal vlrRecBrutaAtiv, decimal vlrExcRecBruta, decimal vlrAdicRecBruta, decimal vlrBcCprb, decimal vlrCprbApur, int r2060_idreg)
        {

            string sql = "insert into r2060_tipocod (codAtivEcon , vlrRecBrutaAtiv , vlrExcRecBruta , vlrAdicRecBruta , vlrBcCprb , vlrCprbApur, r2060_idreg ) values " +
                "(:codAtivEcon, :vlrRecBrutaAtiv, :vlrExcRecBruta, :vlrAdicRecBruta, :vlrBcCprb, :vlrCprbApur," + r2060_idreg.ToString() + ")";

            if (oc.State != ConnectionState.Open)
            {
                oc.Open();
            }
            OracleCommand cmd = new OracleCommand(sql, oc);
            cmd.Parameters.Add(new OracleParameter("codAtivEcon", OracleDbType.Int32, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrRecBrutaAtiv", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrExcRecBruta", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrAdicRecBruta", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrBcCprb", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrCprbApur", OracleDbType.Decimal, ParameterDirection.Input));

            cmd.Parameters["codAtivEcon"].Value = codAtivEcon;
            cmd.Parameters["vlrRecBrutaAtiv"].Value = vlrRecBrutaAtiv;
            cmd.Parameters["vlrExcRecBruta"].Value = vlrExcRecBruta;
            cmd.Parameters["vlrAdicRecBruta"].Value = vlrAdicRecBruta;
            cmd.Parameters["vlrBcCprb"].Value = vlrBcCprb;
            cmd.Parameters["vlrCprbApur"].Value = vlrCprbApur;

            cmd.ExecuteNonQuery();

            oc.Close();
        }
        public void atualizaTipoCod(int idReg, Int32 codAtivEcon, decimal vlrRecBrutaAtiv, decimal vlrExcRecBruta, decimal vlrAdicRecBruta, decimal vlrBcCprb, decimal vlrCprbApur)
        {

            string sql = "update r2060_tipocod set codAtivEcon = :codAtivEcon, vlrRecBrutaAtiv = :vlrRecBrutaAtiv, vlrExcRecBruta = :vlrExcRecBruta, vlrAdicRecBruta = :vlrAdicRecBruta, vlrBcCprb = :vlrBcCprb, vlrCprbApur = :vlrCprbApur where idReg = " + idReg.ToString();


            if (oc.State != ConnectionState.Open)
            {
                oc.Open();
            }
            OracleCommand cmd = new OracleCommand(sql, oc);
            cmd.Parameters.Add(new OracleParameter("codAtivEcon", OracleDbType.Int32, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrRecBrutaAtiv", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrExcRecBruta", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrAdicRecBruta", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrBcCprb", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrCprbApur", OracleDbType.Decimal, ParameterDirection.Input));

            cmd.Parameters["codAtivEcon"].Value = codAtivEcon;
            cmd.Parameters["vlrRecBrutaAtiv"].Value = vlrRecBrutaAtiv;
            cmd.Parameters["vlrExcRecBruta"].Value = vlrExcRecBruta;
            cmd.Parameters["vlrAdicRecBruta"].Value = vlrAdicRecBruta;
            cmd.Parameters["vlrBcCprb"].Value = vlrBcCprb;
            cmd.Parameters["vlrCprbApur"].Value = vlrCprbApur;

            cmd.ExecuteNonQuery();
            oc.Close();
        }


        public void incluirTipoAjuste(int tpAjuste, int codAjuste, decimal vlrAjuste, string descAjuste, string dtAjuste, int r2060_tipocod_idreg)
        {

            string sql = "insert into r2060_TIPOAJUSTE (tpAjuste , codAjuste , vlrAjuste , descAjuste , dtAjuste, r2060_tipocod_idreg ) values " +
                "(:tpAjuste, :codAjuste, :vlrAjuste, :descAjuste, :dtAjuste, :r2060_tipocod_idreg)";

            OracleCommand cmd = new OracleCommand(sql, oc);
            if (oc.State != ConnectionState.Open)
            {
                oc.Open();
            }
            cmd.Parameters.Add(new OracleParameter("tpAjuste", OracleDbType.Int32, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("codAjuste", OracleDbType.Int32, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrAjuste", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("descAjuste", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("dtAjuste", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("r2060_tipocod_idreg", OracleDbType.Int32, ParameterDirection.Input));
                        
            cmd.Parameters["tpAjuste"].Value = tpAjuste;
            cmd.Parameters["codAjuste"].Value = codAjuste;
            cmd.Parameters["vlrAjuste"].Value = vlrAjuste;
            cmd.Parameters["descAjuste"].Value = descAjuste;
            cmd.Parameters["dtAjuste"].Value = dtAjuste;
            cmd.Parameters["r2060_tipocod_idreg"].Value = r2060_tipocod_idreg;

            cmd.ExecuteNonQuery();

            oc.Close();
        }
        public void atualizaTipoAjuste(int idReg, int tpAjuste, int codAjuste, decimal vlrAjuste, string descAjuste, string  dtAjuste)
        {

            string sql = "update r2060_TIPOAJUSTE set tpAjuste = :tpAjuste, codAjuste = :codAjuste, vlrAjuste = :vlrAjuste, descAjuste = :descAjuste, dtAjuste = :dtAjuste where idReg = " + idReg.ToString();

            if (oc.State != ConnectionState.Open)
            {
                oc.Open();
            }
            OracleCommand cmd = new OracleCommand(sql, oc);
            
            cmd.Parameters.Add(new OracleParameter("tpAjuste", OracleDbType.Int32, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("codAjuste", OracleDbType.Int32, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrAjuste", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("descAjuste", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("dtAjuste", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("idReg", OracleDbType.Int64, ParameterDirection.Input));
                        
            cmd.Parameters["tpAjuste"].Value = tpAjuste;
            cmd.Parameters["codAjuste"].Value = codAjuste;
            cmd.Parameters["vlrAjuste"].Value = vlrAjuste;
            cmd.Parameters["descAjuste"].Value = descAjuste;
            cmd.Parameters["dtAjuste"].Value = dtAjuste;
            cmd.Parameters["idReg"].Value = idReg;
            
            cmd.ExecuteNonQuery();

            oc.Close();
        }

        public override void delete(int idReg)
        {
            String sql = "delete from R2060 where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }

        public void gerarEventoExclusao(string cnpj, string nrRecibo, string perApur)
        {
            R9000DAL r = new R9000DAL();
            r.incluir(cnpj, "R-2060", nrRecibo, perApur);
        }

        public override DataTable getData()
        {
            string sql = "select * from R2060";
            return odb.getDataTable(sql);
        }

        public DataTable getData(string cnpjEmpresa, string cnpjEstabelecimento, string perApur)
        {
            string sql = "SELECT R2060.*, SUM(VLRRECBRUTAATIV) AS RECEITA_BRUTA , SUM(VLRCPRBAPUR) AS VALOR_CONTRIB , SUM(VLREXCRECBRUTA) AS EXCLUSAO_RECEITA, SUM(VLRBCCPRB) AS BASE_CALCULO ";
            sql = sql + " FROM R2060 , R2060_TIPOCOD";
            sql = sql + " WHERE R2060.IDREG = R2060_TIPOCOD.R2060_IDREG(+)";
            sql = sql + " AND nrInsc = '" + cnpjEmpresa + "000000'";         
            if (cnpjEstabelecimento != "")
            {
                sql = sql + " and nrInscEstab = '" + cnpjEstabelecimento + "'";
            }
            sql = sql + " and perApur = '" + perApur + "'";
            sql = sql + " GROUP BY     R2060.IDREG,    R2060.ID,    INDRETIF,    NRRECIBO,    PERAPUR,    TPAMB,    PROCEMI,    VERPROC,    TPINSC,";
            sql = sql + "  NRINSC,    TPINSCESTAB,    NRINSCESTAB,    VLRRECBRUTATOTAL,    VLRCPAPURTOTAL,    VLRCPRBSUSPTOTAL,";
            sql = sql + "  DATAHORA_REGISTRO,    STATUS,    DATAHORA_ENVIO,    NR_RECIBO";           

            return odb.getDataTable(sql);
        }

        public DataTable getVerificaExistencia(string cnpjEstabelecimento, string perApur)
        {
            string sql = "SELECT 1 ";
            sql = sql + " FROM R2060 ";
            sql = sql + " WHERE NRINSCESTAB = (SELECT CNPJ FROM ESTABELECIMENTOS WHERE CODIGO = '" + cnpjEstabelecimento + "')";
            sql = sql + " and perApur = '" + perApur + "'";

            return odb.getDataTable(sql);
        }

        public override DataTable getData(int idReg)
        {
            string sql = "select * from R2060 where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getDataR2060_TipoCods(int R2060_idReg)
        {
            string sql = "select * from R2060_TIPOCOD where R2060_IDREG = " + R2060_idReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getDataR2060_TipoCod(int idReg)
        {
            string sql = "select * from R2060_TIPOCOD where IDREG = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getDataR2060_TipoAjustes(int R2060_TIPOCOD_IDReg)
        {
            string sql = "select * from R2060_TIPOAJUSTE where R2060_TIPOCOD_IDREG = " + R2060_TIPOCOD_IDReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getDataR2060_TipoAjuste(int idReg)
        {
            string sql = "select * from R2060_TIPOAJUSTE where IDREG = " + idReg.ToString();
            return odb.getDataTable(sql);
        }


        public void verificarSeReenvioFornecedor(string cnpjEmpresa, string perApur)
        {
            DataTable empresasPendente = new DataTable();
            empresasPendente = verificarSeReenvio(cnpjEmpresa.Substring(0, 8), perApur);
            if (empresasPendente != null)
            {
                for (int i = 0; i < empresasPendente.Rows.Count; i++)
                {
                    DataTable empresasAtualizarRecibo = new DataTable();
                    empresasAtualizarRecibo = verificarSeEnviado(cnpjEmpresa.Substring(0, 8), empresasPendente.Rows[i][2].ToString(), perApur, empresasPendente.Rows[i][1].ToString());
                    if (empresasAtualizarRecibo != null)
                    {
                        for (int j = 0; j < empresasAtualizarRecibo.Rows.Count; j++)
                        {
                            atualizaRecibo(Convert.ToInt32(empresasPendente.Rows[i][0].ToString()), empresasAtualizarRecibo.Rows[j][0].ToString());
                        }
                    }

                }
            }
        }
        public DataTable verificarSeReenvio(string cnpjEmpresa, string perApur)
        {
            string sql = "select R2060.IDREG , CNPJPRESTADOR , R2060.nrInscEstab from R2060 , R2010_IDEPRESTSERV  ";
            sql = sql + " where R2010_IDEPRESTSERV.R2010_IDREG = R2010.IDREG AND nrInsc = '" + cnpjEmpresa + "000000'";
            sql = sql + " and R2010.perApur = '" + perApur + "'";
            sql = sql + " AND R2010.STATUS = 'P' ";

            return odb.getDataTable(sql);
        }

        public DataTable verificarSeEnviado(string cnpjEmpresa, string cnpjEstabelecimento, string perApur, string cnpjFornecedor)
        {
            string sql = "select NR_RECIBO from R2010 , R2010_IDEPRESTSERV  ";
            sql = sql + " where R2010_IDEPRESTSERV.R2010_IDREG = R2010.IDREG AND nrInsc = '" + cnpjEmpresa + "000000'";
            sql = sql + " and R2010.nrInscEstab = '" + cnpjEstabelecimento + "'";
            sql = sql + " and R2010.perApur = '" + perApur + "'";
            sql = sql + " and R2010_IDEPRESTSERV.CNPJPRESTADOR = '" + cnpjFornecedor + "'";
            sql = sql + " AND R2010.NR_RECIBO IS NOT NULL ";
            sql = sql + " AND R2010.idreg = (SELECT MAX(R2010.idreg) FROM R2010 , R2010_IDEPRESTSERV  WHERE R2010_IDEPRESTSERV.R2010_IDREG = R2010.IDREG AND  nrInsc = '" + cnpjEmpresa + "000000' AND NR_RECIBO IS NOT NULL and nrInscEstab = '" + cnpjEstabelecimento + "'  and perApur = '" + perApur + "'  and R2010_IDEPRESTSERV.CNPJPRESTADOR = '" + cnpjFornecedor + "')";

            return odb.getDataTable(sql);
        }

        public void atualizaRecibo(int idReg, string recibo)
        {
            //string sqlUpdR2010 = "update r2010 set indretif = :indretif, NRRECIBO = :NRRECIBO,  nrinsc = :nrinsc, nrinscestab = :nrinscestab, INDOBRA = :INDOBRA  where idReg = " + idReg.ToString();
            string sqlUpdR2060 = "update r2060 set NRRECIBO = :NRRECIBO, INDRETIF = 2 where idReg = " + idReg.ToString();

            OracleCommand cmd = new OracleCommand(sqlUpdR2060, oc);
            cmd.Parameters.Add(new OracleParameter("NRRECIBO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters["NRRECIBO"].Value = recibo;

            oc.Open();
            cmd.ExecuteNonQuery();
            oc.Close();
        }

        public override XmlDocument getXMLEvt(int idReg)
        {
            ReinfOraDB reinfOraDB = new ReinfOraDB();
            DataTable t = getData(idReg);

            evtInfoCPRB.Reinf r = new evtInfoCPRB.Reinf();
            ReinfEvtCPRB evt = new ReinfEvtCPRB();

            // Cabeçalho comum a todos os eventos
            evt.id = t.Rows[0]["id"].ToString();
            evt.ideEvento = new ReinfEvtCPRBIdeEvento();
            evt.ideEvento.procEmi = Convert.ToByte(t.Rows[0]["procEmi"].ToString());
            evt.ideEvento.tpAmb = Convert.ToByte(t.Rows[0]["tpAmb"].ToString());
            evt.ideEvento.verProc = t.Rows[0]["verProc"].ToString();
            evt.ideContri = new ReinfEvtCPRBIdeContri();
            evt.ideContri.tpInsc = Convert.ToByte(t.Rows[0]["tpInsc"].ToString());
            evt.ideContri.nrInsc = t.Rows[0]["nrInsc"].ToString().Substring(0,8);
            // Fim do Cabeçalho

            evt.ideEvento.perApur = t.Rows[0]["perApur"].ToString();
            evt.ideEvento.indRetif = Convert.ToByte(t.Rows[0]["indRetif"].ToString());
            evt.ideEvento.nrRecibo = t.Rows[0]["NRRECIBO"].ToString();

            DataTable dt2060 = getData(idReg);
            // Cessão de Mao de Obra ou Empreitada
            evt.infoCPRB = new ReinfEvtCPRBInfoCPRB();
            evt.infoCPRB.ideEstab = new ReinfEvtCPRBInfoCPRBIdeEstab();
            evt.infoCPRB.ideEstab.tpInscEstab = Convert.ToUInt16(dt2060.Rows[0]["tpInscEstab"].ToString());
            evt.infoCPRB.ideEstab.nrInscEstab = dt2060.Rows[0]["nrInscEstab"].ToString();
            
            evt.infoCPRB.ideEstab.vlrRecBrutaTotal = Utils.ConverteNumero(dt2060.Rows[0]["vlrRecBrutaTotal"].ToString());
            evt.infoCPRB.ideEstab.vlrCPApurTotal = Utils.ConverteNumero(dt2060.Rows[0]["vlrCPApurTotal"].ToString());

            //decimal _vlrCPApurTotal = 0;

            // Adicionar os TipoDeCodAtv
            DataTable dt2060TipoCod = getDataR2060_TipoCods(idReg);
            evt.infoCPRB.ideEstab.tipoCod = new ReinfEvtCPRBInfoCPRBIdeEstabTipoCod[dt2060TipoCod.Rows.Count];
            for (int i = 0; i < dt2060TipoCod.Rows.Count; i++)
            {
                evt.infoCPRB.ideEstab.tipoCod[i] = new ReinfEvtCPRBInfoCPRBIdeEstabTipoCod();
                //evt.infoCPRB.ideEstab.tipoCod[i].codAtivEcon = Convert.ToUInt32(dt2060TipoCod.Rows[i]["codAtivEcon"].ToString());
                evt.infoCPRB.ideEstab.tipoCod[i].codAtivEcon = dt2060TipoCod.Rows[i]["codAtivEcon"].ToString();
                evt.infoCPRB.ideEstab.tipoCod[i].vlrRecBrutaAtiv = Utils.ConverteNumero(dt2060TipoCod.Rows[i]["vlrRecBrutaAtiv"].ToString());
                evt.infoCPRB.ideEstab.tipoCod[i].vlrExcRecBruta = Utils.ConverteNumero(dt2060TipoCod.Rows[i]["vlrExcRecBruta"].ToString());                
                evt.infoCPRB.ideEstab.tipoCod[i].vlrAdicRecBruta = Utils.ConverteNumero(dt2060TipoCod.Rows[i]["vlrAdicRecBruta"].ToString());
                evt.infoCPRB.ideEstab.tipoCod[i].vlrBcCPRB = Utils.ConverteNumero(dt2060TipoCod.Rows[i]["vlrBcCPRB"].ToString());

                if (dt2060TipoCod.Rows[i]["vlrCPRBapur"] != null && dt2060TipoCod.Rows[i]["vlrCPRBapur"].ToString() != "0")
                {
                    evt.infoCPRB.ideEstab.tipoCod[i].vlrCPRBapur = Utils.ConverteNumero(dt2060TipoCod.Rows[i]["vlrCPRBapur"].ToString());
                  //  _vlrCPApurTotal = _vlrCPApurTotal + Convert.ToDecimal(evt.infoCPRB.ideEstab.tipoCod[i].vlrCPRBapur);
                }

                // Adicionar as Notas Fiscais do Prestador                    
                DataTable dt2060TipoAjuste = getDataR2060_TipoAjustes(Convert.ToInt32(dt2060TipoCod.Rows[i]["idReg"].ToString()));
                evt.infoCPRB.ideEstab.tipoCod[i].tipoAjuste = new ReinfEvtCPRBInfoCPRBIdeEstabTipoCodTipoAjuste[dt2060TipoAjuste.Rows.Count];
                for (int j = 0; j < dt2060TipoAjuste.Rows.Count; j++)
                {
                    evt.infoCPRB.ideEstab.tipoCod[i].tipoAjuste[j] = new ReinfEvtCPRBInfoCPRBIdeEstabTipoCodTipoAjuste();
                    evt.infoCPRB.ideEstab.tipoCod[i].tipoAjuste[j].tpAjuste = Convert.ToByte(dt2060TipoAjuste.Rows[j]["tpAjuste"].ToString());
                    evt.infoCPRB.ideEstab.tipoCod[i].tipoAjuste[j].codAjuste = dt2060TipoAjuste.Rows[j]["codAjuste"].ToString();
                    evt.infoCPRB.ideEstab.tipoCod[i].tipoAjuste[j].vlrAjuste = Utils.ConverteNumero(dt2060TipoAjuste.Rows[j]["vlrAjuste"].ToString());
                    evt.infoCPRB.ideEstab.tipoCod[i].tipoAjuste[j].descAjuste = dt2060TipoAjuste.Rows[j]["descAjuste"].ToString(); ;
                    evt.infoCPRB.ideEstab.tipoCod[i].tipoAjuste[j].dtAjuste = dt2060TipoAjuste.Rows[j]["dtAjuste"].ToString();
                }
            }

            r.evtCPRB = evt;


            // Serializaçao do Objeto em Memória para retonrar o XMLDocument
            XmlSerializer x = new XmlSerializer(r.GetType());

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "http://www.reinf.esocial.gov.br/schemas/evtInfoCPRB/" + DadosCabecalhoEventoConst.verProcClass);

            MemoryStream memStm = new MemoryStream();
            x.Serialize(memStm, r, xsn);
            memStm.Position = 0;

            // Retirar as quebras de linhas e espaços em branco do XML
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            var xtr = XmlReader.Create(memStm, settings);

            // Criar o docoumento de retorno
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xtr);

            // Retornar o XMLDocument com o Envento
            return xmlDoc;
        }

    }
}

