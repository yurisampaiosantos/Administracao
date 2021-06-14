using RefinDBClassLibrary;
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
    public partial class frmDadosEmpresa : Form
    {
        public int idReg;
        private EmpresaDAL objDLL;
        public frmDadosEmpresa()
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
                objDLL.atualiza(idReg, txtNome.Text, txtCNPJ.Text, txtCodigo.Text, Convert.ToInt32(cmbResponsavel.SelectedValue.ToString()));
            }
            else
            {
                objDLL.incluir(txtNome.Text, txtCNPJ.Text, txtCodigo.Text, Convert.ToInt32(cmbResponsavel.SelectedValue.ToString()));
            }
            Close();
        }

        private void frmDadosEmpresa_Load(object sender, EventArgs e)
        {
            Utils.CarregaCombo((new ResponsavelDAL()).getReponsaveis(), cmbResponsavel, "nmResp", "idReg");
            objDLL = new EmpresaDAL();
            if (idReg != 0) { 
                DataTable dt = objDLL.getEmpresa(idReg);
                txtNome.Text = dt.Rows[0]["nome"].ToString();
                txtCNPJ.Text = dt.Rows[0]["cnpj"].ToString();
                txtCodigo.Text = dt.Rows[0]["codigo"].ToString();
                if (dt.Rows[0]["RESPONSAVEIS_idReg"].ToString() != "")
                {
                    cmbResponsavel.SelectedValue = dt.Rows[0]["RESPONSAVEIS_idReg"].ToString();
                }
            }
        }
    }
}
