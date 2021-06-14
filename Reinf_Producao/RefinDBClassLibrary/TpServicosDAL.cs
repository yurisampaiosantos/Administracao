using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefinDBClassLibrary
{
    public class TpServicosDAL
    {
        OracleConnection conn;
        ReinfDBClassLibrary.ReinfOraDB odb;

        public TpServicosDAL()
        {
            odb = new ReinfDBClassLibrary.ReinfOraDB();
            conn = odb.getConn();
        }

        public DataTable getServicos()
        {
            String sql = "select * from TP_SERVICO";
            return odb.getDataTable(sql);
        }

        public DataTable getServico(int codigo)
        {
            String sql = "select * from TP_SERVICO where codigo = " + codigo.ToString();
            return odb.getDataTable(sql);
        }
    }
}
