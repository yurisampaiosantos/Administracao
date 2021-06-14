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
    public partial class frmDadosR5011 : Form
    {
        public int idReg;

        private R5011DAL objDLL;
        public frmDadosR5011()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
                objDLL.incluir(Convert.ToInt32(cmbEmpresa.SelectedValue),  dtpPeriodoIni.Text , cmbRecibo.SelectedValue.ToString());
                Close();
        }

        private void frmDadosR2098_Load(object sender, EventArgs e)
        {
            dtpPeriodoIni.Format = DateTimePickerFormat.Custom;
            dtpPeriodoIni.CustomFormat = "yyyy-MM";

            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), cmbEmpresa, "nome", "idReg");

            
            objDLL = new R5011DAL();
            
            if (idReg != 0) { 
                DataTable dt = objDLL.getData(idReg);

                for (int i = 0; i < cmbEmpresa.Items.Count; i++)
                {
                    if (((System.Data.DataRowView)(cmbEmpresa.Items[i])).Row.ItemArray[2].ToString().Contains(dt.Rows[0]["NRINSC"].ToString()))
                    {
                        cmbEmpresa.SelectedIndex = i;
                    }
                }

                for (int i = 0; i < cmbRecibo.Items.Count; i++)
                {
                    if (((System.Data.DataRowView)(cmbRecibo.Items[i])).Row.ItemArray[2].ToString().Contains(dt.Rows[0]["NR_RECIBO"].ToString()))
                    {
                        cmbRecibo.SelectedIndex = i;
                    }
                }

                dtpPeriodoIni.Text = dt.Rows[0]["perApur"].ToString();
            }
            
        }

        private void dtpPeriodoIni_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpresa.SelectedValue != "")
                {

                    AtualizarGrid();
                }
            }
            catch { }
        }

        private void cmbEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpresa.SelectedValue != "")
                {
                    AtualizarGrid();
                }
            }
            catch { }
        }

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpresa.SelectedValue != "")
                {
                    AtualizarGrid();
                }
            }
            catch { }
        }
        private void AtualizarGrid()
        {
            Utils.CarregaCombo((new EventosDAL().getEventoReciboFechamento(dtpPeriodoIni.Text, cmbEmpresa.SelectedValue.ToString())), cmbRecibo, "NR_RECIBO", "NR_RECIBO");
        }
    }
}
