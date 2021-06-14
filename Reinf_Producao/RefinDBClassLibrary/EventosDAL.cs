using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefinDBClassLibrary
{
    public class EventosDAL
    {
        OracleConnection conn;
        ReinfDBClassLibrary.ReinfOraDB odb;

        public EventosDAL()
        {
            odb = new ReinfDBClassLibrary.ReinfOraDB();
            conn = odb.getConn();
        }

        public DataTable getEventos()
        {
            String sql = "select * from EVENTOS";
            return odb.getDataTable(sql);
        }
        public DataTable getEventosExclusao()
        {
            String sql = "select * from EVENTOS WHERE CODIGO NOT IN (1000,1070,2098,2099,5001,9000,2020,2030,2040,2050)";
            return odb.getDataTable(sql);
        }
        public DataTable getEvento(int idReg)
        {
            String sql = "select * from EVENTOS where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public void delete(int idReg)
        {
            String sql = "delete from EVENTOS where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }

        public void incluir(string nome, string codigo, string tagEvento, string ativo)
        {
            String sql = "insert into EVENTOS (nome, codigo, tagevento, ativo) values ('" + nome + "','" + codigo + "','" + tagEvento + "','"+ativo+"')";
            odb.executeSql(sql);
        }

        public void atualiza(int idReg, string nome, string codigo, string tagEvento, string ativo)
        {
            String sql = "update EVENTOS set nome = '" + nome + "', codigo = '" + codigo + "', tagevento = '" + tagEvento + "', ativo = '"+ ativo+"' where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }
        public DataTable getEventoRecibo(string evento , string perapur , string empresa)
        {
            EmpresaDAL empresaDAL = new EmpresaDAL();
            String cnpj = empresaDAL.getEmpresa(Convert.ToInt32(empresa)).Rows[0]["cnpj"].ToString();
            String sql = "select NR_RECIBO from R" + evento + " where PERAPUR = '" + perapur + "' AND NRINSC = '" + cnpj.Substring(0,8) + "000000' AND NR_RECIBO IS NOT NULL";
            sql = sql + " AND NOT EXISTS (SELECT ID FROM R9000 WHERE R9000.NRRECEVT = R" + evento + ".NR_RECIBO AND R9000.PERAPUR = '" + perapur + "')";
            return odb.getDataTable(sql);
        }
        public DataTable getEventoReciboFechamento(string perapur, string empresa)
        {
            EmpresaDAL empresaDAL = new EmpresaDAL();
            String cnpj = empresaDAL.getEmpresa(Convert.ToInt32(empresa)).Rows[0]["cnpj"].ToString();
            String sql = "select NR_RECIBO from R2099 where PERAPUR = '" + perapur + "' AND NRINSC = '" + cnpj.Substring(0, 8) + "000000' AND NR_RECIBO IS NOT NULL AND NOT EXISTS (SELECT ID FROM R5011 WHERE R5011.NRPROTENTR = R2099.NR_RECIBO )";
            return odb.getDataTable(sql);
        }
    }
}
