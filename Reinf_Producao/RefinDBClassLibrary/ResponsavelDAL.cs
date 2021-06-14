using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefinDBClassLibrary
{
    public class ResponsavelDAL
    {
        OracleConnection conn;
        ReinfDBClassLibrary.ReinfOraDB odb;

        public ResponsavelDAL()
        {
            odb = new ReinfDBClassLibrary.ReinfOraDB();
            conn = odb.getConn();
        }

        public DataTable getReponsaveis()
        {
            String sql = "select * from RESPONSAVEIS";
            return odb.getDataTable(sql);
        }

        public DataTable getReponsavel(int idReg)
        {
            String sql = "select * from RESPONSAVEIS where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public void delete(int idReg)
        {
            String sql = "delete from RESPONSAVEIS where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }

        public void incluir(string nome, string cpf, string foneFixo, string foneCel, string email)
        {
            String sql = "insert into RESPONSAVEIS (nmResp, cpfResp, foneFixo, foneCel, email) values ('" + nome + "','" + cpf + "','" + foneFixo + "','" + foneCel + "','" + email + "')";
            odb.executeSql(sql);
        }

        public void atualiza(int idReg, string nome, string cpf, string foneFixo, string foneCel, string email)
        {
            String sql = "update RESPONSAVEIS set nmResp = '" + nome + "', cpfResp = '" + cpf + "', foneFixo = '" + foneFixo + "', foneCel= '" + foneCel + "', email = '" + email + "' where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }
    }
}
