using RefinDBClassLibrary;
using ReinfDBClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFATesteAssinaturaXML
{
    public partial class frmNovoR2010 : Form
    {
        public int idReg;
        private RBASEDAL objDLL;
        public frmNovoR2010()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (idReg != 0)
            {
                
            }
            else
            {
                ReinfOraDB verificar = new ReinfOraDB();
               
                if (verificar.verificarFechamentoReabertura(Convert.ToInt32(cmbEmpresa.SelectedValue), dtpPeriodoIni.Text))
                {
                    (objDLL as R2010DAL).gerarR2010Comply(Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()), dtpPeriodoIni.Text);
                }
                else
                {
                    MessageBox.Show("É necessario reabrir o periodo ou enviar o evento 5011 antes de importar");
                }
            }
            Close();
        }

        private void frmNovoR2010_Load(object sender, EventArgs e)
        {
            dtpPeriodoIni.Format = DateTimePickerFormat.Custom;
            dtpPeriodoIni.CustomFormat = "yyyy-MM";

            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), cmbEmpresa, "nome", "idReg");
            
            objDLL = new R2010DAL();
            
            if (idReg != 0) { 
                DataTable dt = objDLL.getData(idReg);
                //cmbEmpresa.SelectedValue = dt.Rows[0]["idRegEmpresa"].ToString();
                dtpPeriodoIni.Text = dt.Rows[0]["perApur"].ToString();
            }
            
        }

    }
}
