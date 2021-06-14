namespace WFATesteAssinaturaXML
{
    partial class frmDadosR2060tipoAjuste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDadosR2060tipoAjuste));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVlrAjuste = new System.Windows.Forms.TextBox();
            this.txtDescAjuste = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTpAjuste = new System.Windows.Forms.ComboBox();
            this.cmbCodAjuste = new System.Windows.Forms.ComboBox();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Location = new System.Drawing.Point(529, 146);
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
            this.buttonCancel.Location = new System.Drawing.Point(610, 146);
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
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tipo de Ajuste";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Valor do Ajuste";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Código do Ajuste";
            // 
            // txtVlrAjuste
            // 
            this.txtVlrAjuste.Location = new System.Drawing.Point(212, 67);
            this.txtVlrAjuste.Name = "txtVlrAjuste";
            this.txtVlrAjuste.Size = new System.Drawing.Size(181, 20);
            this.txtVlrAjuste.TabIndex = 27;
            // 
            // txtDescAjuste
            // 
            this.txtDescAjuste.Location = new System.Drawing.Point(212, 93);
            this.txtDescAjuste.Name = "txtDescAjuste";
            this.txtDescAjuste.Size = new System.Drawing.Size(476, 20);
            this.txtDescAjuste.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Descrição";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Mês/Ano AjusteData ";
            // 
            // cmbTpAjuste
            // 
            this.cmbTpAjuste.FormattingEnabled = true;
            this.cmbTpAjuste.Items.AddRange(new object[] {
            "0 - Ajuste de Redução",
            "1 - Ajuste de Acréscimo"});
            this.cmbTpAjuste.Location = new System.Drawing.Point(212, 13);
            this.cmbTpAjuste.Name = "cmbTpAjuste";
            this.cmbTpAjuste.Size = new System.Drawing.Size(476, 21);
            this.cmbTpAjuste.TabIndex = 33;
            // 
            // cmbCodAjuste
            // 
            this.cmbCodAjuste.FormattingEnabled = true;
            this.cmbCodAjuste.Items.AddRange(new object[] {
            "1 - Ajuste da CPRB: Adoção de Regime de Caixa",
            "2 - Ajuste da CPRB: Diferimento de Valores a Recolher no Período",
            "3 - Adição de valores Diferidos em Período(s) Anterior(es)",
            "4 - Exportações diretas",
            "5 -Transporte internacional de cargas",
            "6 - Vendas canceladas e os descontos incodicionais concedidos",
            "7 - IPI, se incluído na receita bruta",
            "8 - ICMS, quadno cobrado pelo vendedor dos bens ou prestador dos serviçoes na con" +
                "dição de substituto tributário",
            resources.GetString("cmbCodAjuste.Items"),
            "10 - O valor do aporte de recursos realizado nos termos do art 6 inciso III da Le" +
                "i 11.079/2004",
            "11 - Demais ajustes oriundos da Legislação Tributária, estorno ou outras situaçõe" +
                "s"});
            this.cmbCodAjuste.Location = new System.Drawing.Point(212, 40);
            this.cmbCodAjuste.Name = "cmbCodAjuste";
            this.cmbCodAjuste.Size = new System.Drawing.Size(476, 21);
            this.cmbCodAjuste.TabIndex = 34;
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodo.Location = new System.Drawing.Point(212, 116);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodo.TabIndex = 35;
            // 
            // frmDadosR2060tipoAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(696, 175);
            this.Controls.Add(this.dtpPeriodo);
            this.Controls.Add(this.cmbCodAjuste);
            this.Controls.Add(this.cmbTpAjuste);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescAjuste);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVlrAjuste);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "frmDadosR2060tipoAjuste";
            this.Text = "frmDadosR2060tipoAjuste";
            this.Load += new System.EventHandler(this.frmDadosR2060tipoAjuste_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVlrAjuste;
        private System.Windows.Forms.TextBox txtDescAjuste;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTpAjuste;
        private System.Windows.Forms.ComboBox cmbCodAjuste;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
    }
}