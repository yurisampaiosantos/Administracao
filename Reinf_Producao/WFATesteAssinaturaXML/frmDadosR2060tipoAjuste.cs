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
    public partial class frmDadosR2060tipoAjuste : Form
    {
        public int _idReg;
        public int _idRegTipoCod;
        private R2060DAL objDLL;
        public bool edicao;
        public frmDadosR2060tipoAjuste()
        {
            InitializeComponent();            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_idReg != 0)
            {
                objDLL.atualizaTipoAjuste(_idReg, 
                                Convert.ToInt32(cmbTpAjuste.SelectedIndex),
                                Convert.ToInt32(cmbCodAjuste.SelectedIndex + 1),
                                Convert.ToDecimal(txtVlrAjuste.Text),
                                txtDescAjuste.Text,
                                dtpPeriodo.Text);                              
            }
            else
            {
                objDLL.incluirTipoAjuste(
                                Convert.ToInt32(cmbTpAjuste.SelectedIndex),
                                Convert.ToInt32(cmbCodAjuste.SelectedIndex + 1),
                                Convert.ToDecimal(txtVlrAjuste.Text),
                                txtDescAjuste.Text,
                                dtpPeriodo.Text, _idRegTipoCod);
            }
            Close();
        }

        private void frmDadosR2060tipoAjuste_Load(object sender, EventArgs e)
        {
            if (_idRegTipoCod != null)
            {
                edicao = true;
            }
            buttonOk.Visible = edicao;

            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "yyyy-MM";

            objDLL = new R2060DAL();
            
            if (_idReg != 0) {

                DataTable dt = objDLL.getDataR2060_TipoAjuste(_idReg);

                cmbTpAjuste.SelectedIndex = Convert.ToInt16(dt.Rows[0]["tpAjuste"].ToString());
                cmbCodAjuste.SelectedIndex = Convert.ToInt16(dt.Rows[0]["codAjuste"].ToString())-1;
                txtVlrAjuste.Text = dt.Rows[0]["VLRAJUSTE"].ToString();
                txtDescAjuste.Text = dt.Rows[0]["DESCAJUSTE"].ToString();
                dtpPeriodo.Text = dt.Rows[0]["DTAJUSTE"].ToString();
            }
            
        }

    }
}
