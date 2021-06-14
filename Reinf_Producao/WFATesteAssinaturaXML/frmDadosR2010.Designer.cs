namespace WFATesteAssinaturaXML
{
    partial class frmDadosR2010
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.cmbEstabelecimento = new System.Windows.Forms.ComboBox();
            this.dtpPeriodoIni = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvNFS = new System.Windows.Forms.DataGridView();
            this.idReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtEmissaoNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJPrestador = new System.Windows.Forms.TextBox();
            this.txtVlrTotalBruto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVlrTotalBaseRet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVlrTotalRetPrinc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVlrTotalRetAdic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVlrTotalNRetPrinc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVlrTotalNRetAdic = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbIndCPRB = new System.Windows.Forms.ComboBox();
            this.txtNrRecibo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbIdentRetif = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbIndObra = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNFS)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estabelecimento:";
            // 
            // buttonOk
            // 
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Location = new System.Drawing.Point(558, 497);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(639, 497);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // cmbEstabelecimento
            // 
            this.cmbEstabelecimento.Enabled = false;
            this.cmbEstabelecimento.FormattingEnabled = true;
            this.cmbEstabelecimento.Location = new System.Drawing.Point(111, 30);
            this.cmbEstabelecimento.Name = "cmbEstabelecimento";
            this.cmbEstabelecimento.Size = new System.Drawing.Size(413, 21);
            this.cmbEstabelecimento.TabIndex = 6;
            // 
            // dtpPeriodoIni
            // 
            this.dtpPeriodoIni.Enabled = false;
            this.dtpPeriodoIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodoIni.Location = new System.Drawing.Point(111, 85);
            this.dtpPeriodoIni.Name = "dtpPeriodoIni";
            this.dtpPeriodoIni.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodoIni.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Período:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvNFS);
            this.panel1.Location = new System.Drawing.Point(12, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 207);
            this.panel1.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(728, 30);
            this.panel3.TabIndex = 39;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Excluir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Editar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Novo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(728, 27);
            this.panel2.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "NFS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvNFS
            // 
            this.dgvNFS.AllowUserToAddRows = false;
            this.dgvNFS.AllowUserToDeleteRows = false;
            this.dgvNFS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNFS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReg,
            this.serie,
            this.numDocto,
            this.dtEmissaoNF,
            this.vlrBruto,
            this.obs});
            this.dgvNFS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNFS.Location = new System.Drawing.Point(0, 58);
            this.dgvNFS.Name = "dgvNFS";
            this.dgvNFS.ReadOnly = true;
            this.dgvNFS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNFS.Size = new System.Drawing.Size(728, 149);
            this.dgvNFS.TabIndex = 36;
            this.dgvNFS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipoCod_CellContentClick);
            // 
            // idReg
            // 
            this.idReg.DataPropertyName = "idReg";
            this.idReg.HeaderText = "idReg";
            this.idReg.Name = "idReg";
            this.idReg.ReadOnly = true;
            this.idReg.Width = 50;
            // 
            // serie
            // 
            this.serie.DataPropertyName = "serie";
            this.serie.HeaderText = "serie";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            // 
            // numDocto
            // 
            this.numDocto.DataPropertyName = "numDocto";
            this.numDocto.HeaderText = "numDocto";
            this.numDocto.Name = "numDocto";
            this.numDocto.ReadOnly = true;
            // 
            // dtEmissaoNF
            // 
            this.dtEmissaoNF.DataPropertyName = "dtEmissaoNF";
            this.dtEmissaoNF.HeaderText = "dtEmissaoNF";
            this.dtEmissaoNF.Name = "dtEmissaoNF";
            this.dtEmissaoNF.ReadOnly = true;
            // 
            // vlrBruto
            // 
            this.vlrBruto.DataPropertyName = "vlrBruto";
            this.vlrBruto.HeaderText = "vlrBruto";
            this.vlrBruto.Name = "vlrBruto";
            this.vlrBruto.ReadOnly = true;
            // 
            // obs
            // 
            this.obs.DataPropertyName = "obs";
            this.obs.HeaderText = "obs";
            this.obs.Name = "obs";
            this.obs.ReadOnly = true;
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.Enabled = false;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(111, 3);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(413, 21);
            this.cmbEmpresa.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Empresa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "CNPJ Prestador";
            // 
            // txtCNPJPrestador
            // 
            this.txtCNPJPrestador.Enabled = false;
            this.txtCNPJPrestador.Location = new System.Drawing.Point(111, 156);
            this.txtCNPJPrestador.Name = "txtCNPJPrestador";
            this.txtCNPJPrestador.Size = new System.Drawing.Size(219, 20);
            this.txtCNPJPrestador.TabIndex = 39;
            // 
            // txtVlrTotalBruto
            // 
            this.txtVlrTotalBruto.Location = new System.Drawing.Point(111, 182);
            this.txtVlrTotalBruto.Name = "txtVlrTotalBruto";
            this.txtVlrTotalBruto.ReadOnly = true;
            this.txtVlrTotalBruto.Size = new System.Drawing.Size(219, 20);
            this.txtVlrTotalBruto.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Total Bruto NFs";
            // 
            // txtVlrTotalBaseRet
            // 
            this.txtVlrTotalBaseRet.Location = new System.Drawing.Point(111, 208);
            this.txtVlrTotalBaseRet.Name = "txtVlrTotalBaseRet";
            this.txtVlrTotalBaseRet.ReadOnly = true;
            this.txtVlrTotalBaseRet.Size = new System.Drawing.Size(219, 20);
            this.txtVlrTotalBaseRet.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Base de Calculo";
            // 
            // txtVlrTotalRetPrinc
            // 
            this.txtVlrTotalRetPrinc.Location = new System.Drawing.Point(111, 234);
            this.txtVlrTotalRetPrinc.Name = "txtVlrTotalRetPrinc";
            this.txtVlrTotalRetPrinc.ReadOnly = true;
            this.txtVlrTotalRetPrinc.Size = new System.Drawing.Size(219, 20);
            this.txtVlrTotalRetPrinc.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Tot Ret Princip";
            // 
            // txtVlrTotalRetAdic
            // 
            this.txtVlrTotalRetAdic.Location = new System.Drawing.Point(466, 156);
            this.txtVlrTotalRetAdic.Name = "txtVlrTotalRetAdic";
            this.txtVlrTotalRetAdic.ReadOnly = true;
            this.txtVlrTotalRetAdic.Size = new System.Drawing.Size(219, 20);
            this.txtVlrTotalRetAdic.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(367, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Tot Ret Adicional";
            // 
            // txtVlrTotalNRetPrinc
            // 
            this.txtVlrTotalNRetPrinc.Location = new System.Drawing.Point(466, 182);
            this.txtVlrTotalNRetPrinc.Name = "txtVlrTotalNRetPrinc";
            this.txtVlrTotalNRetPrinc.ReadOnly = true;
            this.txtVlrTotalNRetPrinc.Size = new System.Drawing.Size(219, 20);
            this.txtVlrTotalNRetPrinc.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(367, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Total N Ret Princ";
            // 
            // txtVlrTotalNRetAdic
            // 
            this.txtVlrTotalNRetAdic.Location = new System.Drawing.Point(466, 208);
            this.txtVlrTotalNRetAdic.Name = "txtVlrTotalNRetAdic";
            this.txtVlrTotalNRetAdic.ReadOnly = true;
            this.txtVlrTotalNRetAdic.Size = new System.Drawing.Size(219, 20);
            this.txtVlrTotalNRetAdic.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(367, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Total N Ret Adic";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(367, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Ind. CPRB";
            // 
            // cmbIndCPRB
            // 
            this.cmbIndCPRB.Enabled = false;
            this.cmbIndCPRB.FormattingEnabled = true;
            this.cmbIndCPRB.Items.AddRange(new object[] {
            "0 - Não é contribuinte da Contribuição Previdenciária sobre a Receita Bruta - Ret" +
                "enção 11%",
            "1 - Contribuinte da Contribuição Previdenciária sobre a Receita Bruta - Retenção " +
                "3,5%"});
            this.cmbIndCPRB.Location = new System.Drawing.Point(466, 234);
            this.cmbIndCPRB.Name = "cmbIndCPRB";
            this.cmbIndCPRB.Size = new System.Drawing.Size(274, 21);
            this.cmbIndCPRB.TabIndex = 53;
            // 
            // txtNrRecibo
            // 
            this.txtNrRecibo.Enabled = false;
            this.txtNrRecibo.Location = new System.Drawing.Point(413, 113);
            this.txtNrRecibo.Name = "txtNrRecibo";
            this.txtNrRecibo.Size = new System.Drawing.Size(327, 20);
            this.txtNrRecibo.TabIndex = 57;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(351, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 56;
            this.label13.Text = "Nº Recibo";
            // 
            // cmbIdentRetif
            // 
            this.cmbIdentRetif.Enabled = false;
            this.cmbIdentRetif.FormattingEnabled = true;
            this.cmbIdentRetif.Items.AddRange(new object[] {
            "1 - Arquivo Original",
            "2 - Arquivo de Retificação"});
            this.cmbIdentRetif.Location = new System.Drawing.Point(161, 113);
            this.cmbIdentRetif.Name = "cmbIdentRetif";
            this.cmbIdentRetif.Size = new System.Drawing.Size(184, 21);
            this.cmbIdentRetif.TabIndex = 55;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "Indentificador de Retificação";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 58;
            this.label15.Text = "Indi Obra";
            // 
            // cmbIndObra
            // 
            this.cmbIndObra.Enabled = false;
            this.cmbIndObra.FormattingEnabled = true;
            this.cmbIndObra.Items.AddRange(new object[] {
            "0 - Não é obra de construção civil ou não está sujeita a matrícula de obra",
            "1 - Obra de construção Civil - Empreitada Total",
            "2 - Obra de construção Civil - Empreitada Parcial"});
            this.cmbIndObra.Location = new System.Drawing.Point(111, 57);
            this.cmbIndObra.Name = "cmbIndObra";
            this.cmbIndObra.Size = new System.Drawing.Size(413, 21);
            this.cmbIndObra.TabIndex = 59;
            // 
            // frmDadosR2010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(764, 532);
            this.Controls.Add(this.cmbIndObra);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtNrRecibo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbIdentRetif);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbIndCPRB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtVlrTotalNRetAdic);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtVlrTotalNRetPrinc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtVlrTotalRetAdic);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtVlrTotalRetPrinc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtVlrTotalBaseRet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtVlrTotalBruto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCNPJPrestador);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpPeriodoIni);
            this.Controls.Add(this.cmbEstabelecimento);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label2);
            this.Name = "frmDadosR2010";
            this.Text = "frmDadosR2010";
            this.Load += new System.EventHandler(this.frmDadosR2010_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNFS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox cmbEstabelecimento;
        private System.Windows.Forms.DateTimePicker dtpPeriodoIni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvNFS;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJPrestador;
        private System.Windows.Forms.TextBox txtVlrTotalBruto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVlrTotalBaseRet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVlrTotalRetPrinc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVlrTotalRetAdic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVlrTotalNRetPrinc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVlrTotalNRetAdic;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbIndCPRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtEmissaoNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn obs;
        private System.Windows.Forms.TextBox txtNrRecibo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbIdentRetif;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbIndObra;
    }
}