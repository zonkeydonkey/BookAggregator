namespace Books
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.sheetStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSheetStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releasedBefore2000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releasedAfter2000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.allButton = new System.Windows.Forms.ToolStripButton();
            this.beforeButton = new System.Windows.Forms.ToolStripButton();
            this.afterButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sheetStripMenuItem,
            this.filterToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(996, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // sheetStripMenuItem
            // 
            this.sheetStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSheetStripMenuItem});
            this.sheetStripMenuItem.Name = "sheetStripMenuItem";
            this.sheetStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.sheetStripMenuItem.Text = "Sheet";
            // 
            // newSheetStripMenuItem
            // 
            this.newSheetStripMenuItem.Name = "newSheetStripMenuItem";
            this.newSheetStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newSheetStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.newSheetStripMenuItem.Text = "New";
            this.newSheetStripMenuItem.Click += new System.EventHandler(this.OnAddSheetClicked);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.releasedBefore2000ToolStripMenuItem,
            this.releasedAfter2000ToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.allToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.allToolStripMenuItem.Text = "All ";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.OnAllFilterClicked);
            // 
            // releasedBefore2000ToolStripMenuItem
            // 
            this.releasedBefore2000ToolStripMenuItem.Name = "releasedBefore2000ToolStripMenuItem";
            this.releasedBefore2000ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.releasedBefore2000ToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.releasedBefore2000ToolStripMenuItem.Text = "Released Before 2000";
            this.releasedBefore2000ToolStripMenuItem.Click += new System.EventHandler(this.OnBeforeFilterClicked);
            // 
            // releasedAfter2000ToolStripMenuItem
            // 
            this.releasedAfter2000ToolStripMenuItem.Name = "releasedAfter2000ToolStripMenuItem";
            this.releasedAfter2000ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.releasedAfter2000ToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.releasedAfter2000ToolStripMenuItem.Text = "Released After 2000";
            this.releasedAfter2000ToolStripMenuItem.Click += new System.EventHandler(this.OnAfterFilterClicked);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allButton,
            this.beforeButton,
            this.afterButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(996, 27);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip";
            // 
            // allButton
            // 
            this.allButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.allButton.Image = ((System.Drawing.Image)(resources.GetObject("allButton.Image")));
            this.allButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(24, 24);
            this.allButton.Text = "All";
            this.allButton.Click += new System.EventHandler(this.OnAllFilterClicked);
            // 
            // beforeButton
            // 
            this.beforeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.beforeButton.Image = ((System.Drawing.Image)(resources.GetObject("beforeButton.Image")));
            this.beforeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.beforeButton.Name = "beforeButton";
            this.beforeButton.Size = new System.Drawing.Size(24, 24);
            this.beforeButton.Text = "Released before 2000";
            this.beforeButton.Click += new System.EventHandler(this.OnBeforeFilterClicked);
            // 
            // afterButton
            // 
            this.afterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.afterButton.Image = ((System.Drawing.Image)(resources.GetObject("afterButton.Image")));
            this.afterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.afterButton.Name = "afterButton";
            this.afterButton.Size = new System.Drawing.Size(24, 24);
            this.afterButton.Text = "Released after 2000";
            this.afterButton.Click += new System.EventHandler(this.OnAfterFilterClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 542);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Books";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem sheetStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSheetStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releasedBefore2000ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releasedAfter2000ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton allButton;
        private System.Windows.Forms.ToolStripButton beforeButton;
        private System.Windows.Forms.ToolStripButton afterButton;
    }
}

