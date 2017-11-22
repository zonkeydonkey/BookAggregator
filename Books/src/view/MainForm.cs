using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    public partial class MainForm : Form
    {
        private BookDocument bookDocument = null;

        private static int FilterItemMenuIndex = 1;
        private static int FilterItemMenuChildNb = 3;

        public MainForm()
        {
            this.bookDocument = new BookDocument();
            InitializeComponent();
        }

        private void OnAddSheetClicked(object sender, EventArgs e)
        {
            OnNewSheet();
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            OnNewSheet();
        }

        private void OnNewSheet()
        {
            BookSheetForm newBookSheet = new BookSheetForm(bookDocument)
            {
                MdiParent = this
            };
            AssignEventHandlers(newBookSheet);
            newBookSheet.Show();
        }

        private void OnAllFilterClicked(object sender, EventArgs e)
        {
            OnFilterClicked(BookFilteredSheetForm.Filter.All);
        }

        private void OnBeforeFilterClicked(object sender, EventArgs e)
        {
            OnFilterClicked(BookFilteredSheetForm.Filter.Before);
        }

        private void OnAfterFilterClicked(object sender, EventArgs e)
        {
            OnFilterClicked(BookFilteredSheetForm.Filter.After);
        }

        private void OnFilterClicked(BookFilteredSheetForm.Filter filter)
        {
            if (ActiveMdiChild.GetType() == typeof(BookFilteredSheetForm))
            {
                BookFilteredSheetForm activeForm = (BookFilteredSheetForm)ActiveMdiChild;
                activeForm.ChangeFilterType(filter);
                ResetCheck();
                SetCheck((int)activeForm.DateFilter);
            }
            else
            {
                BookFilteredSheetForm newBookSheet = new BookFilteredSheetForm(bookDocument, filter)
                {
                    MdiParent = this
                };
                AssignEventHandlers(newBookSheet);
                newBookSheet.Show();
            }
        }

        private void AssignEventHandlers(BookSheetForm sheet)
        {
            sheet.Activated += new EventHandler(OnChildActivated);
            sheet.Deactivate += new EventHandler(OnChildDeactivate);
        }

        private void OnChildActivated(object sender, EventArgs e)
        {
            ToolStrip sourceToolStrip = ((IChildForm)this.ActiveMdiChild).GetToolStrip();
            ToolStripManager.Merge(sourceToolStrip, toolStrip);

            StatusBar sourceStatusBar = ((IChildForm)this.ActiveMdiChild).GetStatusBar();
            this.Controls.Add(sourceStatusBar);
            sourceStatusBar.Visible = true;

            if (ActiveMdiChild.GetType() == typeof(BookFilteredSheetForm))
            {
                BookFilteredSheetForm activeForm = (BookFilteredSheetForm)ActiveMdiChild;
                SetCheck((int)activeForm.DateFilter);
            }
        }

        private void OnChildDeactivate(object sender, EventArgs e)
        {
            ToolStrip sourceToolStrip = ((IChildForm)this.ActiveMdiChild).GetToolStrip();
            ToolStripManager.RevertMerge(toolStrip, sourceToolStrip);

            StatusBar sourceStatusBar = ((IChildForm)this.ActiveMdiChild).GetStatusBar();
            this.Controls.Remove(sourceStatusBar);

            ResetCheck();
        }

        private void SetCheck(int index)
        {
            ToolStripMenuItem filterItem = (ToolStripMenuItem)menuStrip.Items[FilterItemMenuIndex];
            ((ToolStripMenuItem)(filterItem).DropDown.Items[index]).Checked = true;
        }

        private void ResetCheck()
        {
            for(int i = 0; i < FilterItemMenuChildNb; ++i)
            {
                ToolStripMenuItem filterItem = (ToolStripMenuItem)menuStrip.Items[FilterItemMenuIndex];
                ((ToolStripMenuItem)(filterItem).DropDown.Items[i]).Checked = false;
            }
        }
    }
}
