namespace WFATesteAssinaturaXML
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estabelecimentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.responsáveisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conferênciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbVersao = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventosToolStripMenuItem,
            this.operaçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(697, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eventosToolStripMenuItem
            // 
            this.eventosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caToolStripMenuItem,
            this.empresasToolStripMenuItem,
            this.estabelecimentosToolStripMenuItem,
            this.responsáveisToolStripMenuItem});
            this.eventosToolStripMenuItem.Name = "eventosToolStripMenuItem";
            this.eventosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.eventosToolStripMenuItem.Text = "Cadastros";
            // 
            // caToolStripMenuItem
            // 
            this.caToolStripMenuItem.Name = "caToolStripMenuItem";
            this.caToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.caToolStripMenuItem.Text = "Eventos";
            this.caToolStripMenuItem.Click += new System.EventHandler(this.caToolStripMenuItem_Click);
            // 
            // empresasToolStripMenuItem
            // 
            this.empresasToolStripMenuItem.Name = "empresasToolStripMenuItem";
            this.empresasToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.empresasToolStripMenuItem.Text = "Empresas";
            this.empresasToolStripMenuItem.Click += new System.EventHandler(this.empresasToolStripMenuItem_Click);
            // 
            // estabelecimentosToolStripMenuItem
            // 
            this.estabelecimentosToolStripMenuItem.Name = "estabelecimentosToolStripMenuItem";
            this.estabelecimentosToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.estabelecimentosToolStripMenuItem.Text = "Estabelecimentos";
            this.estabelecimentosToolStripMenuItem.Click += new System.EventHandler(this.estabelecimentosToolStripMenuItem_Click);
            // 
            // responsáveisToolStripMenuItem
            // 
            this.responsáveisToolStripMenuItem.Name = "responsáveisToolStripMenuItem";
            this.responsáveisToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.responsáveisToolStripMenuItem.Text = "Responsáveis";
            this.responsáveisToolStripMenuItem.Click += new System.EventHandler(this.responsáveisToolStripMenuItem_Click);
            // 
            // operaçõesToolStripMenuItem
            // 
            this.operaçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitorEventosToolStripMenuItem,
            this.workFlowToolStripMenuItem,
            this.conferênciaToolStripMenuItem});
            this.operaçõesToolStripMenuItem.Name = "operaçõesToolStripMenuItem";
            this.operaçõesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.operaçõesToolStripMenuItem.Text = "Operações";
            // 
            // monitorEventosToolStripMenuItem
            // 
            this.monitorEventosToolStripMenuItem.Name = "monitorEventosToolStripMenuItem";
            this.monitorEventosToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.monitorEventosToolStripMenuItem.Text = "Monitor Eventos";
            this.monitorEventosToolStripMenuItem.Click += new System.EventHandler(this.monitorEventosToolStripMenuItem_Click);
            // 
            // workFlowToolStripMenuItem
            // 
            this.workFlowToolStripMenuItem.Name = "workFlowToolStripMenuItem";
            this.workFlowToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.workFlowToolStripMenuItem.Text = "WorkFlow";
            this.workFlowToolStripMenuItem.Click += new System.EventHandler(this.workFlowToolStripMenuItem_Click);
            // 
            // conferênciaToolStripMenuItem
            // 
            this.conferênciaToolStripMenuItem.Name = "conferênciaToolStripMenuItem";
            this.conferênciaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.conferênciaToolStripMenuItem.Text = "Conferência";
            this.conferênciaToolStripMenuItem.Click += new System.EventHandler(this.conferênciaToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Linen;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(697, 382);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(492, 353);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lbVersao
            // 
            this.lbVersao.AutoSize = true;
            this.lbVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersao.Location = new System.Drawing.Point(491, 338);
            this.lbVersao.Name = "lbVersao";
            this.lbVersao.Size = new System.Drawing.Size(51, 15);
            this.lbVersao.TabIndex = 4;
            this.lbVersao.Text = "Versão";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(697, 406);
            this.Controls.Add(this.lbVersao);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Reinf - ENSEADA";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eventosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empresasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estabelecimentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorEventosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem responsáveisToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem conferênciaToolStripMenuItem;
        private System.Windows.Forms.Label lbVersao;
    }
}