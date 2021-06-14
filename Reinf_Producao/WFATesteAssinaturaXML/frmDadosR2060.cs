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
    public partial class frmDadosR2060 : Form
    {
        public int _idReg2060;
        private R2060DAL objDLL;
        public bool edicao;
        public frmDadosR2060()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_idReg2060 != 0)
            {
                objDLL.atualiza(_idReg2060,
                                Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()),
                                (cmbIdentRetif.SelectedIndex + 1).ToString(),
                                dtpPeriodoIni.Text,
                                txtNrRecibo.Text,
                                Convert.ToInt32(cmbEstabelecimento.SelectedValue.ToString()),
                                Convert.ToDecimal(txtVlrRecBrutaTotal.Text),
                                Convert.ToDecimal(txtVlrCPApurTotal.Text),
                                Convert.ToDecimal(txtCPRBSuspTotal.Text));
                              
            }
            else
            {
                objDLL.incluir( Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()),                                
                                (cmbIdentRetif.SelectedIndex + 1).ToString(),
                                dtpPeriodoIni.Text,  
                                txtNrRecibo.Text,
                                Convert.ToInt32(cmbEstabelecimento.SelectedValue.ToString()),
                                Convert.ToDecimal(txtVlrRecBrutaTotal.Text),
                                Convert.ToDecimal(txtVlrCPApurTotal.Text),
                                Convert.ToDecimal(txtCPRBSuspTotal.Text));
            }
            Close();
        }

        private void frmDadosR2060_Load(object sender, EventArgs e)
        {
            if (_idReg2060 == null)
            {
                edicao = true;
            }
            buttonOk.Visible = edicao;
            button1.Visible = edicao;
            button3.Visible = edicao;

            dgvTipoCod.AutoGenerateColumns = false;
            dgvTipoCod.AllowUserToAddRows = false;
            dtpPeriodoIni.Format = DateTimePickerFormat.Custom;
            dtpPeriodoIni.CustomFormat = "yyyy-MM";

            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), cmbEmpresa, "nome", "idReg");
            Utils.CarregaCombo((new EstabelecimentoDAL().getEstabelecimentos()), cmbEstabelecimento, "nome", "idReg");

            objDLL = new R2060DAL();

            if (_idReg2060 != 0)
            {
                DataTable dt = objDLL.getData(_idReg2060);
                int idRegEmpr = (new EmpresaDAL()).getIdEmpresa(dt.Rows[0]["nrInsc"].ToString());
                int idRegEsta = (new EstabelecimentoDAL()).getIdEstabelecimento(dt.Rows[0]["nrInscEstab"].ToString());
                cmbEmpresa.SelectedValue = idRegEmpr;
                cmbEstabelecimento.SelectedValue = idRegEsta;
                dtpPeriodoIni.Text = dt.Rows[0]["perApur"].ToString();
                txtNrRecibo.Text = dt.Rows[0]["NRRECIBO"].ToString();
                txtCPRBSuspTotal.Text = dt.Rows[0]["vlrCPRBSuspTotal"].ToString();
                txtVlrCPApurTotal.Text = dt.Rows[0]["VlrCPApurTotal"].ToString();
                txtVlrRecBrutaTotal.Text = dt.Rows[0]["VlrRecBrutaTotal"].ToString();
                cmbIdentRetif.SelectedIndex = Convert.ToInt16(dt.Rows[0]["indRetif"].ToString())-1;

                dgvTipoCod.DataSource = objDLL.getDataR2060_TipoCods(_idReg2060);
            }
            else
            {
                panel3.Visible = false;
                dgvTipoCod.Visible = false;
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (_idReg2060 > 0)
            {
                if (dgvTipoCod.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvTipoCod.DataSource;
                    int id = Convert.ToInt32(dt.Rows[dgvTipoCod.SelectedRows[0].Index]["idReg"].ToString());
                    frmDadosR2060tipoCod f = new frmDadosR2060tipoCod();
                    f._idReg = id;
                    f._idReg2060 = _idReg2060;
                    f.ShowDialog();
                    dgvTipoCod.DataSource = objDLL.getDataR2060_TipoCods(_idReg2060);
                }
            }
            else
            {
                MessageBox.Show("É obrigatório salvar o registro R2060 para acessar esta opção.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_idReg2060 > 0)
            {
                frmDadosR2060tipoCod f = new frmDadosR2060tipoCod();
                f._idReg2060 = _idReg2060;
                f.ShowDialog();
                dgvTipoCod.DataSource = objDLL.getDataR2060_TipoCods(_idReg2060);
            }
            else
            {
                MessageBox.Show("É obrigatório salvar o registro R2060 para acessar esta opção.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idReg = Convert.ToInt32(dgvTipoCod.Rows[dgvTipoCod.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
            DialogResult dialogResult = MessageBox.Show("Deseja excluir o registro selecionado ? ", "Confirmação", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //objEvento.delete(idReg);
                dgvTipoCod.DataSource = objDLL.getDataR2060_TipoCods(_idReg2060);
            }

        }
    }
}
