using System;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    public partial class BookEditorForm : BookDataEntryForm
    {
        public BookEditorForm() : base()
        {
            InitializeComponent();
        }

        public void OnEditFormLoad(String selectedTitle, String selectedAuthor, String selectedReleaseDate, String selectedCategory)
        {
            titleTextBox.Text = selectedTitle;
            authorTextBox.Text = selectedAuthor;
            dateTimePicker.Value = DateTime.Parse(selectedReleaseDate);
            try
            {
                picturePicker.Description = selectedCategory;
                picturePicker.Parent = this;
            }
            catch (NoImageFoundException ex)
            {
                MessageBox.Show(ex.Message + "There was some problems with edited book's category");
            }
        }
    }
}
