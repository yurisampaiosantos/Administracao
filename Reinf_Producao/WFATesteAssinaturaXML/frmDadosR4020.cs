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
    public partial class frmDadosR4020 : Form
    {
        public int _idReg4020;
        public int _idReg4020_IdePrestServ;
        private R4020DAL objDLL;
        public bool edicao;
        public frmDadosR4020()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_idReg4020 != 0)
            {

                objDLL.atualiza(_idReg4020,
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

        private void frmDadosR4020_Load(object sender, EventArgs e)
        {
            buttonOk.Visible = edicao;
            button1.Visible = edicao;
            button3.Visible = edicao;

            dgvNFS.AutoGenerateColumns = false;
            dgvNFS.AllowUserToAddRows = false;
            

            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), cmbEmpresa, "nome", "idReg");
            Utils.CarregaCombo((new EstabelecimentoDAL().getEstabelecimentos()), cmbEstabelecimento, "nome", "idReg");

            objDLL = new R4020DAL();

            if (_idReg4020 != 0)
            {

                DataTable dt = objDLL.getData(_idReg4020);
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


                DataTable dtPrest = objDLL.getDataR4020IdePrestServ(_idReg4020);
                _idReg4020_IdePrestServ = Convert.ToInt16(dtPrest.Rows[0]["idReg"].ToString());
                txtCNPJPrestador.Text = dtPrest.Rows[0]["CNPJPrestador"].ToString();
                txtVlrTotalBruto.Text = dtPrest.Rows[0]["VlrTotalBruto"].ToString();
                txtVlrTotalBaseRet.Text = dtPrest.Rows[0]["VlrTotalBaseRet"].ToString();
                txtVlrTotalRetPrinc.Text = dtPrest.Rows[0]["VlrTotalRetPrinc"].ToString();
                txtVlrTotalRetAdic.Text = dtPrest.Rows[0]["VlrTotalRetAdic"].ToString();
                txtVlrTotalNRetPrinc.Text = dtPrest.Rows[0]["VlrTotalNRetPrinc"].ToString();
                txtVlrTotalNRetAdic.Text = dtPrest.Rows[0]["VlrTotalNRetAdic"].ToString();
                cmbIndCPRB.SelectedIndex = Convert.ToInt16(dtPrest.Rows[0]["indCPRB"].ToString());
                
                dgvNFS.DataSource = objDLL.getDataR4020NFSByR4020(_idReg4020_IdePrestServ);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (_idReg4020 > 0)
            {
                if (dgvNFS.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvNFS.DataSource;
                    int id = Convert.ToInt32(dt.Rows[dgvNFS.SelectedRows[0].Index]["idReg"].ToString());
                    frmDadosR4020Pgt f = new frmDadosR4020Pgt();
                    f.edicao = edicao;
                    f._idReg = id;
                    f._idReg4020 = _idReg4020;
                    f._idReg4020_IdePrestServ = _idReg4020_IdePrestServ;
                    f.ShowDialog();
                    dgvNFS.DataSource = objDLL.getDataR4020NFSByR4020(_idReg4020_IdePrestServ);
                }
            }
            else
            {
                MessageBox.Show("É obrigatório salvar o registro R4020 para acessar esta opção.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (_idReg4020 > 0)
            {
                frmDadosR4020NFS f = new frmDadosR4020NFS();
                f._idReg4020 = _idReg4020;
                f._idReg4020_IdePrestServ = _idReg4020_IdePrestServ;
                f.ShowDialog();
                dgvNFS.DataSource = objDLL.getDataR4020NFSByR4020(_idReg4020_IdePrestServ);
            }
            else
            {
                MessageBox.Show("É obrigatório salvar o registro R4020 para acessar esta opção.");
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
                dgvNFS.DataSource = objDLL.getDataR4020NFSByR4020(_idReg4020);
            }*/

            MessageBox.Show("A Exclusão é necessário ser realizada no Comply");
        }

        private void dgvTipoCod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
