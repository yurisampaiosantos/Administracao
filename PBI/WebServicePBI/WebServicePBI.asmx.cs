using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServicePBI.Negocio;

namespace WebServicePBI
{
    /// <summary>
    /// Summary description for WebServicePBI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePBI : System.Web.Services.WebService
    {

        [WebMethod]
        public void AtualizarPBI()
        {
            PBI_OracleNeg pBI_OracleNeg = new PBI_OracleNeg();
            pBI_OracleNeg.AtualizarPBI();
        }
    }
}
