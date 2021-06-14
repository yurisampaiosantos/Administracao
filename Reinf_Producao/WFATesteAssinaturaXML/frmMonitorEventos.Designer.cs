namespace WFATesteAssinaturaXML
{
    partial class frmMonitorEventos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("R-1000 - Informações do Contribuinte");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("R-1070 - Tabela de Processos Administrativos/Judiciais");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("R-2010 - Retenção Contribuição Previdenciária - Serviços Tomados");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("R-2020 - Retenção Contribuição Previdenciária - Serviços Prestados");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("R-2030 - Recursos Recebidos por Associação Desportiva");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("R-2040 - Recursos Repassados para Associação Desportiva");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("R-2050 - Comercialização da Produção por Produtor Rural PJ/Agroindústria");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("R-2060 - Contribuição Previdenciária sobre a Receita Bruta - CPRB");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("R-2070 - Retenções na Fonte - IR, CSLL, Cofins, PIS/PASEP");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("R-2098 - Reabertura dos Eventos Periódicos");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("R-2099 - Fechamento dos Eventos Periódicos");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("R-3010 - Receita de Espetáculo Desportivo");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("R-5001 - Informações das bases e dos tributos consolidados por contribuinte");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("R-5011 - Informações de bases e tributos consolidadas por período de apuração");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("R-9000 - Exclusão de Eventos");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitorEventos));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IDReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datahora_registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IconStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(14, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "R1000";
            treeNode1.Text = "R-1000 - Informações do Contribuinte";
            treeNode2.Name = "R1070";
            treeNode2.Text = "R-1070 - Tabela de Processos Administrativos/Judiciais";
            treeNode3.Name = "R2010";
            treeNode3.Text = "R-2010 - Retenção Contribuição Previdenciária - Serviços Tomados";
            treeNode4.Name = "R2020";
            treeNode4.Text = "R-2020 - Retenção Contribuição Previdenciária - Serviços Prestados";
            treeNode5.Name = "R2030";
            treeNode5.Text = "R-2030 - Recursos Recebidos por Associação Desportiva";
            treeNode6.Name = "R2040";
            treeNode6.Text = "R-2040 - Recursos Repassados para Associação Desportiva";
            treeNode7.Name = "R2050";
            treeNode7.Text = "R-2050 - Comercialização da Produção por Produtor Rural PJ/Agroindústria";
            treeNode8.Name = "R2060";
            treeNode8.Text = "R-2060 - Contribuição Previdenciária sobre a Receita Bruta - CPRB";
            treeNode9.Name = "R2070";
            treeNode9.Text = "R-2070 - Retenções na Fonte - IR, CSLL, Cofins, PIS/PASEP";
            treeNode10.Name = "R2098";
            treeNode10.Text = "R-2098 - Reabertura dos Eventos Periódicos";
            treeNode11.Name = "R2099";
            treeNode11.Text = "R-2099 - Fechamento dos Eventos Periódicos";
            treeNode12.Name = "R3010";
            treeNode12.Text = "R-3010 - Receita de Espetáculo Desportivo";
            treeNode13.Name = "R5001";
            treeNode13.Text = "R-5001 - Informações das bases e dos tributos consolidados por contribuinte";
            treeNode14.Name = "R5011";
            treeNode14.Text = "R-5011 - Informações de bases e tributos consolidadas por período de apuração";
            treeNode15.Name = "R9000";
            treeNode15.Text = "R-9000 - Exclusão de Eventos";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            this.treeView1.Size = new System.Drawing.Size(392, 321);
            this.treeView1.TabIndex = 17;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDReg,
            this.ID,
            this.Datahora_registro,
            this.STATUS,
            this.IconStatus});
            this.dataGridView1.Location = new System.Drawing.Point(420, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(519, 312);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // IDReg
            // 
            this.IDReg.DataPropertyName = "IDREG";
            this.IDReg.HeaderText = "IdReg";
            this.IDReg.Name = "IDReg";
            this.IDReg.ReadOnly = true;
            this.IDReg.Width = 80;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 150;
            // 
            // Datahora_registro
            // 
            this.Datahora_registro.DataPropertyName = "DATAHORA_REGISTRO";
            this.Datahora_registro.HeaderText = "Data/Hora Registro";
            this.Datahora_registro.Name = "Datahora_registro";
            this.Datahora_registro.ReadOnly = true;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.HeaderText = "Status";
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STATUS.Width = 5;
            // 
            // IconStatus
            // 
            this.IconStatus.HeaderText = "Status";
            this.IconStatus.Name = "IconStatus";
            this.IconStatus.ReadOnly = true;
            this.IconStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IconStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IconStatus.Width = 50;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Good mark.png");
            this.imageList1.Images.SetKeyName(1, "Bad mark.png");
            // 
            // frmMonitorEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(951, 333);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.Name = "frmMonitorEventos";
            this.Text = "Monitor de Eventos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datahora_registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewImageColumn IconStatus;
    }
}

