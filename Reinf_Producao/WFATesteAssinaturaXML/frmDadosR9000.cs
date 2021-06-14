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
    public partial class frmDadosR9000 : Form
    {
        public int idReg;
        private R9000DAL objDLL;
        public frmDadosR9000()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(cmbEmpresa.SelectedValue.ToString()).Rows[0]["cnpj"].ToString();

            if (idReg != 0)
            {

                objDLL.atualiza(idReg, cnpj , cmbEvento.SelectedValue.ToString(), cmbRecibo.SelectedValue.ToString(),
                              dtpPeriodoIni.Text);
            }
            else
            {
                objDLL.incluir(cnpj, cmbEvento.SelectedValue.ToString(), cmbRecibo.SelectedValue.ToString(),
                              dtpPeriodoIni.Text);
            }
            Close();
        }

        private void frmDadosR2098_Load(object sender, EventArgs e)
        {
            dtpPeriodoIni.Format = DateTimePickerFormat.Custom;
            dtpPeriodoIni.CustomFormat = "yyyy-MM";

            Utils.CarregaCombo((new EventosDAL().getEventosExclusao()), cmbEvento, "nome", "codigo");
            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), cmbEmpresa, "nome", "idReg");

            
            objDLL = new R9000DAL();
            
            if (idReg != 0) { 
                DataTable dt = objDLL.getData(idReg);

                for (int i = 0; i < cmbEmpresa.Items.Count; i++)
                {
                    if (((System.Data.DataRowView)(cmbEmpresa.Items[i])).Row.ItemArray[2].ToString().Contains(dt.Rows[0]["NRINSC"].ToString()))
                    {
                        cmbEmpresa.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < cmbEvento.Items.Count; i++)
                {
                    if (((System.Data.DataRowView)(cmbEvento.Items[i])).Row.ItemArray[2].ToString().Contains(dt.Rows[0]["CODIGO"].ToString()))
                    {
                        cmbEvento.SelectedIndex = i;
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
                if (cmbEvento.SelectedValue != "")
                {
                    Utils.CarregaCombo((new EventosDAL().getEventoRecibo(cmbEvento.SelectedValue.ToString(), dtpPeriodoIni.Text, cmbEmpresa.SelectedValue.ToString())), cmbRecibo, "NR_RECIBO", "NR_RECIBO");
                }
            }
            catch { }
        }

        private void cmbEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEvento.SelectedValue != "")
                {
                    Utils.CarregaCombo((new EventosDAL().getEventoRecibo(cmbEvento.SelectedValue.ToString(), dtpPeriodoIni.Text, cmbEmpresa.SelectedValue.ToString())), cmbRecibo, "NR_RECIBO", "NR_RECIBO");
                }
            }
            catch { }
        }

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEvento.SelectedValue != "")
                {
                    Utils.CarregaCombo((new EventosDAL().getEventoRecibo(cmbEvento.SelectedValue.ToString(), dtpPeriodoIni.Text, cmbEmpresa.SelectedValue.ToString())), cmbRecibo, "NR_RECIBO", "NR_RECIBO");
                }
            }
            catch { }
        }
    }
}
