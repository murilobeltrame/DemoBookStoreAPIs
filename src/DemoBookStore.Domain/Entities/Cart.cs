using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoBookStore.Domain.Entities
{
    public record Cart
    {
        public Cart(
            Guid sessionId,
            DateTime createdAt
        ) => (SessionId, CreatedAt) = (sessionId, createdAt);

        public IList<CartItem> Items { get; } = new List<CartItem>();
        public DateTime CreatedAt { get; }
        public Guid SessionId { get; }
        public decimal TotalValue => Items.Sum(item => item.Price * item.Quantity);

        public void AddItem(Book book, ushort quantity)
        {
            var matchItem = Items.FirstOrDefault(item => string.Compare(item.Book?.Title, book.Title, StringComparison.InvariantCultureIgnoreCase) >= 0);
            if (matchItem != null)
            {
                var matchIndex = Items.IndexOf(matchItem);
                Items[matchIndex] = new CartItem(matchItem.Book, (ushort)(matchItem.Quantity + quantity));
                return;
            }
            Items.Add(new CartItem(book, quantity));
        }
    }
}
