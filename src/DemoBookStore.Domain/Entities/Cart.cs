using System;
using System.Collections.Generic;

namespace DemoBookStore.Domain.Entities
{
    public record Cart
    {
        public Cart(DateTime createdAt) => CreatedAt = createdAt;

        public IList<CartItem> Items { get; } = new List<CartItem>();
        public DateTime CreatedAt { get; }

        public void AddItem(Book book) => Items.Add(new CartItem(book));
    }
}
