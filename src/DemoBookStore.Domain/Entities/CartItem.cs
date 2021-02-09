using System;

namespace DemoBookStore.Domain.Entities
{
    public record CartItem
    {
        public CartItem(
            Book book,
            ushort quantity
        ) => (Book, Price, Quantity) = (book, book.GetPriceAt(DateTime.Now).Value, quantity);

        public Book Book { get; }
        public decimal Price { get; }
        public ushort Quantity { get; }
    }
}