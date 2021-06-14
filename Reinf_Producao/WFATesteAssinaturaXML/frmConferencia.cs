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
    public partial class frmConferencia : Form
    {
        public frmConferencia()
        {
            InitializeComponent();
        }


        private void frmConferencia_Load(object sender, EventArgs e)
        {
            Utils.CarregaCombo((new EmpresaDAL().getEmpresas()), comboBoxMatriz, "nome", "idReg");
            Utils.CarregaCombo((new EstabelecimentoDAL().getEstabelecimentos()), cmbEstabelecimento, "nome", "idReg");
            Utils.CarregaCombo((new EventosDAL().getEventos()), cmbEventos, "nome", "codigo");
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "yyyy-MM";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RBASEDAL rb = null;
            EmpresaDAL emp = new EmpresaDAL();
            DataTable dtEmp = emp.getEmpresa(Convert.ToInt16(comboBoxMatriz.SelectedValue.ToString()));
            EstabelecimentoDAL estab = new EstabelecimentoDAL();
            DataTable dtEstab = estab.getEstabelecimento(Convert.ToInt16(cmbEstabelecimento.SelectedValue.ToString()));

            string evt = cmbEventos.SelectedValue.ToString();
            if (evt == "1000")
            {
                rb = new R1000DAL();
                dataGridView1.DataSource = (rb as R1000DAL).getData(dtEmp.Rows[0]["cnpj"].ToString());
            }
            else if (evt == "1070")
            {
                // dataGridView1.DataSource = odb.getDataR1070();
            }
            else if (evt == "2010")
            {
                rb = new R2010DAL();
                dataGridView1.DataSource = (rb as R2010DAL).getData(dtEmp.Rows[0]["cnpj"].ToString(), dtEstab.Rows[0]["cnpj"].ToString(), dtpPeriodo.Text);
            }
            else if (evt == "2020")
            {
                // dataGridView1.DataSource = odb.getDataR2020();
            }
            else if (evt == "2060")
            {
                rb = new R2060DAL();
                dataGridView1.DataSource = (rb as R2060DAL).getData(dtEmp.Rows[0]["cnpj"].ToString(), dtEstab.Rows[0]["cnpj"].ToString(), dtpPeriodo.Text);
            }
            else if (evt == "2070")
            {
                // dataGridView1.DataSource = odb.getDataR2070();
            }
            else if (evt == "2098")
            {
                rb = new R2098DAL();
                dataGridView1.DataSource = (rb as R2098DAL).getData(dtEmp.Rows[0]["cnpj"].ToString(), dtpPeriodo.Text);
            }
            else if (evt == "2099")
            {
                rb = new R2099DAL();
                dataGridView1.DataSource = (rb as R2099DAL).getData(dtEmp.Rows[0]["cnpj"].ToString(), dtpPeriodo.Text);
            }
            else if (evt == "5001")
            {
                // dataGridView1.DataSource = odb.getDataR5001();
            }
            else if (evt == "9000")
            {
                //  dataGridView1.DataSource = odb.getDataR9000();
            }
            
        }

        private void cmbEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string evt = cmbEventos.SelectedValue.ToString();

            dtpPeriodo.Visible = "2010,2020,2060,2098,2099".Contains(evt);
            cmbEstabelecimento.Visible = "2010,2020,2060".Contains(evt);

            labelPeriodo.Visible = "2010,2020,2060,2098,2099".Contains(evt);
            labelEstab.Visible = "2010,2020,2060".Contains(evt);

        }
    }
}
