using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    public partial class BookDataEntryForm : Form
    {
        protected BookDocument bookDocument = null;

        public BookDataEntryForm()
        {
            bookDocument = null;
            InitializeComponent();
        }

        public BookDataEntryForm(BookDocument bookDocument)
        {
            this.bookDocument = bookDocument;
            InitializeComponent();
            //this.picturePicker.ImageChanged += new PicturePicker.ImageChangedEventHandler(OnImageChanged);
        }

        /*private void OnImageChanged(object sender, EventArgs args, Image image, String description)
        {
            this.Refresh();
        }*/

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void OnTitleValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(titleTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(titleTextBox, "Provide book's title");
            }
        }

        private void OnTitleValidated(object sender, EventArgs e)
        {
            errorProvider.SetError(titleTextBox, "");
        }

        private void OnAuthorValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(authorTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(authorTextBox, "Provide book's author");
            }
        }

        private void OnAuthorValidated(object sender, EventArgs e)
        {
            errorProvider.SetError(authorTextBox, "");
        }

        private void OnDateValidating(object sender, CancelEventArgs e)
        {
            DateTime provided = DateTime.Parse(dateTimePicker.Text);
            if (DateTime.Compare(provided, DateTime.Now) >= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(dateTimePicker, "Book's release date cannot be greater than today");
            }
        }

        private void OnDateValidated(object sender, EventArgs e)
        {
            errorProvider.SetError(dateTimePicker, "");
        }

        private void OnCategoryClick(object sender, EventArgs e)
        {
            picturePicker.OnClick(sender, e);
            Invalidate();
        }
    }
}
