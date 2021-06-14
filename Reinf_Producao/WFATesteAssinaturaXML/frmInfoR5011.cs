using RefinDBClassLibrary;
using ReinfDBClassLibrary;
using reinfPreWSDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WFATesteAssinaturaXML
{
    public partial class frmInfoR5011 : Form
    {
        private R5011DAL objEvento;
        public frmInfoR5011()
        {
            InitializeComponent();
        }

        private void frmInfoR2098_Load(object sender, EventArgs e)
        {
            dgvEventos.AutoGenerateColumns = false;
            objEvento = new R5011DAL();
           // dgvEventos.DataSource = objEvento.getData();
            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), comboBoxMatriz, "nome", "idReg");
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "yyyy-MM";
            AtualizaGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {
                MessageBox.Show("Evento já transmitido, não pode ser reenviado.");
            }
            else
            {
                int idReg = Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["ID"].Value.ToString());
                byte tpinsc = Convert.ToByte(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["TPINSC"].Value.ToString());
                string nrinsc = dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["NRINSC"].Value.ToString();
                string nrrecibo = dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["NRPROTENTR"].Value.ToString();
                Assinatura.ConsultaInformacoesConsolidadasReinf(idReg, tpinsc, nrinsc.Substring(0, 8), nrrecibo);
                AtualizaGrid();
            }
        }


        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDadosR5011 f = new frmDadosR5011();
            f.ShowDialog();
            AtualizaGrid();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {
                MessageBox.Show("Evento já transmitido, não pode ser excluído.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Deseja excluir o registro selecionado ? ", "Confirmação", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    objEvento.delete(Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["ID"].Value.ToString()));
                    AtualizaGrid();
                    //dgvEventos.DataSource = objEvento.getData();
                }
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        private void AtualizaGrid()
        {
            DataTable dtEmp = (new EmpresaDAL()).getEmpresa(Convert.ToInt32(comboBoxMatriz.SelectedValue.ToString()));
            dgvEventos.DataSource = objEvento.getData(dtEmp.Rows[0]["cnpj"].ToString(), dtpPeriodo.Text);
        }

        private void dtpPeriodo_ValueChanged(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void comboBoxMatriz_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

    }
}


