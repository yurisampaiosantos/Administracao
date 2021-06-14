using RefinDBClassLibrary;
using ReinfDBClassLibrary;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml;

namespace WFATesteAssinaturaXML
{
    public partial class frmInfoR2060 : Form
    {
        private R2060DAL objEvento;

        public frmInfoR2060()
        {
            InitializeComponent();
        }

        private void frmInfoR2060_Load(object sender, EventArgs e)
        {
            dgvEventos.AutoGenerateColumns = false;
            objEvento = new R2060DAL();
            //dgvEventos.DataSource = objEvento.getData();
            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), comboBoxMatriz, "nome", "idReg");
            Utils.CarregaCombo((new EstabelecimentoDAL().getEstabelecimentosDaEmpresa(Convert.ToInt32(comboBoxMatriz.SelectedValue))), cmbEstabelecimento, "nome", "idReg");
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "yyyy-MM";
        }

        private void buttonGerarXML_Click(object sender, EventArgs e)
        {
            string idReg = dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc = objEvento.getXMLEvt(int.Parse(idReg));
            using (XmlTextWriter xmlWriter = new XmlTextWriter(System.Environment.GetEnvironmentVariable("TEMP") + @"\" + this.GetType().ToString() + ".xml", null))
            {
                xmlWriter.Formatting = Formatting.None;
                xmlDoc.Save(xmlWriter);
            }
            frmWebBrowser f = new frmWebBrowser();
            f.Navigate(System.Environment.GetEnvironmentVariable("TEMP") + @"\" + this.GetType().ToString() + ".xml");
            f.ShowDialog();
        }

        private void btExcluirEvento_Click(object sender, EventArgs e)
        {
            R2060DAL r = new R2060DAL();
            AtualizaGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {
                MessageBox.Show("Evento já transmitido, não pode ser reenviado.");
            }
            else
            {
                int idReg = Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
                Assinatura.assinarEnviarXML(idReg, objEvento.getXMLEvt(idReg), "evtCPRB");
                AtualizaGrid();
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
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From [R2060$]", conexao);
                da.Fill(ds);
                dgvEventos.DataSource = ds.Tables[0];
                dgvEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
                conexao.Close();

                objEvento.carregaR2060Temp(ds);
                objEvento.preencherR2060();
                AtualizaGrid();
            }
        }

        private void importarComplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNovoR2060 f = new frmNovoR2060();            
            f.ShowDialog();
            AtualizaGrid();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEventos.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgvEventos.DataSource;
                frmDadosR2060 f = new frmDadosR2060();
                if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
                {
                    f.edicao = false;
                }
                else
                {
                    f.edicao = true;
                }
                f._idReg2060 = Convert.ToInt32(dt.Rows[dgvEventos.SelectedRows[0].Index]["idReg"].ToString()); 
                f.ShowDialog();
            }
        }

        private void comboBoxMatriz_SelectedIndexChanged(object sender, EventArgs e)
        {


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
                dgvEventos.DataSource = objEvento.getData(dtEmp.Rows[0]["cnpj"].ToString().ToString().Substring(0, 8), dtEstab.Rows[0]["cnpj"].ToString(), dtpPeriodo.Text);
            }
            catch { dgvEventos.DataSource = null; }

        }

        private void cmbEstabelecimento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void dtpPeriodo_ValueChanged(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void manualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDadosR2060 f = new frmDadosR2060();
            f.edicao = true;
            f._idReg2060 = 0;
            f.ShowDialog();
            AtualizaGrid();
        }
    }
}


