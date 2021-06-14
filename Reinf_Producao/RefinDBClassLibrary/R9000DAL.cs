using evtExclusao;
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
    public class R9000DAL : RBASEDAL
    {

        public R9000DAL(){
            odb = new ReinfOraDB();
            oc = odb.getConn();
        }

        public void incluir(string cnpj, string tipoEvento, string nrRecibo, string perApur)
        {
            // Preencher com os dados da Carga
            string sqlInsR9000 = "insert into r9000 (ID, TPAMB, PROCEMI, VERPROC, TPINSC, NRINSC, TPEVENTO, NRRECEVT,PERAPUR,STATUS) " +
                         " values(:ID, :TPAMB, :PROCEMI, :VERPROC, :TPINSC, :NRINSC, :TPEVENTO, :NRRECEVT, :PERAPUR, :STATUS) ";

            oc.Open();
            OracleCommand cmd = new OracleCommand(sqlInsR9000, oc);
            cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TPAMB", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("PROCEMI", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VERPROC", OracleDbType.Varchar2));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TPEVENTO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NRRECEVT", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("PERAPUR", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("STATUS", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["id"].Value = "ID"+ DadosCabecalhoEventoConst.tpInsc.ToString() + cnpj + DateTime.Now.ToString("yyyyMMddHHmmss") + 1.ToString("00000");            
            cmd.Parameters["TPAMB"].Value = DadosCabecalhoEventoConst.tpAmb;
            cmd.Parameters["PROCEMI"].Value = DadosCabecalhoEventoConst.procEmi;
            cmd.Parameters["VERPROC"].Value = DadosCabecalhoEventoConst.verProc;
            cmd.Parameters["tpinsc"].Value = DadosCabecalhoEventoConst.tpInsc;
            cmd.Parameters["nrinsc"].Value = cnpj.Substring(0, 8);
            cmd.Parameters["TPEVENTO"].Value =  tipoEvento;
            cmd.Parameters["NRRECEVT"].Value = nrRecibo;
            cmd.Parameters["PERAPUR"].Value = perApur;
            cmd.Parameters["STATUS"].Value = "P";

            cmd.ExecuteNonQuery();

            oc.Close();
        }

        public void atualiza(int idReg, string cnpj, string tipoEvento, string nrRecibo, string perApur)
        {
            // Preencher com os dados da Carga
            string sqlInsR9000 = "update r9000 set ID = :ID, TPAMB = :TPAMB, PROCEMI = :PROCEMI, VERPROC = :VERPROC, TPINSC = :TPINSC, NRINSC = :NRINSC, TPEVENTO = :TPEVENTO, NRRECEVT = :NRRECEVT,PERAPUR = :PERAPUR WHERE  idReg = " + idReg.ToString();


            oc.Open();
            OracleCommand cmd = new OracleCommand(sqlInsR9000, oc);
            cmd.Parameters.Add(new OracleParameter("TPAMB", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("PROCEMI", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VERPROC", OracleDbType.Varchar2));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TPEVENTO", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NRRECEVT", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("PERAPUR", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("STATUS", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["TPAMB"].Value = DadosCabecalhoEventoConst.tpAmb;
            cmd.Parameters["PROCEMI"].Value = DadosCabecalhoEventoConst.procEmi;
            cmd.Parameters["VERPROC"].Value = DadosCabecalhoEventoConst.verProc;
            cmd.Parameters["tpinsc"].Value = "R" + DadosCabecalhoEventoConst.tpInsc;
            cmd.Parameters["nrinsc"].Value = cnpj;
            cmd.Parameters["TPEVENTO"].Value = tipoEvento;
            cmd.Parameters["NRRECEVT"].Value = nrRecibo;
            cmd.Parameters["PERAPUR"].Value = perApur;
            cmd.Parameters["STATUS"].Value = "P";

            cmd.ExecuteNonQuery();

            oc.Close();
        }
        public override void delete(int idReg)
        {
            String sql = "delete from R9000 where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }

        public override DataTable getData()
        {
            string sql = "select * from R9000 order by datahora_registro";
            return odb.getDataTable(sql);            

        }

        public override DataTable getData(int idReg)
        {
            string sql = "select * from R9000 where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getData(string cnpjEmpresa, string perApur)
        {
            string sql = "select * from R9000 where nrInsc = '" + cnpjEmpresa + "'";
            sql = sql + " and perApur = '" + perApur + "'";

            return odb.getDataTable(sql);
        }

        public override XmlDocument getXMLEvt(int idReg)
        {
            ReinfOraDB reinfOraDB = new ReinfOraDB();
            DataTable t = getData(idReg);

            Reinf r = new Reinf();
            ReinfEvtExclusao evt = new ReinfEvtExclusao();

            // Cabeçalho comum a todos os eventos
            evt.id = t.Rows[0]["id"].ToString();
            evt.ideEvento = new ReinfEvtExclusaoIdeEvento();
            evt.ideEvento.procEmi = Convert.ToByte(t.Rows[0]["procEmi"].ToString());
            evt.ideEvento.tpAmb = Convert.ToUInt16(t.Rows[0]["tpAmb"].ToString());
            evt.ideEvento.verProc = t.Rows[0]["verProc"].ToString();

            evt.ideContri = new ReinfEvtExclusaoIdeContri();
            evt.ideContri.tpInsc = Convert.ToByte(t.Rows[0]["tpInsc"].ToString());
            evt.ideContri.nrInsc = t.Rows[0]["nrInsc"].ToString().Substring(0,8);
            // Fim do Cabeçalho
            evt.infoExclusao = new ReinfEvtExclusaoInfoExclusao();
            evt.infoExclusao.tpEvento = t.Rows[0]["tpEvento"].ToString();            
            evt.infoExclusao.nrRecEvt = t.Rows[0]["nrRecEvt"].ToString();
            evt.infoExclusao.perApur = t.Rows[0]["perApur"].ToString();

            r.evtExclusao = evt;

            // Serializaçao do Objeto em Memória para retonrar o XMLDocument
            XmlSerializer x = new XmlSerializer(r.GetType());

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "http://www.reinf.esocial.gov.br/schemas/evtExclusao/" + DadosCabecalhoEventoConst.verProcClass);

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
