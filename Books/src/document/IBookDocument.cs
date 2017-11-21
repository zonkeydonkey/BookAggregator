using System;

namespace Books
{
    using Book = BookModel;

    public interface IBookDocument
    {
        Book CreateBook(String title, String author, DateTime releaseDate, String category);
        Book ReadLast();
        int ReadBookNb();
        Book ReadBook(int index);
        void UpdateBook(Book newBook, Book oldBook);
        Book GetEquivalent(Book compared);
        bool DeleteBook(Book book);
    }
}
