namespace Books
{
    partial class BookSheetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookSheetForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addBookToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.updateBookToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteBookToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.treeView = new System.Windows.Forms.TreeView();
            this.nbElementStatusBar = new System.Windows.Forms.StatusBar();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(629, 28);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.Visible = false;
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.bookToolStripMenuItem.Text = "Book";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.OnCreateBookClicked);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBookToolStripButton,
            this.updateBookToolStripButton,
            this.deleteBookToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(629, 27);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip";
            this.toolStrip.Visible = false;
            // 
            // addBookToolStripButton
            // 
            this.addBookToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBookToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addBookToolStripButton.Image")));
            this.addBookToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBookToolStripButton.Name = "addBookToolStripButton";
            this.addBookToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.addBookToolStripButton.Text = "Add Book";
            this.addBookToolStripButton.Click += new System.EventHandler(this.OnCreateBookClicked);
            // 
            // updateBookToolStripButton
            // 
            this.updateBookToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateBookToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("updateBookToolStripButton.Image")));
            this.updateBookToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateBookToolStripButton.Name = "updateBookToolStripButton";
            this.updateBookToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.updateBookToolStripButton.Text = "Edit Book";
            this.updateBookToolStripButton.Click += new System.EventHandler(this.OnEditBookClicked);
            // 
            // deleteBookToolStripButton
            // 
            this.deleteBookToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBookToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteBookToolStripButton.Image")));
            this.deleteBookToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBookToolStripButton.Name = "deleteBookToolStripButton";
            this.deleteBookToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.deleteBookToolStripButton.Text = "Delete Book";
            this.deleteBookToolStripButton.Click += new System.EventHandler(this.OnDeleteBookClicked);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 56);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(617, 370);
            this.treeView.TabIndex = 2;
            // 
            // nbElementsLabel
            // 
            this.nbElementStatusBar.AutoSize = true;
            this.nbElementStatusBar.Location = new System.Drawing.Point(12, 429);
            this.nbElementStatusBar.Name = "nbElementsLabel";
            this.nbElementStatusBar.Size = new System.Drawing.Size(0, 17);
            this.nbElementStatusBar.TabIndex = 5;
            this.nbElementStatusBar.Visible = false;
            // 
            // BookSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 449);
            this.Controls.Add(this.nbElementStatusBar);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BookSheetForm";
            this.Text = "Books Sheet";
            this.Load += new System.EventHandler(this.OnBookSheetFormLoad);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.MenuStrip menuStrip;
        protected System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        protected System.Windows.Forms.ToolStrip toolStrip;
        protected System.Windows.Forms.ToolStripButton addBookToolStripButton;
        protected System.Windows.Forms.ToolStripButton updateBookToolStripButton;
        protected System.Windows.Forms.ToolStripButton deleteBookToolStripButton;
        protected System.Windows.Forms.TreeView treeView;
        protected System.Windows.Forms.StatusBar nbElementStatusBar;
    }
}