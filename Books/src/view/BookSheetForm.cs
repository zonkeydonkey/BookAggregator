using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    public partial class BookSheetForm : Form, IChildForm
    {
        protected BookDocument bookDocument;
        protected int nbElements = 0;
        protected List<Book> books = new List<Book>();

        private const String IdPrefix = "Id: ";
        private const String AuthorPrefix = "Author: ";
        private const String ReleaseDatePrefix = "Release Date: ";
        private const String CategoryPrefix = "Category: ";
        protected const String ElementNbPrefix = "Number of elements: ";

        public BookSheetForm()
        {
            InitializeComponent();
            nbElementStatusBar.Text = ElementNbPrefix + nbElements;
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
            nbElements = treeView.Nodes.Count;
            nbElementStatusBar.Text = ElementNbPrefix + nbElements;
        }

        private void OnEditBookClicked(object sender, EventArgs e)
        {
            BookEditorForm newBookEditor = new BookEditorForm();
            try
            {
                TreeNode selected = GetSelected();
                newBookEditor.OnEditFormLoad(
                    selected.Text,
                    GetNodeValue(selected, 1, AuthorPrefix),
                    GetNodeValue(selected, 2, ReleaseDatePrefix),
                    GetNodeValue(selected, 3, CategoryPrefix));
                if(newBookEditor.ShowDialog() == DialogResult.OK)
                {
                    int updatedId = Int32.Parse(GetNodeValue(selected, 0, IdPrefix));
                    bookDocument.UpdateBook(updatedId, newBookEditor.Title, newBookEditor.Author, newBookEditor.ReleaseDate, newBookEditor.Category);
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

        protected TreeNode GetNodeWithException(int id)
        {
            TreeNode node = GetNode(id);
            if (node == null)
                throw new NoSuchNodeFoundException();
            return node;
        }

        protected TreeNode GetNode(int id)
        {
            if (treeView.Nodes == null)
                return null;

            foreach (TreeNode node in treeView.Nodes)
            {
                String idCompared = GetNodeValue(node, 0, IdPrefix);
                if (Int32.Parse(idCompared) == id)
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
            TreeNode titleNode = new TreeNode(book.Title);
            treeView.Nodes.Add(titleNode);

            TreeNode idNode = new TreeNode(IdPrefix + book.Id);
            titleNode.Nodes.Add(idNode);
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
            node.Nodes[1].Text = AuthorPrefix + book.Author;
            node.Nodes[2].Text = ReleaseDatePrefix + book.ReleaseDate.ToString();
            node.Nodes[3].Text = CategoryPrefix + book.Category;

            treeView.EndUpdate();
        }

        public virtual void OnBookCreated(object sender, EventArgs e, Book book)
        {
            OnTreeNodeLoad(book);
            books.Add(book);
            ++nbElements;
            nbElementStatusBar.Text = ElementNbPrefix + nbElements;
        }

        public virtual void OnBookEdited(object sender, EventArgs e, Book edited)
        {
            try
            {
                TreeNode node = GetNodeWithException(edited.Id);
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
                int id = Int32.Parse(GetNodeValue(selected, 0, IdPrefix));
                bookDocument.DeleteBook(id);
            }
            catch (NoNodeSelectedException ex)
            {
                MessageBox.Show(ex.Message + "Select deleted book first");
            }
        }

        public virtual void OnBookDeleted(object sender, EventArgs e, int id)
        {
            try
            {
                TreeNode node = GetNodeWithException(id);
                treeView.Nodes.Remove(node);
                DeleteBookOrNop(id);
                --nbElements;
                nbElementStatusBar.Text = ElementNbPrefix + nbElements;
            }
            catch (NoSuchNodeFoundException ex)
            {
                MessageBox.Show(ex.Message + "Deleted book with id: " + id + " not found (was deleted previously or other unexpected error occurred)");
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

        private String GetNodeValue(TreeNode parent, int index, String prefix)
        {
            return parent.Nodes[index].Text.Substring(prefix.Length);
        }

        protected bool DeleteBookOrNop(int id)
        {
            foreach(Book book in books)
            {
                if(book.Id == id)
                {
                    books.Remove(book);
                    return true;
                }
            }
            return false;
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
    }
}
