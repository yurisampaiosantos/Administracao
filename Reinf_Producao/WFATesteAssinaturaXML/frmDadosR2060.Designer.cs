namespace WFATesteAssinaturaXML
{
    partial class frmDadosR2060
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVlrRecBrutaTotal = new System.Windows.Forms.TextBox();
            this.txtVlrCPApurTotal = new System.Windows.Forms.TextBox();
            this.txtCPRBSuspTotal = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTipoCod = new System.Windows.Forms.DataGridView();
            this.idReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codAtivEcon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrRecBrutaAtiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrExcRecBruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrAdicRecBruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrBcCPRB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrCPRBapur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbIdentRetif = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNrRecibo = new System.Windows.Forms.TextBox();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoCod)).BeginInit();
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
            this.cmbEstabelecimento.FormattingEnabled = true;
            this.cmbEstabelecimento.Location = new System.Drawing.Point(111, 30);
            this.cmbEstabelecimento.Name = "cmbEstabelecimento";
            this.cmbEstabelecimento.Size = new System.Drawing.Size(413, 21);
            this.cmbEstabelecimento.TabIndex = 6;
            // 
            // dtpPeriodoIni
            // 
            this.dtpPeriodoIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodoIni.Location = new System.Drawing.Point(111, 57);
            this.dtpPeriodoIni.Name = "dtpPeriodoIni";
            this.dtpPeriodoIni.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodoIni.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Período:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Valor da Receita Bruta Total do Estabelecimento no Período :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Valor da Contribuição Previdenciária com exigibildade Suspensa :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(304, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Valor total da Contribuição Previdenciária sobre Receita Bruta :";
            // 
            // txtVlrRecBrutaTotal
            // 
            this.txtVlrRecBrutaTotal.Location = new System.Drawing.Point(343, 86);
            this.txtVlrRecBrutaTotal.Name = "txtVlrRecBrutaTotal";
            this.txtVlrRecBrutaTotal.Size = new System.Drawing.Size(181, 20);
            this.txtVlrRecBrutaTotal.TabIndex = 25;
            // 
            // txtVlrCPApurTotal
            // 
            this.txtVlrCPApurTotal.Location = new System.Drawing.Point(343, 113);
            this.txtVlrCPApurTotal.Name = "txtVlrCPApurTotal";
            this.txtVlrCPApurTotal.Size = new System.Drawing.Size(181, 20);
            this.txtVlrCPApurTotal.TabIndex = 26;
            // 
            // txtCPRBSuspTotal
            // 
            this.txtCPRBSuspTotal.Location = new System.Drawing.Point(343, 140);
            this.txtCPRBSuspTotal.Name = "txtCPRBSuspTotal";
            this.txtCPRBSuspTotal.Size = new System.Drawing.Size(181, 20);
            this.txtCPRBSuspTotal.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvTipoCod);
            this.panel1.Location = new System.Drawing.Point(12, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 257);
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
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 27);
            this.panel2.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(257, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Receita por Código de Atividade Economica";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTipoCod
            // 
            this.dgvTipoCod.AllowUserToAddRows = false;
            this.dgvTipoCod.AllowUserToDeleteRows = false;
            this.dgvTipoCod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoCod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReg,
            this.codAtivEcon,
            this.vlrRecBrutaAtiv,
            this.vlrExcRecBruta,
            this.vlrAdicRecBruta,
            this.vlrBcCPRB,
            this.vlrCPRBapur});
            this.dgvTipoCod.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTipoCod.Location = new System.Drawing.Point(0, 60);
            this.dgvTipoCod.Name = "dgvTipoCod";
            this.dgvTipoCod.ReadOnly = true;
            this.dgvTipoCod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTipoCod.Size = new System.Drawing.Size(702, 197);
            this.dgvTipoCod.TabIndex = 36;
            // 
            // idReg
            // 
            this.idReg.DataPropertyName = "idReg";
            this.idReg.HeaderText = "idReg";
            this.idReg.Name = "idReg";
            this.idReg.ReadOnly = true;
            this.idReg.Width = 50;
            // 
            // codAtivEcon
            // 
            this.codAtivEcon.DataPropertyName = "codAtivEcon";
            this.codAtivEcon.HeaderText = "codAtivEcon";
            this.codAtivEcon.Name = "codAtivEcon";
            this.codAtivEcon.ReadOnly = true;
            // 
            // vlrRecBrutaAtiv
            // 
            this.vlrRecBrutaAtiv.DataPropertyName = "vlrRecBrutaAtiv";
            this.vlrRecBrutaAtiv.HeaderText = "vlrRecBrutaAtiv";
            this.vlrRecBrutaAtiv.Name = "vlrRecBrutaAtiv";
            this.vlrRecBrutaAtiv.ReadOnly = true;
            // 
            // vlrExcRecBruta
            // 
            this.vlrExcRecBruta.DataPropertyName = "vlrExcRecBruta";
            this.vlrExcRecBruta.HeaderText = "vlrExcRecBruta";
            this.vlrExcRecBruta.Name = "vlrExcRecBruta";
            this.vlrExcRecBruta.ReadOnly = true;
            // 
            // vlrAdicRecBruta
            // 
            this.vlrAdicRecBruta.DataPropertyName = "vlrAdicRecBruta";
            this.vlrAdicRecBruta.HeaderText = "vlrAdicRecBruta";
            this.vlrAdicRecBruta.Name = "vlrAdicRecBruta";
            this.vlrAdicRecBruta.ReadOnly = true;
            // 
            // vlrBcCPRB
            // 
            this.vlrBcCPRB.DataPropertyName = "vlrBcCPRB";
            this.vlrBcCPRB.HeaderText = "vlrBcCPRB";
            this.vlrBcCPRB.Name = "vlrBcCPRB";
            this.vlrBcCPRB.ReadOnly = true;
            // 
            // vlrCPRBapur
            // 
            this.vlrCPRBapur.DataPropertyName = "vlrCPRBapur";
            this.vlrCPRBapur.HeaderText = "vlrCPRBapur";
            this.vlrCPRBapur.Name = "vlrCPRBapur";
            this.vlrCPRBapur.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Indentificador de Retificação";
            // 
            // cmbIdentRetif
            // 
            this.cmbIdentRetif.FormattingEnabled = true;
            this.cmbIdentRetif.Items.AddRange(new object[] {
            "1 - Arquivo Original",
            "2 - Arquivo de Retificação"});
            this.cmbIdentRetif.Location = new System.Drawing.Point(177, 166);
            this.cmbIdentRetif.Name = "cmbIdentRetif";
            this.cmbIdentRetif.Size = new System.Drawing.Size(347, 21);
            this.cmbIdentRetif.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Nº Recibo";
            // 
            // txtNrRecibo
            // 
            this.txtNrRecibo.Location = new System.Drawing.Point(177, 193);
            this.txtNrRecibo.Name = "txtNrRecibo";
            this.txtNrRecibo.Size = new System.Drawing.Size(347, 20);
            this.txtNrRecibo.TabIndex = 35;
            // 
            // cmbEmpresa
            // 
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
            // frmDadosR2060
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(743, 532);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNrRecibo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbIdentRetif);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCPRBSuspTotal);
            this.Controls.Add(this.txtVlrCPApurTotal);
            this.Controls.Add(this.txtVlrRecBrutaTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpPeriodoIni);
            this.Controls.Add(this.cmbEstabelecimento);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label2);
            this.Name = "frmDadosR2060";
            this.Text = "frmDadosR2060";
            this.Load += new System.EventHandler(this.frmDadosR2060_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoCod)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVlrRecBrutaTotal;
        private System.Windows.Forms.TextBox txtVlrCPApurTotal;
        private System.Windows.Forms.TextBox txtCPRBSuspTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvTipoCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn codAtivEcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrRecBrutaAtiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrExcRecBruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrAdicRecBruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrBcCPRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrCPRBapur;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbIdentRetif;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNrRecibo;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label label9;
    }
}