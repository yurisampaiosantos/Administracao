using evtInfoContribuinte;
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
    public class R1000DAL : RBASEDAL
    {

        public void incluir(int idRegEmpresa, int idRegResponsavel, string iniValid, string classTrib, int indEscrituracao, int indDesoneracao, int indAcordoIsencaoMulta, int indSitPj)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            // Preencher com os dados da Carga
            string sqlInsR1000 = "insert into r1000 (ID, TPAMB, PROCEMI, VERPROC, TPINSC, NRINSC, TIPO_EVENTO, INIVALID, CLASSTRIB, INDESCRITURACAO, INDDESONERACAO, INDACORDOISENMULTA, INDSITPJ, NMCTT, CPFCTT, FONEFIXO, FONECEL,EMAIL, STATUS) " +
                         " values(:ID, :TPAMB, :PROCEMI, :VERPROC, :TPINSC, :NRINSC, :TIPO_EVENTO, :INIVALID, :CLASSTRIB, :INDESCRITURACAO, :INDDESONERACAO, :INDACORDOISENMULTA, :INDSITPJ, :NMCTT, :CPFCTT, :FONEFIXO, :FONECEL,:EMAIL,:STATUS) ";

            oc.Open();
            OracleCommand cmd = new OracleCommand(sqlInsR1000, oc);
            cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TPAMB", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("PROCEMI", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VERPROC", OracleDbType.Varchar2));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TIPO_EVENTO", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INIVALID", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("CLASSTRIB", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INDESCRITURACAO", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INDDESONERACAO", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INDACORDOISENMULTA", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INDSITPJ", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NMCTT", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("CPFCTT", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("FONEFIXO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("FONECEL", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EMAIL", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("STATUS", OracleDbType.Varchar2, ParameterDirection.Input));


            cmd.Parameters["id"].Value = "ID"+ DadosCabecalhoEventoConst.tpInsc.ToString() + cnpj.Substring(0,8)+"000000" + DateTime.Now.ToString("yyyyMMddHHmmss") + 1.ToString("00000");
            cmd.Parameters["TPAMB"].Value = DadosCabecalhoEventoConst.tpAmb;
            cmd.Parameters["PROCEMI"].Value = DadosCabecalhoEventoConst.procEmi;
            cmd.Parameters["VERPROC"].Value = DadosCabecalhoEventoConst.verProc;
            cmd.Parameters["tpinsc"].Value = DadosCabecalhoEventoConst.tpInsc;
            cmd.Parameters["nrinsc"].Value = cnpj;
            cmd.Parameters["TIPO_EVENTO"].Value = 1;
            cmd.Parameters["INIVALID"].Value = iniValid;

            cmd.Parameters["CLASSTRIB"].Value = classTrib;
            cmd.Parameters["INDESCRITURACAO"].Value = indEscrituracao;
            cmd.Parameters["INDDESONERACAO"].Value = indDesoneracao;
            cmd.Parameters["INDACORDOISENMULTA"].Value = indAcordoIsencaoMulta;
            cmd.Parameters["INDSITPJ"].Value = indSitPj;
            ResponsavelDAL r = new ResponsavelDAL();
            DataTable dtResp = r.getReponsavel(idRegResponsavel);

            cmd.Parameters["NMCTT"].Value = dtResp.Rows[0]["NMRESP"].ToString();
            cmd.Parameters["CPFCTT"].Value = dtResp.Rows[0]["CPFRESP"].ToString();
            cmd.Parameters["FONEFIXO"].Value = dtResp.Rows[0]["FONEFIXO"].ToString();
            cmd.Parameters["FONECEL"].Value = dtResp.Rows[0]["FONECEL"].ToString();
            cmd.Parameters["EMAIL"].Value = dtResp.Rows[0]["EMAIL"].ToString();
            cmd.Parameters["STATUS"].Value = "P";

            cmd.ExecuteNonQuery();

            oc.Close();
        }

        public void atualiza(int idReg, int idRegEmpresa, int idRegResponsavel, string iniValid, string classTrib, int indEscrituracao, int indDesoneracao, int indAcordoIsencaoMulta, int indSitPj, string fimValid)
        {
            // Pega o CNPJ
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(idRegEmpresa).Rows[0]["cnpj"].ToString();

            // Preencher com os dados da Carga
            string sqlInsR1000 = "update r1000 set TPAMB =:TPAMB , PROCEMI = :PROCEMI, VERPROC = :VERPROC, TPINSC = :TPINSC, NRINSC = :NRINSC, TIPO_EVENTO = :TIPO_EVENTO , INIVALID=:INIVALID, CLASSTRIB=:CLASSTRIB, INDESCRITURACAO=:INDESCRITURACAO, INDDESONERACAO=:INDDESONERACAO, INDACORDOISENMULTA=:INDACORDOINSEMULTA, INDSITPJ=:INDSITPJ, NMCTT=:NMCTT, CPFCTT=:CPFCTT, FONEFIXO=:FONEFIXO, FONECEL=:FONECEL,EMAIL=:EMAIL, FIMVALID=:FIMVALID where idReg = " + idReg.ToString();
                        

            oc.Open();
            OracleCommand cmd = new OracleCommand(sqlInsR1000, oc);
            //cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TPAMB", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("PROCEMI", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VERPROC", OracleDbType.Varchar2));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TIPO_EVENTO", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INIVALID", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("CLASSTRIB", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INDESCRITURACAO", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INDDESONERACAO", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INDACORDOISENMULTA", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INDSITPJ", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("NMCTT", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("CPFCTT", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("FONEFIXO", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("FONECEL", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("EMAIL", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("FIMVALID", OracleDbType.Varchar2, ParameterDirection.Input));
            

           // cmd.Parameters["id"].Value = "ID" + DadosCabecalhoEventoConst.tpInsc.ToString() + cnpj + DateTime.Now.ToString("yyyyMMddHHmmss") + 1.ToString("00000");
            cmd.Parameters["TPAMB"].Value = DadosCabecalhoEventoConst.tpAmb;
            cmd.Parameters["PROCEMI"].Value = DadosCabecalhoEventoConst.procEmi;
            cmd.Parameters["VERPROC"].Value = DadosCabecalhoEventoConst.verProc;
            cmd.Parameters["tpinsc"].Value = DadosCabecalhoEventoConst.tpInsc;
            cmd.Parameters["nrinsc"].Value = cnpj;
            cmd.Parameters["TIPO_EVENTO"].Value = 1;
            cmd.Parameters["INIVALID"].Value = iniValid;
            cmd.Parameters["CLASSTRIB"].Value = classTrib;
            cmd.Parameters["INDESCRITURACAO"].Value = indEscrituracao;
            cmd.Parameters["INDDESONERACAO"].Value = indDesoneracao;
            cmd.Parameters["INDACORDOISENMULTA"].Value = indAcordoIsencaoMulta;
            cmd.Parameters["INDSITPJ"].Value = indSitPj;
            cmd.Parameters["FIMVALID"].Value = fimValid;

            ResponsavelDAL r = new ResponsavelDAL();
            DataTable dtResp = r.getReponsavel(idRegResponsavel);

            cmd.Parameters["NMCTT"].Value = dtResp.Rows[0]["NMRESP"].ToString();
            cmd.Parameters["CPFCTT"].Value = dtResp.Rows[0]["CPFRESP"].ToString();
            cmd.Parameters["FONEFIXO"].Value = dtResp.Rows[0]["FONEFIXO"].ToString();
            cmd.Parameters["FONECEL"].Value = dtResp.Rows[0]["FONECEL"].ToString();
            cmd.Parameters["EMAIL"].Value = dtResp.Rows[0]["EMAIL"].ToString();
            


            cmd.ExecuteNonQuery();

            oc.Close();
        }

        public override void delete(int idReg)
        {
            String sql = "delete from R1000 where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }

        public void gerarDataExclusaoR1000(int idReg)
        {

            string sql = "select * from R1000 where idReg = " + idReg.ToString();           
            DataTable dt = odb.getDataTable(sql);

            // Preencher com os dados da Carga
            string sqlInsR1000 = "insert into r1000 (ID, TPAMB, PROCEMI, VERPROC, TPINSC, NRINSC, TIPO_EVENTO, INIVALID, STATUS) " +
                         " values(:ID, :TPAMB, :PROCEMI, :VERPROC, :TPINSC, :NRINSC, :TIPO_EVENTO, :INIVALID, :STATUS) ";


            oc.Open();
            OracleCommand cmd = new OracleCommand(sqlInsR1000, oc);
            cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TPAMB", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("PROCEMI", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("VERPROC", OracleDbType.Varchar2));
            cmd.Parameters.Add(new OracleParameter("tpinsc", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("nrinsc", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("TIPO_EVENTO", OracleDbType.Int16, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("INIVALID", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("STATUS", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["id"].Value = "ID1" + dt.Rows[0]["nrinsc"].ToString().Substring(0,8) +"000000" + DateTime.Now.ToString("yyyyMMddHHmmss") + 1.ToString("00000");
            cmd.Parameters["TPAMB"].Value = dt.Rows[0]["TPAMB"].ToString();
            cmd.Parameters["PROCEMI"].Value = dt.Rows[0]["PROCEMI"].ToString();
            cmd.Parameters["VERPROC"].Value = dt.Rows[0]["VERPROC"].ToString();
            cmd.Parameters["tpinsc"].Value = dt.Rows[0]["tpinsc"].ToString();
            cmd.Parameters["nrinsc"].Value = dt.Rows[0]["nrinsc"].ToString();
            cmd.Parameters["TIPO_EVENTO"].Value = 3;
            cmd.Parameters["INIVALID"].Value = dt.Rows[0]["INIVALID"].ToString();
            cmd.Parameters["STATUS"].Value = "P";
            cmd.ExecuteNonQuery();

            oc.Close();
        }

        public void gerarDataFecharR1000(int idReg)
        {

            // Inserir com os dados da Carga
            string sqlFecharR1000 = "insert into r1000 ( ID,  TPAMB,  PROCEMI,  VERPROC,  TPINSC,  NRINSC,  TIPO_EVENTO,  INIVALID,  FIMVALID,  CLASSTRIB,  INDESCRITURACAO,  INDDESONERACAO,  INDACORDOISENMULTA,  INDSITPJ,  " +
                                                        "DATAHORA_REGISTRO, NMCTT,  CPFCTT,  FONEFIXO,  FONECEL,  EMAIL,  STATUS ) " +
                                     "select " + "'ID1'" + "||SUBSTR(nrinsc,1,8,)||'000000'||'" + DateTime.Now.ToString("yyyyMMddHHmmss") + 1.ToString("00000") + "',  TPAMB,  PROCEMI,  VERPROC,  TPINSC,  NRINSC,  2,  INIVALID,  FIMVALID,  CLASSTRIB,  INDESCRITURACAO,  INDDESONERACAO,  INDACORDOISENMULTA,  INDSITPJ,  " +
                                                        "DATAHORA_REGISTRO, NMCTT,  CPFCTT,  FONEFIXO,  FONECEL,  EMAIL,  'P' " +
                                     "from R1000 where idReg = " + idReg.ToString();

           
            oc.Open();
            OracleCommand cmd = new OracleCommand(sqlFecharR1000, oc);
           
            cmd.ExecuteNonQuery();

            oc.Close();
        }
        public override DataTable getData()
        {
            string sql = "select * from R1000 order by datahora_registro";
            return odb.getDataTable(sql);            

        }

        public DataTable getData(string cnpjEmpresa)
        {
            string sql = "select * from R1000 where nrInsc = '" + cnpjEmpresa + "'";
            return odb.getDataTable(sql);
        }

        public override DataTable getData(int idReg)
        {
            string sql = "select * from R1000 where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public override XmlDocument getXMLEvt(int idReg)
        {
            ReinfOraDB reinfOraDB = new ReinfOraDB();
            DataTable t = getData(idReg);

            Reinf r = new Reinf();
            ReinfEvtInfoContri evt = new ReinfEvtInfoContri();

            // Cabeçalho comum a todos os eventos
            evt.id = t.Rows[0]["id"].ToString();
            evt.ideEvento = new ReinfEvtInfoContriIdeEvento();
            evt.ideEvento.procEmi = Convert.ToUInt16(t.Rows[0]["procEmi"].ToString());
            evt.ideEvento.tpAmb = Convert.ToUInt16(t.Rows[0]["tpAmb"].ToString());
            evt.ideEvento.verProc = t.Rows[0]["verProc"].ToString();
            evt.ideContri = new ReinfEvtInfoContriIdeContri();
            evt.ideContri.tpInsc = Convert.ToByte(t.Rows[0]["tpInsc"].ToString());
            evt.ideContri.nrInsc = t.Rows[0]["nrInsc"].ToString().Substring(0,8);
            // Fim do Cabeçalho


            evt.infoContri = new ReinfEvtInfoContriInfoContri();
            if (t.Rows[0]["tipo_evento"].ToString() == "1")
            {
                // Grupo Dados do Contribuinte                
                evt.infoContri.Item = new ReinfEvtInfoContriInfoContriInclusao();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).idePeriodo = new ReinfEvtInfoContriInfoContriInclusaoIdePeriodo();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).idePeriodo.iniValid = t.Rows[0]["iniValid"].ToString();
                /*if (t.Rows[0]["fimValid"].ToString() != "")
                {
                    (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).idePeriodo.fimValid = t.Rows[0]["fimValid"].ToString();
                }*/
                // Informações do Contribuinte
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro = new ReinfEvtInfoContriInfoContriInclusaoInfoCadastro();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro.classTrib = t.Rows[0]["classTrib"].ToString();  // Preencher com o código correspondente à classificação tributária do contribuinte, conforme tabela 8.
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro.indEscrituracao = Convert.ToUInt16(t.Rows[0]["indEscrituracao"].ToString());
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro.indDesoneracao = Convert.ToUInt16(t.Rows[0]["indDesoneracao"].ToString());
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro.indAcordoIsenMulta = Convert.ToUInt16(t.Rows[0]["indAcordoIsenMulta"].ToString());
                if (evt.ideContri.tpInsc == 1)
                {
                    (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro.indSitPJSpecified = true;
                    (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro.indSitPJ = Convert.ToUInt16(t.Rows[0]["indSitPJ"].ToString());
                }
                // Informações do Contato            
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro.contato = new ReinfEvtInfoContriInfoContriInclusaoInfoCadastroContato();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro.contato.nmCtt = t.Rows[0]["nmCtt"].ToString();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro.contato.cpfCtt = t.Rows[0]["cpfCtt"].ToString();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriInclusao).infoCadastro.contato.foneFixo = t.Rows[0]["foneFixo"].ToString();
            }
            if (t.Rows[0]["tipo_evento"].ToString() == "2")
            {
                // Grupo Dados do Contribuinte                
                evt.infoContri.Item = new ReinfEvtInfoContriInfoContriAlteracao();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).idePeriodo = new ReinfEvtInfoContriInfoContriAlteracaoIdePeriodo();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).idePeriodo.iniValid = t.Rows[0]["iniValid"].ToString();
                if (t.Rows[0]["fimValid"].ToString() != "")
                {
                    (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).idePeriodo.fimValid = t.Rows[0]["fimValid"].ToString();
                }

                // Informações do Contribuinte
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro = new ReinfEvtInfoContriInfoContriAlteracaoInfoCadastro();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro.classTrib = t.Rows[0]["classTrib"].ToString();  // Preencher com o código correspondente à classificação tributária do contribuinte, conforme tabela 8.
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro.indEscrituracao = Convert.ToUInt16(t.Rows[0]["indEscrituracao"].ToString());
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro.indDesoneracao = Convert.ToUInt16(t.Rows[0]["indDesoneracao"].ToString());
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro.indAcordoIsenMulta = Convert.ToUInt16(t.Rows[0]["indAcordoIsenMulta"].ToString());
                if (evt.ideContri.tpInsc == 1)
                {
                    (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro.indSitPJSpecified = true;
                    (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro.indSitPJ = Convert.ToUInt16(t.Rows[0]["indSitPJ"].ToString());
                }
                // Informações do Contato            
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro.contato = new ReinfEvtInfoContriInfoContriAlteracaoInfoCadastroContato();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro.contato.nmCtt = t.Rows[0]["nmCtt"].ToString();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro.contato.cpfCtt = t.Rows[0]["cpfCtt"].ToString();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriAlteracao).infoCadastro.contato.foneFixo = t.Rows[0]["foneFixo"].ToString();                
            }
            if (t.Rows[0]["tipo_evento"].ToString() == "3")
            {
                // Grupo Dados do Contribuinte                
                evt.infoContri.Item = new ReinfEvtInfoContriInfoContriExclusao();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriExclusao).idePeriodo = new ReinfEvtInfoContriInfoContriExclusaoIdePeriodo();
                (evt.infoContri.Item as ReinfEvtInfoContriInfoContriExclusao).idePeriodo.iniValid = t.Rows[0]["iniValid"].ToString();
            }

            r.evtInfoContri = evt;


            // Serializaçao do Objeto em Memória para retonrar o XMLDocument
            XmlSerializer x = new XmlSerializer(r.GetType());

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/"+DadosCabecalhoEventoConst.verProcClass);

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
