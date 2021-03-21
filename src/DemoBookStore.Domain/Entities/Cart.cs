using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoBookStore.Domain.Entities
{
    public record Cart : BaseEntity
    {
        public Cart(
            Guid sessionId,
            DateTime createdAt
        ) => (SessionId, CreatedAt) = (sessionId, createdAt);

        public DateTime CreatedAt { get; }
        public Guid SessionId { get; }
        public IList<CartItem> Items { get; } = new List<CartItem>();
        public bool CheckedOut { get; private set; } = false;
        public decimal TotalValue => Items.Sum(item => item.Price * item.Quantity);

        public void AddItem(Book book, ushort quantity)
        {
            if (book == null) throw new ArgumentNullException("book");
            var item = GetCartItemByTitle(book.Title);
            if (item != null)
            {
                var index = Items.IndexOf(item);
                Items[index] = new CartItem(item.Book, (ushort)(item.Quantity + quantity));
                return;
            }
            Items.Add(new CartItem(book, quantity));
        }

        public void Checkout() => CheckedOut = true;

        public void RemoveItem(string bookTitle)
        {
            if (string.IsNullOrWhiteSpace(bookTitle)) throw new ArgumentNullException("bookTitle");
            var item = GetCartItemByTitle(bookTitle);
            if (item == null) throw new ArgumentException("", "bookTitle");
            Items.Remove(item);
        }

        public void UpdateItemQuantity(string bookTitle, ushort newQuantity)
        {
            if (string.IsNullOrWhiteSpace(bookTitle)) throw new ArgumentNullException("bookTitle");
            var item = GetCartItemByTitle(bookTitle);
            if (item == null) throw new ArgumentException("", "bookTitle");
            var index = Items.IndexOf(item);
            Items[index] = new CartItem(item.Book, newQuantity);
        }

        private CartItem GetCartItemByTitle(string title) => Items.FirstOrDefault(item => string.Compare(item.Book?.Title, title, StringComparison.InvariantCultureIgnoreCase) >= 0);
    }
}
