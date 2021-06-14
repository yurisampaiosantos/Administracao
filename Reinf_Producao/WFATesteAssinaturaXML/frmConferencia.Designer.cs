namespace WFATesteAssinaturaXML
{
    partial class frmConferencia
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
            this.labelPeriodo = new System.Windows.Forms.Label();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.cmbEstabelecimento = new System.Windows.Forms.ComboBox();
            this.labelEstab = new System.Windows.Forms.Label();
            this.comboBoxMatriz = new System.Windows.Forms.ComboBox();
            this.labelEmpresa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEventos = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPeriodo
            // 
            this.labelPeriodo.AutoSize = true;
            this.labelPeriodo.Location = new System.Drawing.Point(8, 99);
            this.labelPeriodo.Name = "labelPeriodo";
            this.labelPeriodo.Size = new System.Drawing.Size(48, 13);
            this.labelPeriodo.TabIndex = 41;
            this.labelPeriodo.Text = "Período:";
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodo.Location = new System.Drawing.Point(109, 93);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodo.TabIndex = 40;
            // 
            // cmbEstabelecimento
            // 
            this.cmbEstabelecimento.FormattingEnabled = true;
            this.cmbEstabelecimento.Location = new System.Drawing.Point(109, 63);
            this.cmbEstabelecimento.Name = "cmbEstabelecimento";
            this.cmbEstabelecimento.Size = new System.Drawing.Size(340, 21);
            this.cmbEstabelecimento.TabIndex = 39;
            // 
            // labelEstab
            // 
            this.labelEstab.AutoSize = true;
            this.labelEstab.Location = new System.Drawing.Point(8, 66);
            this.labelEstab.Name = "labelEstab";
            this.labelEstab.Size = new System.Drawing.Size(88, 13);
            this.labelEstab.TabIndex = 38;
            this.labelEstab.Text = "Estabelecimento:";
            // 
            // comboBoxMatriz
            // 
            this.comboBoxMatriz.FormattingEnabled = true;
            this.comboBoxMatriz.Location = new System.Drawing.Point(109, 36);
            this.comboBoxMatriz.Name = "comboBoxMatriz";
            this.comboBoxMatriz.Size = new System.Drawing.Size(340, 21);
            this.comboBoxMatriz.TabIndex = 37;
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.AutoSize = true;
            this.labelEmpresa.Location = new System.Drawing.Point(8, 39);
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(51, 13);
            this.labelEmpresa.TabIndex = 36;
            this.labelEmpresa.Text = "Empresa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Evento:";
            // 
            // cmbEventos
            // 
            this.cmbEventos.FormattingEnabled = true;
            this.cmbEventos.Location = new System.Drawing.Point(109, 9);
            this.cmbEventos.Name = "cmbEventos";
            this.cmbEventos.Size = new System.Drawing.Size(340, 21);
            this.cmbEventos.TabIndex = 43;
            this.cmbEventos.SelectedIndexChanged += new System.EventHandler(this.cmbEventos_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(851, 428);
            this.dataGridView1.TabIndex = 45;
            // 
            // frmConferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(874, 568);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbEventos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelPeriodo);
            this.Controls.Add(this.dtpPeriodo);
            this.Controls.Add(this.cmbEstabelecimento);
            this.Controls.Add(this.labelEstab);
            this.Controls.Add(this.comboBoxMatriz);
            this.Controls.Add(this.labelEmpresa);
            this.Name = "frmConferencia";
            this.Text = "frmConferencia";
            this.Load += new System.EventHandler(this.frmConferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPeriodo;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
        private System.Windows.Forms.ComboBox cmbEstabelecimento;
        private System.Windows.Forms.Label labelEstab;
        private System.Windows.Forms.ComboBox comboBoxMatriz;
        private System.Windows.Forms.Label labelEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEventos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}