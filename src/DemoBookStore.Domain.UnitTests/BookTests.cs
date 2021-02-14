using DemoBookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace DemoBookStore.Domain.UnitTests
{
    public class BookTests
    {
        private static readonly IEnumerable<Author> _mockedAuthors = new Author[] { new Author("John", "Doe") };
        private static readonly Publisher _mockedPublisher = new Publisher("Publishers House");
        private static readonly string _validTitle = "Book Title";

        [Fact]
        public void Should_Be_Instantiated()
        {
            ushort expectedPages = 10;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher, expectedPages);
            Assert.Equal(_validTitle, book.Title);
            Assert.Equal(_mockedPublisher.Name, book.Publisher.Name);
            Assert.Equal(expectedPages, book.Pages);
            Assert.Contains(book.Authors, (author) =>
                _mockedAuthors.ElementAt(0).FirstName == author.FirstName &&
                _mockedAuthors.ElementAt(0).LastName == author.LastName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_title_should_throw_an_ArgumentNullException()
        {
            var expectedExceptionFieldName = "title";
            static void act() => new Book(null, _mockedAuthors, _mockedPublisher);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_a_least_one_Author_should_throw_an_ArgumentException()
        {
            var expectedExceptionFieldName = "authors";
            static void act() => new Book(_validTitle, null, _mockedPublisher);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_a_Publisher_should_throw_an_ArgumentException()
        {
            var expectedExceptionFieldName = "publisher";
            static void act() => new Book(_validTitle, _mockedAuthors, null);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        // PRICING

        [Fact]
        public void Setting_Price_should_accumulate_Price_record()
        {
            var expectedPrice = 10m;
            var expectedDate = DateTime.Now;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            book.SetPrice(expectedPrice, expectedDate);
            Assert.Contains(book.Pricing, (price) =>
                price.Value == expectedPrice &&
                price.StartingAt == expectedDate);
        }

        [Fact]
        public void Setting_Price_without_Date_should_add_a_price_with_current_Date()
        {
            var expectedPrice = 10m;
            var expectedDate = DateTime.Now;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            book.SetPrice(expectedPrice);
            Assert.Contains(book.Pricing, (price) =>
                price.Value == expectedPrice &&
                price.StartingAt.Date == expectedDate.Date);
        }

        [Fact]
        public void Getting_Price_at_exact_Date_should_return_the_Price()
        {
            var expectedPrice = 10m;
            var expectedDate = DateTime.Now;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            book.SetPrice(expectedPrice - 5, expectedDate.AddDays(-20));
            book.SetPrice(expectedPrice, expectedDate);
            book.SetPrice(expectedPrice + 5, expectedDate.AddDays(20));
            var _result = book.GetPriceAt(expectedDate);
            Assert.Equal(expectedPrice, _result.Value);
        }

        [Fact]
        public void Getting_Price_in_inverval_should_return_the_oldest_Price()
        {
            var expectedPrice = 10m;
            var expectedDate = DateTime.Now;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            book.SetPrice(expectedPrice + 5, expectedDate.AddDays(20));
            book.SetPrice(expectedPrice, expectedDate);
            book.SetPrice(expectedPrice - 5, expectedDate.AddDays(-20));
            var _result = book.GetPriceAt(expectedDate.AddDays(10));
            Assert.Equal(expectedPrice, _result.Value);
        }

        [Fact]
        public void Getting_Price_for_an_unset_Price_history_should_return_value_0_for_Today()
        {
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            var result = book.GetPriceAt(DateTime.Now);
            Assert.Equal(0m, result.Value);
        }

        // RATING

        [Fact]
        public void Placing_Review_greater_than_5_should_thrown_ArgumentOutOfRangeException()
        {
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            void act() => book.PlaceReview(6);
            Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal(0, book.Reviews.Count);
        }

        [Fact]
        public void Getting_average_rating_should_be_the_Reviews_raging_average()
        {
            ushort? expectedRating = 2;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            book.PlaceReview(3);
            book.PlaceReview(1);
            var result = book.GetAverageRating();
            Assert.Equal(expectedRating, result);
        }

        [Fact]
        public void Getting_average_rating_for_an_unset_Review_history_should_return_Null()
        {
            ushort? expectedRating = null;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            var result = book.GetAverageRating();
            Assert.Equal(expectedRating, result);
        }
    }
}
