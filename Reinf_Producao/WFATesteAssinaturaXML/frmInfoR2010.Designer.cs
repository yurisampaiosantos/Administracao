namespace WFATesteAssinaturaXML
{
    partial class frmInfoR2010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoR2010));
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarXLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarComplyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.IdReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorRetido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataHoraEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NrRecibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IconStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.cmbEstabelecimento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMatriz = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ver XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Location = new System.Drawing.Point(18, 316);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Assinar e Enviar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.excluirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1185, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarXLSToolStripMenuItem,
            this.importarComplyToolStripMenuItem});
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.novoToolStripMenuItem.Text = "Novo";
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
            this.Fornecedor,
            this.ValorBruto,
            this.ValorBase,
            this.ValorRetido,
            this.DataHoraEnvio,
            this.NrRecibo,
            this.STATUS,
            this.IconStatus});
            this.dgvEventos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvEventos.Location = new System.Drawing.Point(0, 0);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.ReadOnly = true;
            this.dgvEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEventos.Size = new System.Drawing.Size(1185, 268);
            this.dgvEventos.TabIndex = 14;
            this.dgvEventos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEventos_CellFormatting);
            // 
            // IdReg
            // 
            this.IdReg.DataPropertyName = "IDREG";
            this.IdReg.HeaderText = "IdReg";
            this.IdReg.Name = "IdReg";
            this.IdReg.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 250;
            // 
            // Fornecedor
            // 
            this.Fornecedor.DataPropertyName = "CNPJPRESTADOR";
            this.Fornecedor.HeaderText = "Fornecedor";
            this.Fornecedor.Name = "Fornecedor";
            this.Fornecedor.ReadOnly = true;
            // 
            // ValorBruto
            // 
            this.ValorBruto.DataPropertyName = "VLRTOTALBRUTO";
            this.ValorBruto.HeaderText = "Valor Bruto";
            this.ValorBruto.Name = "ValorBruto";
            this.ValorBruto.ReadOnly = true;
            // 
            // ValorBase
            // 
            this.ValorBase.DataPropertyName = "VLRTOTALBASERET";
            this.ValorBase.HeaderText = "Valor Base";
            this.ValorBase.Name = "ValorBase";
            this.ValorBase.ReadOnly = true;
            // 
            // ValorRetido
            // 
            this.ValorRetido.DataPropertyName = "VLRTOTALRETPRINC";
            this.ValorRetido.HeaderText = "Valor Retido";
            this.ValorRetido.Name = "ValorRetido";
            this.ValorRetido.ReadOnly = true;
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
            this.NrRecibo.DataPropertyName = "Nr_Recibo";
            this.NrRecibo.HeaderText = "NrRecibo";
            this.NrRecibo.Name = "NrRecibo";
            this.NrRecibo.ReadOnly = true;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Período:";
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodo.Location = new System.Drawing.Point(116, 90);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodo.TabIndex = 40;
            this.dtpPeriodo.ValueChanged += new System.EventHandler(this.dtpPeriodo_ValueChanged);
            // 
            // cmbEstabelecimento
            // 
            this.cmbEstabelecimento.FormattingEnabled = true;
            this.cmbEstabelecimento.Location = new System.Drawing.Point(116, 63);
            this.cmbEstabelecimento.Name = "cmbEstabelecimento";
            this.cmbEstabelecimento.Size = new System.Drawing.Size(340, 21);
            this.cmbEstabelecimento.TabIndex = 39;
            this.cmbEstabelecimento.SelectionChangeCommitted += new System.EventHandler(this.cmbEstabelecimento_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Estabelecimento:";
            // 
            // comboBoxMatriz
            // 
            this.comboBoxMatriz.FormattingEnabled = true;
            this.comboBoxMatriz.Location = new System.Drawing.Point(116, 36);
            this.comboBoxMatriz.Name = "comboBoxMatriz";
            this.comboBoxMatriz.Size = new System.Drawing.Size(340, 21);
            this.comboBoxMatriz.TabIndex = 37;
            this.comboBoxMatriz.SelectionChangeCommitted += new System.EventHandler(this.comboBoxMatriz_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Empresa:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Good mark.png");
            this.imageList1.Images.SetKeyName(1, "Bad mark.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.dgvEventos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 361);
            this.panel1.TabIndex = 42;
            // 
            // frmInfoR2010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1185, 477);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpPeriodo);
            this.Controls.Add(this.cmbEstabelecimento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxMatriz);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmInfoR2010";
            this.Text = "frmInfoR2010";
            this.Load += new System.EventHandler(this.frmInfoR2010_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarXLSToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
        private System.Windows.Forms.ComboBox cmbEstabelecimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMatriz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem importarComplyToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorRetido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataHoraEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NrRecibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewImageColumn IconStatus;
    }
}