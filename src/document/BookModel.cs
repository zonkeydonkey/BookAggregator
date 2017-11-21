using System;

namespace Books
{
    [Serializable]
    public class BookModel
    {
        public String Title
        {
            get;
            set;
        }

        public String Author
        {
            get;
            set;
        }

        public DateTime ReleaseDate
        {
            get;
            set;
        }

        public String Category
        {
            get;
            set;
        }

        public BookModel(String title, String author, DateTime releaseDate, String category)
        {
            this.Title = title;
            this.Author = author;
            this.ReleaseDate = releaseDate;
            this.Category = category;
        }

        public bool Equal(BookModel compared)
        {
            if (compared == null)
                return false;
            return (Title == compared.Title) && (Author == compared.Author) && (Category == compared.Category) && 
                (ReleaseDate.ToString() == compared.ReleaseDate.ToString());
        }

        public bool Equal(String title, String author, DateTime releaseDate, String category)
        {
            return (Title == title) && (Author == author) && (Category == category) &&
                (ReleaseDate.ToString() == releaseDate.ToString());
        }
    }
}
