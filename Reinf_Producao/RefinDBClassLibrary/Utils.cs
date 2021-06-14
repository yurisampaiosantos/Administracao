using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefinDBClassLibrary
{
    public class Utils
    {
        public static void CarregaCombo(DataTable dt, ComboBox c, string display, string value)
        {
            c.DataSource = null;
            c.DataSource = dt;
            c.ValueMember = value;
            c.DisplayMember = display;
        }

        public static string ConverteNumero(string valor)
        {
            string valorResultado = "";

            valorResultado = Convert.ToDecimal(valor).ToString("0.00").ToString();           

            return valorResultado;
        }
        

    }
   
}
