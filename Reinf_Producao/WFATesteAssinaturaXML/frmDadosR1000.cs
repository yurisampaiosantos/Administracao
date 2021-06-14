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
    public partial class frmDadosR1000 : Form
    {
        public int idReg;
        public bool edicao;
        private R1000DAL objDLL;
        public frmDadosR1000()
        {        
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            dtpPeriodoIni.CustomFormat = "yyyy-MM";
            dtpPeriodoFim.CustomFormat = "yyyy-MM";
            if (idReg != 0)
            {
                objDLL.atualiza(idReg, 
                              Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()),
                              Convert.ToInt32(cmbResponsavel.SelectedValue.ToString()),
                              dtpPeriodoIni.Text,
                              cmbClassTrib.SelectedItem.ToString().Substring(0, 2),
                              cmbECD.SelectedIndex,
                              cmbIndDesoneracao.SelectedIndex,
                              cmbIndAcordo.SelectedIndex,
                              cmbIndSitPJ.SelectedIndex,
                              dtpPeriodoFim.Text);
            }
            else
            {
                objDLL.incluir(Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()),
                              Convert.ToInt32(cmbResponsavel.SelectedValue.ToString()),
                              dtpPeriodoIni.Text,
                              cmbClassTrib.SelectedItem.ToString().Substring(0,2),
                              cmbECD.SelectedIndex,
                              cmbIndDesoneracao.SelectedIndex,
                              cmbIndAcordo.SelectedIndex,
                              cmbIndSitPJ.SelectedIndex);
            }
            Close();
        }

        private void frmDadosR1000_Load(object sender, EventArgs e)
        {
            if (idReg == 0)
            {
                edicao = true;
            }
            buttonOk.Visible = edicao;

            dtpPeriodoIni.Format = DateTimePickerFormat.Custom;
            dtpPeriodoFim.Format = DateTimePickerFormat.Custom;
        //    dtpPeriodoIni.CustomFormat = "yyyy-MM";

            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), cmbEmpresa, "nome", "idReg");
            Utils.CarregaCombo((new ResponsavelDAL().getReponsaveis()), cmbResponsavel, "nmResp", "idReg");
            
            objDLL = new R1000DAL();
            
            if (idReg != 0) { 
                DataTable dt = objDLL.getData(idReg);

                for (int i = 0; i < cmbClassTrib.Items.Count; i++)
                {
                    if (cmbClassTrib.Items[i].ToString().Contains(dt.Rows[0]["CLASSTRIB"].ToString())){
                        cmbClassTrib.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < cmbEmpresa.Items.Count; i++)
                {
                    if (((System.Data.DataRowView)(cmbEmpresa.Items[i])).Row.ItemArray[2].ToString().Contains(dt.Rows[0]["NRINSC"].ToString()))
                    {
                        cmbEmpresa.SelectedIndex = i;
                    }
                }

                for (int i = 0; i < cmbResponsavel.Items.Count; i++)
                {
                    if (((System.Data.DataRowView)(cmbResponsavel.Items[i])).Row.ItemArray[1].ToString().Contains(dt.Rows[0]["NMCTT"].ToString()))
                    {
                        cmbResponsavel.SelectedIndex = i;
                    }
                }

                cmbECD.SelectedIndex = Convert.ToInt16(dt.Rows[0]["INDESCRITURACAO"].ToString());
                cmbIndAcordo.SelectedIndex = Convert.ToInt16(dt.Rows[0]["INDACORDOISENMULTA"].ToString());
                cmbIndDesoneracao.SelectedIndex = Convert.ToInt16(dt.Rows[0]["INDDESONERACAO"].ToString());
                cmbIndSitPJ.SelectedIndex = Convert.ToInt16(dt.Rows[0]["INDSITPJ"].ToString());
                dtpPeriodoIni.Text = (dt.Rows[0]["INIVALID"].ToString());

                if (dt.Rows[0]["TIPO_EVENTO"].ToString() == "2")
                {
                    dtpPeriodoFim.Text = (dt.Rows[0]["FIMVALID"].ToString());
                }
                else
                {
                    dtpPeriodoFim.Visible = false;
                    label9.Visible = false;
                }

            }
            else
            {
                dtpPeriodoFim.Visible = false;
                label9.Visible = false;
            }            
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
