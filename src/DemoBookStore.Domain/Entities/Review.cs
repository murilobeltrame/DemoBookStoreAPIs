using System;

namespace DemoBookStore.Domain.Entities
{
    public record Review
    {
        public Review(Book book, ushort rating, string note) => (Book, Rating, Note) = (book, rating, note);

        private Book _book;
        private ushort _rating;

        public Book Book
        {
            get => _book;
            init => _book = value ?? throw new ArgumentNullException("book");
        }
        public ushort Rating
        {
            get => _rating;
            init => _rating = value <= 5 ? value : throw new ArgumentOutOfRangeException("rating");
        }
        public string Note { get; }
    }
}