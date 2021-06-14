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
    public partial class frmDadosR2010 : Form
    {
        public int _idReg2010;
        public int _idReg2010_IdePrestServ;
        private R2010DAL objDLL;
        public bool edicao;
        public frmDadosR2010()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_idReg2010 != 0)
            {

                objDLL.atualiza(_idReg2010,
                                Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()),
                                cmbIdentRetif.SelectedIndex + 1,
                                Convert.ToInt32(cmbEstabelecimento.SelectedValue.ToString()),
                                txtNrRecibo.Text,
                                cmbIndObra.SelectedIndex,
                                txtCNPJPrestador.Text,
                                cmbIndCPRB.SelectedIndex);                                
                              
            }
            else
            {
                objDLL.incluir(Convert.ToInt32(cmbEmpresa.SelectedValue.ToString()),
                                cmbIdentRetif.SelectedIndex + 1,
                                dtpPeriodoIni.Text,
                                Convert.ToInt32(cmbEstabelecimento.SelectedValue.ToString()),
                                txtNrRecibo.Text,
                                cmbIndObra.SelectedIndex,
                                txtCNPJPrestador.Text,
                                cmbIndCPRB.SelectedIndex);
            }
            Close();
        }

        private void frmDadosR2010_Load(object sender, EventArgs e)
        {
            buttonOk.Visible = edicao;
            button1.Visible = edicao;
            button3.Visible = edicao;

            dgvNFS.AutoGenerateColumns = false;
            dgvNFS.AllowUserToAddRows = false;
            

            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), cmbEmpresa, "nome", "idReg");
            Utils.CarregaCombo((new EstabelecimentoDAL().getEstabelecimentos()), cmbEstabelecimento, "nome", "idReg");

            objDLL = new R2010DAL();

            if (_idReg2010 != 0)
            {

                DataTable dt = objDLL.getData(_idReg2010);
                int idRegEmpr = (new EmpresaDAL()).getIdEmpresa(dt.Rows[0]["nrInsc"].ToString());
                int idRegEsta = (new EstabelecimentoDAL()).getIdEstabelecimento(dt.Rows[0]["nrInscEstab"].ToString());
                cmbEmpresa.SelectedValue = idRegEmpr;
                cmbEmpresa.Enabled = false;
                cmbEstabelecimento.SelectedValue = idRegEsta;
                cmbEstabelecimento.Enabled = false;


                cmbIndObra.SelectedIndex = Convert.ToInt16(dt.Rows[0]["indObra"].ToString());
                cmbIdentRetif.SelectedIndex = Convert.ToInt16(dt.Rows[0]["indRetif"].ToString())-1;
                dtpPeriodoIni.Text = dt.Rows[0]["perApur"].ToString();
                txtNrRecibo.Text = dt.Rows[0]["NRRECIBO"].ToString();
                dtpPeriodoIni.Enabled = false;


                DataTable dtPrest = objDLL.getDataR2010IdePrestServ(_idReg2010);
                _idReg2010_IdePrestServ = Convert.ToInt16(dtPrest.Rows[0]["idReg"].ToString());
                txtCNPJPrestador.Text = dtPrest.Rows[0]["CNPJPrestador"].ToString();
                txtVlrTotalBruto.Text = dtPrest.Rows[0]["VlrTotalBruto"].ToString();
                txtVlrTotalBaseRet.Text = dtPrest.Rows[0]["VlrTotalBaseRet"].ToString();
                txtVlrTotalRetPrinc.Text = dtPrest.Rows[0]["VlrTotalRetPrinc"].ToString();
                txtVlrTotalRetAdic.Text = dtPrest.Rows[0]["VlrTotalRetAdic"].ToString();
                txtVlrTotalNRetPrinc.Text = dtPrest.Rows[0]["VlrTotalNRetPrinc"].ToString();
                txtVlrTotalNRetAdic.Text = dtPrest.Rows[0]["VlrTotalNRetAdic"].ToString();
                cmbIndCPRB.SelectedIndex = Convert.ToInt16(dtPrest.Rows[0]["indCPRB"].ToString());
                
                dgvNFS.DataSource = objDLL.getDataR2010NFSByR2010(_idReg2010_IdePrestServ);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (_idReg2010 > 0)
            {
                if (dgvNFS.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvNFS.DataSource;
                    int id = Convert.ToInt32(dt.Rows[dgvNFS.SelectedRows[0].Index]["idReg"].ToString());
                    frmDadosR2010NFS f = new frmDadosR2010NFS();
                    f.edicao = edicao;
                    f._idReg = id;
                    f._idReg2010 = _idReg2010;
                    f._idReg2010_IdePrestServ = _idReg2010_IdePrestServ;
                    f.ShowDialog();
                    dgvNFS.DataSource = objDLL.getDataR2010NFSByR2010(_idReg2010_IdePrestServ);
                }
            }
            else
            {
                MessageBox.Show("É obrigatório salvar o registro R2010 para acessar esta opção.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (_idReg2010 > 0)
            {
                frmDadosR2010NFS f = new frmDadosR2010NFS();
                f._idReg2010 = _idReg2010;
                f._idReg2010_IdePrestServ = _idReg2010_IdePrestServ;
                f.ShowDialog();
                dgvNFS.DataSource = objDLL.getDataR2010NFSByR2010(_idReg2010_IdePrestServ);
            }
            else
            {
                MessageBox.Show("É obrigatório salvar o registro R2010 para acessar esta opção.");
            }*/
            MessageBox.Show("Para adicionar é necessário ser realizada no Comply");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*int idReg = Convert.ToInt32(dgvNFS.Rows[dgvNFS.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
            DialogResult dialogResult = MessageBox.Show("Deseja excluir o registro selecionado ? ", "Confirmação", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                objDLL.deleteNFS(idReg);
                dgvNFS.DataSource = objDLL.getDataR2010NFSByR2010(_idReg2010);
            }*/

            MessageBox.Show("A Exclusão é necessário ser realizada no Comply");
        }

        private void dgvTipoCod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
