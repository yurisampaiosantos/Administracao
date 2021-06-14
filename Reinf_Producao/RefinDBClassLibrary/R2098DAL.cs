using evtReabreEvPer;
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
    public class R2098DAL : RBASEDAL
    {

        public R2098DAL(){
            odb = new ReinfOraDB();
            oc = odb.getConn();
        }
        
        public void incluir(int idRegEmpresa, string perApur)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            // Preencher com os dados da Carga
            string sqlInsR2098 = "insert into R2098 (id, perapur, tpamb, procemi, verproc, tpinsc, nrinsc, STATUS) " +
                " values (:id, :perapur, :tpamb, :procemi, :verproc, :tpinsc, :nrinsc, :STATUS) ";

            oc.Open();

            OracleCommand cmd = new OracleCommand(sqlInsR2098, oc);
            cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpamb", OracleDbType.Int16));
            cmd.Parameters.Add(new OracleParameter("procemi", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("verproc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("STATUS", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["id"].Value = "ID1" + cnpj.Substring(0, 8) + "000000" + DateTime.Now.ToString("yyyyMMddHHmmss") + 1.ToString("00000");
            cmd.Parameters["perapur"].Value = perApur;
            cmd.Parameters["tpamb"].Value = DadosCabecalhoEventoConst.tpAmb;
            cmd.Parameters["procemi"].Value = DadosCabecalhoEventoConst.procEmi;
            cmd.Parameters["verproc"].Value = DadosCabecalhoEventoConst.verProc;
            cmd.Parameters["tpinsc"].Value = DadosCabecalhoEventoConst.tpInsc;
            cmd.Parameters["nrinsc"].Value = cnpj.Substring(0, 8) + "000000"; 
            cmd.Parameters["STATUS"].Value = "P";
            cmd.ExecuteNonQuery();
            oc.Close();
        }

        public void atualiza(int idReg, int idRegEmpresa, string perApur)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            // Preencher com os dados da Carga
            string sqlInsR2098 = "update R2098 set perapur = :perapur , tpamb=:tpamb, procemi=:procemi, verproc=:verproc, tpinsc=:tpinsc, nrinsc=:nrinsc where idReg = " + idReg.ToString();

            oc.Open();

            OracleCommand cmd = new OracleCommand(sqlInsR2098, oc);
            
            cmd.Parameters.Add(new OracleParameter("perapur", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpamb", OracleDbType.Int16));
            cmd.Parameters.Add(new OracleParameter("procemi", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("verproc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            
            cmd.Parameters["perapur"].Value = perApur;
            cmd.Parameters["tpamb"].Value = DadosCabecalhoEventoConst.tpAmb;
            cmd.Parameters["procemi"].Value = DadosCabecalhoEventoConst.procEmi;
            cmd.Parameters["verproc"].Value = DadosCabecalhoEventoConst.verProc;
            cmd.Parameters["tpinsc"].Value = DadosCabecalhoEventoConst.tpInsc;
            cmd.Parameters["nrinsc"].Value = cnpj;
            cmd.ExecuteNonQuery();
            oc.Close();
        }

        public override void delete(int idReg)
        {
            String sql = "delete from R2098 where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }

        public override DataTable getData()
        {
            string sql = "select * from R2098";
            return odb.getDataTable(sql);
        }

        public DataTable getData(string cnpjEmpresa, string perApur)
        {
            string sql = "select IDREG,   ID,  STATUS,  DATAHORA_ENVIO,  NR_RECIBO from R2098 where nrInsc = '" + cnpjEmpresa + "'";
            sql = sql + " and perApur = '" + perApur + "'";

            return odb.getDataTable(sql);
        }

        public override DataTable getData(int idReg)
        {
            string sql = "select * from R2098 where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }
        public override XmlDocument getXMLEvt(int idReg)
        {            
            DataTable t = getData(idReg);

            Reinf r = new Reinf();
            ReinfEvtReabreEvPer evt = new ReinfEvtReabreEvPer();

            // Cabeçalho comum a todos os eventos
            evt.id = t.Rows[0]["id"].ToString();
            evt.ideEvento = new ReinfEvtReabreEvPerIdeEvento();
            evt.ideEvento.procEmi = Convert.ToUInt16(t.Rows[0]["procEmi"].ToString());
            evt.ideEvento.tpAmb = Convert.ToUInt16(t.Rows[0]["tpAmb"].ToString());
            evt.ideEvento.verProc = t.Rows[0]["verProc"].ToString();
            evt.ideContri = new ReinfEvtReabreEvPerIdeContri();
            evt.ideContri.tpInsc = Convert.ToByte(t.Rows[0]["tpInsc"].ToString());
            evt.ideContri.nrInsc = t.Rows[0]["nrInsc"].ToString().Substring(0,8);;
            // Fim do Cabeçalho

            evt.ideEvento.perApur = t.Rows[0]["perApur"].ToString();
            r.evtReabreEvPer = evt;

            // Serializaçao do Objeto em Memória para retonrar o XMLDocument
            XmlSerializer x = new XmlSerializer(r.GetType());

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "http://www.reinf.esocial.gov.br/schemas/evtReabreEvPer/" + DadosCabecalhoEventoConst.verProcClass);

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
