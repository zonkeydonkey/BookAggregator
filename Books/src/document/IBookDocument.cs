using System;

namespace Books
{
    using Book = BookModel;

    public interface IBookDocument
    {
        Book CreateBook(String title, String author, DateTime releaseDate, String category);
        void InsertBook(Book book);
        int ReadBookNb();
        bool UpdateBook(Book edited, String title, String author, DateTime releaseDate, String category);
        bool DeleteBook(Book deleted);
    }
}