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
    public abstract class RBASEDAL
    {
        public OracleConnection oc;
        public ReinfOraDB odb = new ReinfOraDB();

        public RBASEDAL(){
            odb = new ReinfOraDB();
            oc = odb.getConn();
        }

        public abstract void delete(int idReg);

        public abstract DataTable getData();

        public abstract DataTable getData(int idReg);

        public abstract XmlDocument getXMLEvt(int idReg);
    }
}
