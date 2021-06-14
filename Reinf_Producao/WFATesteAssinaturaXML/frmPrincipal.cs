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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                Version ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                lbVersao.Text = string.Format(" V.Prod: {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
            }
            else
            {
                var ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                lbVersao.Text = string.Format(" V.Prod: {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
            }
        }

        private void monitorEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonitorEventos f = new frmMonitorEventos();
            f.Show();
        }

        private void workFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWorkFlow f = new frmWorkFlow();
            f.Show();
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpresas f = new frmEmpresas();
            f.Show();

        }

        private void estabelecimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstabelecimentos f = new frmEstabelecimentos();
            f.Show();
        }

        private void caToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            frmEventos fe = new frmEventos();
            fe.Show();            
        }

        private void responsáveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResponsaveis fe = new frmResponsaveis();
            fe.Show();
        }

        private void conferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConferencia fc = new frmConferencia();
            fc.Show();
        }


    }
}
