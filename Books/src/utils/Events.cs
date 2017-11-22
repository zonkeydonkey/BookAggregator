using System;

namespace Books
{
    using Book = BookModel;

    public class Events
    {
        public delegate void BookCreatedEventHandler(object sender, EventArgs args, Book book);
        public delegate void BookEditedEventHandler(object sender, EventArgs args, Book book);
        public delegate void BookDeletedEventHandler(object sender, EventArgs args, int id);
    }
}
