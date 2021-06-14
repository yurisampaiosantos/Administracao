namespace WFATesteAssinaturaXML
{
    partial class frmDadosR1000
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
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.cmbResponsavel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClassTrib = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbECD = new System.Windows.Forms.ComboBox();
            this.cmbIndAcordo = new System.Windows.Forms.ComboBox();
            this.cmbIndDesoneracao = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbIndSitPJ = new System.Windows.Forms.ComboBox();
            this.dtpPeriodoIni = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpPeriodoFim = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Empresa:";
            // 
            // buttonOk
            // 
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Location = new System.Drawing.Point(251, 253);
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
            this.buttonCancel.Location = new System.Drawing.Point(332, 253);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(111, 7);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(296, 21);
            this.cmbEmpresa.TabIndex = 6;
            // 
            // cmbResponsavel
            // 
            this.cmbResponsavel.FormattingEnabled = true;
            this.cmbResponsavel.Location = new System.Drawing.Point(111, 179);
            this.cmbResponsavel.Name = "cmbResponsavel";
            this.cmbResponsavel.Size = new System.Drawing.Size(296, 21);
            this.cmbResponsavel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Responsável:";
            // 
            // cmbClassTrib
            // 
            this.cmbClassTrib.FormattingEnabled = true;
            this.cmbClassTrib.Items.AddRange(new object[] {
            "01 - Empresa enquadrada no regime de tributação Simples Nacional com tributação p" +
                "revidenciária substituída",
            "02 - Empresa enquadrada no regime de tributação Simples Nacional com tributação p" +
                "revidenciária não substituída",
            "03 - Empresa enquadrada no regime de tributação Simples Nacional com tributação p" +
                "revidenciária substituída e não substituída",
            "04 - MEI - Micro Empreendedor Individual",
            "06 - Agroindústria",
            "07 - Produtor Rural Pessoa Jurídica",
            "08 - Consórcio Simplificado de Produtores Rurais",
            "09 - Órgão Gestor de Mão de Obra",
            "10 - Entidade Sindical a que se refere a Lei 12.023/2009",
            "11 - Associação Desportiva que mantém Clube de Futebol Profissional",
            "13 - Banco, caixa econômica, sociedade de crédito, financiamento e investimento e" +
                " demais empresas relacionadas no parágrafo 1º do art. 22 da Lei 8.212./91",
            "14 - Sindicatos em geral, exceto aquele classificado no código [10]",
            "21 - Pessoa Física, exceto Segurado Especial",
            "22 - Segurado Especial",
            "60 - Missão Diplomática ou Repartição Consular de carreira estrangeira",
            "70 - Empresa de que trata o Decreto 5.436/2005",
            "80 - Entidade Beneficente/Isenta",
            "85 - Ente Federativo, Orgãos da União, Autarquias e Fundações Públicas",
            "99 - Pessoas Jurídicas em Geral"});
            this.cmbClassTrib.Location = new System.Drawing.Point(111, 34);
            this.cmbClassTrib.Name = "cmbClassTrib";
            this.cmbClassTrib.Size = new System.Drawing.Size(296, 21);
            this.cmbClassTrib.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Class. Tributária:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Entrega ECD :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ind. Acordo Isenção de Multa:";
            // 
            // cmbECD
            // 
            this.cmbECD.FormattingEnabled = true;
            this.cmbECD.Items.AddRange(new object[] {
            "0 - Nao Faz",
            "1 - Empresa entrega ECD"});
            this.cmbECD.Location = new System.Drawing.Point(111, 64);
            this.cmbECD.Name = "cmbECD";
            this.cmbECD.Size = new System.Drawing.Size(296, 21);
            this.cmbECD.TabIndex = 14;
            // 
            // cmbIndAcordo
            // 
            this.cmbIndAcordo.FormattingEnabled = true;
            this.cmbIndAcordo.Items.AddRange(new object[] {
            "0 - Sem acordo",
            "1 - Com acordo"});
            this.cmbIndAcordo.Location = new System.Drawing.Point(167, 118);
            this.cmbIndAcordo.Name = "cmbIndAcordo";
            this.cmbIndAcordo.Size = new System.Drawing.Size(240, 21);
            this.cmbIndAcordo.TabIndex = 15;
            // 
            // cmbIndDesoneracao
            // 
            this.cmbIndDesoneracao.FormattingEnabled = true;
            this.cmbIndDesoneracao.Items.AddRange(new object[] {
            "0 - Não aplicável",
            "1 - Empresa enquadra nos termos da Leu 12.546/2011 e alterações"});
            this.cmbIndDesoneracao.Location = new System.Drawing.Point(111, 91);
            this.cmbIndDesoneracao.Name = "cmbIndDesoneracao";
            this.cmbIndDesoneracao.Size = new System.Drawing.Size(296, 21);
            this.cmbIndDesoneracao.TabIndex = 17;
            this.cmbIndDesoneracao.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ind. Desoneração:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ind Situ. PJ:";
            // 
            // cmbIndSitPJ
            // 
            this.cmbIndSitPJ.FormattingEnabled = true;
            this.cmbIndSitPJ.Items.AddRange(new object[] {
            "0 - Situação Normal",
            "1 - Extinção",
            "2 - Fusão",
            "3 - Cisão",
            "4 - Incorporação"});
            this.cmbIndSitPJ.Location = new System.Drawing.Point(111, 150);
            this.cmbIndSitPJ.Name = "cmbIndSitPJ";
            this.cmbIndSitPJ.Size = new System.Drawing.Size(296, 21);
            this.cmbIndSitPJ.TabIndex = 19;
            // 
            // dtpPeriodoIni
            // 
            this.dtpPeriodoIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodoIni.Location = new System.Drawing.Point(111, 206);
            this.dtpPeriodoIni.Name = "dtpPeriodoIni";
            this.dtpPeriodoIni.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodoIni.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Ini Validade:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Fim Validade:";
            // 
            // dtpPeriodoFim
            // 
            this.dtpPeriodoFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodoFim.Location = new System.Drawing.Point(306, 207);
            this.dtpPeriodoFim.Name = "dtpPeriodoFim";
            this.dtpPeriodoFim.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodoFim.TabIndex = 22;
            // 
            // frmDadosR1000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(425, 298);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpPeriodoFim);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpPeriodoIni);
            this.Controls.Add(this.cmbIndSitPJ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbIndDesoneracao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbIndAcordo);
            this.Controls.Add(this.cmbECD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbClassTrib);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbResponsavel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label2);
            this.Name = "frmDadosR1000";
            this.Text = "frmDadosR1000";
            this.Load += new System.EventHandler(this.frmDadosR1000_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.ComboBox cmbResponsavel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClassTrib;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbECD;
        private System.Windows.Forms.ComboBox cmbIndAcordo;
        private System.Windows.Forms.ComboBox cmbIndDesoneracao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbIndSitPJ;
        private System.Windows.Forms.DateTimePicker dtpPeriodoIni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpPeriodoFim;
    }
}