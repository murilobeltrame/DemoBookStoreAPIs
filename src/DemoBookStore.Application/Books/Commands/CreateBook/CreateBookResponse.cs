﻿using System;
using System.Collections.Generic;
using DemoBookStore.Domain.Entities;

namespace DemoBookStore.Application.Books.Commands.CreateBook
{
    public record CreateBookResponse
    {
        public IEnumerable<Author> Authors { get; }
        public Publisher Publisher { get; }
        public string Title { get; }
        public ushort? Pages { get; }
        public decimal Price { get; }

        public CreateBookResponse(
            string title,
            IEnumerable<Author> authors,
            Publisher publisher,
            ushort? pages,
            decimal price) => (Title, Authors, Publisher, Pages, Price) = (title, authors, publisher, pages, price);

        internal static CreateBookResponse FromBook(Book book) => new CreateBookResponse(
            book.Title,
            book.Authors,
            book.Publisher,
            book.Pages,
            book.GetPriceAt(DateTime.Now)?.Value ?? 0m);
    }
}
