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
    public partial class frmDadosR2098 : Form
    {
        public int idReg;
        private R2098DAL objDLL;
        public frmDadosR2098()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ReinfOraDB verificar = new ReinfOraDB();

            if (!verificar.verificarFechamentoReabertura(Convert.ToInt32(cmbEmpresa.SelectedValue), dtpPeriodoIni.Text))
            {
                if (idReg != 0)
                {
                    objDLL.atualiza(idReg, Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()),
                                  dtpPeriodoIni.Text);
                }
                else
                {
                    objDLL.incluir(Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()),
                                  dtpPeriodoIni.Text);
                }
                Close();
            }
            else
            {
                MessageBox.Show("É necessario ter um fechamento");
            }
        }

        private void frmDadosR2098_Load(object sender, EventArgs e)
        {
            dtpPeriodoIni.Format = DateTimePickerFormat.Custom;
            dtpPeriodoIni.CustomFormat = "yyyy-MM";

            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), cmbEmpresa, "nome", "idReg");
            
            objDLL = new R2098DAL();
            
            if (idReg != 0) { 
                DataTable dt = objDLL.getData(idReg);
                //cmbEmpresa.SelectedValue = dt.Rows[0]["idRegEmpresa"].ToString();
                dtpPeriodoIni.Text = dt.Rows[0]["perApur"].ToString();
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dtpPeriodoIni_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
