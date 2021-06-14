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
    public partial class frmDadosEstabelecimento : Form
    {
        public int idReg;
        private EstabelecimentoDAL objDLL;
        public frmDadosEstabelecimento()
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
                objDLL.atualiza(idReg, txtNome.Text, txtCNPJ.Text,txtCodigo.Text, Convert.ToInt32(comboBox1.SelectedValue.ToString()));
            }
            else
            {
                objDLL.incluir(txtNome.Text, txtCNPJ.Text, txtCodigo.Text, Convert.ToInt32(comboBox1.SelectedValue.ToString()));
            }
            Close();
        }

        private void frmDadosEmpresa_Load(object sender, EventArgs e)
        {

            objDLL = new EstabelecimentoDAL();
            CarregaComboEmpresa();
            if (idReg != 0) { 
                DataTable dt = objDLL.getEstabelecimento(idReg);
                txtNome.Text = dt.Rows[0]["nome"].ToString();
                txtCNPJ.Text = dt.Rows[0]["cnpj"].ToString();
                txtCodigo.Text = dt.Rows[0]["codigo"].ToString();
                comboBox1.SelectedValue = dt.Rows[0]["EMPRESAS_idReg"].ToString();
            }
        }

        private void CarregaComboEmpresa()
        {
            Utils.CarregaCombo((new EmpresaDAL()).getEmpresas(), comboBox1, "nome", "idReg");

        }
    }
}
