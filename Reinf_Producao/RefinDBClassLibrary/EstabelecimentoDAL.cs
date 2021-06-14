using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefinDBClassLibrary
{
    public class EstabelecimentoDAL
    {
        OracleConnection conn;
        ReinfDBClassLibrary.ReinfOraDB odb;

        public EstabelecimentoDAL()
        {
            odb = new ReinfDBClassLibrary.ReinfOraDB();
            conn = odb.getConn();
        }

        public DataTable getEstabelecimentos()
        {
            String sql = "select esta.*, empr.nome nome_empresa from ESTABELECIMENTOS esta, EMPRESAS empr where esta.empresas_idreg = empr.idreg";
            return odb.getDataTable(sql);
        }

        public DataTable getEstabelecimentosDaEmpresa(int idRegEmpresa)
        {
            String sql = "select esta.*, empr.nome nome_empresa from ESTABELECIMENTOS esta, EMPRESAS empr where esta.empresas_idreg = empr.idreg and empr.idreg = " + idRegEmpresa.ToString();
            return odb.getDataTable(sql);
        }

        public DataTable getEstabelecimento(int idReg)
        {
            String sql = "select esta.*, empr.nome nome_empresa from ESTABELECIMENTOS esta, EMPRESAS empr where esta.empresas_idreg = empr.idreg and esta.idReg = " + idReg.ToString();
            return odb.getDataTable(sql);
        }

        
        public DataTable getEstabelecimentoByCodigo(string codigo)
        {
            String sql = "select * from ESTABELECIMENTOS esta where esta.codigo = '" + codigo + "'";
            return odb.getDataTable(sql);
        }

        public int getIdEstabelecimento(string cnpj)
        {
            String sql = "select esta.idReg from ESTABELECIMENTOS esta where esta.cnpj = '" + cnpj + "'";
            return Convert.ToInt32(odb.getDataTable(sql).Rows[0]["idReg"].ToString());
        }

        public void delete(int idReg)
        {
            String sql = "delete from ESTABELECIMENTOS where idReg = " + idReg.ToString();

            odb.executeSql(sql);
        }

        public void incluir(string nome, string cnpj, string codigo, int idRegEmpresa)
        {
            String sql = "insert into ESTABELECIMENTOS (nome,cnpj, codigo, empresas_idreg) values ('" + nome + "','" + cnpj + "','" + codigo + "'," + idRegEmpresa.ToString() +")";
            odb.executeSql(sql);
        }

        public void atualiza(int idReg, string nome, string cnpj, string codigo, int idRegEmpresa)
        {
            String sql = "update ESTABELECIMENTOS set nome = '" + nome + "', cnpj = '" + cnpj + "', codigo = '"+codigo+"', empresas_idreg = "+idRegEmpresa.ToString() +" where idReg = " + idReg.ToString();
            odb.executeSql(sql);
        }
    }
}
