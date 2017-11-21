using System;
using System.Collections.Generic;
using System.Linq;

namespace Books
{
    using Book = BookModel;

    public class BookDocument : IBookDocument
    {
        private List<Book> books;

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
            return book;
        }

        public Book ReadLast()
        {
            return Books.Last();
        }

        public int ReadBookNb()
        {
            return Books.Count();
        }

        public Book ReadBook(int index)
        {
            if (index < 0 || index > Books.Count)
                return null;
            return Books[index];
        }

        public void UpdateBook (Book newBook, Book oldBook)
        {
            if (newBook == null || oldBook == null || newBook.Equal(oldBook))
                return;

            Book updated = GetEquivalent(oldBook);
            if(updated != null)
            {
                updated.Title = newBook.Title;
                updated.Author = newBook.Author;
                updated.ReleaseDate = newBook.ReleaseDate;
                updated.Category = newBook.Category;
            }  
        }

        public Book GetEquivalent(Book compared)
        {
            foreach (Book book in Books.AsNotNull())
            {
                if (book.Equal(compared))
                {
                    return book;
                }
            }
            return null;
        }

        public bool DeleteBook(Book book)
        {
            Book deleted = GetEquivalent(book);

            if (deleted == null)
                return false;

            Books.Remove(deleted);
            return true;
        }
    }
}
