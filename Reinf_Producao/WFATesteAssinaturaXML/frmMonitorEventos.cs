using Oracle.ManagedDataAccess.Client;
using RefinDBClassLibrary;
using ReinfDBClassLibrary;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace WFATesteAssinaturaXML
{

    public partial class frmMonitorEventos : Form
    {

        private OracleConnection oc;


        public frmMonitorEventos()
        {
            InitializeComponent();
        }


        private static bool CustomValidation(object sender,
        X509Certificate cert,
        X509Chain chain, System.Net.Security.SslPolicyErrors error)
        {
            return true;
        }


        private OracleConnection getConn()
        {
            oc = new OracleConnection("User Id=LF;Password=eepSALF;Data Source=LDCDBHML01.intranet.local/CRP01HML.intranet.local");
            oc.Open();
            return oc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            treeView1.Nodes[1].ForeColor = Color.Gray;
            treeView1.Nodes[3].ForeColor = Color.Gray;
            treeView1.Nodes[4].ForeColor = Color.Gray;
            treeView1.Nodes[5].ForeColor = Color.Gray;
            treeView1.Nodes[6].ForeColor = Color.Gray;
           // treeView1.Nodes[7].ForeColor = Color.Gray;
            treeView1.Nodes[8].ForeColor = Color.Gray;
            treeView1.Nodes[11].ForeColor = Color.Gray;
            treeView1.Nodes[12].ForeColor = Color.Gray;
            //Utils.CarregaCombo(new EmpresaDLL().getEmpresas(), comboBoxMatriz, "nome","idReg");
            //dtpPeriodo.Format = DateTimePickerFormat.Custom;
            //dtpPeriodo.CustomFormat = "yyyy-MM";
        }



        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dataGridView1.DataSource = null;
            ReinfOraDB odb = new ReinfOraDB();
            odb = new ReinfDBClassLibrary.ReinfOraDB();
            if (e.Node.Name == "R1000")
            {
                R1000DAL r = new R1000DAL();
                dataGridView1.DataSource = r.getData();
            }
            else if (e.Node.Name == "R1070")
            {
                // dataGridView1.DataSource = odb.getDataR1070();
            }
            else if (e.Node.Name == "R2010")
            {
                R2010DAL r = new R2010DAL();
                dataGridView1.DataSource = r.getData();
            }
            else if (e.Node.Name == "R2020")
            {
                // dataGridView1.DataSource = odb.getDataR2020();
            }
            else if (e.Node.Name == "R2060")
            {
                R2060DAL r = new R2060DAL();
                dataGridView1.DataSource = r.getData();
            }
            else if (e.Node.Name == "R2070")
            {
                // dataGridView1.DataSource = odb.getDataR2070();
            }
            else if (e.Node.Name == "R2098")
            {
                R2098DAL r = new R2098DAL();
                dataGridView1.DataSource = r.getData();
            }
            else if (e.Node.Name == "R2099")
            {
                R2099DAL r = new R2099DAL();
                dataGridView1.DataSource = r.getData();
            }
            else if (e.Node.Name == "R5001")
            {
                // dataGridView1.DataSource = odb.getDataR5001();
            }
            else if (e.Node.Name == "R5011")
            {
                R5011DAL r = new R5011DAL();
                dataGridView1.DataSource = r.getData();
            }
            else if (e.Node.Name == "R9000")
            {
                 R9000DAL r = new R9000DAL();
                 dataGridView1.DataSource = r.getData();                 
            }

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {


                switch (treeView1.SelectedNode.Index)
                {
                    case 0:
                        //R - 1000 - Informações do Contribuinte
                        frmInfoR1000 f1000 = new frmInfoR1000();
                        f1000.StartPosition = FormStartPosition.CenterScreen;
                        f1000.Show();
                        break;
                    case 1:
                        //R - 1070 - Tabela de Processos Administrativos / Judiciais
                        // xmlDoc = odb.getEvtR1070(comboBoxMatriz.SelectedValue.ToString());
                        break;
                    case 2:
                        //R - 2010 - Retenção Contribuição Previdenciária -Serviços Tomados
                        frmInfoR2010 f2010 = new frmInfoR2010();
                        f2010.StartPosition = FormStartPosition.CenterScreen;
                        f2010.Show();
                        break;
                    case 3:
                        //R - 2020 - Retenção Contribuição Previdenciária -Serviços Prestados
                        MessageBox.Show("Não usar !");
                        break;
                    case 4:
                        //R - 2030 - Recursos Recebidos por Associação Desportiva
                        MessageBox.Show("Não usar !");
                        break;
                    case 5:
                        //R - 2040 - Recursos Repassados para Associação Desportiva
                        MessageBox.Show("Não usar !");
                        break;
                    case 6:
                        //R - 2050 - Comercialização da Produção por Produtor Rural PJ/ Agroindústria
                        MessageBox.Show("Não usar !");
                        break;
                    case 7:
                        //R - 2060 - Contribuição Previdenciária sobre a Receita Bruta - CPRB
                        frmInfoR2060 f2060 = new frmInfoR2060();
                        f2060.StartPosition = FormStartPosition.CenterScreen;
                        f2060.Show();
                        break;
                    case 8:
                        //R - 2070 - Retenções na Fonte -IR, CSLL, Cofins, PIS / PASEP
                        // xmlDoc = odb.getEvtR2070(comboBoxMatriz.SelectedValue.ToString());
                        break;
                    case 9:
                        //R - 2098 - Reabertura dos Eventos Periódicos
                        frmInfoR2098 f2098 = new frmInfoR2098();
                        f2098.StartPosition = FormStartPosition.CenterScreen;
                        f2098.Show();
                        break;
                    case 10:
                        //R - 2099 - Fechamento dos Eventos Periódicos
                        frmInfoR2099 f2099 = new frmInfoR2099();
                        f2099.StartPosition = FormStartPosition.CenterScreen;
                        f2099.Show();
                        break;
                    case 11:
                        //R - 3010 - Receita de Espetáculo Desportivo
                        MessageBox.Show("Não usar !");
                        break;
                    case 12:
                        //R - 5001 - Informações das bases e dos tributos consolidados por contribuinte
                        // xmlDoc = odb.getEvtR5001(comboBoxMatriz.SelectedValue.ToString());
                        break;
                    case 13:
                        //R - 9000 - Exclusão de Eventos
                        frmInfoR5011 f5011 = new frmInfoR5011();
                        f5011.StartPosition = FormStartPosition.CenterScreen;
                        f5011.Show();
                        break;
                    case 14:
                        //R - 9000 - Exclusão de Eventos
                        frmInfoR9000 f9000 = new frmInfoR9000();
                        f9000.StartPosition = FormStartPosition.CenterScreen;
                        f9000.Show();
                        break;
                    default:
                        MessageBox.Show("Selecione um Evento");
                        break;
                }
            }

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "STATUS")
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
                            dataGridView1.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[0];
                        }
                        else if ((stringValue == "P"))
                        {
                            //e.CellStyle.BackColor = System.Drawing.Color.Red;
                            dataGridView1.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[1];
                        }

                    }

                }
            }
        }
    }
}


