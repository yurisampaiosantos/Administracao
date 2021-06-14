using evtFechamento;
using Oracle.ManagedDataAccess.Client;
using RefinDBClassLibrary;
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
    public class R2099DAL : RBASEDAL
    {
        public R2099DAL(){
            odb = new ReinfOraDB();
            oc = odb.getConn();
        }

        public void incluir(int idRegEmpresa, int idRegResponsavel, string perApur, string comSemMovto)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            // Preencher com os dados da Carga
            string sqlInsR2099 = "insert into R2099 (id, perapur, tpamb, procemi, verproc, tpinsc, nrinsc,NMRESP,CPFRESP,TELEFONE,EMAIL,EVTSERVTM,EVTSERVPR,EVTASSDESPREC,EVTASSDESPREP,EVTCOMPROD,EVTCPRB,EVTPGTOS,COMPSEMMOVTO, STATUS) " +
                " values (:id, :perapur, :tpamb, :procemi, :verproc, :tpinsc, :nrinsc, :NMRESP,:CPFRESP,:TELEFONE,:EMAIL,:EVTSERVTM,:EVTSERVPR,:EVTASSDESPREC,:EVTASSDESPREP,:EVTCOMPROD,:EVTCPRB,:EVTPGTOS,:COMPSEMMOVTO, :STATUS) ";

            oc.Open();

            OracleCommand cmd = new OracleCommand(sqlInsR2099, oc);
            cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpamb", OracleDbType.Int16));
            cmd.Parameters.Add(new OracleParameter("procemi", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("verproc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NMRESP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("CPFRESP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TELEFONE", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EMAIL", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTSERVTM", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTSERVPR", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTASSDESPREC", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTASSDESPREP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTCOMPROD", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTCPRB", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTPGTOS", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("COMPSEMMOVTO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("STATUS", OracleDbType.Varchar2, ParameterDirection.Input));


            cmd.Parameters["id"].Value = "ID1" + cnpj.Substring(0, 8) + "000000" + DateTime.Now.ToString("yyyyMMddHHmmss") + 1.ToString("00000");
            cmd.Parameters["perapur"].Value = perApur;
            cmd.Parameters["tpamb"].Value = DadosCabecalhoEventoConst.tpAmb;
            cmd.Parameters["procemi"].Value = DadosCabecalhoEventoConst.procEmi;
            cmd.Parameters["verproc"].Value = DadosCabecalhoEventoConst.verProc;
            cmd.Parameters["tpinsc"].Value = DadosCabecalhoEventoConst.tpInsc;
            cmd.Parameters["nrinsc"].Value = cnpj.Substring(0, 8) + "000000";

            ResponsavelDAL r = new ResponsavelDAL();
            DataTable dtResp = r.getReponsavel(idRegResponsavel);

            cmd.Parameters["NMRESP"].Value = dtResp.Rows[0]["NMRESP"].ToString();
            cmd.Parameters["CPFRESP"].Value = dtResp.Rows[0]["CPFRESP"].ToString();
            cmd.Parameters["TELEFONE"].Value = dtResp.Rows[0]["FONEFIXO"].ToString();
            cmd.Parameters["EMAIL"].Value = dtResp.Rows[0]["EMAIL"].ToString();

            // Buscar os eventos do periodo e preencher as variaveis abaixo
          //  cmd.Parameters["EVTSERVTM"].Value = "N";
            cmd.Parameters["EVTSERVPR"].Value = "N";
            cmd.Parameters["EVTASSDESPREC"].Value = "N";
            cmd.Parameters["EVTASSDESPREP"].Value = "N";
            cmd.Parameters["EVTCOMPROD"].Value = "N";
           // cmd.Parameters["EVTCPRB"].Value = "N";
            cmd.Parameters["EVTPGTOS"].Value = "N";
            cmd.Parameters["COMPSEMMOVTO"].Value = comSemMovto;
            cmd.Parameters["STATUS"].Value = "P";

            cmd.ExecuteNonQuery();
            oc.Close();
        }

        public void atualiza(int idReg, int idRegEmpresa, int idRegResponsavel, string perApur , string comSemMovto)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            // Preencher com os dados da Carga
            string sqlInsR2099 = "update R2099 set perapur = :perapur, tpamb=:tpamb, procemi=:procemi, verproc=:verproc, tpinsc=:tpinsc, nrinsc=:nrinsc ,NMRESP=:NMRESP,CPFRESP=:CPFRESP,TELEFONE=:TELEFONE,EMAIL=:EMAIL,EVTSERVTM=:EVTSERVTM,EVTSERVPR=:EVTSERVPR,EVTASSDESPREC=:EVTASSDESPREC,EVTASSDESPREP=:EVTASSDESPREP,EVTCOMPROD=:EVTCOMPROD,EVTCPRB=:EVTCPRB,EVTPGTOS=:EVTPGTOS,COMPSEMMOVTO=:COMPSEMMOVTO where idReg  = " + idReg.ToString();

            oc.Open();

            OracleCommand cmd = new OracleCommand(sqlInsR2099, oc);
            cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpamb", OracleDbType.Int16));
            cmd.Parameters.Add(new OracleParameter("procemi", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("verproc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NMRESP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("CPFRESP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TELEFONE", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EMAIL", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTSERVTM", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTSERVPR", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTASSDESPREC", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTASSDESPREP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTCOMPROD", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTCPRB", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EVTPGTOS", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("COMPSEMMOVTO", OracleDbType.Varchar2, ParameterDirection.Input));


            cmd.Parameters["perapur"].Value = perApur;
            cmd.Parameters["tpamb"].Value = DadosCabecalhoEventoConst.tpAmb;
            cmd.Parameters["procemi"].Value = DadosCabecalhoEventoConst.procEmi;
            cmd.Parameters["verproc"].Value = DadosCabecalhoEventoConst.verProc;
            cmd.Parameters["tpinsc"].Value = DadosCabecalhoEventoConst.tpInsc;
            cmd.Parameters["nrinsc"].Value = cnpj.Substring(0, 8) + "000000"; ;

            ResponsavelDAL r = new ResponsavelDAL();
            DataTable dtResp = r.getReponsavel(idRegResponsavel);

            cmd.Parameters["NMRESP"].Value = dtResp.Rows[0]["NMRESP"].ToString();
            cmd.Parameters["CPFRESP"].Value = dtResp.Rows[0]["CPFRESP"].ToString();
            cmd.Parameters["TELEFONE"].Value = dtResp.Rows[0]["FONEFIXO"].ToString();
            cmd.Parameters["EMAIL"].Value = dtResp.Rows[0]["EMAIL"].ToString();

            // Buscar os eventos do periodo e preencher as variaveis abaixo
           // cmd.Parameters["EVTSERVTM"].Value = "N";
            //cmd.Parameters["EVTSERVPR"].Value = "N";
            //cmd.Parameters["EVTASSDESPREC"].Value = "N";
           // cmd.Parameters["EVTASSDESPREP"].Value = "N";
           // cmd.Parameters["EVTCOMPROD"].Value = "N";
           // cmd.Parameters["EVTCPRB"].Value = "N";
           // cmd.Parameters["EVTPGTOS"].Value = "N";
            cmd.Parameters["COMPSEMMOVTO"].Value = comSemMovto;

            cmd.ExecuteNonQuery();
            oc.Close();
        }

        public override void delete(int idReg)
        {
            String sql = "delete from R2099 where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }

        public override DataTable getData()
        {
            string sql = "select * from R2099";
            return odb.getDataTable(sql);
        }

        public override DataTable getData(int idReg)
        {
            string sql = "select * from R2099 where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getData(string cnpjEmpresa, string perApur)
        {
            string sql = "select IDREG,   ID,  STATUS,  DATAHORA_ENVIO,  NR_RECIBO from R2099 where nrInsc = '" + cnpjEmpresa + "000000'";
            sql = sql + " and perApur = '" + perApur + "'";

            return odb.getDataTable(sql);
        }

        public bool verificaCompetencia(int idReg)
        {
            bool retorno = false;
            String sql = " SELECT COUNT(*) AS TOTAL "+
                         "      FROM R2099 " +
                         "      WHERE  IDREG =" + idReg +
                         "      AND EVTSERVTM = 'N' AND EVTSERVPR = 'N' AND EVTASSDESPREC = 'N' AND EVTASSDESPREP = 'N' AND EVTCOMPROD = 'N' AND EVTCPRB = 'N' AND EVTPGTOS = 'N' AND COMPSEMMOVTO IS NULL";
           
            odb = new ReinfOraDB();
            OracleConnection oc = odb.getConn();
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
        public override XmlDocument getXMLEvt(int idReg)
        {            
            DataTable t = getData(idReg);

            Reinf r = new Reinf();
            ReinfEvtFechaEvPer evt = new ReinfEvtFechaEvPer();

            // Cabeçalho comum a todos os eventos
            evt.id = t.Rows[0]["id"].ToString();
            evt.ideEvento = new ReinfEvtFechaEvPerIdeEvento();
            evt.ideEvento.procEmi = Convert.ToUInt16(t.Rows[0]["procEmi"].ToString());
            evt.ideEvento.tpAmb = Convert.ToUInt16(t.Rows[0]["tpAmb"].ToString());
            evt.ideEvento.verProc = t.Rows[0]["verProc"].ToString();
            evt.ideContri = new ReinfEvtFechaEvPerIdeContri();
            evt.ideContri.tpInsc = Convert.ToByte(t.Rows[0]["tpInsc"].ToString());
            evt.ideContri.nrInsc = t.Rows[0]["nrInsc"].ToString().Substring(0,8);
            // Fim do Cabeçalho                       

            evt.ideEvento.perApur = t.Rows[0]["perApur"].ToString();

            // Informações do Responsável pelo Fechamento
            evt.ideRespInf = new ReinfEvtFechaEvPerIdeRespInf();
            evt.ideRespInf.nmResp = t.Rows[0]["nmResp"].ToString();
            evt.ideRespInf.cpfResp = t.Rows[0]["cpfResp"].ToString();
            evt.ideRespInf.telefone = t.Rows[0]["telefone"].ToString();
            evt.ideRespInf.email = t.Rows[0]["email"].ToString();

            // Informações do Fechamento
            evt.infoFech = new ReinfEvtFechaEvPerInfoFech();
            evt.infoFech.evtServTm = (ReinfEvtFechaEvPerInfoFechEvtServTm)System.Enum.Parse(typeof(ReinfEvtFechaEvPerInfoFechEvtServTm), t.Rows[0]["evtServTm"].ToString());
            evt.infoFech.evtServPr = (ReinfEvtFechaEvPerInfoFechEvtServPr)System.Enum.Parse(typeof(ReinfEvtFechaEvPerInfoFechEvtServPr), t.Rows[0]["evtServPr"].ToString());
            evt.infoFech.evtAssDespRec = (ReinfEvtFechaEvPerInfoFechEvtAssDespRec)System.Enum.Parse(typeof(ReinfEvtFechaEvPerInfoFechEvtAssDespRec), t.Rows[0]["evtAssDespRec"].ToString());
            evt.infoFech.evtAssDespRep = (ReinfEvtFechaEvPerInfoFechEvtAssDespRep)System.Enum.Parse(typeof(ReinfEvtFechaEvPerInfoFechEvtAssDespRep), t.Rows[0]["evtAssDespRep"].ToString());
            evt.infoFech.evtComProd = (ReinfEvtFechaEvPerInfoFechEvtComProd)System.Enum.Parse(typeof(ReinfEvtFechaEvPerInfoFechEvtComProd), t.Rows[0]["evtComProd"].ToString());
            evt.infoFech.evtCPRB = (ReinfEvtFechaEvPerInfoFechEvtCPRB)System.Enum.Parse(typeof(ReinfEvtFechaEvPerInfoFechEvtCPRB), t.Rows[0]["evtCPRB"].ToString());
            evt.infoFech.evtAquis = (ReinfEvtFechaEvPerInfoFechEvtAquis)System.Enum.Parse(typeof(ReinfEvtFechaEvPerInfoFechEvtAquis), "N".ToString());
            // evt.infoFech.evtPgtos =  t.Rows[0]["evtPgtos"].ToString();// (ReinfEvtFechaEvPerInfoFechEvtPgtos)System.Enum.Parse(typeof(ReinfEvtFechaEvPerInfoFechEvtPgtos), t.Rows[0]["evtPgtos"].ToString());
            /*   if (t.Rows[0]["compSemMovto"].ToString() != "")
               {
                   evt.infoFech.compSemMovto = t.Rows[0]["compSemMovto"].ToString();
               }
               */
            r.evtFechaEvPer = evt;


            // Serializaçao do Objeto em Memória para retonrar o XMLDocument
            XmlSerializer x = new XmlSerializer(r.GetType());

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "http://www.reinf.esocial.gov.br/schemas/evtFechamento/" + DadosCabecalhoEventoConst.verProcClass);

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
