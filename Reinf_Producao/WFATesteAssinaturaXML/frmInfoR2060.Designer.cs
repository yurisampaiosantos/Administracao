namespace WFATesteAssinaturaXML
{
    partial class frmInfoR2060
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoR2060));
            this.btGerarXML = new System.Windows.Forms.Button();
            this.btExcluirEvento = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarXLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarComplyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.IdReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceitaBrutaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExclusaoReceita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseCalculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContribuicaoPrevidenciari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataHoraEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NrRecibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IconStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBoxMatriz = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEstabelecimento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reinfOraDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.manualToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reinfOraDBBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGerarXML
            // 
            this.btGerarXML.Location = new System.Drawing.Point(20, 30);
            this.btGerarXML.Name = "btGerarXML";
            this.btGerarXML.Size = new System.Drawing.Size(75, 23);
            this.btGerarXML.TabIndex = 1;
            this.btGerarXML.Text = "Ver XML";
            this.btGerarXML.UseVisualStyleBackColor = true;
            this.btGerarXML.Click += new System.EventHandler(this.buttonGerarXML_Click);
            // 
            // btExcluirEvento
            // 
            this.btExcluirEvento.Location = new System.Drawing.Point(993, 637);
            this.btExcluirEvento.Name = "btExcluirEvento";
            this.btExcluirEvento.Size = new System.Drawing.Size(156, 23);
            this.btExcluirEvento.TabIndex = 10;
            this.btExcluirEvento.Text = "Gerar Evento de Exclusão";
            this.btExcluirEvento.UseVisualStyleBackColor = true;
            this.btExcluirEvento.Click += new System.EventHandler(this.btExcluirEvento_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(19, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Assinar e Enviar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.excluirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(928, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarXLSToolStripMenuItem,
            this.importarComplyToolStripMenuItem,
            this.manualToolStripMenuItem1});
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.novoToolStripMenuItem.Text = "Novo";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
            // 
            // importarXLSToolStripMenuItem
            // 
            this.importarXLSToolStripMenuItem.Name = "importarXLSToolStripMenuItem";
            this.importarXLSToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.importarXLSToolStripMenuItem.Text = "Importar .XLS";
            this.importarXLSToolStripMenuItem.Visible = false;
            this.importarXLSToolStripMenuItem.Click += new System.EventHandler(this.importarXLSToolStripMenuItem_Click);
            // 
            // importarComplyToolStripMenuItem
            // 
            this.importarComplyToolStripMenuItem.Name = "importarComplyToolStripMenuItem";
            this.importarComplyToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.importarComplyToolStripMenuItem.Text = "Importar Comply";
            this.importarComplyToolStripMenuItem.Click += new System.EventHandler(this.importarComplyToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.excluirToolStripMenuItem.Text = "Excluir";
            this.excluirToolStripMenuItem.Click += new System.EventHandler(this.excluirToolStripMenuItem_Click);
            // 
            // dgvEventos
            // 
            this.dgvEventos.AllowUserToAddRows = false;
            this.dgvEventos.AllowUserToDeleteRows = false;
            this.dgvEventos.AllowUserToResizeRows = false;
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdReg,
            this.ID,
            this.ReceitaBrutaTotal,
            this.ExclusaoReceita,
            this.BaseCalculo,
            this.ContribuicaoPrevidenciari,
            this.DataHoraEnvio,
            this.NrRecibo,
            this.STATUS,
            this.IconStatus});
            this.dgvEventos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEventos.Location = new System.Drawing.Point(0, 0);
            this.dgvEventos.MultiSelect = false;
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.ReadOnly = true;
            this.dgvEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEventos.Size = new System.Drawing.Size(928, 333);
            this.dgvEventos.TabIndex = 29;
            this.dgvEventos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEventos_CellFormatting);
            // 
            // IdReg
            // 
            this.IdReg.DataPropertyName = "IDREG";
            this.IdReg.HeaderText = "IdReg";
            this.IdReg.Name = "IdReg";
            this.IdReg.ReadOnly = true;
            this.IdReg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 250;
            // 
            // ReceitaBrutaTotal
            // 
            this.ReceitaBrutaTotal.DataPropertyName = "RECEITA_BRUTA";
            this.ReceitaBrutaTotal.HeaderText = "Receita Bruta Total";
            this.ReceitaBrutaTotal.Name = "ReceitaBrutaTotal";
            this.ReceitaBrutaTotal.ReadOnly = true;
            // 
            // ExclusaoReceita
            // 
            this.ExclusaoReceita.DataPropertyName = "EXCLUSAO_RECEITA";
            this.ExclusaoReceita.HeaderText = "Exclusao da Receita";
            this.ExclusaoReceita.Name = "ExclusaoReceita";
            this.ExclusaoReceita.ReadOnly = true;
            // 
            // BaseCalculo
            // 
            this.BaseCalculo.DataPropertyName = "BASE_CALCULO";
            this.BaseCalculo.HeaderText = "Base Calculo";
            this.BaseCalculo.Name = "BaseCalculo";
            this.BaseCalculo.ReadOnly = true;
            // 
            // ContribuicaoPrevidenciari
            // 
            this.ContribuicaoPrevidenciari.DataPropertyName = "VALOR_CONTRIB";
            this.ContribuicaoPrevidenciari.HeaderText = "Contribuicao Previdenciaria";
            this.ContribuicaoPrevidenciari.Name = "ContribuicaoPrevidenciari";
            this.ContribuicaoPrevidenciari.ReadOnly = true;
            // 
            // DataHoraEnvio
            // 
            this.DataHoraEnvio.DataPropertyName = "DATAHORA_ENVIO";
            this.DataHoraEnvio.HeaderText = "Data/Hora Envio";
            this.DataHoraEnvio.Name = "DataHoraEnvio";
            this.DataHoraEnvio.ReadOnly = true;
            this.DataHoraEnvio.Width = 150;
            // 
            // NrRecibo
            // 
            this.NrRecibo.DataPropertyName = "NR_RECIBO";
            this.NrRecibo.HeaderText = "Nr Recibo";
            this.NrRecibo.Name = "NrRecibo";
            this.NrRecibo.ReadOnly = true;
            this.NrRecibo.Width = 150;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.HeaderText = "Status";
            this.STATUS.MinimumWidth = 2;
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STATUS.Width = 2;
            // 
            // IconStatus
            // 
            this.IconStatus.HeaderText = "Status";
            this.IconStatus.Name = "IconStatus";
            this.IconStatus.ReadOnly = true;
            this.IconStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IconStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Good mark.png");
            this.imageList1.Images.SetKeyName(1, "Bad mark.png");
            // 
            // comboBoxMatriz
            // 
            this.comboBoxMatriz.FormattingEnabled = true;
            this.comboBoxMatriz.Location = new System.Drawing.Point(108, 3);
            this.comboBoxMatriz.Name = "comboBoxMatriz";
            this.comboBoxMatriz.Size = new System.Drawing.Size(340, 21);
            this.comboBoxMatriz.TabIndex = 31;
            this.comboBoxMatriz.SelectedIndexChanged += new System.EventHandler(this.comboBoxMatriz_SelectedIndexChanged);
            this.comboBoxMatriz.SelectionChangeCommitted += new System.EventHandler(this.comboBoxMatriz_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Empresa:";
            // 
            // cmbEstabelecimento
            // 
            this.cmbEstabelecimento.FormattingEnabled = true;
            this.cmbEstabelecimento.Location = new System.Drawing.Point(108, 30);
            this.cmbEstabelecimento.Name = "cmbEstabelecimento";
            this.cmbEstabelecimento.Size = new System.Drawing.Size(340, 21);
            this.cmbEstabelecimento.TabIndex = 33;
            this.cmbEstabelecimento.SelectionChangeCommitted += new System.EventHandler(this.cmbEstabelecimento_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Estabelecimento:";
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodo.Location = new System.Drawing.Point(108, 57);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodo.TabIndex = 34;
            this.dtpPeriodo.ValueChanged += new System.EventHandler(this.dtpPeriodo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Período:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btGerarXML);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 446);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 105);
            this.panel1.TabIndex = 36;
            // 
            // reinfOraDBBindingSource
            // 
            this.reinfOraDBBindingSource.DataSource = typeof(ReinfDBClassLibrary.ReinfOraDB);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBoxMatriz);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtpPeriodo);
            this.panel2.Controls.Add(this.cmbEstabelecimento);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(928, 89);
            this.panel2.TabIndex = 37;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvEventos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(928, 333);
            this.panel3.TabIndex = 38;
            // 
            // manualToolStripMenuItem1
            // 
            this.manualToolStripMenuItem1.Name = "manualToolStripMenuItem1";
            this.manualToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.manualToolStripMenuItem1.Text = "Manual";
            this.manualToolStripMenuItem1.Click += new System.EventHandler(this.manualToolStripMenuItem1_Click);
            // 
            // frmInfoR2060
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(928, 551);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btExcluirEvento);
            this.Name = "frmInfoR2060";
            this.Text = "frmInfoR2060";
            this.Load += new System.EventHandler(this.frmInfoR2060_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reinfOraDBBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource reinfOraDBBindingSource;
        private System.Windows.Forms.Button btGerarXML;
        private System.Windows.Forms.Button btExcluirEvento;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem importarXLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarComplyToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxMatriz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEstabelecimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceitaBrutaTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExclusaoReceita;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseCalculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContribuicaoPrevidenciari;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataHoraEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NrRecibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewImageColumn IconStatus;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem1;
    }
}