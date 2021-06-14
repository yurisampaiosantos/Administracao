using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefinDBClassLibrary
{
    public class EmpresaDAL
    {
        OracleConnection conn;
        ReinfDBClassLibrary.ReinfOraDB odb;

        public EmpresaDAL()
        {
            odb = new ReinfDBClassLibrary.ReinfOraDB();
            conn = odb.getConn();
        }

        public DataTable getEmpresas()
        {
            String sql = "select * from EMPRESAS";
            return odb.getDataTable(sql);
        }

        public DataTable getEmpresa(int idReg)
        {
            String sql = "select * from EMPRESAS where idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getEmpresaByCodigo(string codigo)
        {
            String sql = "select IDREG , NOME , SUBSTR(CNPJ,0,8)||'000000' AS CNPJ , RESPONSAVEIS_IDREG , CODIGO from EMPRESAS where codigo = " + codigo;
            return odb.getDataTable(sql);
        }

        public int getIdEmpresa(string cnpj)
        {
            String sql = "select idReg from EMPRESAS where SUBSTR(cnpj,0,8)||'000000' = '" + cnpj + "'";
            return Convert.ToInt32(odb.getDataTable(sql).Rows[0]["idReg"].ToString());
        }

        public DataTable getEmpresa(string cnpj)
        {
            String sql = "select * from EMPRESAS where cnpj = '" + cnpj + "'";
            return odb.getDataTable(sql);
        }


        public void delete(int idReg)
        {
            String sql = "delete from EMPRESAS where idReg = " + idReg.ToString();

            conn.Open();
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void incluir(string nome, string cnpj, string codigo, int idRegResponsavel)
        {
            String sql = "insert into EMPRESAS (nome,cnpj, codigo, responsaveis_idReg) values ('" + nome + "','" + cnpj + "','" + codigo + "' ," + idRegResponsavel.ToString() + " )";
            conn.Open();
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void atualiza(int idReg, string nome, string cnpj, string codigo, int idRegResponsavel)
        {
            String sql = "update EMPRESAS set nome = '" + nome + "', cnpj = '" + cnpj + "', codigo = '"+codigo +"', responsaveis_idReg = " + idRegResponsavel.ToString() + " where idReg = " + idReg.ToString();

            conn.Open();
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
