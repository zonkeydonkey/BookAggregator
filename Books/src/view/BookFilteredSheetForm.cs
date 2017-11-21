using System;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    public partial class BookFilteredSheetForm : BookSheetForm, IChildForm
    {
        public enum Filter { All, Before, After };
        private Filter filter;

        private static DateTime boundaryDate = DateTime.Parse("01/01/2000");

        private delegate bool FilterPredicate(Book book);

        public BookFilteredSheetForm() : base()
        {
            InitializeComponent();
            filter = Filter.All;
        }

        public BookFilteredSheetForm(BookDocument bookDocument) : base(bookDocument)
        {
            InitializeComponent();
            filter = Filter.All;
        }

        public BookFilteredSheetForm(BookDocument bookDocument, Filter filter) : base(bookDocument)
        {
            InitializeComponent();
            this.filter = filter;
        }

        private void OnRefresh ()
        {
            treeView.Nodes.Clear();
            if (filter == Filter.All)
            {
                OnTreeViewLoad();
            }
            else if (filter == Filter.Before)
            {
                OnFilterLoad(ReleasedBefore);
            }
            else if (filter == Filter.After)
            {
                OnFilterLoad(ReleasedAfter);
            }
            nbElementsLabel.Text = ElementNbPrefix + treeView.Nodes.Count;
    }

        protected override void OnBookSheetFormLoad(object sender, EventArgs e)
        {
            this.Text = filter.ToString();
            OnRefresh();
        } 

        private void OnFilterLoad(FilterPredicate predicate)
        {
            int bookCounter = 0;
            foreach (Book book in bookDocument.Books.AsNotNull())
            {
                if (predicate(book))
                {
                    OnTreeNodeLoad(book);
                    bookCounter++;
                }  
            }
        }

        private bool ReleasedBefore(Book book)
        {
            if (book == null)
                return false;
            return book.ReleaseDate <= boundaryDate;
        }

        private bool ReleasedAfter(Book book)
        {
            if (book == null)
                return false;
            return book.ReleaseDate > boundaryDate;
        }

        public override void OnBookCreated(Book book)
        {
            OnRefresh();
        }

        public override void OnBookEdited(Book newBook, Book oldBook)
        {
            OnRefresh();
        }

        public override void OnBookDeleted(Book book)
        {
            OnRefresh();
        }
    }
}
