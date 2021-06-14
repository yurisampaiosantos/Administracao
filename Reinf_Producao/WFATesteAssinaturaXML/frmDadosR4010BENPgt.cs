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
    public partial class frmDadosR4010BENPgt : Form
    {
        public int _idReg;
        public int _idReg4010;
        private R4010DAL objDLL;
        public bool edicao;

        public frmDadosR4010BENPgt()
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
                objDLL.atualizaTpServ(_idReg,
                                cmdTpServico.SelectedValue.ToString(),
                                Convert.ToDecimal(txtvlrBaseRet.Text),
                                Convert.ToDecimal(txtvlrRetencao.Text),
                                Convert.ToDecimal(txtvlrRetSub.Text),
                                Convert.ToDecimal(txtvlrNRetPrinc.Text),
                                Convert.ToDecimal(txtvlrServicos15.Text),
                                Convert.ToDecimal(txtvlrServicos20.Text),
                                Convert.ToDecimal(txtvlrServicos25.Text),
                                Convert.ToDecimal(txtvlrAdicional.Text),
                                Convert.ToDecimal(txtvlrNRetAdic.Text));

            }
            else
            {
                objDLL.incluirTpServ(
                                cmdTpServico.SelectedValue.ToString(),
                                Convert.ToInt32(txtvlrBaseRet.Text),
                                Convert.ToDecimal(txtvlrRetencao.Text),
                                Convert.ToDecimal(txtvlrRetSub.Text),
                                Convert.ToDecimal(txtvlrNRetPrinc.Text),
                                Convert.ToDecimal(txtvlrServicos15.Text),
                                Convert.ToDecimal(txtvlrServicos20.Text),
                                Convert.ToDecimal(txtvlrServicos25.Text),
                                Convert.ToDecimal(txtvlrAdicional.Text),
                                Convert.ToDecimal(txtvlrNRetAdic.Text), _idReg4010);
            }
            // Atualizar a soma dos valores da R4010PrestServ
            objDLL.ajustarValoresTotais(_idReg4010);

            Close();
            
        }

        private void frmDadosR2060tipoCod_Load(object sender, EventArgs e)
        {
            buttonOk.Visible = edicao;

            Utils.CarregaCombo((new TpServicosDAL()).getServicos(), cmdTpServico, "DESCRICAO", "codigo");

            objDLL = new R4010DAL();
            
            if (_idReg != 0) {

                DataTable dt = objDLL.getDataR4010INFOTPSERV(_idReg);

                try
                {
                    cmdTpServico.SelectedValue = dt.Rows[0]["tpServico"].ToString();
                }
                catch { }
                txtvlrBaseRet.Text = dt.Rows[0]["vlrBaseRet"].ToString();
                txtvlrRetencao.Text = dt.Rows[0]["vlrRetencao"].ToString();
                txtvlrRetSub.Text = dt.Rows[0]["vlrRetSub"].ToString();
                txtvlrNRetPrinc.Text = dt.Rows[0]["vlrNRetPrinc"].ToString();                               
                txtvlrServicos15.Text = dt.Rows[0]["vlrServicos15"].ToString();
                txtvlrServicos20.Text = dt.Rows[0]["vlrServicos20"].ToString();
                txtvlrServicos25.Text = dt.Rows[0]["vlrServicos25"].ToString();
                txtvlrAdicional.Text = dt.Rows[0]["vlrAdicional"].ToString();
                txtvlrNRetAdic.Text = dt.Rows[0]["vlrNRetAdic"].ToString();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*
            frmDadosR4010tipoAjuste f = new frmDadosR2060tipoAjuste();
            f.ShowDialog();
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            DataTable dt = (DataTable)dgvTipoAjuste.DataSource;
            int idReg = Convert.ToInt32(dt.Rows[dgvTipoAjuste.SelectedRows[0].Index]["idReg"].ToString());
            frmDadosR2060tipoAjuste f = new frmDadosR2060tipoAjuste();
            f._idReg = idReg;
            f.ShowDialog();
            */

        }
    }
}
