using evtTomadorServicos;
using Oracle.ManagedDataAccess.Client;
using RefinDBClassLibrary;
using ReinfModelClassLibrary;
using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ReinfDBClassLibrary
{
    public class R2010DAL : RBASEDAL
    {
        ComplyOraDB c_odb = new ComplyOraDB();

        public override void delete(int idReg)
        {
            String sql = "delete from R2010 where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }
        public void deleteNFS(int idReg)
        {
            String sql = "delete from R2010_NFS where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }
        public void deleteNFSServ(int idReg)
        {
            String sql = "delete from R2010_INFOTPSERV where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }
        public void gerarR2010Comply(int idRegEmpresa, string perApur)
        {
            string sdtIni = "01/" + perApur.Substring(5, 2) + "/" + perApur.Substring(0, 4);
            DateTime dtIni = Convert.ToDateTime(sdtIni);
            DateTime dtFim = dtIni.AddMonths(1).AddDays(-1);
            string sdtFim = dtFim.ToString("dd-MM-yyyy");

            EmpresaDAL eDLL = new EmpresaDAL();
            string empresa = eDLL.getEmpresa(Convert.ToInt32(idRegEmpresa)).Rows[0]["CODIGO"].ToString();
            //
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("perapur"));
            dt.Columns.Add(new DataColumn("empresa"));
            dt.Columns.Add(new DataColumn("filial"));
            dt.Columns.Add(new DataColumn("dtemissaonf"));
            dt.Columns.Add(new DataColumn("cpf_cnpjprestador"));
            dt.Columns.Add(new DataColumn("vlrbruto"));
            dt.Columns.Add(new DataColumn("numdocto"));
            dt.Columns.Add(new DataColumn("SERIE"));
            dt.Columns.Add(new DataColumn("VLRBASERET"));
            dt.Columns.Add(new DataColumn("vlrretencao"));
            dt.Columns.Add(new DataColumn("TPSERVICO"));
            dt.Columns.Add(new DataColumn("VLRNRETPRINCIPAL"));
            dt.Columns.Add(new DataColumn("VLRSERVICO15"));
            dt.Columns.Add(new DataColumn("VLRSERVICO20"));
            dt.Columns.Add(new DataColumn("VLRSERVICO25"));
            dt.Columns.Add(new DataColumn("VLRADICIONAL"));
            dt.Columns.Add(new DataColumn("VLRNRETADICIONAL"));

            DataTable dt2010;

            string sql =
                    "     select " +
                    " to_char(s.SVT_DT_EMISSAO, 'YYYY-MM') perApur,   " +
                    "   (select m.bmz_codigo from bsc_matriz m where m.cus_id = (select f.cus_id from bsc_filial f where f.bus_id = s.BUS_ID)) empresa," +
                    "    (select f.BFL_CODIGO from bsc_filial f where f.bus_id = s.BUS_ID) filial, " +
                    "    to_char(s.SVT_DT_EMISSAO, 'DD-MM-YYYY') dtemissaonf,  " +
                    "    (select BPC_CNPJ_CPF from BSC_PARCEIRO where bpc_id = s.BPC_ID) cpf_cnpjprestador, " +
                    "     s.SVT_TOT_NOTA vlrbruto, " +
                    "     s.SVT_NUM_NF numdocto, " +
                    "     s.SVT_SERIE, " +
                    "     p.STI_BASE_CALCULO VLRBASERET, " +
                    "     p.STI_VLR_IMPOSTO vlrretencao, " +
                    "     (SELECT CODIGO_REINF " +
                    "     FROM BSC_NF_ITEM , Z_REINF_CODIGO_SERVICO" +
                    "     WHERE BSC_NF_ITEM.NIT_COD_PRODUTO = Z_REINF_CODIGO_SERVICO.CODIGO_SAP" +
                    "     AND NCP_ID = (select NCP_ID from BSC_NF_CAPA where NCP_DOCNUM_CONT = s.SVT_DOCNUM_CONT AND ROWNUM = 1)" +
                    "     AND ROWNUM = 1 )TPSERVICO, " +
                    "     0 VLRNRETPRINCIPAL, " +
                    "     0 VLRSERVICO15, " +
                    "     0 VLRSERVICO20, " +
                    "     0 VLRSERVICO25, " +
                    "     0 VLRADICIONAL, " +
                    "     0 VLRNRETADICIONAL " +
                    "   from " +
                    "     STD_SERVICO_TOMADO s, " +
                    "     STD_SERVICO_TOMADO_ITEM i, " +
                    "     STD_SERVICO_TOMADO_IMPOSTO p," +
                    "     BSC_FILIAL f, " +
                    "     BSC_MATRIZ m " +
                    "   WHERE " +
                    "     s.BST_ID = 1 and " +
                    "     p.BTI_ID = 69 and " + // INSS
                    "     p.SIT_ID = i.SIT_ID and " +
                    "     i.SVT_ID = s.svt_id and " +
                    "     s.BUS_ID = f.bus_id and " +
                    "     m.cus_id = s.cus_id and " +
                    "     p.STI_VLR_IMPOSTO > 0  and " +
                    "     s.SVT_DT_EMISSAO BETWEEN '" + sdtIni + "' and '" + sdtFim + "' and" +
                    "     (select m.bmz_codigo from bsc_matriz m where m.cus_id = (select f.cus_id from bsc_filial f where f.bus_id = s.BUS_ID)) = " + empresa;
            dt2010 = c_odb.getDataTable(sql);

            foreach (DataRow dr in dt2010.Rows)
            {
                dt.Rows.Add(dr.ItemArray);
            }
            ds.Tables.Add(dt);
            carregaR2010Temp(ds);
            preencherR2010();
            empresa = eDLL.getEmpresa(Convert.ToInt32(idRegEmpresa)).Rows[0]["CNPJ"].ToString();
            verificarSeReenvioFornecedor(empresa, perApur);
        }

        public void gerarEventoExclusao(string cnpj, string nrRecibo, string perApur)
        {
            R9000DAL r = new R9000DAL();
            r.incluir(cnpj, "R-2010", nrRecibo, perApur);
        }

        public void limparR2010Temp()
        {
            string sqlDelete = "delete from r2010_temp";
            odb.executeSql(sqlDelete);

        }

        public void carregaR2010Temp(DataSet ds)
        {

            limparR2010Temp();
            string sql = "insert into r2010_temp (perapur, empresa, filial, dtemissaonf, vlrretencao,  cpf_cnpjprestador, vlrbruto, numdocto, serie, vlrBaseRet, tpServico, vlrNRetPrincipal, vlrServico15, vlrServico20, vlrServico25, vlrAdicional, vlrNRetAdicional ) " +
                "values (:perapur, :empresa, :filial, :dtemissaonf, :vlrretencao, :cpf_cnpjprestador, :vlrbruto, :numdocto, :serie, :vlrBaseRet, :tpServico, :vlrNRetPrincipal, :vlrServico15, :vlrServico20, :vlrServico25, :vlrAdicional, :vlrNRetAdicional)";
            
            oc.Open();

            // Preencher com os dados da Carga
            OracleCommand cmd = new OracleCommand(sql, oc);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("empresa", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("filial", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("dtemissaonf", OracleDbType.Date));
                cmd.Parameters.Add(new OracleParameter("vlrretencao", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("cpf_cnpjprestador", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("vlrbruto", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("numdocto", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("serie", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("vlrBaseRet", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("tpServico", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("vlrNRetPrincipal", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("vlrServico15", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("vlrServico20", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("vlrServico25", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("vlrAdicional", OracleDbType.Decimal, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("vlrNRetAdicional", OracleDbType.Decimal, ParameterDirection.Input));

                if (getVerificaExistencia(r["filial"].ToString(), r["cpf_cnpjprestador"].ToString(), r["perapur"].ToString()).Rows.Count == 0)
                {
                    cmd.Parameters["perapur"].Value = r["perapur"].ToString();
                    cmd.Parameters["empresa"].Value = r["empresa"].ToString();
                    cmd.Parameters["filial"].Value = r["filial"].ToString();
                    cmd.Parameters["dtemissaonf"].Value = Convert.ToDateTime(r["dtemissaonf"].ToString());
                    cmd.Parameters["vlrretencao"].Value = Convert.ToDecimal(r["vlrretencao"].ToString());
                    cmd.Parameters["cpf_cnpjprestador"].Value = r["cpf_cnpjprestador"].ToString();
                    cmd.Parameters["vlrbruto"].Value = Convert.ToDecimal(r["vlrbruto"].ToString());
                    cmd.Parameters["numdocto"].Value = r["numdocto"].ToString();
                    cmd.Parameters["serie"].Value = r["serie"].ToString();
                    if (r["vlrBaseRet"].ToString() != "")
                        cmd.Parameters["vlrBaseRet"].Value = Convert.ToDecimal(r["vlrBaseRet"].ToString());
                    cmd.Parameters["tpServico"].Value = r["tpServico"].ToString();

                    if (r["vlrNRetPrincipal"].ToString() != "" && r["vlrNRetPrincipal"].ToString() != "0")
                        cmd.Parameters["vlrNRetPrincipal"].Value = Convert.ToDecimal(r["vlrNRetPrincipal"].ToString());
                    if (r["vlrServico15"].ToString() != "")
                        cmd.Parameters["vlrServico15"].Value = Convert.ToDecimal(r["vlrServico15"].ToString());
                    if (r["vlrServico20"].ToString() != "")
                        cmd.Parameters["vlrServico20"].Value = Convert.ToDecimal(r["vlrServico20"].ToString());
                    if (r["vlrServico25"].ToString() != "")
                        cmd.Parameters["vlrServico25"].Value = Convert.ToDecimal(r["vlrServico25"].ToString());
                    if (r["vlrAdicional"].ToString() != "" && r["vlrAdicional"].ToString() != "0")
                        cmd.Parameters["vlrAdicional"].Value = Convert.ToDecimal(r["vlrAdicional"].ToString());
                    if (r["vlrNRetAdicional"].ToString() != "")
                        cmd.Parameters["vlrNRetAdicional"].Value = Convert.ToDecimal(r["vlrNRetAdicional"].ToString());
                    cmd.ExecuteNonQuery();
                }
            }

            oc.Close();
        }

        public void preencherR2010()
        {
            int i = 0;

            EmpresaDAL empDLL = new EmpresaDAL();
            EstabelecimentoDAL estDLL = new EstabelecimentoDAL();

            string sqlEventos = "select distinct perapur, " +
                                  "empresa, filial, cpf_cnpjprestador  " +
                                  " from " +
                                  " r2010_temp";

            oc.Open();
            OracleDataAdapter da = new OracleDataAdapter(sqlEventos, oc);
            DataSet ds2010 = new DataSet();
            da.Fill(ds2010);

            // Preencher com os dados da Carga
            string sqlInsR2010 = "insert into r2010 (id, indretif,perapur, tpamb, procemi, verproc, tpinsc, nrinsc, tpinscestab, nrinscestab, indobra) " +
                " values (:id, :indretif, :perapur, :tpamb, :procemi, :verproc, :tpinsc, :nrinsc, :tpinscestab, :nrinscestab, :indobra) " +
                 " RETURNING idReg INTO :idReg";

            OracleCommand cmd = new OracleCommand(sqlInsR2010, oc);      
 
            // Inserir no Evento R2010
            foreach (DataRow r in ds2010.Tables[0].Rows)
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
                cmd.Parameters.Add(new OracleParameter("indobra", OracleDbType.Int16, ParameterDirection.Input));
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
                cmd.Parameters["indobra"].Value = 0;
                cmd.ExecuteNonQuery();
                int idReg2010 = Convert.ToInt16(cmd.Parameters["idReg"].Value.ToString());

                // Inserir no Evento R2010_IDEPRESTSERV
                string sql2010_IdePrestServ = "select CPF_CNPJPRESTADOR,  sum(VLRBRUTO) vlrTotalBruto, sum(VLRRETENCAO) vlrTotalRetPrinc, " +
                                        " sum(VLRBASERET) VLRTOTALBASERET, sum(VLRADICIONAL) VLRTOTALRETADIC, SUM(VLRNRETPRINCIPAL) VLRTOTALNRETPRINC, SUM(VLRNRETADICIONAL) VLRTOTALNRETADIC" +
                                        " from R2010_TEMP where empresa = '" + r["empresa"].ToString() + "' and filial = '" + r["filial"].ToString() + "' and PERAPUR = '" + r["perapur"].ToString() + "' and CPF_CNPJPRESTADOR = '" + r["cpf_cnpjprestador"].ToString() + "'" +
                                        " group by CPF_CNPJPRESTADOR";
                da = new OracleDataAdapter(sql2010_IdePrestServ, oc);
                DataSet ds2010IdePrestServ = new DataSet();
                da.Fill(ds2010IdePrestServ);


                string sqlInsR2010_IDEPRESTSERV = "insert into r2010_IDEPRESTSERV (cnpjprestador, VLRTOTALBRUTO, VLRTOTALBASERET, VLRTOTALRETPRINC, VLRTOTALRETADIC, VLRTOTALNRETPRINC, VLRTOTALNRETADIC, indcprb,r2010_idreg) " +
                    " values (:cnpjprestador, :VLRTOTALBRUTO, :VLRTOTALBASERET, :VLRTOTALRETPRINC, :VLRTOTALRETADIC, :VLRTOTALNRETPRINC, :VLRTOTALNRETADIC, :indcprb, :r2010_idreg) " +
                     " RETURNING idReg INTO :idRegIdePrestServ";
                OracleCommand cmdIdePrestServ = new OracleCommand(sqlInsR2010_IDEPRESTSERV, oc);
                foreach (DataRow rIdePrestServ in ds2010IdePrestServ.Tables[0].Rows)
                {
                    cmdIdePrestServ.Parameters.Clear();
                    cmdIdePrestServ.Parameters.Add(new OracleParameter("cnpjprestador", OracleDbType.Varchar2, ParameterDirection.Input));
                    cmdIdePrestServ.Parameters.Add(new OracleParameter("VLRTOTALBRUTO", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdIdePrestServ.Parameters.Add(new OracleParameter("VLRTOTALBASERET", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdIdePrestServ.Parameters.Add(new OracleParameter("VLRTOTALRETPRINC", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdIdePrestServ.Parameters.Add(new OracleParameter("VLRTOTALRETADIC", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdIdePrestServ.Parameters.Add(new OracleParameter("VLRTOTALNRETPRINC", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdIdePrestServ.Parameters.Add(new OracleParameter("VLRTOTALNRETADIC", OracleDbType.Decimal, ParameterDirection.Input));
                    cmdIdePrestServ.Parameters.Add(new OracleParameter("indcprb", OracleDbType.Int16));
                    cmdIdePrestServ.Parameters.Add(new OracleParameter("r2010_idreg", OracleDbType.Int16, ParameterDirection.Input));
                    cmdIdePrestServ.Parameters.Add(new OracleParameter("idRegIdePrestServ", OracleDbType.Int64, ParameterDirection.Output));

                    cmdIdePrestServ.Parameters["cnpjprestador"].Value = rIdePrestServ["CPF_CNPJPRESTADOR"].ToString();
                    cmdIdePrestServ.Parameters["VLRTOTALBRUTO"].Value = Convert.ToDecimal(rIdePrestServ["vlrTotalBruto"].ToString());
                    cmdIdePrestServ.Parameters["VLRTOTALBASERET"].Value = Convert.ToDecimal(rIdePrestServ["VLRTOTALBASERET"].ToString());
                    cmdIdePrestServ.Parameters["VLRTOTALRETPRINC"].Value = Convert.ToDecimal(rIdePrestServ["vlrTotalRetPrinc"].ToString());
                    if (rIdePrestServ["VLRTOTALRETADIC"].ToString() != "")
                    {
                        cmdIdePrestServ.Parameters["VLRTOTALRETADIC"].Value = Convert.ToDecimal(rIdePrestServ["VLRTOTALRETADIC"].ToString());
                    }
                    if (rIdePrestServ["VLRTOTALNRETPRINC"].ToString() != "")
                    {
                        cmdIdePrestServ.Parameters["VLRTOTALNRETPRINC"].Value = Convert.ToDecimal(rIdePrestServ["VLRTOTALNRETPRINC"].ToString());
                    }
                    if (rIdePrestServ["VLRTOTALNRETADIC"].ToString() != "")
                    {
                        cmdIdePrestServ.Parameters["VLRTOTALNRETADIC"].Value = Convert.ToDecimal(rIdePrestServ["VLRTOTALNRETADIC"].ToString());
                    }
                    try
                    {
                        if ((Convert.ToDecimal(rIdePrestServ["vlrTotalRetPrinc"].ToString()) / Convert.ToDecimal(rIdePrestServ["VLRTOTALBASERET"].ToString())) * 100 >= 10)
                        {
                            cmdIdePrestServ.Parameters["indcprb"].Value = 0;
                        }
                        else
                        {
                            cmdIdePrestServ.Parameters["indcprb"].Value = 1;
                        }
                    }
                    catch { cmdIdePrestServ.Parameters["indcprb"].Value = 0; }
                    cmdIdePrestServ.Parameters["r2010_idreg"].Value = idReg2010;
                    cmdIdePrestServ.ExecuteNonQuery();
                    int idRegIdePrestServ = Convert.ToInt16(cmdIdePrestServ.Parameters["idRegIdePrestServ"].Value.ToString());

                    // Inserir no Evento R2010_NFS
                    string sql2010_NFS = "select * from R2010_TEMP where empresa = '" + r["empresa"].ToString() + "' and filial = '" + r["filial"].ToString() + "' and PERAPUR = '" + r["perapur"].ToString() + "' " +
                                         " and CPF_CNPJPRESTADOR = '" + rIdePrestServ["CPF_CNPJPRESTADOR"].ToString() + "'";
                    da = new OracleDataAdapter(sql2010_NFS, oc);
                    DataSet ds2010NFS = new DataSet();
                    da.Fill(ds2010NFS);

                    string sqlInsR2010_NFS = "insert into r2010_NFS (SERIE,NUMDOCTO,DTEMISSAONF,VLRBRUTO, OBS, R2010_IDEPRESTSERV_IDREG) " +
                        " values (:SERIE,:NUMDOCTO,:DTEMISSAONF,:VLRBRUTO, :OBS, :R2010_IDEPRESTSERV_IDREG) " +
                         " RETURNING idReg INTO :idRegNFS";
                    OracleCommand cmdNFS = new OracleCommand(sqlInsR2010_NFS, oc);
                    foreach (DataRow rNFS in ds2010NFS.Tables[0].Rows)
                    {
                        cmdNFS.Parameters.Clear();
                        cmdNFS.Parameters.Add(new OracleParameter("SERIE", OracleDbType.Varchar2, ParameterDirection.Input));
                        cmdNFS.Parameters.Add(new OracleParameter("NUMDOCTO", OracleDbType.Varchar2, ParameterDirection.Input));
                        cmdNFS.Parameters.Add(new OracleParameter("DTEMISSAONF", OracleDbType.Date));
                        cmdNFS.Parameters.Add(new OracleParameter("VLRBRUTO", OracleDbType.Decimal, ParameterDirection.Input));
                        cmdNFS.Parameters.Add(new OracleParameter("OBS", OracleDbType.Varchar2, ParameterDirection.Input));
                        cmdNFS.Parameters.Add(new OracleParameter("R2010_IDEPRESTSERV_IDREG", OracleDbType.Int64, ParameterDirection.Input));
                        cmdNFS.Parameters.Add(new OracleParameter("idRegNFS", OracleDbType.Int64, ParameterDirection.Output));

                        cmdNFS.Parameters["SERIE"].Value = "1";// rNFS["SERIE"].ToString();
                        cmdNFS.Parameters["NUMDOCTO"].Value = rNFS["NUMDOCTO"].ToString();
                        cmdNFS.Parameters["DTEMISSAONF"].Value = Convert.ToDateTime(rNFS["DTEMISSAONF"].ToString());
                        cmdNFS.Parameters["VLRBRUTO"].Value = Convert.ToDecimal(rNFS["VLRBRUTO"].ToString());
                        cmdNFS.Parameters["OBS"].Value = "";
                        cmdNFS.Parameters["R2010_IDEPRESTSERV_IDREG"].Value = idRegIdePrestServ;
                        cmdNFS.ExecuteNonQuery();
                        int idRegNFS = Convert.ToInt16(cmdNFS.Parameters["idRegNFS"].Value.ToString());

                        // Inserir no Evento R2010_INFOTPSERV
                        string sql2010_INFOTPSERV = "select * from R2010_TEMP where empresa = '" + r["empresa"].ToString() + "' and filial = '" + r["filial"].ToString() + "' and PERAPUR = '" + r["perapur"].ToString() + "' " +
                         " and CPF_CNPJPRESTADOR = '" + rIdePrestServ["CPF_CNPJPRESTADOR"].ToString() + "' and numdocto = '" + rNFS["numdocto"].ToString() + "'";
                        da = new OracleDataAdapter(sql2010_INFOTPSERV, oc);
                        DataSet ds2010InfoTpServ = new DataSet();
                        da.Fill(ds2010InfoTpServ);
                        string sqlInsR2010__INFOTPSERV = "insert into r2010_INFOTPSERV (TPSERVICO, VLRBASERET, VLRRETENCAO,VLRRETSUB,VLRNRETPRINC,VLRSERVICOS15,VLRSERVICOS20,VLRSERVICOS25,VLRADICIONAL,VLRNRETADIC,R2010_NFS_IDREG ) " +
                            " values (:TPSERVICO, :VLRBASERET, :VLRRETENCAO,:VLRRETSUB,:VLRNRETPRINC,:VLRSERVICOS15,:VLRSERVICOS20,:VLRSERVICOS25,:VLRADICIONAL,:VLRNRETADIC,:R2010_NFS_IDREG) " +
                             " RETURNING idReg INTO :idRegINFOTPSERV";
                        OracleCommand cmdINFOTPSERV = new OracleCommand(sqlInsR2010__INFOTPSERV, oc);
                        foreach (DataRow rNFOTPSERV in ds2010InfoTpServ.Tables[0].Rows)
                        {
                            cmdINFOTPSERV.Parameters.Clear();
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("TPSERVICO", OracleDbType.Varchar2, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRBASERET", OracleDbType.Decimal, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRRETENCAO", OracleDbType.Decimal, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRRETSUB", OracleDbType.Decimal, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRNRETPRINC", OracleDbType.Decimal, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRSERVICOS15", OracleDbType.Decimal, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRSERVICOS20", OracleDbType.Decimal, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRSERVICOS25", OracleDbType.Decimal, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRADICIONAL", OracleDbType.Decimal, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("VLRNRETADIC", OracleDbType.Decimal, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("R2010_NFS_IDREG", OracleDbType.Int64, ParameterDirection.Input));
                            cmdINFOTPSERV.Parameters.Add(new OracleParameter("idRegINFOTPSERV", OracleDbType.Int64, ParameterDirection.Output));

                            if (rNFOTPSERV["TPSERVICO"].ToString() != "")
                            {
                                cmdINFOTPSERV.Parameters["TPSERVICO"].Value = rNFOTPSERV["TPSERVICO"].ToString();
                            }
                            else
                            {
                                cmdINFOTPSERV.Parameters["TPSERVICO"].Value = "NÃO EXIST";
                            }
                            cmdINFOTPSERV.Parameters["VLRBASERET"].Value = Convert.ToDecimal(rNFOTPSERV["VLRBASERET"].ToString());
                            cmdINFOTPSERV.Parameters["VLRRETENCAO"].Value = Convert.ToDecimal(rNFOTPSERV["VLRRETENCAO"].ToString());
                            cmdINFOTPSERV.Parameters["VLRRETSUB"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRNRETPRINC"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRSERVICOS15"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRSERVICOS20"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRSERVICOS25"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRADICIONAL"].Value = 0;
                            cmdINFOTPSERV.Parameters["VLRNRETADIC"].Value = 0;
                            cmdINFOTPSERV.Parameters["R2010_NFS_IDREG"].Value = idRegNFS;
                            cmdINFOTPSERV.ExecuteNonQuery();
                            int idRegINFOTPSERV = Convert.ToInt16(cmdINFOTPSERV.Parameters["idRegINFOTPSERV"].Value.ToString());
                        }
                    }
                }
            }
            oc.Close();
        }

        public void ajustarValoresTotais(int idReg)
        {
            string sqlValores = "select " +
                 " sum(vlrBaseRet) totalBaseRet," +
                 " (sum(vlrRetencao) - sum(vlrRetSub)) totalRetPrinc,  " +
                 " sum(vlrAdicional) totalRetAdic,    " +
                 " sum(vlrNRetPrinc) totalNRetPrinc," +
                 " sum(vlrNRetAdic) totalNRetAdic" +
                 " from R2010_INFOTPSERV where R2010_NFS_IDREG in " +
                 " (select idReg from R2010_NFS where R2010_IDEPRESTSERV_IDREG in (select idReg from R2010_IDEPRESTSERV where R2010_IDREG = " + idReg.ToString() + "))";

            string sqlValorBruto = "select sum(vlrBruto) totalBruto from R2010_NFS where R2010_IDEPRESTSERV_IDREG in (select idReg from R2010_IDEPRESTSERV where R2010_IDREG =  " + idReg.ToString() + ")";


            DataTable dtVals = odb.getDataTable(sqlValores);
            DataTable dtVlBruto = odb.getDataTable(sqlValorBruto);

            decimal _vlrTotalBruto = Convert.ToDecimal(dtVlBruto.Rows[0]["TotalBruto"].ToString());
            decimal _vlrtotalBaseRet = Convert.ToDecimal(dtVals.Rows[0]["totalBaseRet"].ToString());
            decimal _vlrtotalRetPrinc = Convert.ToDecimal(dtVals.Rows[0]["totalRetPrinc"].ToString());
            decimal _vlrtotalRetAdic = Convert.ToDecimal(dtVals.Rows[0]["totalRetAdic"].ToString());
            decimal _vlrtotalNRetPrinc = Convert.ToDecimal(dtVals.Rows[0]["totalNRetPrinc"].ToString());
            decimal _vlrtotalNRetAdic = Convert.ToDecimal(dtVals.Rows[0]["totalNRetAdic"].ToString());


            string sqlUpdR2010 = "update r2010_ideprestserv set vlrTotalBruto = :vlrTotalBruto, vlrtotalBaseRet = :vlrtotalBaseRet, vlrtotalRetPrinc = :vlrtotalRetPrinc, vlrtotalRetAdic = :vlrtotalRetAdic, vlrtotalNRetPrinc = :vlrtotalNRetPrinc, vlrtotalNRetAdic = :vlrtotalNRetAdic  where R2010_IDREG = " + idReg.ToString();

            OracleCommand cmd = new OracleCommand(sqlUpdR2010, oc);
            cmd.Parameters.Add(new OracleParameter("vlrTotalBruto", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrtotalBaseRet", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrtotalRetPrinc", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrtotalRetAdic", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrtotalNRetPrinc", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("vlrtotalNRetAdic", OracleDbType.Decimal, ParameterDirection.Input));

            cmd.Parameters["vlrTotalBruto"].Value = _vlrTotalBruto;
            cmd.Parameters["vlrtotalBaseRet"].Value = _vlrtotalBaseRet;
            cmd.Parameters["vlrtotalRetPrinc"].Value = _vlrtotalRetPrinc;
            cmd.Parameters["vlrtotalRetAdic"].Value = _vlrtotalRetAdic;
            cmd.Parameters["vlrtotalNRetPrinc"].Value = _vlrtotalNRetPrinc;
            cmd.Parameters["vlrtotalNRetAdic"].Value = _vlrtotalNRetAdic;
      
            oc.Open();
            cmd.ExecuteNonQuery();            
            oc.Close();
        }

        public void verificarSeReenvioFornecedor(string cnpjEmpresa, string perApur)
        {
            DataTable empresasPendente = new DataTable();
            empresasPendente = verificarSeReenvio(cnpjEmpresa.Substring(0,8), perApur);
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
            string sql = "select R2010.IDREG , CNPJPRESTADOR , R2010.nrInscEstab from R2010 , R2010_IDEPRESTSERV  ";
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
            string sqlUpdR2010 = "update r2010 set NRRECIBO = :NRRECIBO, INDRETIF = 2 where idReg = " + idReg.ToString();

            OracleCommand cmd = new OracleCommand(sqlUpdR2010, oc);
            cmd.Parameters.Add(new OracleParameter("NRRECIBO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters["NRRECIBO"].Value = recibo;

            oc.Open();
            cmd.ExecuteNonQuery();
            oc.Close();
        }

        public void incluir(int idRegEmpresa, int indretif, string perapur, int idRegEstabelecimento, string nrRecibo, int indObra, string cnpjPrestador, int indCPRB)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            EstabelecimentoDAL estabDLL = new EstabelecimentoDAL();
            String cnpjEstab = estabDLL.getEstabelecimento(idRegEstabelecimento).Rows[0]["cnpj"].ToString();

            string sqlUpdR2060 = "inssert into r2010 set indretif = :indretif, NRRECIBO = :NRRECIBO, perapur = :perapur, nrinsc = :nrinsc, nrinscestab = :nrinscestab, INDOBRA = :INDOBRA ";

            OracleCommand cmd = new OracleCommand(sqlUpdR2060, oc);
            cmd.Parameters.Add(new OracleParameter("indretif", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinscestab", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrRecibo", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("indObra", OracleDbType.Int16, ParameterDirection.Input));

            cmd.Parameters["indretif"].Value = indretif;
            cmd.Parameters["perapur"].Value = perapur;
            cmd.Parameters["nrinsc"].Value = cnpj;
            cmd.Parameters["nrinscestab"].Value = cnpjEstab;
            cmd.Parameters["nrRecibo"].Value = nrRecibo;
            cmd.Parameters["indObra"].Value = indObra;

            oc.Open();
            cmd.ExecuteNonQuery();

            oc.Close();
        }

        public void atualiza(int idReg, int idRegEmpresa, int indretif, int idRegEstabelecimento, string nrRecibo, int indObra, string cnpjPrestador, int indCPRB)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            EstabelecimentoDAL estabDLL = new EstabelecimentoDAL();
            String cnpjEstab = estabDLL.getEstabelecimento(idRegEstabelecimento).Rows[0]["cnpj"].ToString();


            //string sqlUpdR2010 = "update r2010 set indretif = :indretif, NRRECIBO = :NRRECIBO,  nrinsc = :nrinsc, nrinscestab = :nrinscestab, INDOBRA = :INDOBRA  where idReg = " + idReg.ToString();
            string sqlUpdR2010 = "update r2010 set indretif = :indretif, INDOBRA = :INDOBRA where idReg = " + idReg.ToString();

            OracleCommand cmd = new OracleCommand(sqlUpdR2010, oc);
            cmd.Parameters.Add(new OracleParameter("indretif", OracleDbType.Int16, ParameterDirection.Input));
            //cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            //cmd.Parameters.Add(new OracleParameter("nrinscestab", OracleDbType.Varchar2, ParameterDirection.Input));
            //cmd.Parameters.Add(new OracleParameter("nrRecibo", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("indObra", OracleDbType.Int16, ParameterDirection.Input));         
            cmd.Parameters["indretif"].Value = indretif;
            //cmd.Parameters["nrinsc"].Value = cnpj;
            //cmd.Parameters["nrinscestab"].Value = cnpjEstab;
            //cmd.Parameters["nrRecibo"].Value = nrRecibo;
            cmd.Parameters["indObra"].Value = indObra;

            oc.Open();
            cmd.ExecuteNonQuery();
            oc.Close();

            string sqlUpdR2010PrestServ = "update r2010_ideprestserv set CNPJPRESTADOR = :CNPJPRESTADOR, INDCPRB = :INDCPRB where R2010_IDREG = " + idReg.ToString();
            OracleCommand cmdPrestServ = new OracleCommand(sqlUpdR2010PrestServ, oc);
            cmdPrestServ.Parameters.Add(new OracleParameter("CNPJPRESTADOR", OracleDbType.Varchar2, ParameterDirection.Input));
            cmdPrestServ.Parameters.Add(new OracleParameter("INDCPRB", OracleDbType.Int32, ParameterDirection.Input));
            cmdPrestServ.Parameters["CNPJPRESTADOR"].Value = cnpjPrestador;
            cmdPrestServ.Parameters["INDCPRB"].Value = indCPRB;

            oc.Open();
            cmdPrestServ.ExecuteNonQuery();
            oc.Close();
        }

        public void incluirNFS(string serie, string numDocto, DateTime dtEmissaoNF, decimal vlrBruto, string obs, int R2010_IDEPRESTSERV_IDREG)
        {

            string sql = "insert into r2010_NFS (SERIE , NUMDOCTO , DTEMISSAONF , VLRBRUTO , OBS, R2010_IDEPRESTSERV_IDREG ) values " +
                "(:SERIE , :NUMDOCTO , :DTEMISSAONF , :VLRBRUTO , :OBS, " + R2010_IDEPRESTSERV_IDREG.ToString() + ")";

            oc.Open();
            OracleCommand cmd = new OracleCommand(sql, oc);
            cmd.Parameters.Add(new OracleParameter("SERIE", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NUMDOCTO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("DTEMISSAONF", OracleDbType.Date, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRBRUTO", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("OBS", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["SERIE"].Value = serie;
            cmd.Parameters["NUMDOCTO"].Value = numDocto;
            cmd.Parameters["DTEMISSAONF"].Value = dtEmissaoNF;
            cmd.Parameters["VLRBRUTO"].Value = vlrBruto;
            cmd.Parameters["OBS"].Value = obs;           

            cmd.ExecuteNonQuery();

            oc.Close();
        }
        public void atualizaNFS(int idReg, string serie, string numDocto, DateTime dtEmissaoNF, decimal vlrBruto, string obs, int R2010_IDEPRESTSERV_IDREG)
        {

            string sql = "update r2010_NFS set SERIE = :SERIE , NUMDOCTO = :NUMDOCTO , DTEMISSAONF = :DTEMISSAONF, VLRBRUTO = :VLRBRUTO , OBS = :obs where idReg = " + idReg.ToString();


            oc.Open();
            OracleCommand cmd = new OracleCommand(sql, oc);
            cmd.Parameters.Add(new OracleParameter("SERIE", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NUMDOCTO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("DTEMISSAONF", OracleDbType.Date, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRBRUTO", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("OBS", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["SERIE"].Value = serie;
            cmd.Parameters["NUMDOCTO"].Value = numDocto;
            cmd.Parameters["DTEMISSAONF"].Value = dtEmissaoNF;
            cmd.Parameters["VLRBRUTO"].Value = vlrBruto;
            cmd.Parameters["OBS"].Value = obs;

            cmd.ExecuteNonQuery();
            oc.Close();
        }

        public void incluirTpServ(string tpServico, decimal vlrBaseRet, decimal vlrRetencao, decimal vlrRetSub, decimal vlrNRetPrinc, decimal vlrServicos15, decimal vlrServicos20, decimal vlrServicos25, decimal vlrAdicional, decimal vlrNRetAdic, int r2010_nfs_idreg)
        {

            string sql = "insert into r2010_infotpserv (TPSERVICO , VLRBASERET , VLRRETENCAO , VLRRETSUB , VLRNRETPRINC,VLRSERVICOS15, VLRSERVICOS20, VLRSERVICOS25,VLRADICIONAL, VLRNRETADIC, R2010_NFS_IDREG ) values " +
                "(:TPSERVICO , :VLRBASERET , :VLRRETENCAO , :VLRRETSUB , :VLRNRETPRINC, :VLRSERVICOS15, :VLRSERVICOS20, :VLRSERVICOS25, :VLRADICIONAL, :VLRNRETADIC, " + r2010_nfs_idreg.ToString() + ")";

            oc.Open();
            OracleCommand cmd = new OracleCommand(sql, oc);
            cmd.Parameters.Add(new OracleParameter("TPSERVICO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRBASERET", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRRETENCAO", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRRETSUB", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRNRETPRINC", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRSERVICOS15", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRSERVICOS20", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRSERVICOS25", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRADICIONAL", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRNRETADIC", OracleDbType.Decimal, ParameterDirection.Input));

            cmd.Parameters["TPSERVICO"].Value = tpServico;
            cmd.Parameters["VLRBASERET"].Value = vlrBaseRet;
            cmd.Parameters["VLRRETENCAO"].Value = vlrRetencao;
            cmd.Parameters["VLRRETSUB"].Value = vlrRetSub;
            cmd.Parameters["VLRNRETPRINC"].Value = vlrNRetPrinc;
            cmd.Parameters["VLRSERVICOS15"].Value = vlrServicos15;
            cmd.Parameters["VLRSERVICOS20"].Value = vlrServicos20;
            cmd.Parameters["VLRSERVICOS25"].Value = vlrServicos25;
            cmd.Parameters["VLRADICIONAL"].Value = vlrAdicional;
            cmd.Parameters["VLRNRETADIC"].Value = vlrNRetAdic;

            cmd.ExecuteNonQuery();

            oc.Close();
        }
        public void atualizaTpServ(int idReg, string tpServico, decimal vlrBaseRet, decimal vlrRetencao, decimal vlrRetSub, decimal vlrNRetPrinc, decimal vlrServicos15, decimal vlrServicos20, decimal vlrServicos25, decimal vlrAdicional, decimal vlrNRetAdic)
        {

            string sql = "update r2010_infotpserv  set TPSERVICO = :TPSERVICO, VLRBASERET = :VLRBASERET, VLRRETENCAO= :VLRRETENCAO, VLRRETSUB= :VLRRETSUB, VLRNRETPRINC= :VLRNRETPRINC,VLRSERVICOS15= :VLRSERVICOS15, VLRSERVICOS20= :VLRSERVICOS20, VLRSERVICOS25= :VLRSERVICOS25, VLRADICIONAL= :VLRADICIONAL, VLRNRETADIC = :VLRNRETADIC where idReg = " + idReg.ToString();


            oc.Open();
            OracleCommand cmd = new OracleCommand(sql, oc);
            cmd.Parameters.Add(new OracleParameter("TPSERVICO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRBASERET", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRRETENCAO", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRRETSUB", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRNRETPRINC", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRSERVICOS15", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRSERVICOS20", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRSERVICOS25", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRADICIONAL", OracleDbType.Decimal, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VLRNRETADIC", OracleDbType.Decimal, ParameterDirection.Input));

            cmd.Parameters["TPSERVICO"].Value = tpServico;
            cmd.Parameters["VLRBASERET"].Value = vlrBaseRet;
            cmd.Parameters["VLRRETENCAO"].Value = vlrRetencao;
            cmd.Parameters["VLRRETSUB"].Value = vlrRetSub;
            cmd.Parameters["VLRNRETPRINC"].Value = vlrNRetPrinc;
            cmd.Parameters["VLRSERVICOS15"].Value = vlrServicos15;
            cmd.Parameters["VLRSERVICOS20"].Value = vlrServicos20;
            cmd.Parameters["VLRSERVICOS25"].Value = vlrServicos25;
            cmd.Parameters["VLRADICIONAL"].Value = vlrAdicional;
            cmd.Parameters["VLRNRETADIC"].Value = vlrNRetAdic;

            cmd.ExecuteNonQuery();
            oc.Close();
        }
        public override DataTable getData()
        {
            string sql = "select * from R2010";
            return odb.getDataTable(sql);
        }

        public override DataTable getData(int idReg)
        {
            string sql = "select * from R2010 where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getDataLote(int idReg)
        {
            string sql = "SELECT * FROM R2010 CONS WHERE STATUS = 'P' AND  EXISTS (select PESQ.PERAPUR from R2010 PESQ where PESQ.PERAPUR = CONS.PERAPUR AND  PESQ.NRINSC = CONS.NRINSC AND PESQ.NRINSCESTAB = CONS.NRINSCESTAB AND PESQ.idReg = " + idReg.ToString() + ")";
            return odb.getDataTable(sql);
        }
        public DataTable getData(string cnpjEmpresa, string cnpjEstabelecimento, string perApur)
        {
            string sql = "select R2010.* , CNPJPRESTADOR,  VLRTOTALBRUTO, VLRTOTALBASERET, VLRTOTALRETPRINC from R2010 , R2010_IDEPRESTSERV  ";
            sql = sql + " where R2010_IDEPRESTSERV.R2010_IDREG = R2010.IDREG AND nrInsc = '" + cnpjEmpresa + "000000'";
            if (cnpjEstabelecimento != "")
            {
                sql = sql + " and nrInscEstab = '" + cnpjEstabelecimento + "'";
            }
            sql = sql + " and perApur = '" + perApur + "'";

            return odb.getDataTable(sql);
        }
        private DataTable getVerificaExistencia( string cnpjEstabelecimento, string cnpjFornecedor,  string perApur)
        {
            string sql = "select R2010.* , CNPJPRESTADOR,  VLRTOTALBRUTO, VLRTOTALBASERET, VLRTOTALRETPRINC from R2010 , R2010_IDEPRESTSERV  ";
            sql = sql + " where R2010_IDEPRESTSERV.R2010_IDREG = R2010.IDREG AND STATUS = 'P' AND NRINSCESTAB = (SELECT CNPJ FROM ESTABELECIMENTOS WHERE CODIGO = '" + cnpjEstabelecimento + "')";
            if (cnpjFornecedor != "")
            {
                sql = sql + " and CNPJPRESTADOR = '" + cnpjFornecedor + "'";
            }
            sql = sql + " and perApur = '" + perApur + "'";

            return odb.getDataTable(sql);
        }

        public DataTable getDataR2010IdePrestServ(int R2010_idReg)
        {
            string sql = "select * from R2010_IDEPRESTSERV where R2010_idReg = " + R2010_idReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getDataR2010NFS(int IdReg)
        {
            string sql = "select * from R2010_NFS where IDREG = " + IdReg.ToString();
            return odb.getDataTable(sql);
        }
        public DataTable getDataR2010NFSByR2010(int R2010_IdePrestServ_IdReg)
        {
            string sql = "select * from R2010_NFS where R2010_IDEPRESTSERV_IDREG = " + R2010_IdePrestServ_IdReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getDataR2010INFOTPSERV(int idReg)
        {
            string sql = "select * from R2010_INFOTPSERV where IDREG = " + idReg.ToString();
            return odb.getDataTable(sql);
        }
        public DataTable getDataR2010INFOTPSERVByNFS(int R2010_NFS_IDREG)
        {
            string sql = "select * from R2010_INFOTPSERV where R2010_NFS_IDREG = " + R2010_NFS_IDREG.ToString();
            return odb.getDataTable(sql);
        }
        public System.Collections.Generic.List<XmlDocument> getXMLEvtLote(int idReg)
        {
            ReinfOraDB reinfOraDB = new ReinfOraDB();
            DataTable t = getDataLote(idReg);

            System.Collections.Generic.List<XmlDocument> r = new System.Collections.Generic.List<XmlDocument>();

            for (int a = 0; a < t.Rows.Count; a++)
            {

                ReinfEvtServTom evt = new ReinfEvtServTom();

                // Cabeçalho comum a todos os eventos
                evt.id = t.Rows[a]["id"].ToString();
                evt.ideEvento = new ReinfEvtServTomIdeEvento();
                evt.ideEvento.procEmi = Convert.ToByte(t.Rows[a]["procEmi"].ToString());
                evt.ideEvento.indRetif = Convert.ToByte(t.Rows[a]["indretif"].ToString());
                if (evt.ideEvento.indRetif == 2)
                {
                    evt.ideEvento.nrRecibo = t.Rows[a]["nrRecibo"].ToString();
                }
                evt.ideEvento.tpAmb = Convert.ToByte(t.Rows[a]["tpAmb"].ToString());
                evt.ideEvento.verProc = t.Rows[a]["verProc"].ToString();
                evt.ideContri = new ReinfEvtServTomIdeContri();
                evt.ideContri.tpInsc = Convert.ToByte(t.Rows[a]["tpInsc"].ToString());
                evt.ideContri.nrInsc = t.Rows[a]["nrInsc"].ToString().Substring(0, 8);
                // Fim do Cabeçalho

                evt.ideEvento.perApur = t.Rows[a]["perApur"].ToString();

                DataTable dt2010 = getData(Convert.ToInt32(t.Rows[a]["idREG"].ToString()));
                // Cessão de Mao de Obra ou Empreitada
                evt.infoServTom = new ReinfEvtServTomInfoServTom();
                evt.infoServTom.ideEstabObra = new ReinfEvtServTomInfoServTomIdeEstabObra();

                evt.infoServTom.ideEstabObra.tpInscEstab = Convert.ToByte(dt2010.Rows[0]["tpInscEstab"].ToString());
                evt.infoServTom.ideEstabObra.nrInscEstab = dt2010.Rows[0]["nrInscEstab"].ToString();
                evt.infoServTom.ideEstabObra.indObra = Convert.ToByte(dt2010.Rows[0]["indObra"].ToString());

                // Adicionar os Prestadores (Para o Layout 1.2 somente deve existir 1 prestador por evento)
                DataTable dt2010IdePrestServ = getDataR2010IdePrestServ(Convert.ToInt32(t.Rows[a]["idREG"].ToString()));
                evt.infoServTom.ideEstabObra.idePrestServ = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServ();
                for (int i = 0; i < dt2010IdePrestServ.Rows.Count; i++)
                {
                    evt.infoServTom.ideEstabObra.idePrestServ = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServ();
                    evt.infoServTom.ideEstabObra.idePrestServ.cnpjPrestador = dt2010IdePrestServ.Rows[i]["cnpjPrestador"].ToString();
                    evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalBruto = Utils.ConverteNumero(dt2010IdePrestServ.Rows[i]["vlrTotalBruto"].ToString());                 
                    evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalBaseRet = Utils.ConverteNumero(dt2010IdePrestServ.Rows[i]["vlrTotalBaseRet"].ToString());
                    evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalRetPrinc = Utils.ConverteNumero(dt2010IdePrestServ.Rows[i]["vlrTotalRetPrinc"].ToString());
                    if (dt2010IdePrestServ.Rows[i]["vlrTotalRetAdic"].ToString() != "0" && dt2010IdePrestServ.Rows[i]["vlrTotalRetAdic"].ToString() != "")
                    {
                        evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalRetAdic = Utils.ConverteNumero(dt2010IdePrestServ.Rows[i]["vlrTotalRetAdic"].ToString());
                    }
                    if (dt2010IdePrestServ.Rows[i]["vlrTotalNRetPrinc"].ToString() != "0" && dt2010IdePrestServ.Rows[i]["vlrTotalNRetPrinc"].ToString() != "")
                    {
                        evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalNRetPrinc = Utils.ConverteNumero(dt2010IdePrestServ.Rows[i]["vlrTotalNRetPrinc"].ToString());
                    }
                    if (dt2010IdePrestServ.Rows[i]["vlrTotalNRetAdic"].ToString() != "0" && dt2010IdePrestServ.Rows[i]["vlrTotalNRetAdic"].ToString() != "")
                    {
                        evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalNRetAdic = Utils.ConverteNumero(dt2010IdePrestServ.Rows[i]["vlrTotalNRetAdic"].ToString());
                    }
                    evt.infoServTom.ideEstabObra.idePrestServ.indCPRB = Convert.ToByte(dt2010IdePrestServ.Rows[i]["indCPRB"].ToString());


                    // Adicionar as Notas Fiscais do Prestador  
                    R2010DAL objDLL = new R2010DAL();
                    DataTable dtPrest = objDLL.getDataR2010IdePrestServ(Convert.ToInt32(t.Rows[a]["idREG"].ToString()));
                    DataTable dt2010NFS = getDataR2010NFSByR2010(Convert.ToInt16(dtPrest.Rows[i]["idReg"].ToString()));
                    evt.infoServTom.ideEstabObra.idePrestServ.nfs = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs[dt2010NFS.Rows.Count];
                    for (int j = 0; j < dt2010NFS.Rows.Count; j++)
                    {
                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j] = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs();
                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].serie = dt2010NFS.Rows[j]["serie"].ToString();
                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].numDocto = dt2010NFS.Rows[j]["numDocto"].ToString();
                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].dtEmissaoNF = DateTime.Parse(dt2010NFS.Rows[j]["dtEmissaoNF"].ToString());
                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].vlrBruto = Utils.ConverteNumero(dt2010NFS.Rows[j]["vlrBruto"].ToString());
                        if (dt2010NFS.Rows[i]["obs"].ToString() != "")
                        {
                            evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].obs = dt2010NFS.Rows[j]["obs"].ToString();
                        }
                        // Adicionar os Tipos de Servicos constantes da NF
                        DataTable dt2010InfoTpServ = getDataR2010INFOTPSERVByNFS(Convert.ToInt16(dt2010NFS.Rows[j]["idReg"].ToString()));
                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ[dt2010InfoTpServ.Rows.Count];
                        for (int k = 0; k < dt2010InfoTpServ.Rows.Count; k++)
                        {
                            evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k] = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ();
                            evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].tpServico = dt2010InfoTpServ.Rows[k]["tpServico"].ToString();
                            evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrBaseRet = Utils.ConverteNumero(dt2010InfoTpServ.Rows[k]["vlrBaseRet"].ToString());
                            evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrRetencao = Utils.ConverteNumero(dt2010InfoTpServ.Rows[k]["vlrRetencao"].ToString());
                            if (dt2010InfoTpServ.Rows[i]["vlrRetSub"].ToString() != "0")
                            {
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrRetSub = Utils.ConverteNumero(dt2010InfoTpServ.Rows[k]["vlrRetSub"].ToString());
                            }
                            if (dt2010InfoTpServ.Rows[i]["vlrNRetPrinc"].ToString() != "0")
                            {
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrNRetPrinc = Utils.ConverteNumero(dt2010InfoTpServ.Rows[k]["vlrNRetPrinc"].ToString());
                            }
                            if (dt2010InfoTpServ.Rows[i]["vlrServicos15"].ToString() != "0")
                            {
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrServicos15 = Utils.ConverteNumero(dt2010InfoTpServ.Rows[k]["vlrServicos15"].ToString());
                            }
                            if (dt2010InfoTpServ.Rows[i]["vlrServicos20"].ToString() != "0")
                            {
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrServicos20 = Utils.ConverteNumero(dt2010InfoTpServ.Rows[k]["vlrServicos20"].ToString());
                            }
                            if (dt2010InfoTpServ.Rows[i]["vlrServicos25"].ToString() != "0")
                            {
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrServicos25 = Utils.ConverteNumero(dt2010InfoTpServ.Rows[k]["vlrServicos25"].ToString());
                            }
                            if (dt2010InfoTpServ.Rows[i]["vlrNRetAdic"].ToString() != "0")
                            {
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrNRetAdic = Utils.ConverteNumero(dt2010InfoTpServ.Rows[k]["vlrNRetAdic"].ToString());
                            }
                        }
                    }
                }
                Reinf retorno = new Reinf();
                retorno.evtServTom = evt;
                // Serializaçao do Objeto em Memória para retonrar o XMLDocument
                XmlSerializer x = new XmlSerializer(retorno.GetType());

                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                xsn.Add("", "http://www.reinf.esocial.gov.br/schemas/evtTomadorServicos/" + DadosCabecalhoEventoConst.verProcClass);

                MemoryStream memStm = new MemoryStream();
                x.Serialize(memStm, retorno, xsn);
                memStm.Position = 0;

                // Retirar as quebras de linhas e espaços em branco do XML
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                var xtr = XmlReader.Create(memStm, settings);

                // Criar o docoumento de retorno
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xtr);
                r.Add(xmlDoc);
            }


            // Retornar o XMLDocument com o Envento
            return r;
        }
        public override XmlDocument getXMLEvt(int idReg)
                {
                    ReinfOraDB reinfOraDB = new ReinfOraDB();
                    DataTable t = getData(idReg);

                    System.Collections.Generic.List<Reinf> r = new System.Collections.Generic.List<Reinf>();

                    for (int a = 0; a < t.Rows.Count; a++)
                    {

                        ReinfEvtServTom evt = new ReinfEvtServTom();

                        // Cabeçalho comum a todos os eventos
                        evt.id = t.Rows[a]["id"].ToString();
                        evt.ideEvento = new ReinfEvtServTomIdeEvento();
                        evt.ideEvento.procEmi = Convert.ToByte(t.Rows[a]["procEmi"].ToString());
                        evt.ideEvento.indRetif = Convert.ToByte(t.Rows[a]["indretif"].ToString());
                        if (evt.ideEvento.indRetif == 2)
                        {
                            evt.ideEvento.nrRecibo = t.Rows[a]["nrRecibo"].ToString();
                        }
                        evt.ideEvento.tpAmb = Convert.ToByte(t.Rows[a]["tpAmb"].ToString());
                        evt.ideEvento.verProc = t.Rows[a]["verProc"].ToString();
                        evt.ideContri = new ReinfEvtServTomIdeContri();
                        evt.ideContri.tpInsc = Convert.ToByte(t.Rows[a]["tpInsc"].ToString());
                        evt.ideContri.nrInsc = t.Rows[a]["nrInsc"].ToString();
                        // Fim do Cabeçalho

                        evt.ideEvento.perApur = t.Rows[a]["perApur"].ToString();

                        DataTable dt2010 = getData(Convert.ToInt32(t.Rows[a]["idREG"].ToString()));
                        // Cessão de Mao de Obra ou Empreitada
                        evt.infoServTom = new ReinfEvtServTomInfoServTom();
                        evt.infoServTom.ideEstabObra = new ReinfEvtServTomInfoServTomIdeEstabObra();

                        evt.infoServTom.ideEstabObra.tpInscEstab = Convert.ToByte(dt2010.Rows[0]["tpInscEstab"].ToString());
                        evt.infoServTom.ideEstabObra.nrInscEstab = dt2010.Rows[0]["nrInscEstab"].ToString();
                        evt.infoServTom.ideEstabObra.indObra = Convert.ToByte(dt2010.Rows[0]["indObra"].ToString());

                        // Adicionar os Prestadores (Para o Layout 1.2 somente deve existir 1 prestador por evento)
                        DataTable dt2010IdePrestServ = getDataR2010IdePrestServ(Convert.ToInt32(t.Rows[a]["idREG"].ToString()));
                        evt.infoServTom.ideEstabObra.idePrestServ = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServ();
                        for (int i = 0; i < dt2010IdePrestServ.Rows.Count; i++)
                        {
                            evt.infoServTom.ideEstabObra.idePrestServ = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServ();
                            evt.infoServTom.ideEstabObra.idePrestServ.cnpjPrestador = dt2010IdePrestServ.Rows[i]["cnpjPrestador"].ToString();
                            evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalBruto = dt2010IdePrestServ.Rows[i]["vlrTotalBruto"].ToString();
                            evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalBaseRet = dt2010IdePrestServ.Rows[i]["vlrTotalBaseRet"].ToString();
                            evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalRetPrinc = dt2010IdePrestServ.Rows[i]["vlrTotalRetPrinc"].ToString();
                            if (dt2010IdePrestServ.Rows[i]["vlrTotalRetAdic"].ToString() != "0" && dt2010IdePrestServ.Rows[i]["vlrTotalRetAdic"].ToString() != "")
                            {
                                evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalRetAdic = dt2010IdePrestServ.Rows[i]["vlrTotalRetAdic"].ToString();
                            }
                            if (dt2010IdePrestServ.Rows[i]["vlrTotalNRetPrinc"].ToString() != "0" && dt2010IdePrestServ.Rows[i]["vlrTotalNRetPrinc"].ToString() != "")
                            {
                                evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalNRetPrinc = dt2010IdePrestServ.Rows[i]["vlrTotalNRetPrinc"].ToString();
                            }
                            if (dt2010IdePrestServ.Rows[i]["vlrTotalNRetAdic"].ToString() != "0" && dt2010IdePrestServ.Rows[i]["vlrTotalNRetAdic"].ToString() != "")
                            {
                                evt.infoServTom.ideEstabObra.idePrestServ.vlrTotalNRetAdic = dt2010IdePrestServ.Rows[i]["vlrTotalNRetAdic"].ToString();
                            }
                            evt.infoServTom.ideEstabObra.idePrestServ.indCPRB = Convert.ToByte(dt2010IdePrestServ.Rows[i]["indCPRB"].ToString());


                            // Adicionar as Notas Fiscais do Prestador  
                            R2010DAL objDLL = new R2010DAL();
                            DataTable dtPrest = objDLL.getDataR2010IdePrestServ(Convert.ToInt32(t.Rows[a]["idREG"].ToString()));                    
                            DataTable dt2010NFS = getDataR2010NFSByR2010(Convert.ToInt16(dtPrest.Rows[0]["idReg"].ToString()));
                            evt.infoServTom.ideEstabObra.idePrestServ.nfs = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs[dt2010NFS.Rows.Count];
                            for (int j = 0; j < dt2010NFS.Rows.Count; j++)
                            {
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j] = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfs();
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].serie = dt2010NFS.Rows[j]["serie"].ToString();
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].numDocto = dt2010NFS.Rows[j]["numDocto"].ToString();
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].dtEmissaoNF = DateTime.Parse(dt2010NFS.Rows[j]["dtEmissaoNF"].ToString());
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].vlrBruto = dt2010NFS.Rows[j]["vlrBruto"].ToString(); ;
                                if (dt2010NFS.Rows[i]["obs"].ToString() != "")
                                {
                                    evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].obs = dt2010NFS.Rows[j]["obs"].ToString();
                                }
                                // Adicionar os Tipos de Servicos constantes da NF
                                DataTable dt2010InfoTpServ = getDataR2010INFOTPSERVByNFS(Convert.ToInt16(dt2010NFS.Rows[j]["idReg"].ToString()));
                                evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ[dt2010InfoTpServ.Rows.Count];
                                for (int k = 0; k < dt2010InfoTpServ.Rows.Count; k++)
                                {
                                    evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k] = new ReinfEvtServTomInfoServTomIdeEstabObraIdePrestServNfsInfoTpServ();
                                    evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].tpServico = dt2010InfoTpServ.Rows[k]["tpServico"].ToString(); 
                                    evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrBaseRet = dt2010InfoTpServ.Rows[k]["vlrBaseRet"].ToString();
                                    evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrRetencao = dt2010InfoTpServ.Rows[k]["vlrRetencao"].ToString();
                                    if (dt2010InfoTpServ.Rows[i]["vlrRetSub"].ToString() != "0")
                                    {
                                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrRetSub = dt2010InfoTpServ.Rows[k]["vlrRetSub"].ToString();
                                    }
                                    if (dt2010InfoTpServ.Rows[i]["vlrNRetPrinc"].ToString() != "0")
                                    {
                                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrNRetPrinc = dt2010InfoTpServ.Rows[k]["vlrNRetPrinc"].ToString();
                                    }
                                    if (dt2010InfoTpServ.Rows[i]["vlrServicos15"].ToString() != "0")
                                    {
                                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrServicos15 = dt2010InfoTpServ.Rows[k]["vlrServicos15"].ToString();
                                    }
                                    if (dt2010InfoTpServ.Rows[i]["vlrServicos20"].ToString() != "0")
                                    {
                                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrServicos20 = dt2010InfoTpServ.Rows[k]["vlrServicos20"].ToString();
                                    }
                                    if (dt2010InfoTpServ.Rows[i]["vlrServicos25"].ToString() != "0")
                                    {
                                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrServicos25 = dt2010InfoTpServ.Rows[k]["vlrServicos25"].ToString();
                                    }
                                    if (dt2010InfoTpServ.Rows[i]["vlrNRetAdic"].ToString() != "0")
                                    {
                                        evt.infoServTom.ideEstabObra.idePrestServ.nfs[j].infoTpServ[k].vlrNRetAdic = dt2010InfoTpServ.Rows[k]["vlrNRetAdic"].ToString();
                                    }
                                }
                            }
                        }
                        Reinf retorno = new Reinf();
                        retorno.evtServTom = evt;
                        r.Add(retorno);
                    }

                    // Serializaçao do Objeto em Memória para retonrar o XMLDocument
                    XmlSerializer x = new XmlSerializer(r.GetType());

                    XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                    xsn.Add("", "http://www.reinf.esocial.gov.br/schemas/evtTomadorServicos/" + DadosCabecalhoEventoConst.verProcClass);

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
