using System;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    public partial class BookCreatorForm : BookDataEntryForm
    {
        public event Events.BookCreatedEventHandler BookCreated; 

        public BookCreatorForm(BookDocument bookDocument) : base(bookDocument)
        {
            InitializeComponent();
        }

        private void OnOKButtonClicked(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Book book = bookDocument.CreateBook(titleTextBox.Text, authorTextBox.Text, dateTimePicker.Value, picturePicker.Description);
                BookCreated(sender, e, book);

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }  
}
