namespace WFATesteAssinaturaXML
{
    partial class frmInfoR9000
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoR9000));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.comboBoxMatriz = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinfOraDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.IdReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRRECEVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IconStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataHoraEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NR_RECIBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reinfOraDBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ver XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(12, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Assinar e Enviar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodo.Location = new System.Drawing.Point(74, 64);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodo.TabIndex = 5;
            this.dtpPeriodo.ValueChanged += new System.EventHandler(this.dtpPeriodo_ValueChanged);
            // 
            // comboBoxMatriz
            // 
            this.comboBoxMatriz.FormattingEnabled = true;
            this.comboBoxMatriz.Location = new System.Drawing.Point(74, 28);
            this.comboBoxMatriz.Name = "comboBoxMatriz";
            this.comboBoxMatriz.Size = new System.Drawing.Size(340, 21);
            this.comboBoxMatriz.TabIndex = 25;
            this.comboBoxMatriz.SelectionChangeCommitted += new System.EventHandler(this.comboBoxMatriz_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Empresa:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.excluirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(975, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.novoToolStripMenuItem.Text = "Novo";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Visible = false;
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.excluirToolStripMenuItem.Text = "Excluir";
            this.excluirToolStripMenuItem.Click += new System.EventHandler(this.excluirToolStripMenuItem_Click);
            // 
            // reinfOraDBBindingSource
            // 
            this.reinfOraDBBindingSource.DataSource = typeof(ReinfDBClassLibrary.ReinfOraDB);
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
            this.TipoEvento,
            this.NRRECEVT,
            this.STATUS,
            this.IconStatus,
            this.DataHoraEnvio,
            this.NR_RECIBO});
            this.dgvEventos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEventos.Location = new System.Drawing.Point(0, 0);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.ReadOnly = true;
            this.dgvEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEventos.Size = new System.Drawing.Size(975, 310);
            this.dgvEventos.TabIndex = 30;
            this.dgvEventos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEventos_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Período:";
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
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 78);
            this.panel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvEventos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(975, 310);
            this.panel2.TabIndex = 33;
            // 
            // IdReg
            // 
            this.IdReg.DataPropertyName = "IDREG";
            this.IdReg.Frozen = true;
            this.IdReg.HeaderText = "IdReg";
            this.IdReg.Name = "IdReg";
            this.IdReg.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 250;
            // 
            // TipoEvento
            // 
            this.TipoEvento.DataPropertyName = "TpEvento";
            this.TipoEvento.Frozen = true;
            this.TipoEvento.HeaderText = "TipoEvento";
            this.TipoEvento.Name = "TipoEvento";
            this.TipoEvento.ReadOnly = true;
            // 
            // NRRECEVT
            // 
            this.NRRECEVT.DataPropertyName = "NRRECEVT";
            this.NRRECEVT.Frozen = true;
            this.NRRECEVT.HeaderText = "N. Protocolo Evento";
            this.NRRECEVT.Name = "NRRECEVT";
            this.NRRECEVT.ReadOnly = true;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.Frozen = true;
            this.STATUS.HeaderText = "Status";
            this.STATUS.MinimumWidth = 2;
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STATUS.Width = 2;
            // 
            // IconStatus
            // 
            this.IconStatus.Frozen = true;
            this.IconStatus.HeaderText = "Status";
            this.IconStatus.Name = "IconStatus";
            this.IconStatus.ReadOnly = true;
            this.IconStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IconStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DataHoraEnvio
            // 
            this.DataHoraEnvio.DataPropertyName = "DATAHORA_ENVIO";
            this.DataHoraEnvio.Frozen = true;
            this.DataHoraEnvio.HeaderText = "Data/Hora Envio";
            this.DataHoraEnvio.Name = "DataHoraEnvio";
            this.DataHoraEnvio.ReadOnly = true;
            this.DataHoraEnvio.Width = 150;
            // 
            // NR_RECIBO
            // 
            this.NR_RECIBO.DataPropertyName = "NR_RECIBO";
            this.NR_RECIBO.Frozen = true;
            this.NR_RECIBO.HeaderText = "Numero Recibo";
            this.NR_RECIBO.Name = "NR_RECIBO";
            this.NR_RECIBO.ReadOnly = true;
            // 
            // frmInfoR9000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(975, 478);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.comboBoxMatriz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpPeriodo);
            this.Name = "frmInfoR9000";
            this.Text = "frmInfoR9000";
            this.Load += new System.EventHandler(this.frmInfoR2098_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reinfOraDBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource reinfOraDBBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
        private System.Windows.Forms.ComboBox comboBoxMatriz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRRECEVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewImageColumn IconStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataHoraEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NR_RECIBO;
    }
}