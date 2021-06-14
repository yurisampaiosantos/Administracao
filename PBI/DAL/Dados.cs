using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

namespace WebServicePBI.DAL
{
    public class Dados
    {
        public static string StringDeConexaoOracle
        {
            get
            {//MSDAORA                 
                //------produção                                                                             
                return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_EMRB;Password=EmRbOraçqq";
            }
        }
        public static string StringDeConexaoSqlServer
        {
            get
            {//SQL Server                 
                //------produção              
                return "Data Source=CDCSQLCM01;Initial Catalog=CM_ENS;User ID=f_app_pbi;Password=pbi14SQL";
            }
        }
    }
}
