using System;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    public partial class BookFilteredSheetForm : BookSheetForm, IChildForm
    {
        public enum Filter { All = 0, Before = 1, After = 2 };
        private Filter filter;

        public Filter DateFilter
        {
            get { return filter; }
        }

        private static DateTime boundaryDate = DateTime.Parse("01/01/2000");

        Predicate<Book> filterPredicate;

        public BookFilteredSheetForm() : base()
        {
            InitializeComponent();
            filter = Filter.All;
            filterPredicate = delegate (Book b) { return true; };
        }

        public BookFilteredSheetForm(BookDocument bookDocument) : base(bookDocument)
        {
            InitializeComponent();
            filter = Filter.All;
            filterPredicate = delegate (Book b) { return true; };
        }

        public BookFilteredSheetForm(BookDocument bookDocument, Filter filter) : base(bookDocument)
        {
            InitializeComponent();
            this.filter = filter;

            if (filter == Filter.All)
                filterPredicate = delegate (Book b) { return true; };
            else if (filter == Filter.Before)
                filterPredicate = ReleasedBefore;
            else if (filter == Filter.After)
                filterPredicate = ReleasedAfter;
        }

        protected override void OnBookSheetFormLoad(object sender, EventArgs e)
        {
            if (bookDocument != null)
            {
                bookDocument.Books.ConditionalCopy(this.books, filterPredicate);
            }

            Text = filter.ToString();
            if (filter == Filter.All)
            {
                OnTreeViewLoad();
            }
            else
                OnFilterLoad(filterPredicate);
            nbElementStatusBar.Text = ElementNbPrefix + treeView.Nodes.Count;
        } 

        private void OnFilterLoad(Predicate<Book> predicate)
        {
            int bookCounter = 0;
            foreach (Book book in books.AsNotNull())
            {
                if (predicate(book))
                {
                    OnTreeNodeLoad(book);
                    bookCounter++;
                }  
            }
        }

        private static bool ReleasedBefore(Book book)
        {
            if (book == null)
                return false;
            return book.ReleaseDate <= boundaryDate;
        }

        private static bool ReleasedAfter(Book book)
        {
            if (book == null)
                return false;
            return book.ReleaseDate > boundaryDate;
        }

        public override void OnBookCreated(object sender, EventArgs e, Book book)
        {
            if (filterPredicate(book))
            {
                base.OnBookCreated(sender, e, book);
            }
        }

        public override void OnBookEdited(object sender, EventArgs e, Book book)
        {
            if(filterPredicate(book))
            {
                TreeNode editedNode = GetNode(book.Id);
                if (editedNode != null)
                    base.OnBookEdited(sender, e, book);
                else
                    base.OnBookCreated(sender, e, book);
            }
            else
            {
                OnBookDeleted(sender, e, book.Id);
            }
        }

        public override void OnBookDeleted(object sender, EventArgs e, int id)
        {
            foreach(Book book in books.AsNotNull())
            {
                if(book.Id == id)
                {
                    TreeNode node = GetNode(id);
                    treeView.Nodes.Remove(node);
                    books.Remove(book);
                    --nbElements;
                    nbElementStatusBar.Text = ElementNbPrefix + nbElements;
                    return;
                }
            }
        }

        public void ChangeFilterType(Filter newFilter)
        {
            filter = newFilter;
            ChangePredicate(newFilter);
            treeView.Nodes.Clear();
            books.Clear();
            OnBookSheetFormLoad(this, new EventArgs());
        }

        private void ChangePredicate(Filter newFilter)
        {
            if (newFilter == Filter.All)
                filterPredicate = delegate (Book b) { return true; };
            else if (newFilter == Filter.Before)
                filterPredicate = ReleasedBefore;
            else if (newFilter == Filter.After)
                filterPredicate = ReleasedAfter;
        }
    }
}