using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    public partial class MainForm : Form
    {
        private BookDocument bookDocument = null;

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

        private void OnBookCreated(object sender, EventArgs e, Book b)
        {
            foreach (Form child in MdiChildren.AsNotNull())
            {
                ((IChildForm)child).OnBookCreated(b);
            }
        }

        private void OnBookEdited(object sender, EventArgs e, Book edited, Book old)
        {
            foreach (Form child in MdiChildren.AsNotNull())
            {
                ((IChildForm)child).OnBookEdited(edited, old);
            }
        }

        private void OnBookDeleted(object sender, EventArgs e, Book book)
        {
            foreach (Form child in MdiChildren.AsNotNull())
            {
                ((IChildForm)child).OnBookDeleted(book);
            }
        }

        private void OnAllFilterClicked(object sender, EventArgs e)
        {
            BookFilteredSheetForm newBookSheet = new BookFilteredSheetForm(bookDocument, BookFilteredSheetForm.Filter.All)
            {
                MdiParent = this
            };
            AssignEventHandlers(newBookSheet);
            newBookSheet.Show();
        }

        private void OnBeforeFilterClicked(object sender, EventArgs e)
        {
            BookFilteredSheetForm newBookSheet = new BookFilteredSheetForm(bookDocument, BookFilteredSheetForm.Filter.Before)
            {
                MdiParent = this
            };
            AssignEventHandlers(newBookSheet);
            newBookSheet.Show();
        }

        private void OnAfterFilterClicked(object sender, EventArgs e)
        {
            BookFilteredSheetForm newBookSheet = new BookFilteredSheetForm(bookDocument, BookFilteredSheetForm.Filter.After)
            {
                MdiParent = this
            };
            AssignEventHandlers(newBookSheet);
            newBookSheet.Show();
        }

        private void AssignEventHandlers(BookSheetForm sheet)
        {
            sheet.BookCreated += new Events.BookCreatedEventHandler(OnBookCreated);
            sheet.BookEdited += new Events.BookEditedEventHandler(OnBookEdited);
            sheet.BookDeleted += new Events.BookDeletedEventHandler(OnBookDeleted);
            sheet.Closing += new CancelEventHandler(OnChildClosing);
            sheet.Activated += new EventHandler(OnChildActivated);
            sheet.Deactivate += new EventHandler(OnChildDeactivate);
        }

        private void OnChildClosing(object sender, CancelEventArgs e)
        {
            if (MdiChildren.Length == 1)
            {
                e.Cancel = true;
                MessageBox.Show("At least one sheet must be open.");
            }
        }

        private void OnChildActivated(object sender, EventArgs e)
        {
            ToolStrip source = ((IChildForm)this.ActiveMdiChild).GetToolStrip();
            ToolStripManager.Merge(source, toolStrip);
        }

        private void OnChildDeactivate(object sender, EventArgs e)
        {
            ToolStrip source = ((IChildForm)this.ActiveMdiChild).GetToolStrip();
            ToolStripManager.RevertMerge(toolStrip, source);
        }
    }
}
