using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    public partial class BookSheetForm : Form, IChildForm
    {
        protected BookDocument bookDocument;
        protected List<Book> books = new List<Book>();

        private const String AuthorPrefix = "Author: ";
        private const String ReleaseDatePrefix = "Release Date: ";
        private const String CategoryPrefix = "Category: ";
        protected const String ElementNbPrefix = "Number of elements: ";

        private const int AuthorNodeId = 0;
        private const int ReleaseDateNodeId = 1;
        private const int CategoryNodeId = 2;

        public BookSheetForm()
        {
            InitializeComponent();
            OnNbElementsRefresh();
        }

        public BookSheetForm(BookDocument bookDocument) : this()
        {
            this.bookDocument = bookDocument;
            bookDocument.BookCreated += new Events.BookCreatedEventHandler(OnBookCreated);
            bookDocument.BookEdited += new Events.BookEditedEventHandler(OnBookEdited);
            bookDocument.BookDeleted += new Events.BookDeletedEventHandler(OnBookDeleted);
        }

        private void OnCreateBookClicked(object sender, EventArgs e)
        {
            BookCreatorForm newBookCreator = new BookCreatorForm();
            if (newBookCreator.ShowDialog() == DialogResult.OK)
            {
                Book created = new Book(newBookCreator.Title, newBookCreator.Author, newBookCreator.ReleaseDate, newBookCreator.Category);
                bookDocument.InsertBook(created);
            }
        }

        protected virtual void OnBookSheetFormLoad(object sender, EventArgs e)
        {
            if (bookDocument != null)
            {
                bookDocument.Books.Copy(this.books);
            }

            OnTreeViewLoad();
            OnNbElementsRefresh();
        }

        private void OnEditBookClicked(object sender, EventArgs e)
        {
            BookEditorForm newBookEditor = new BookEditorForm();
            try
            {
                TreeNode selectedNode = GetSelected();
                Book selectedBook = (Book) selectedNode.Tag;
                newBookEditor.OnEditFormLoad(
                    selectedBook.Title,
                    selectedBook.Author,
                    selectedBook.ReleaseDate.ToString(),
                    selectedBook.Category);
                if(newBookEditor.ShowDialog() == DialogResult.OK)
                {
                    bookDocument.UpdateBook(selectedBook, newBookEditor.Title, newBookEditor.Author, newBookEditor.ReleaseDate, newBookEditor.Category);
                }
            }
            catch (NoNodeSelectedException ex)
            {
                MessageBox.Show(ex.Message + "Select edited book first");
            }
        }

        private TreeNode GetSelected ()
        {
            TreeNode selected = treeView.SelectedNode;
            if (selected == null)
            {
                throw new NoNodeSelectedException();
            }
            return selected;
        }

        protected TreeNode GetNodeWithException(object tag)
        {
            TreeNode node = GetNode(tag);
            if (node == null)
                throw new NoSuchNodeFoundException();
            return node;
        }

        protected TreeNode GetNode(object tag)
        {
            if (treeView.Nodes == null)
                return null;

            foreach (TreeNode node in treeView.Nodes)
            {
                if (node.Tag == tag)
                {
                    return node;
                }
            }
            return null;
        }

        protected void OnTreeViewLoad ()
        {
            int bookCounter = 0;
            foreach (Book book in books.AsNotNull())
            {
                OnTreeNodeLoad(book);
                bookCounter++;
            }
        }

        protected void OnTreeNodeLoad (Book book)
        {
            treeView.BeginUpdate();
            TreeNode titleNode = new TreeNode(book.Title)
            {
                Tag = book
            };
            treeView.Nodes.Add(titleNode);

            TreeNode authorNode = new TreeNode(AuthorPrefix + book.Author);
            titleNode.Nodes.Add(authorNode);
            TreeNode releaseDateNode = new TreeNode(ReleaseDatePrefix + book.ReleaseDate.ToString());
            titleNode.Nodes.Add(releaseDateNode);
            TreeNode categoryNode = new TreeNode(CategoryPrefix + book.Category);
            titleNode.Nodes.Add(categoryNode);
            treeView.EndUpdate();
        }

        private void OnTreeNodeRefresh (TreeNode node, Book book)
        {
            treeView.BeginUpdate();

            node.Text = book.Title;
            node.Nodes[AuthorNodeId].Text = AuthorPrefix + book.Author;
            node.Nodes[ReleaseDateNodeId].Text = ReleaseDatePrefix + book.ReleaseDate.ToString();
            node.Nodes[CategoryNodeId].Text = CategoryPrefix + book.Category;

            treeView.EndUpdate();
        }

        public virtual void OnBookCreated(object sender, EventArgs e, Book book)
        {
            OnTreeNodeLoad(book);
            books.Add(book);
            OnNbElementsRefresh();
        }

        public virtual void OnBookEdited(object sender, EventArgs e, Book edited)
        {
            try
            {
                TreeNode node = GetNodeWithException(edited);
                OnTreeNodeRefresh(node, edited);
            }
            catch (NoSuchNodeFoundException ex)
            {
                MessageBox.Show(ex.Message + "Edited book " + edited.ToString() + " not found (was deleted or other unexpected error occurred)");
            }
        } 

        private void OnDeleteBookClicked(object sender, EventArgs e)
        {
            try
            {
                TreeNode selected = GetSelected();
                bookDocument.DeleteBook((Book) selected.Tag);
            }
            catch (NoNodeSelectedException ex)
            {
                MessageBox.Show(ex.Message + "Select deleted book first");
            }
        }

        public virtual void OnBookDeleted(object sender, EventArgs e, Book book)
        {
            if(DeleteBookOrNop(book))
            {
                try
                {
                    TreeNode node = GetNodeWithException(book);
                    treeView.Nodes.Remove(node);
                    OnNbElementsRefresh();
                }
                catch (NoSuchNodeFoundException ex)
                {
                    MessageBox.Show(ex.Message + "Deleted book: " + book.ToString() + " not found (was deleted previously or other unexpected error occurred)");
                }
            }
        }

        public ToolStrip GetToolStrip()
        {
            return toolStrip;
        }

        public StatusBar GetStatusBar()
        {
            return nbElementStatusBar;
        } 

        protected bool DeleteBookOrNop(object tag)
        {
            return books.Remove((Book) tag);
        }

        public void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MdiParent != null && MdiParent.MdiChildren.Length < 2)
                {
                    MessageBox.Show("At least one sheet must be open.");
                    e.Cancel = true;
                }
            }
        }

        protected void OnNbElementsRefresh()
        {
            int nbElements = 0;
            if (books != null)
                nbElements = books.Count; 
            nbElementStatusBar.Text = ElementNbPrefix + nbElements;
        }
    }
}
