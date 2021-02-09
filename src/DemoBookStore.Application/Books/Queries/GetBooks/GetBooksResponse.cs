using DemoBookStore.Domain.Entities;
using System;
using System.Linq;

namespace DemoBookStore.Application.Books.Queries.GetBooks
{
    public record GetBooksResponse
    {
        public GetBooksResponse(
            string title,
            string authors,
            string publiser,
            ushort? pages,
            decimal? currentPrice,
            ushort? averageRating) => (Title, Authors, Publisher, Pages, CurrentPrice, AverageRating) = (title, authors, publiser, pages, currentPrice, averageRating);

        public string Title { get; }
        public string Authors { get; }
        public string Publisher { get; }
        public ushort? Pages { get; }
        public decimal? CurrentPrice { get; }
        public ushort? AverageRating { get; }

        internal static GetBooksResponse FromBook(Book book) => new GetBooksResponse(
            book.Title,
            string.Join(',', book.Authors.Select(author => $"{author.FirstName} {author.LastName}, ")),
            book.Publisher?.Name,
            book.Pages,
            book.GetPriceAt(DateTime.Now)?.Value,
            book.GetAverageRating()
        );
    }
}