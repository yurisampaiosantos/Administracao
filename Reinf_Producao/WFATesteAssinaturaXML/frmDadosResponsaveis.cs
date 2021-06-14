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
    public partial class frmDadosResponsaveis : Form
    {
        public int idReg;
        private ResponsavelDAL obj;
        public frmDadosResponsaveis()
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
                obj.atualiza(idReg, txtNome.Text, txtCPF.Text, txtTelefone.Text, txtCelular.Text, txtEmail.Text);
            }
            else
            {
                obj.incluir(txtNome.Text, txtCPF.Text, txtTelefone.Text, txtCelular.Text, txtEmail.Text);
            }
            Close();
        }

        private void frmDadosResponsaveis_Load(object sender, EventArgs e)
        {
            obj = new ResponsavelDAL();
            if (idReg != 0) { 
                DataTable dt = obj.getReponsavel(idReg);
                txtNome.Text = dt.Rows[0]["nmResp"].ToString();
                txtCelular.Text = dt.Rows[0]["foneCel"].ToString();
                txtTelefone.Text = dt.Rows[0]["foneFixo"].ToString();
                txtCPF.Text = dt.Rows[0]["cpfResp"].ToString();
                txtEmail.Text = dt.Rows[0]["email"].ToString();
            }
        }
    }
}
