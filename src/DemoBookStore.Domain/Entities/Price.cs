using System;

namespace DemoBookStore.Domain.Entities
{
    public record Price
    {
        public Price(Book book, decimal value, DateTime startingAt) => (Book, Value, StartingAt) = (book, value, startingAt);

        public DateTime StartingAt { get; }
        public decimal Value { get; }
        public Book Book { get; }
    }
}