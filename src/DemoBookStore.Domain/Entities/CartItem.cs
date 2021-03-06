﻿using System;

namespace DemoBookStore.Domain.Entities
{
    public record CartItem : BaseEntity
    {
        public CartItem(
            Book book,
            ushort quantity
        ) => (Book, Price, Quantity) = (book, book.GetPriceAt(DateTime.Now).Value, quantity);

        private Book _book;
        public Book Book
        {
            get => _book;
            init => _book = value ?? throw new ArgumentNullException("book");
        }
        public decimal Price { get; }
        public ushort Quantity { get; }
    }
}