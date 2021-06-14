using envioLoteEventos;
using RefinDBClassLibrary;
using ReinfDBClassLibrary;
using reinfPreWSDL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WFATesteAssinaturaXML
{
    public partial class frmInfoR1000 : Form
    {
        private RBASEDAL objEvento;
        public frmInfoR1000()
        {
            InitializeComponent();
        }
        private void AtualizaGrid()
        {   
            R1000DAL objEventoCNPJ = new R1000DAL();
            EmpresaDAL eDLL = new EmpresaDAL();
            String cnpj = eDLL.getEmpresa(Convert.ToInt32(comboBoxMatriz.SelectedValue)).Rows[0]["cnpj"].ToString();
            dgvEventos.DataSource = objEventoCNPJ.getData(cnpj);

        }
        private void frmInfoR1000_Load(object sender, EventArgs e)
        {
            dgvEventos.AutoGenerateColumns = false;
            objEvento = new R1000DAL();
            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), comboBoxMatriz, "nome", "idReg");
            AtualizaGrid(); // dgvEventos.DataSource = objEvento.getData();
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



        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {
                MessageBox.Show("Evento já transmitido, não pode ser reenviado.");
            }
            else
            {
                int idReg = Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
                Assinatura.assinarEnviarXML(idReg, objEvento.getXMLEvt(idReg), "evtInfoContri");
                AtualizaGrid();
                //dgvEventos.DataSource = objEvento.getData();
            }
        }
       

        private void dgvEventos_SelectionChanged(object sender, EventArgs e)
        {            
            
        }


        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDadosR1000 f = new frmDadosR1000();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.edicao = true;
            f.ShowDialog();
            //dgvEventos.DataSource = objEvento.getData();
            AtualizaGrid();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          /*  if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {
                MessageBox.Show("Evento já transmitido, não pode ser modificado.");
            }
            else
            {*/
                frmDadosR1000 f = new frmDadosR1000();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.idReg = Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
                if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
                {
                    f.edicao = false;
                }
                else
                {
                    f.edicao = true;
                }
                f.ShowDialog();
                //dgvEventos.DataSource = objEvento.getData();
                AtualizaGrid();
           // }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idReg = Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
            
            if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {                
                DialogResult dialogResult = MessageBox.Show("Evento já transmitido, não pode ser excluído. Deseja gerar um evento de exclusão para este registro? ", "Confirmação", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {                  
                    (objEvento as R1000DAL).gerarDataExclusaoR1000(idReg);
                    AtualizaGrid();
                   // dgvEventos.DataSource = objEvento.getData();

                }                
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Deseja excluir o registro selecionado ? ", "Confirmação", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    objEvento.delete(idReg);
                    AtualizaGrid();
                   // dgvEventos.DataSource = objEvento.getData();
                }
            }            
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

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idReg = Convert.ToInt32(dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["idReg"].Value.ToString());

            if (dgvEventos.Rows[dgvEventos.SelectedRows[0].Index].Cells["status"].Value.ToString() == "E")
            {
                DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja finalizar o Evento?", "Confirmação", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    (objEvento as R1000DAL).gerarDataFecharR1000(idReg);
                    AtualizaGrid();
                    //dgvEventos.DataSource = objEvento.getData();
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Evento não foi transmitido, e não pode ser fechado");
            }       
        }

        private void comboBoxMatriz_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AtualizaGrid();
        }
    }
}


