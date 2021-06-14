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
    public partial class frmDadosR2060tipoCod : Form
    {
        public int _idReg;
        public int _idReg2060;
        private R2060DAL objDLL;
        public bool edicao;

        public frmDadosR2060tipoCod()
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
                objDLL.atualizaTipoCod(_idReg,
                                Convert.ToInt32(txtCodAtivEcon.Text),
                                Convert.ToDecimal(txtVlrRecBrutaAtiv.Text),
                                Convert.ToDecimal(txtVlrExcRecBruta.Text),
                                Convert.ToDecimal(txtVlrAdicRecBruta.Text),
                                Convert.ToDecimal(txtVlrBcCPRB.Text),
                                Convert.ToDecimal(txtVlrCPRBapur.Text));

            }
            else
            {
                objDLL.incluirTipoCod(
                                Convert.ToInt32(txtCodAtivEcon.Text),
                                Convert.ToDecimal(txtVlrRecBrutaAtiv.Text),
                                Convert.ToDecimal(txtVlrExcRecBruta.Text),
                                Convert.ToDecimal(txtVlrAdicRecBruta.Text),
                                Convert.ToDecimal(txtVlrBcCPRB.Text),
                                Convert.ToDecimal(txtVlrCPRBapur.Text),_idReg2060);
            }
            Close();
        }

        private void frmDadosR2060tipoCod_Load(object sender, EventArgs e)
        {
            if (_idReg2060 != null)
            {
                edicao = true;
            }
            button1.Visible = edicao;
            button3.Visible = edicao;
            dgvTipoAjuste.AutoGenerateColumns = false;
            dgvTipoAjuste.AllowUserToAddRows = false;
            
            objDLL = new R2060DAL();
            
            if (_idReg != 0) {

                DataTable dt = objDLL.getDataR2060_TipoCod(_idReg);

                txtCodAtivEcon.Text = dt.Rows[0]["codAtivEcon"].ToString();
                txtVlrRecBrutaAtiv.Text = dt.Rows[0]["vlrRecBrutaAtiv"].ToString();
                txtVlrExcRecBruta.Text = dt.Rows[0]["vlrExcRecBruta"].ToString();
                txtVlrAdicRecBruta.Text = dt.Rows[0]["vlrAdicRecBruta"].ToString();                               
                txtVlrBcCPRB.Text = dt.Rows[0]["VlrBcCPRB"].ToString();
                txtVlrCPRBapur.Text = dt.Rows[0]["VlrCPRBapur"].ToString();               

                dgvTipoAjuste.DataSource = objDLL.getDataR2060_TipoAjustes(_idReg);
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            frmDadosR2060tipoAjuste f = new frmDadosR2060tipoAjuste();
            f._idRegTipoCod = _idReg;
            f.ShowDialog();
            dgvTipoAjuste.DataSource = objDLL.getDataR2060_TipoAjustes(_idReg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvTipoAjuste.DataSource;
                int idReg = Convert.ToInt32(dt.Rows[dgvTipoAjuste.SelectedRows[0].Index]["idReg"].ToString());
                frmDadosR2060tipoAjuste f = new frmDadosR2060tipoAjuste();
                f.edicao = edicao;
                f._idReg = idReg;
                f.ShowDialog();
                dgvTipoAjuste.DataSource = objDLL.getDataR2060_TipoAjustes(_idReg);
            }
            catch { }

        }
    }
}
