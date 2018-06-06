namespace WindowsFormsApplication1
{
    partial class FormMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cUSTOMERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cUSTOMERToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iNVENTARISOBATToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iNVENTARISOBATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sIGNOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cUSTOMERToolStripMenuItem,
            this.iNVENTARISOBATToolStripMenuItem,
            this.sIGNOUTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cUSTOMERToolStripMenuItem
            // 
            this.cUSTOMERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cUSTOMERToolStripMenuItem1,
            this.iNVENTARISOBATToolStripMenuItem1});
            this.cUSTOMERToolStripMenuItem.Name = "cUSTOMERToolStripMenuItem";
            this.cUSTOMERToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.cUSTOMERToolStripMenuItem.Text = "MASTER DATA";
            // 
            // cUSTOMERToolStripMenuItem1
            // 
            this.cUSTOMERToolStripMenuItem1.Name = "cUSTOMERToolStripMenuItem1";
            this.cUSTOMERToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.cUSTOMERToolStripMenuItem1.Text = "CUSTOMER";
            this.cUSTOMERToolStripMenuItem1.Click += new System.EventHandler(this.cUSTOMERToolStripMenuItem1_Click);
            // 
            // iNVENTARISOBATToolStripMenuItem1
            // 
            this.iNVENTARISOBATToolStripMenuItem1.Name = "iNVENTARISOBATToolStripMenuItem1";
            this.iNVENTARISOBATToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.iNVENTARISOBATToolStripMenuItem1.Text = "INVENTARIS OBAT";
            this.iNVENTARISOBATToolStripMenuItem1.Click += new System.EventHandler(this.iNVENTARISOBATToolStripMenuItem1_Click);
            // 
            // iNVENTARISOBATToolStripMenuItem
            // 
            this.iNVENTARISOBATToolStripMenuItem.Name = "iNVENTARISOBATToolStripMenuItem";
            this.iNVENTARISOBATToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.iNVENTARISOBATToolStripMenuItem.Text = "TRANSAKSI";
            this.iNVENTARISOBATToolStripMenuItem.Click += new System.EventHandler(this.iNVENTARISOBATToolStripMenuItem_Click);
            // 
            // sIGNOUTToolStripMenuItem
            // 
            this.sIGNOUTToolStripMenuItem.Name = "sIGNOUTToolStripMenuItem";
            this.sIGNOUTToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.sIGNOUTToolStripMenuItem.Text = "SIGN OUT";
            this.sIGNOUTToolStripMenuItem.Click += new System.EventHandler(this.sIGNOUTToolStripMenuItem_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.permintaan_obat_alkes_meningkat_dampaknya_R5IPWNgyCy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(731, 469);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cUSTOMERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cUSTOMERToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iNVENTARISOBATToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iNVENTARISOBATToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sIGNOUTToolStripMenuItem;
    }
}