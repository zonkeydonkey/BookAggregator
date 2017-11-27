using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    // There may be some errors during work with Visual Studio Designer due to tool's bugs - to avoid them, comment 'abstract' keyword 
    public abstract partial class BookDataEntryForm : Form
    {
        public String Title
        {
            get { return titleTextBox.Text; }
        }

        public String Author
        {
            get { return authorTextBox.Text; }
        }

        public DateTime ReleaseDate
        {
            get { return dateTimePicker.Value; }
        }

        public String Category
        {
            get { return picturePicker.Description; }
        }

        public BookDataEntryForm()
        {
            InitializeComponent();
            picturePicker.Parent = this;
        }

        public BookDataEntryForm(BookDocument bookDocument)
        {
            InitializeComponent();
            picturePicker.Parent = this;
        }

        private void OnImageChanged(object sender, EventArgs args)
        {
            picturePicker.Refresh();
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        protected void OnOKButtonClicked(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
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
    }
}
