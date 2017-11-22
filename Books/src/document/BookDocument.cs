using System;
using System.Collections.Generic;
using System.Linq;

namespace Books
{
    using Book = BookModel;

    public class BookDocument : IBookDocument
    {
        private List<Book> books;

        public event Events.BookCreatedEventHandler BookCreated;
        public event Events.BookEditedEventHandler BookEdited;
        public event Events.BookDeletedEventHandler BookDeleted;

        public List<Book> Books
        {
            get { return books; }
            private set { this.books = value; }
        }

        public BookDocument() => Books = new List<Book>();

        public Book CreateBook(String title, String author, DateTime releaseDate, String category)
        {
            Book book = new Book(title, author, releaseDate, category);
            Books.Add(book);
            BookCreated(this, new EventArgs(), book);
            return book;
        }

        public void InsertBook(Book book)
        {
            Books.Add(book);
            BookCreated(this, new EventArgs(), book);
        }

        public Book ReadLast()
        {
            return Books.Last();
        }

        public int ReadBookNb()
        {
            return Books.Count();
        }

        public Book ReadBook(int id)
        {
            foreach(Book book in Books)
            {
                if (book.Id == id)
                    return book;
            }
            return null;
        }

        public bool UpdateBook (int id, String title, String author, DateTime releaseDate, String category)
        {
            Book edited = ReadBook(id);
            if(edited != null)
            {
                edited.Title = title;
                edited.Author = author;
                edited.ReleaseDate = releaseDate;
                edited.Category = category;

                BookEdited(this, new EventArgs(), edited);
                return true;
            }
            return false;  
        }

        public bool DeleteBook(int id)
        {
            Book deleted = ReadBook(id);

            if (deleted == null)
                return false;

            Books.Remove(deleted);
            BookDeleted(this, new EventArgs(), id);
            return true;
        }
    }
}
