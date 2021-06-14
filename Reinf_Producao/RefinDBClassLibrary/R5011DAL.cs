using Oracle.ManagedDataAccess.Client;
using ReinfModelClassLibrary;
using RefinDBClassLibrary;
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
    public class R5011DAL: RBASEDAL
    {
        public R5011DAL()
        {
            odb = new ReinfOraDB();
            oc = odb.getConn();
        }

        ComplyOraDB c_odb = new ComplyOraDB();
        public void preencherR5011(int idR5011, retornoTotalizadorContribuinte.Reinf ConsultaReinfEvt, string xml)
        {
            if (ConsultaReinfEvt.evtTotalContrib != null)
            {
                oc.Open();
                // Preencher com os dados da Carga
                string sqlIns5011 = "UPDATE R5011 SET CDRETORNO   = :CDRETORNO, DESCRETORNO = :DESCRETORNO, DHPROCESS   = :DHPROCESS, TPEV        = :TPEV, " +
                                    " IDEV = :IDEV, HASH        = :HASH, RETORNO_XML = :RETORNO_XML, STATUS      =  'E' ,  DATAHORA_ENVIO = sysdate" +
                                     " WHERE ID  = " + idR5011;


                OracleCommand cmd = new OracleCommand(sqlIns5011, oc);
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new OracleParameter("CDRETORNO", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("DESCRETORNO", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("DHPROCESS", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("TPEV", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("IDEV", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("HASH", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("RETORNO_XML", OracleDbType.Clob, ParameterDirection.Input));
                
                cmd.Parameters["CDRETORNO"].Value = ConsultaReinfEvt.evtTotalContrib.ideRecRetorno.ideStatus.cdRetorno;
                cmd.Parameters["DESCRETORNO"].Value = ConsultaReinfEvt.evtTotalContrib.ideRecRetorno.ideStatus.descRetorno;
                cmd.Parameters["DHPROCESS"].Value = ConsultaReinfEvt.evtTotalContrib.infoRecEv.dhProcess;
                cmd.Parameters["TPEV"].Value = ConsultaReinfEvt.evtTotalContrib.infoRecEv.tpEv;
                cmd.Parameters["IDEV"].Value = ConsultaReinfEvt.evtTotalContrib.infoRecEv.idEv;
                cmd.Parameters["HASH"].Value = ConsultaReinfEvt.evtTotalContrib.infoRecEv.hash;
                cmd.Parameters["RETORNO_XML"].Value = xml;

                cmd.ExecuteNonQuery();


                if (ConsultaReinfEvt.evtTotalContrib.infoTotalContrib != null)
                {
                    try
                    {
                        // Preencher com os dados da Carga
                        string sqlIns5011InfoCont = "INSERT INTO R5011_INFOCONTRIB  (    R5011_ID,    NRRECARQBASE,    INDEXISTINFO  )  " +
                            " VALUES  (   :R5011_ID,    :NRRECARQBASE,    :INDEXISTINFO  ) " +
                             " RETURNING ID INTO :ID";


                        OracleCommand cmdInfoCont = new OracleCommand(sqlIns5011InfoCont, oc);
                        cmdInfoCont.Parameters.Clear();
                        cmdInfoCont.Parameters.Add(new OracleParameter("R5011_ID", OracleDbType.Int64, ParameterDirection.Input));
                        cmdInfoCont.Parameters.Add(new OracleParameter("NRRECARQBASE", OracleDbType.Varchar2, ParameterDirection.Input));
                        cmdInfoCont.Parameters.Add(new OracleParameter("INDEXISTINFO", OracleDbType.Int64, ParameterDirection.Input));

                        cmdInfoCont.Parameters.Add(new OracleParameter("ID", OracleDbType.Int64, ParameterDirection.Output));

                        cmdInfoCont.Parameters["R5011_ID"].Value = idR5011;
                        cmdInfoCont.Parameters["NRRECARQBASE"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.nrRecArqBase;
                        cmdInfoCont.Parameters["INDEXISTINFO"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.indExistInfo;

                        cmdInfoCont.ExecuteNonQuery();
                        int idR5011InfoCont = Convert.ToInt16(cmdInfoCont.Parameters["ID"].Value.ToString());
                       
                        if (ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RTom != null)
                        {                       
                            // Preencher com os dados da Carga
                            string sqlIns5011InfoContRTOM = "INSERT INTO R5011_CONT_RTOM (   INFOCONTRIB_ID,    CNPJPRESTADOR,    VLRTOTALBASERET  )  " +
                                "   VALUES  ( :INFOCONTRIB_ID,    :CNPJPRESTADOR,    :VLRTOTALBASERET  ) " +
                                 " RETURNING ID INTO :ID";


                            OracleCommand cmdInfoContRTOM = new OracleCommand(sqlIns5011InfoContRTOM, oc);
                            for (int a = 0; a <= ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RTom.Length - 1; a++)
                            {
                                cmdInfoContRTOM.Parameters.Clear();
                                cmdInfoContRTOM.Parameters.Add(new OracleParameter("INFOCONTRIB_ID", OracleDbType.Int64, ParameterDirection.Input));
                                cmdInfoContRTOM.Parameters.Add(new OracleParameter("CNPJPRESTADOR", OracleDbType.Varchar2, ParameterDirection.Input));
                                cmdInfoContRTOM.Parameters.Add(new OracleParameter("VLRTOTALBASERET", OracleDbType.Double, ParameterDirection.Input));

                                cmdInfoContRTOM.Parameters.Add(new OracleParameter("ID", OracleDbType.Int64, ParameterDirection.Output));

                                try
                                {
                                    cmdInfoContRTOM.Parameters["INFOCONTRIB_ID"].Value = idR5011InfoCont;
                                    cmdInfoContRTOM.Parameters["CNPJPRESTADOR"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RTom[a].cnpjPrestador;
                                    cmdInfoContRTOM.Parameters["VLRTOTALBASERET"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RTom[a].vlrTotalBaseRet.Replace(",",".");

                                    cmdInfoContRTOM.ExecuteNonQuery();
                                    int idR5011InfoContRTOM = Convert.ToInt16(cmdInfoContRTOM.Parameters["ID"].Value.ToString());

                                    if (ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RTom[a].infoCRTom != null)
                                    {
                                        // Preencher com os dados da Carga
                                        string sqlIns5011InfoContRTOMCR = "INSERT  INTO R5011_CONT_RTOM_CRTOM  (      CONT_RTOM_ID,    CRTOM,    VLRCRTOM,    VLRCRTOMSUSP  )    " +
                                            "   VALUES  ( :CONT_RTOM_ID,    :CRTOM,    :VLRCRTOM,    :VLRCRTOMSUSP  ) ";

                                        OracleCommand cmdInfoContRTOMCR = new OracleCommand(sqlIns5011InfoContRTOMCR, oc);
                                        for (int b = 0; b <= ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RTom[a].infoCRTom.Length - 1; b++)
                                        {
                                            cmdInfoContRTOMCR.Parameters.Clear();
                                            cmdInfoContRTOMCR.Parameters.Add(new OracleParameter("CONT_RTOM_ID", OracleDbType.Int64, ParameterDirection.Input));
                                            cmdInfoContRTOMCR.Parameters.Add(new OracleParameter("CRTOM", OracleDbType.Double, ParameterDirection.Input));
                                            cmdInfoContRTOMCR.Parameters.Add(new OracleParameter("VLRCRTOM", OracleDbType.Double, ParameterDirection.Input));
                                            cmdInfoContRTOMCR.Parameters.Add(new OracleParameter("VLRCRTOMSUSP", OracleDbType.Double, ParameterDirection.Input));

                                            try
                                            {
                                                cmdInfoContRTOMCR.Parameters["CONT_RTOM_ID"].Value = idR5011InfoContRTOM;
                                                cmdInfoContRTOMCR.Parameters["CRTOM"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RTom[a].infoCRTom[b].CRTom.Replace(",", ".");
                                                cmdInfoContRTOMCR.Parameters["VLRCRTOM"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RTom[a].infoCRTom[b].VlrCRTom.Replace(",", ".");
                                                cmdInfoContRTOMCR.Parameters["VLRCRTOMSUSP"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RTom[a].infoCRTom[b].VlrCRTomSusp.Replace(",", ".");

                                                cmdInfoContRTOMCR.ExecuteNonQuery();
                                            }
                                            catch (Exception err)
                                            {
                                            }
                                        }
                                    }
                                }
                                catch (Exception err)
                                {
                                }
                            }
                        }

                        if (ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RPrest != null)
                        {
                            // Preencher com os dados da Carga
                            string sqlIns5011InfoContRPREST = "INSERT INTO R5011_CONTR_RPREST  (    INFOCONTRIB_ID,    TPINSCTOMADOR,    NRINSCTOMADOR,    VLRTOTALBASERET,    VLRTOTALRETPRINC,    VLRTOTALRETADIC,    VLRTOTALNRETPRINC,    VLRTOTALNRETADIC  )" +
                                "   VALUES  ( :INFOCONTRIB_ID,    :TPINSCTOMADOR,    :NRINSCTOMADOR,    :VLRTOTALBASERET,    :VLRTOTALRETPRINC,    :VLRTOTALRETADIC,    :VLRTOTALNRETPRINC,    :VLRTOTALNRETADIC ) ";

                            OracleCommand cmdInfoContRPREST = new OracleCommand(sqlIns5011InfoContRPREST, oc);
                            for (int a = 0; a <= ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RPrest.Length - 1; a++)
                            {
                                cmdInfoContRPREST.Parameters.Clear();
                                cmdInfoContRPREST.Parameters.Add(new OracleParameter("INFOCONTRIB_ID", OracleDbType.Int64, ParameterDirection.Input));
                                cmdInfoContRPREST.Parameters.Add(new OracleParameter("TPINSCTOMADOR", OracleDbType.Int32, ParameterDirection.Input));
                                cmdInfoContRPREST.Parameters.Add(new OracleParameter("NRINSCTOMADOR", OracleDbType.Varchar2, ParameterDirection.Input));
                                cmdInfoContRPREST.Parameters.Add(new OracleParameter("VLRTOTALBASERET", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRPREST.Parameters.Add(new OracleParameter("VLRTOTALRETPRINC", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRPREST.Parameters.Add(new OracleParameter("VLRTOTALRETADIC", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRPREST.Parameters.Add(new OracleParameter("VLRTOTALNRETPRINC", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRPREST.Parameters.Add(new OracleParameter("VLRTOTALNRETADIC", OracleDbType.Double, ParameterDirection.Input));

                                try
                                {
                                    cmdInfoContRPREST.Parameters["INFOCONTRIB_ID"].Value = idR5011InfoCont;
                                    cmdInfoContRPREST.Parameters["TPINSCTOMADOR"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RPrest[a].tpInscTomador;
                                    cmdInfoContRPREST.Parameters["NRINSCTOMADOR"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RPrest[a].nrInscTomador;
                                    cmdInfoContRPREST.Parameters["VLRTOTALBASERET"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RPrest[a].vlrTotalBaseRet.Replace(",", ".");
                                    cmdInfoContRPREST.Parameters["VLRTOTALRETPRINC"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RPrest[a].vlrTotalRetPrinc.Replace(",", ".");
                                    cmdInfoContRPREST.Parameters["VLRTOTALRETADIC"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RPrest[a].vlrTotalRetAdic.Replace(",", ".");
                                    cmdInfoContRPREST.Parameters["VLRTOTALNRETPRINC"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RPrest[a].vlrTotalNRetPrinc.Replace(",", ".");
                                    cmdInfoContRPREST.Parameters["VLRTOTALNRETADIC"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RPrest[a].vlrTotalNRetAdic.Replace(",", ".");

                                    cmdInfoContRPREST.ExecuteNonQuery();
                                }
                                catch (Exception err)
                                {
                                }
                            }
                        }

                        if (ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RRecRepAD != null)
                        {
                            // Preencher com os dados da Carga
                            string sqlIns5011InfoContRRecRepAD = "INSERT INTO R5011_CONT_RRECREPAD (    INFOCONTRIB_ID,    CNPJASSOCDESP,    VLRTOTALREP,    CRRECREPAD,    VLRCRRECREPAD,    VLRCRRECREPADSUSP  )" +
                                "   VALUES  ( :INFOCONTRIB_ID,    :CNPJASSOCDESP,    :VLRTOTALREP,    :CRRECREPAD,    :VLRCRRECREPAD,    :VLRCRRECREPADSUSP ) ";

                            OracleCommand cmdInfoContRRecRepAD = new OracleCommand(sqlIns5011InfoContRRecRepAD, oc);
                            for (int a = 0; a <= ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RRecRepAD.Length - 1; a++)
                            {
                                cmdInfoContRRecRepAD.Parameters.Clear();
                                cmdInfoContRRecRepAD.Parameters.Add(new OracleParameter("INFOCONTRIB_ID", OracleDbType.Int64, ParameterDirection.Input));
                                cmdInfoContRRecRepAD.Parameters.Add(new OracleParameter("CNPJASSOCDESP", OracleDbType.Varchar2, ParameterDirection.Input));
                                cmdInfoContRRecRepAD.Parameters.Add(new OracleParameter("VLRTOTALREP", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRRecRepAD.Parameters.Add(new OracleParameter("CRRECREPAD", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRRecRepAD.Parameters.Add(new OracleParameter("VLRCRRECREPAD", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRRecRepAD.Parameters.Add(new OracleParameter("VLRCRRECREPADSUSP", OracleDbType.Double, ParameterDirection.Input));

                                try
                                {
                                    cmdInfoContRRecRepAD.Parameters["INFOCONTRIB_ID"].Value = idR5011InfoCont;
                                    //cmdInfoContRRecRepAD.Parameters["CNPJASSOCDESP"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RRecRepAD[a].cnpjAssocDesp;
                                    //cmdInfoContRRecRepAD.Parameters["VLRTOTALREP"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RRecRepAD[a].vlrTotalRep.Replace(",", ".");
                                    cmdInfoContRRecRepAD.Parameters["CRRECREPAD"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RRecRepAD[a].vlrCRRecRepAD.Replace(",", ".");
                                    cmdInfoContRRecRepAD.Parameters["VLRCRRECREPAD"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RRecRepAD[a].vlrCRRecRepAD.Replace(",", ".");
                                    cmdInfoContRRecRepAD.Parameters["VLRCRRECREPADSUSP"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RRecRepAD[a].vlrCRRecRepADSusp.Replace(",", ".");

                                    cmdInfoContRRecRepAD.ExecuteNonQuery();
                                }
                                catch (Exception err)
                                {
                                }
                            }
                        }

                        if (ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RComl != null)
                        {
                            string sqlIns5011InfoContRComl = "INSERT INTO R5011_CONT_RCOML  (    INFOCONTRIB_ID,    CRCOML,    VLRCRCOML,    VLRCRCOMLSUSP  )" +
                                                             "   VALUES  (   :INFOCONTRIB_ID,    :CRCOML,    :VLRCRCOML,    :VLRCRCOMLSUSP ) ";

                            OracleCommand cmdInfoContRComl = new OracleCommand(sqlIns5011InfoContRComl, oc);
                            for (int a = 0; a <= ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RComl.Length - 1; a++)
                            {
                                cmdInfoContRComl.Parameters.Clear();
                                cmdInfoContRComl.Parameters.Add(new OracleParameter("INFOCONTRIB_ID", OracleDbType.Int64, ParameterDirection.Input));
                                cmdInfoContRComl.Parameters.Add(new OracleParameter("CRCOML", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRComl.Parameters.Add(new OracleParameter("VLRCRCOML", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRComl.Parameters.Add(new OracleParameter("VLRCRCOMLSUSP", OracleDbType.Double, ParameterDirection.Input));

                                try
                                {
                                    // Preencher com os dados da Carga
                                    cmdInfoContRComl.Parameters["INFOCONTRIB_ID"].Value = idR5011InfoCont;
                                    cmdInfoContRComl.Parameters["CRCOML"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RComl[a].CRComl.Replace(",", ".");
                                    cmdInfoContRComl.Parameters["VLRCRCOML"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RComl[a].vlrCRComl.Replace(",", ".");
                                    cmdInfoContRComl.Parameters["VLRCRCOMLSUSP"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RComl[a].vlrCRComlSusp.Replace(",", ".");

                                    cmdInfoContRComl.ExecuteNonQuery();
                                }
                                catch (Exception err)
                                {
                                }
                            }
                        }

                        if (ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RCPRB != null)
                        {
                            // Preencher com os dados da Carga
                            string sqlIns5011InfoContRComl = "INSERT INTO R5011_CONT_RCPRB  (     INFOCONTRIB_ID,    CRCPRB,    VLRCRCPRB,    VLRCRCPRBSUSP  )" +
                                "   VALUES  (   :INFOCONTRIB_ID,    :CRCPRB,    :VLRCRCPRB,    :VLRCRCPRBSUSP  ) ";

                            OracleCommand cmdInfoContRComl = new OracleCommand(sqlIns5011InfoContRComl, oc);
                            for (int a = 0; a <= ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RCPRB.Length - 1; a++)
                            {
                                cmdInfoContRComl.Parameters.Clear();
                                cmdInfoContRComl.Parameters.Add(new OracleParameter("INFOCONTRIB_ID", OracleDbType.Int64, ParameterDirection.Input));
                                cmdInfoContRComl.Parameters.Add(new OracleParameter("CRCPRB", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRComl.Parameters.Add(new OracleParameter("VLRCRCPRB", OracleDbType.Double, ParameterDirection.Input));
                                cmdInfoContRComl.Parameters.Add(new OracleParameter("VLRCRCPRBSUSP", OracleDbType.Double, ParameterDirection.Input));

                                try
                                {
                                    cmdInfoContRComl.Parameters["INFOCONTRIB_ID"].Value = idR5011InfoCont;
                                    cmdInfoContRComl.Parameters["CRCPRB"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RCPRB[a].CRCPRB.Replace(",", ".");
                                    cmdInfoContRComl.Parameters["VLRCRCPRB"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RCPRB[a].vlrCRCPRB.Replace(",", ".");
                                    cmdInfoContRComl.Parameters["VLRCRCPRBSUSP"].Value = ConsultaReinfEvt.evtTotalContrib.infoTotalContrib.RCPRB[a].vlrCRCPRBSusp.Replace(",", ".");

                                    cmdInfoContRComl.ExecuteNonQuery();
                                }
                                catch (Exception err)
                                {
                                }
                            }
                        }
                    }
                    catch (Exception err)
                    {                       
                    }
                }

                oc.Close();
            }
        }
        public void incluir(int codcnpj, string perApur, string nrRecibo)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            string cnpj = eDLL.getEmpresa(codcnpj).Rows[0]["cnpj"].ToString();
            int tpinsc = DadosCabecalhoEventoConst.tpInsc;

            // Preencher com os dados da Carga
            string sqlIns5011 = "INSERT INTO R5011  (    PERAPUR,    TPINSC,    NRINSC,    NRPROTENTR  ) " +
                                " VALUES  (     :PERAPUR,    :TPINSC,    :NRINSC,    :NRPROTENTR ) ";
        
            oc.Open();

            OracleCommand cmd = new OracleCommand(sqlIns5011, oc);
            cmd.Parameters.Add(new OracleParameter("PERAPUR", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TPINSC", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NRINSC", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NRPROTENTR", OracleDbType.Varchar2, ParameterDirection.Input));


            cmd.Parameters["PERAPUR"].Value = perApur;
            cmd.Parameters["TPINSC"].Value = tpinsc;
            cmd.Parameters["NRINSC"].Value = cnpj;
            cmd.Parameters["NRPROTENTR"].Value = nrRecibo;           

            cmd.ExecuteNonQuery();
            oc.Close();
        } 
        public override void delete(int idReg)
        {
            String sql = "delete from R5011 where ID = " + idReg.ToString();
            odb.executeSql(sql);
        }

        public override DataTable getData()
        {
            string sql = "select * from R5011 order by ID";
            return odb.getDataTable(sql);

        }

        public override DataTable getData(int idReg)
        {
            string sql = "select * from R5011 where ID = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getData(string cnpjEmpresa, string perApur)
        {
            string sql = "select * from R5011 where nrInsc = '" + cnpjEmpresa + "'";
            sql = sql + " and perApur = '" + perApur + "'";

            return odb.getDataTable(sql);
        }

        public override XmlDocument getXMLEvt(int idReg)
        {
            // Criar o docoumento de retorno
            XmlDocument xmlDoc = new XmlDocument();

            return xmlDoc;
        }
    }
}

