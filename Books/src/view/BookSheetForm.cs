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

        private const String AuthorPrefix = "Author: ";
        private const String ReleaseDatePrefix = "Release Date: ";
        private const String CategoryPrefix = "Category: ";
        protected const String ElementNbPrefix = "Number of elements: ";

        public event Events.BookCreatedEventHandler BookCreated;
        public event Events.BookEditedEventHandler BookEdited;
        public event Events.BookDeletedEventHandler BookDeleted;

        public BookSheetForm()
        {
            InitializeComponent();
            nbElementsLabel.Text = ElementNbPrefix + nbElements;
        }

        public BookSheetForm(BookDocument bookDocument) : this()
        {
            this.bookDocument = bookDocument;
        }

        private void OnCreateBookClicked(object sender, EventArgs e)
        {
            BookCreatorForm newBookCreator = new BookCreatorForm(bookDocument);
            newBookCreator.BookCreated += new Events.BookCreatedEventHandler(BookCreated);
            newBookCreator.ShowDialog();
        }

        protected virtual void OnBookSheetFormLoad(object sender, EventArgs e)
        {
            OnTreeViewLoad();
            nbElements = treeView.Nodes.Count;
            nbElementsLabel.Text = ElementNbPrefix + nbElements;
        }

        private void OnEditBookClicked(object sender, EventArgs e)
        {
            BookEditorForm newBookEditor = new BookEditorForm(bookDocument);
            newBookEditor.BookEdited += new Events.BookEditedEventHandler(BookEdited);
            try
            {
                TreeNode selected = GetSelected();
                newBookEditor.OnEditFormLoad(
                    selected.Text,
                    selected.Nodes[0].Text.Substring(AuthorPrefix.Length),
                    selected.Nodes[1].Text.Substring(ReleaseDatePrefix.Length),
                    selected.Nodes[2].Text.Substring(CategoryPrefix.Length));
                newBookEditor.ShowDialog();

            }
            catch (NoNodeSelectedException ex)
            {
                MessageBox.Show("Select edited book first");
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

        private TreeNode GetNode(Book book)
        {
            if (book == null || treeView.Nodes == null)
                throw new NoSuchNodeFoundException();

            foreach (TreeNode node in treeView.Nodes)
            {
                String releaseDate = node.Nodes[1].Text.Substring(ReleaseDatePrefix.Length);
                if (book.Equal(
                        node.Text,
                        node.Nodes[0].Text.Substring(AuthorPrefix.Length),
                        DateTime.Parse(releaseDate),
                        node.Nodes[2].Text.Substring(CategoryPrefix.Length))
                )
                {
                    return node;
                }
            }
            throw new NoSuchNodeFoundException();
        }

        protected void OnTreeViewLoad ()
        {
            int bookCounter = 0;
            foreach (Book book in bookDocument.Books.AsNotNull())
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

            node.Nodes[0].Text = AuthorPrefix + book.Author;
            node.Nodes[1].Text = ReleaseDatePrefix + book.ReleaseDate.ToString();
            node.Nodes[2].Text = CategoryPrefix + book.Category;

            treeView.EndUpdate();
        }

        public virtual void OnBookCreated(Book book)
        {
            OnTreeNodeLoad(book);
            ++nbElements;
            nbElementsLabel.Text = ElementNbPrefix + nbElements;
        }

        public virtual void OnBookEdited(Book newBook, Book oldBook)
        {
            try
            {
                TreeNode node = GetNode(oldBook);
                OnTreeNodeRefresh(node, newBook);
            }
            catch (NoSuchNodeFoundException ex)
            {
                MessageBox.Show(ex.Message + "Edited book " + oldBook.ToString() + " not found (was deleted or other unexpected error occurred)");
            } 
        }

        private void OnDeleteBookClicked(object sender, EventArgs e)
        {
            try
            {
                TreeNode selected = GetSelected();
                String releaseDate = selected.Nodes[1].Text.Substring(ReleaseDatePrefix.Length);
                Book deleted = new Book(
                    selected.Text,
                    selected.Nodes[0].Text.Substring(AuthorPrefix.Length),
                    DateTime.Parse(releaseDate),
                    selected.Nodes[2].Text.Substring(CategoryPrefix.Length));
                bookDocument.DeleteBook(deleted);
                BookDeleted(sender, e, deleted);
            }
            catch (NoNodeSelectedException ex)
            {
                MessageBox.Show("Select deleted book first");
            }
        }

        public virtual void OnBookDeleted(Book book)
        {
            try
            {
                TreeNode node = GetNode(book);
                treeView.Nodes.Remove(node);
                --nbElements;
                nbElementsLabel.Text = ElementNbPrefix + nbElements;
            }
            catch (NoSuchNodeFoundException ex)
            {
                MessageBox.Show(ex.Message + "Deleted book " + book.ToString() + " not found (was deleted previously or other unexpected error occurred)");
            }
        }

        public ToolStrip GetToolStrip()
        {
            return toolStrip;
        }
    }
}
