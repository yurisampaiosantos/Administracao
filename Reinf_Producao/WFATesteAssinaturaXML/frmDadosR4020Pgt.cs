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
    public partial class frmDadosR4020Pgt : Form
    {
        public int _idReg;
        public int _idReg4020;
        public int _idReg4020_IdePrestServ;
        private R4020DAL objDLL;
        public bool edicao;
        public frmDadosR4020Pgt()
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
                                txtObs.Text, _idReg4020_IdePrestServ);

            }
            else
            {
                objDLL.incluirNFS(
                                 txtSerie.Text,
                                txtnumDocto.Text,
                                dtpDtEmissaoNF.Value,
                                Convert.ToDecimal(txtvlrBruto.Text),
                                txtObs.Text, _idReg4020_IdePrestServ);
            }
            objDLL.ajustarValoresTotais(_idReg4020);
            Close();
            
        }

        private void frmDadosR4020Pgt_Load(object sender, EventArgs e)
        {
            buttonOk.Visible = edicao;
            button1.Visible = edicao;
            button3.Visible = edicao;

            objDLL = new R4020DAL();
            
            if (_idReg != 0) {

                DataTable dt = objDLL.getDataR4020NFS(_idReg);
                txtSerie.Text = dt.Rows[0]["serie"].ToString();
                txtnumDocto.Text = dt.Rows[0]["numDocto"].ToString();
                dtpDtEmissaoNF.Value = Convert.ToDateTime(dt.Rows[0]["dtEmissaoNF"].ToString());
                txtvlrBruto.Text = dt.Rows[0]["vlrBruto"].ToString();
                txtObs.Text = dt.Rows[0]["obs"].ToString();

                dgvInfoTpServ.DataSource = objDLL.getDataR4020INFOTPSERVByNFS(_idReg);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_idReg4020 > 0)
            {
                if (dgvInfoTpServ.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvInfoTpServ.DataSource;
                    int id = Convert.ToInt32(dt.Rows[dgvInfoTpServ.SelectedRows[0].Index]["idReg"].ToString());
                    frmDadosR4020PgtInfo f = new frmDadosR4020PgtInfo();
                    f.edicao = edicao;
                    f._idReg = id;
                    f._idReg4020 = _idReg4020;
                    f.ShowDialog();
              //      dgvInfoTpServ.DataSource = objDLL.getDataR4020INFOTPSERVByNFS(_idReg);
                }
            }
            else
            {
                MessageBox.Show("É obrigatório salvar o registro R4020 para acessar esta opção.");
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
                dgvInfoTpServ.DataSource = objDLL.getDataR4020NFSByR4020(_idReg4020);
            }*/

            MessageBox.Show("A Exclusão é necessário ser realizada no Comply");
        }
    }
}




