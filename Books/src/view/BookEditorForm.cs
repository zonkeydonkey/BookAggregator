using System;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    public partial class BookEditorForm : BookDataEntryForm
    {
        public event Events.BookEditedEventHandler BookEdited;

        private Book selected = null;

        public BookEditorForm(BookDocument bookDocument) : base(bookDocument)
        {
            InitializeComponent();
        }

        public void OnEditFormLoad(String selectedTitle, String selectedAuthor, String selectedReleaseDate, String selectedCategory)
        {
            selected = new Book(selectedTitle, selectedAuthor, DateTime.Parse(selectedReleaseDate), selectedCategory);
            titleTextBox.Text = selectedTitle;
            authorTextBox.Text = selectedAuthor;
            dateTimePicker.Value = DateTime.Parse(selectedReleaseDate);
            try
            {
                picturePicker.Description = selectedCategory;
            }
            catch (NoImageFoundException ex)
            {
                MessageBox.Show("There was some problems with edited book's category");
            }
        }

        private void OnOKButtonClicked(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Book editedBook = new Book(titleTextBox.Text, authorTextBox.Text, dateTimePicker.Value, picturePicker.Description);
                bookDocument.UpdateBook(editedBook, selected);
                BookEdited(sender, e, editedBook, selected);

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
