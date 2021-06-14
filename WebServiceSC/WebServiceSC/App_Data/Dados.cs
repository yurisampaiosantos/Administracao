using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceSC
{
    public class Dados
    {
        //DEV
        //private static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=F_APP_EAC;Password=chAMADO15";
        //PROD
        public static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_EAC;Password=cHa#AMDO@ORA15";

    }
}