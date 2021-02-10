using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoBookStore.Domain.Entities
{
    public record Book
    {
        public Book(
            string title,
            IEnumerable<Author> authors,
            Publisher publisher,
            ushort? pages = null) => (Title, Authors, Publisher, Pages) = (title, authors, publisher, pages);

        public IEnumerable<Author> Authors { get; }
        public Publisher Publisher { get; }
        public string Title { get; }
        public ushort? Pages { get; }
        public IList<Review> Reviews { get; } = new List<Review>();
        public IList<Price> Pricing { get; } = new List<Price>();

        public void SetPrice(decimal value, DateTime? startingAt) => Pricing.Add(new Price(this, value, startingAt ?? DateTime.Now));

        public Price GetPriceAt(DateTime date) => Pricing
            .OrderByDescending(price => price.StartingAt)
            .LastOrDefault(price => price.StartingAt >= date);

        public void PlaceReview(ushort rating, string note = null) => Reviews.Add(new Review(this, rating, note));

        public ushort? GetAverageRating() => Reviews.Any() ? (ushort?)Reviews.Average(review => review.Rating) : null;
    }
}
