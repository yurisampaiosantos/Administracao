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
    public partial class frmDadosR2099 : Form
    {
        public int idReg;
        private R2099DAL objDLL;
        public frmDadosR2099()
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
            if (verificar.verificarPendencias(Convert.ToInt32(cmbEmpresa.SelectedValue), dtpPeriodoIni.Text))
            {
                if (verificar.verificarFechamentoReabertura(Convert.ToInt32(cmbEmpresa.SelectedValue), dtpPeriodoIni.Text))
                {
                    if (idReg != 0)
                    {
                        objDLL.atualiza(idReg, Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()),
                                      Convert.ToInt32(cmbResponsavel.SelectedValue.ToString()),
                                      dtpPeriodoIni.Text, dt1Competencia.Text);
                    }
                    else
                    {
                        objDLL.incluir(Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()),
                                      Convert.ToInt32(cmbResponsavel.SelectedValue.ToString()),
                                      dtpPeriodoIni.Text, dt1Competencia.Text);
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("É necessario reabrir");
                }
            }
            else 
            {
                MessageBox.Show("É necessario enviar ou excluir os registros dos enventos 2010 ou 2060");
            }
        }

        private void frmDadosR1000_Load(object sender, EventArgs e)
        {
            dtpPeriodoIni.Format = DateTimePickerFormat.Custom;
            dtpPeriodoIni.CustomFormat = "yyyy-MM";

            dt1Competencia.Format = DateTimePickerFormat.Custom;
            dt1Competencia.CustomFormat = " ";

            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), cmbEmpresa, "nome", "idReg");
            Utils.CarregaCombo((new ResponsavelDAL().getReponsaveis()), cmbResponsavel, "nmResp", "idReg");
            
            objDLL = new R2099DAL();
            
            if (idReg != 0) { 
                DataTable dt = objDLL.getData(idReg);
                //cmbEmpresa.SelectedValue = dt.Rows[0]["idRegEmpresa"].ToString();
                //cmb.SelectedValue = dt.Rows[0]["idRegResponsaveis"].ToString();
                dtpPeriodoIni.Text = dt.Rows[0]["perApur"].ToString();
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dt1Competencia_ValueChanged(object sender, EventArgs e)
        {
            dt1Competencia.CustomFormat = "yyyy-MM";
        }
    }
}
