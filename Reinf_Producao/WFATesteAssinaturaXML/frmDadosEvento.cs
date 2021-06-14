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
    public partial class frmDadosEvento : Form
    {
        public int idReg;
        private EventosDAL eDLL;
        public frmDadosEvento()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string ativo = "";
            if (chkAtivo.Checked)
            {
                ativo = "S";
            }
            else
            {
                ativo = "N";

            }

            if (idReg != 0)
            {
                eDLL.atualiza(idReg, txtNome.Text, txtCodigo.Text, txtTag.Text, ativo);
            }
            else
            {
                eDLL.incluir(txtNome.Text, txtCodigo.Text, txtTag.Text, ativo);
            }
            Close();
        }

        private void frmDadosEmpresa_Load(object sender, EventArgs e)
        {
            eDLL = new EventosDAL();
            if (idReg != 0) { 
                DataTable dt = eDLL.getEvento(idReg);
                txtNome.Text = dt.Rows[0]["nome"].ToString();
                txtCodigo.Text = dt.Rows[0]["codigo"].ToString();
                txtTag.Text = dt.Rows[0]["tagevento"].ToString();
                if (dt.Rows[0]["ativo"].ToString() == "S")
                {
                    chkAtivo.Checked = true;
                }
            }
        }
    }
}
