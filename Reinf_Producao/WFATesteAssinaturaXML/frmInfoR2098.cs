using envioLoteEventos;
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
    public partial class frmInfoR2098 : Form
    {

        private R2098DAL objEvento;
        public frmInfoR2098()
        {
            InitializeComponent();
        }

        private void frmInfoR2098_Load(object sender, EventArgs e)
        {
            objEvento = new R2098DAL();
            dgvEventos.DataSource = objEvento.getData();
            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), comboBoxMatriz, "nome", "idReg");
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "yyyy-MM";
            AtualizaGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idReg = dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc = objEvento.getXMLEvt(int.Parse(idReg));
            using (XmlTextWriter xmlWriter = new XmlTextWriter(System.Environment.GetEnvironmentVariable("TEMP") + @"\" + this.GetType().ToString() + ".xml", null))
            {
                xmlWriter.Formatting = Formatting.None;
                xmlDoc.Save(xmlWriter);
            }            
            webBrowser1.Navigate(System.Environment.GetEnvironmentVariable("TEMP") + @"\" + this.GetType().ToString() + ".xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {
                MessageBox.Show("Evento já transmitido, não pode ser reenviado.");
            }
            else
            {
                int idReg = Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc = objEvento.getXMLEvt(idReg);
                Assinatura.assinarEnviarXML(idReg, xmlDoc, "evtReabreEvPer");
                AtualizaGrid();
                //dgvEventos.DataSource = objEvento.getData();
            }
        }


        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDadosR2098 f = new frmDadosR2098();
            f.ShowDialog();
            AtualizaGrid();
            //dgvEventos.DataSource = objEvento.getData();
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

                    objEvento.delete(Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString()));
                    AtualizaGrid();
                    //dgvEventos.DataSource = objEvento.getData();
                }
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {
                MessageBox.Show("Evento já transmitido, não pode ser modificado.");
            }
            else
            {                
                frmDadosR2098 f = new frmDadosR2098();
                f.idReg = Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
                f.ShowDialog();
                AtualizaGrid();
                // dgvEventos.DataSource = objEvento.getData();
            }
        }
        private void AtualizaGrid()
        {
            DataTable dtEmp = (new EmpresaDAL()).getEmpresa(Convert.ToInt32(comboBoxMatriz.SelectedValue.ToString()));
            dgvEventos.DataSource = objEvento.getData(dtEmp.Rows[0]["cnpj"].ToString().Substring(0, 8) + "000000", dtpPeriodo.Text);

        }

        private void dtpPeriodo_ValueChanged(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void comboBoxMatriz_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void dgvEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    }
}


