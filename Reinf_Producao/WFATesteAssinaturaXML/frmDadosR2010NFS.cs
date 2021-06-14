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
    public partial class frmDadosR2010NFS : Form
    {
        public int _idReg;
        public int _idReg2010;
        public int _idReg2010_IdePrestServ;
        private R2010DAL objDLL;
        public bool edicao;
        public frmDadosR2010NFS()
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
                objDLL.atualizaNFS(_idReg,
                                txtSerie.Text,
                                txtnumDocto.Text, 
                                dtpDtEmissaoNF.Value,
                                Convert.ToDecimal(txtvlrBruto.Text),
                                txtObs.Text, _idReg2010_IdePrestServ);

            }
            else
            {
                objDLL.incluirNFS(
                                 txtSerie.Text,
                                txtnumDocto.Text,
                                dtpDtEmissaoNF.Value,
                                Convert.ToDecimal(txtvlrBruto.Text),
                                txtObs.Text, _idReg2010_IdePrestServ);
            }
            objDLL.ajustarValoresTotais(_idReg2010);
            Close();
            
        }

        private void frmDadosR2010NFS_Load(object sender, EventArgs e)
        {
            buttonOk.Visible = edicao;
            button1.Visible = edicao;
            button3.Visible = edicao;

            objDLL = new R2010DAL();
            
            if (_idReg != 0) {

                DataTable dt = objDLL.getDataR2010NFS(_idReg);
                txtSerie.Text = dt.Rows[0]["serie"].ToString();
                txtnumDocto.Text = dt.Rows[0]["numDocto"].ToString();
                dtpDtEmissaoNF.Value = Convert.ToDateTime(dt.Rows[0]["dtEmissaoNF"].ToString());
                txtvlrBruto.Text = dt.Rows[0]["vlrBruto"].ToString();
                txtObs.Text = dt.Rows[0]["obs"].ToString();

                dgvInfoTpServ.DataSource = objDLL.getDataR2010INFOTPSERVByNFS(_idReg);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_idReg2010 > 0)
            {
                if (dgvInfoTpServ.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvInfoTpServ.DataSource;
                    int id = Convert.ToInt32(dt.Rows[dgvInfoTpServ.SelectedRows[0].Index]["idReg"].ToString());
                    frmDadosR2010tpServ f = new frmDadosR2010tpServ();
                    f.edicao = edicao;
                    f._idReg = id;
                    f._idReg2010 = _idReg2010;
                    f.ShowDialog();
              //      dgvInfoTpServ.DataSource = objDLL.getDataR2010INFOTPSERVByNFS(_idReg);
                }
            }
            else
            {
                MessageBox.Show("É obrigatório salvar o registro R2010 para acessar esta opção.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para adicionar é necessário ser realizada no Comply");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*int idReg = Convert.ToInt32(dgvInfoTpServ.Rows[dgvInfoTpServ.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
            DialogResult dialogResult = MessageBox.Show("Deseja excluir o registro selecionado ? ", "Confirmação", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                objDLL.deleteNFSServ(idReg);
                dgvInfoTpServ.DataSource = objDLL.getDataR2010NFSByR2010(_idReg2010);
            }*/

            MessageBox.Show("A Exclusão é necessário ser realizada no Comply");
        }
    }
}




