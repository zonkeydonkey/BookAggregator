using System;

namespace Books
{
    using Book = BookModel;

    public interface IBookDocument
    {
        Book CreateBook(String title, String author, DateTime releaseDate, String category);
        void InsertBook(Book book);
        Book ReadLast();
        int ReadBookNb();
        Book ReadBook(int index);
        bool UpdateBook(int id, String title, String author, DateTime releaseDate, String category);
        bool DeleteBook(int id);
    }
}
