using System;

namespace DemoBookStore.Domain.Entities
{
    public record CartItem
    {
        public CartItem(Book book) => (Book, Price) = (book, book.GetPriceAt(DateTime.Now).Value);

        public Book Book { get; }
        public decimal Price { get; }
    }
}