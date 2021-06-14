namespace WFATesteAssinaturaXML
{
    partial class frmDadosR2010NFS
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtnumDocto = new System.Windows.Forms.TextBox();
            this.txtvlrBruto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvInfoTpServ = new System.Windows.Forms.DataGridView();
            this.idReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpServico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrBaseRet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrRetencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrRetSub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrNRetPrinc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrServicos15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrServicos20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrServicos25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrAdicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrNRetAdic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpDtEmissaoNF = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoTpServ)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Location = new System.Drawing.Point(548, 369);
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
            this.buttonCancel.Location = new System.Drawing.Point(629, 369);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "serie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "dtEmissaoNF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "numDocto";
            // 
            // txtSerie
            // 
            this.txtSerie.Enabled = false;
            this.txtSerie.Location = new System.Drawing.Point(75, 13);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(181, 20);
            this.txtSerie.TabIndex = 25;
            // 
            // txtnumDocto
            // 
            this.txtnumDocto.Enabled = false;
            this.txtnumDocto.Location = new System.Drawing.Point(75, 40);
            this.txtnumDocto.Name = "txtnumDocto";
            this.txtnumDocto.Size = new System.Drawing.Size(181, 20);
            this.txtnumDocto.TabIndex = 26;
            // 
            // txtvlrBruto
            // 
            this.txtvlrBruto.Enabled = false;
            this.txtvlrBruto.Location = new System.Drawing.Point(343, 39);
            this.txtvlrBruto.Name = "txtvlrBruto";
            this.txtvlrBruto.Size = new System.Drawing.Size(181, 20);
            this.txtvlrBruto.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "vlrBruto";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(75, 70);
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(449, 20);
            this.txtObs.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "obs";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvInfoTpServ);
            this.panel1.Location = new System.Drawing.Point(3, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 257);
            this.panel1.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(702, 30);
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
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 27);
            this.panel2.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "infoTpServ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvInfoTpServ
            // 
            this.dgvInfoTpServ.AllowUserToAddRows = false;
            this.dgvInfoTpServ.AllowUserToDeleteRows = false;
            this.dgvInfoTpServ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoTpServ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReg,
            this.tpServico,
            this.vlrBaseRet,
            this.vlrRetencao,
            this.vlrRetSub,
            this.vlrNRetPrinc,
            this.vlrServicos15,
            this.vlrServicos20,
            this.vlrServicos25,
            this.vlrAdicional,
            this.vlrNRetAdic});
            this.dgvInfoTpServ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvInfoTpServ.Location = new System.Drawing.Point(0, 60);
            this.dgvInfoTpServ.Name = "dgvInfoTpServ";
            this.dgvInfoTpServ.ReadOnly = true;
            this.dgvInfoTpServ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfoTpServ.Size = new System.Drawing.Size(702, 197);
            this.dgvInfoTpServ.TabIndex = 36;
            // 
            // idReg
            // 
            this.idReg.DataPropertyName = "idReg";
            this.idReg.HeaderText = "idReg";
            this.idReg.Name = "idReg";
            this.idReg.ReadOnly = true;
            this.idReg.Width = 50;
            // 
            // tpServico
            // 
            this.tpServico.DataPropertyName = "tpServico";
            this.tpServico.HeaderText = "tpServico";
            this.tpServico.Name = "tpServico";
            this.tpServico.ReadOnly = true;
            // 
            // vlrBaseRet
            // 
            this.vlrBaseRet.DataPropertyName = "vlrBaseRet";
            this.vlrBaseRet.HeaderText = "vlrBaseRet";
            this.vlrBaseRet.Name = "vlrBaseRet";
            this.vlrBaseRet.ReadOnly = true;
            // 
            // vlrRetencao
            // 
            this.vlrRetencao.DataPropertyName = "vlrRetencao";
            this.vlrRetencao.HeaderText = "vlrRetencao";
            this.vlrRetencao.Name = "vlrRetencao";
            this.vlrRetencao.ReadOnly = true;
            // 
            // vlrRetSub
            // 
            this.vlrRetSub.DataPropertyName = "vlrRetSub";
            this.vlrRetSub.HeaderText = "vlrRetSub";
            this.vlrRetSub.Name = "vlrRetSub";
            this.vlrRetSub.ReadOnly = true;
            // 
            // vlrNRetPrinc
            // 
            this.vlrNRetPrinc.DataPropertyName = "vlrNRetPrinc";
            this.vlrNRetPrinc.HeaderText = "vlrNRetPrinc";
            this.vlrNRetPrinc.Name = "vlrNRetPrinc";
            this.vlrNRetPrinc.ReadOnly = true;
            // 
            // vlrServicos15
            // 
            this.vlrServicos15.DataPropertyName = "vlrServicos15";
            this.vlrServicos15.HeaderText = "vlrServicos15";
            this.vlrServicos15.Name = "vlrServicos15";
            this.vlrServicos15.ReadOnly = true;
            // 
            // vlrServicos20
            // 
            this.vlrServicos20.DataPropertyName = "vlrServicos20";
            this.vlrServicos20.HeaderText = "vlrServicos20";
            this.vlrServicos20.Name = "vlrServicos20";
            this.vlrServicos20.ReadOnly = true;
            // 
            // vlrServicos25
            // 
            this.vlrServicos25.DataPropertyName = "vlrServicos25";
            this.vlrServicos25.HeaderText = "vlrServicos25";
            this.vlrServicos25.Name = "vlrServicos25";
            this.vlrServicos25.ReadOnly = true;
            // 
            // vlrAdicional
            // 
            this.vlrAdicional.DataPropertyName = "vlrAdicional";
            this.vlrAdicional.HeaderText = "vlrAdicional";
            this.vlrAdicional.Name = "vlrAdicional";
            this.vlrAdicional.ReadOnly = true;
            // 
            // vlrNRetAdic
            // 
            this.vlrNRetAdic.DataPropertyName = "vlrNRetAdic";
            this.vlrNRetAdic.HeaderText = "vlrNRetAdic";
            this.vlrNRetAdic.Name = "vlrNRetAdic";
            this.vlrNRetAdic.ReadOnly = true;
            // 
            // dtpDtEmissaoNF
            // 
            this.dtpDtEmissaoNF.Enabled = false;
            this.dtpDtEmissaoNF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtEmissaoNF.Location = new System.Drawing.Point(343, 13);
            this.dtpDtEmissaoNF.Name = "dtpDtEmissaoNF";
            this.dtpDtEmissaoNF.Size = new System.Drawing.Size(181, 20);
            this.dtpDtEmissaoNF.TabIndex = 34;
            // 
            // frmDadosR2010NFS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(711, 402);
            this.Controls.Add(this.dtpDtEmissaoNF);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtvlrBruto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtnumDocto);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "frmDadosR2010NFS";
            this.Text = "frmDadosR2010NFS";
            this.Load += new System.EventHandler(this.frmDadosR2010NFS_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoTpServ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtnumDocto;
        private System.Windows.Forms.TextBox txtvlrBruto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvInfoTpServ;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrBaseRet;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrRetencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrRetSub;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrNRetPrinc;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrServicos15;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrServicos20;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrServicos25;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrAdicional;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrNRetAdic;
        private System.Windows.Forms.DateTimePicker dtpDtEmissaoNF;
    }
}