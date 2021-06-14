using RefinDBClassLibrary;
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
    public partial class frmEmpresas : Form
    {

        private EmpresaDAL eDLL;

        private void AtualizaGrid()
        {
            dataGridView1.DataSource = eDLL.getEmpresas();
        }

        public frmEmpresas()
        {
            InitializeComponent();
        }

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            eDLL = new EmpresaDAL();
            AtualizaGrid();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Confirma a exclusão do regsitro ?", "Confirmação", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                eDLL.delete(Convert.ToInt32(dt.Rows[dataGridView1.SelectedRows[0].Index]["idReg"].ToString()));
                AtualizaGrid();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) { 
                frmDadosEmpresa fde = new frmDadosEmpresa();
                fde.idReg = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["idReg"].Value.ToString());
                fde.ShowDialog();
                AtualizaGrid();
            }
            else
            {
                MessageBox.Show("Selecione um registro !");
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDadosEmpresa fde = new frmDadosEmpresa();
            fde.idReg = 0;
            fde.ShowDialog();
            AtualizaGrid();
        }
    }
}
