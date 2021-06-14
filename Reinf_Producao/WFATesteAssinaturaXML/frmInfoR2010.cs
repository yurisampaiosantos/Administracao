using RefinDBClassLibrary;
using ReinfDBClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WFATesteAssinaturaXML
{
    public partial class frmInfoR2010 : Form
    {
        private R2010DAL objEvento;

        public frmInfoR2010()
        {
            InitializeComponent();
            objEvento = new R2010DAL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idReg = dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString();
            XmlDocument xmlDoc = new XmlDocument();
            R2010DAL ojbEvento = new R2010DAL();
            xmlDoc = ojbEvento.getXMLEvt(int.Parse(idReg));
            xmlDoc.Save(System.Environment.GetEnvironmentVariable("TEMP") + @"\" + this.GetType().ToString() + ".xml");

            frmWebBrowser f = new frmWebBrowser();
            f.Navigate(System.Environment.GetEnvironmentVariable("TEMP") + @"\" + this.GetType().ToString() + ".xml");
            f.ShowDialog();
        }

        private void frmInfoR2010_Load(object sender, EventArgs e)
        {
            dgvEventos.AutoGenerateColumns = false;
            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), comboBoxMatriz, "nome", "idReg");
            Utils.CarregaCombo((new EstabelecimentoDAL().getEstabelecimentosDaEmpresa(Convert.ToInt32(comboBoxMatriz.SelectedValue))), cmbEstabelecimento, "nome", "idReg");
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "yyyy-MM";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //odb.preencherR2010();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {
                MessageBox.Show("Evento já transmitido, não pode ser reenviado.");
            }
            else
            {
                int idReg = Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
                //   Assinatura.assinarEnviarXML(idReg, objEvento.getXMLEvt(idReg), "evtServTom");
                Assinatura.assinarEnviarLoteXML(idReg, objEvento.getXMLEvtLote(idReg), "evtServTom");
                AtualizaGrid();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEventos.SelectedRows.Count > 0)
            {
               /* int idReg = Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
                if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
                {
                    MessageBox.Show("Evento já transmitido, não pode ser modificado.");
                }
                else
                {*/
                    DataTable dt = (DataTable)dgvEventos.DataSource;
                    frmDadosR2010 f = new frmDadosR2010();
                    if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
                    {
                        f.edicao = false;
                    }
                    else
                    {
                        f.edicao = true;
                    }
                    f._idReg2010 = Convert.ToInt32(dt.Rows[dgvEventos.SelectedRows[0].Index]["idReg"].ToString());
                    f.ShowDialog();
               // }
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvEventos.DataSource;
            int idReg = Convert.ToInt32(dt.Rows[dgvEventos.SelectedRows[0].Index]["idReg"].ToString());

            string cnpj = dt.Rows[dgvEventos.SelectedRows[0].Index]["NRINSC"].ToString();
            string nrRecibo = dt.Rows[dgvEventos.SelectedRows[0].Index]["NR_RECIBO"].ToString();
            string perApur = dt.Rows[dgvEventos.SelectedRows[0].Index]["perApur"].ToString();

            if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {
                DialogResult dialogResult = MessageBox.Show("Evento já transmitido, não pode ser excluído. Deseja gerar um evento de exclusão para este registro? ", "Confirmação", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ReinfOraDB eventTeste = new ReinfOraDB();
                    if (eventTeste.verificaExclusaoEvento(nrRecibo))
                    {
                        objEvento.gerarEventoExclusao(cnpj, nrRecibo, perApur);
                        MessageBox.Show("Envento de exclusão gerado. Verificar os eventos tipo R-9000 para envio.");
                    }
                    else
                    {
                        MessageBox.Show("Envento de exclusão ja foi gerado. Verificar o evento tipo R-9000.");
                    }
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Deseja excluir o registro selecionado ? ", "Confirmação", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    objEvento.delete(idReg);
                    AtualizaGrid();
                }
            }

        }

        private void importarXLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog vAbreArq = new OpenFileDialog();
            vAbreArq.Filter = "Excel 97-2003 WorkBook|*.xls|Excel WorkBook|*.xlsx|All Excel Files|*.xls;*.xlsx|All Files|*.*";
            vAbreArq.Title = "Selecione o Arquivo";
            if (vAbreArq.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet();
                OleDbConnection conexao = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + vAbreArq.FileName + ";" +
                "Extended Properties=Excel 8.0;");
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From [R2010$]", conexao);
                da.Fill(ds);
                dgvEventos.DataSource = ds.Tables[0];
                dgvEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
                conexao.Close();

                objEvento.carregaR2010Temp(ds);
                objEvento.preencherR2010();
                AtualizaGrid();                
            }

        }

        private void comboBoxMatriz_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Utils.CarregaCombo((new EstabelecimentoDAL().getEstabelecimentosDaEmpresa(Convert.ToInt32(comboBoxMatriz.SelectedValue))), cmbEstabelecimento, "nome", "idReg");
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            DataTable dtEmp = (new EmpresaDAL()).getEmpresa(Convert.ToInt32(comboBoxMatriz.SelectedValue.ToString()));
            try
            {
                DataTable dtEstab = (new EstabelecimentoDAL()).getEstabelecimento(Convert.ToInt32(cmbEstabelecimento.SelectedValue.ToString()));
                dgvEventos.DataSource = objEvento.getData(dtEmp.Rows[0]["cnpj"].ToString().Substring(0, 8), dtEstab.Rows[0]["cnpj"].ToString(), dtpPeriodo.Text);
            }
            catch
            { dgvEventos.DataSource = null; }

        }

        private void cmbEstabelecimento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void dtpPeriodo_ValueChanged(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void importarComplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNovoR2010 f = new frmNovoR2010();
            f.ShowDialog();
            AtualizaGrid();
        }

        private void dgvEventos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvEventos.Columns[e.ColumnIndex].Name == "STATUS")
            {
                if (e.Value != null)
                {
                    // Check for the string "pink" in the cell.
                    if (e.Value != System.DBNull.Value)
                    {
                        string stringValue = (string)e.Value;
                        if ((stringValue == "E"))
                        {
                            //e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                            dgvEventos.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[0];
                        }
                        else if ((stringValue == "P"))
                        {
                            //e.CellStyle.BackColor = System.Drawing.Color.Red;
                            dgvEventos.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[1];
                        }

                    }

                }
            }
        }
    }
}
