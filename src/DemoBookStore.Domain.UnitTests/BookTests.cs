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
        private static IEnumerable<Author> MockedAuthors => new Author[] { new Author("John", "Doe") };
        private static Publisher MockedPublisher => new Publisher("Publishers House");
        private static string ValidTitle => "Book Title";
        private static Book MockedBook => new Book(ValidTitle, MockedAuthors, MockedPublisher);

        [Fact]
        public void Should_Be_Instantiated()
        {
            ushort _expectedPages = 10;
            var _book = new Book(ValidTitle, MockedAuthors, MockedPublisher, _expectedPages);
            Assert.Equal(ValidTitle, _book.Title);
            Assert.Equal(MockedPublisher.Name, _book.Publisher.Name);
            Assert.Equal(_expectedPages, _book.Pages);
            Assert.Contains(_book.Authors, (author) =>
                MockedAuthors.ElementAt(0).FirstName == author.FirstName &&
                MockedAuthors.ElementAt(0).LastName == author.LastName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_title_should_throw_an_ArgumentNullException()
        {
            var expectedExceptionFieldName = "title";
            static void act() => new Book(null, MockedAuthors, MockedPublisher);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_a_least_one_Author_should_throw_an_ArgumentException()
        {
            var expectedExceptionFieldName = "authors";
            static void act() => new Book(ValidTitle, null, MockedPublisher);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_a_Publisher_should_throw_an_ArgumentException()
        {
            var expectedExceptionFieldName = "publisher";
            static void act() => new Book(ValidTitle, MockedAuthors, null);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        // PRICING

        [Fact]
        public void Setting_Price_should_accumulate_Price_record()
        {
            var _expectedPrice = 10m;
            var _expectedDate = DateTime.Now;
            var _book = new Book(ValidTitle, MockedAuthors, MockedPublisher);
            _book.SetPrice(_expectedPrice, _expectedDate);
            Assert.Contains(_book.Pricing, (price) =>
                price.Value == _expectedPrice &&
                price.StartingAt == _expectedDate);
        }

        [Fact]
        public void Setting_Price_without_Date_should_add_a_price_with_current_Date()
        {
            var _expectedPrice = 10m;
            var _expectedDate = DateTime.Now;
            var _book = new Book(ValidTitle, MockedAuthors, MockedPublisher);
            _book.SetPrice(_expectedPrice);
            Assert.Contains(_book.Pricing, (price) =>
                price.Value == _expectedPrice &&
                price.StartingAt.Date == _expectedDate.Date);
        }

        [Fact]
        public void Getting_Price_at_exact_Date_should_return_the_Price()
        {
            var _expectedPrice = 10m;
            var _expectedDate = DateTime.Now;
            var _book = new Book(ValidTitle, MockedAuthors, MockedPublisher);

            _book.SetPrice(_expectedPrice - 5, _expectedDate.AddDays(-20));
            _book.SetPrice(_expectedPrice, _expectedDate);
            _book.SetPrice(_expectedPrice + 5, _expectedDate.AddDays(20));

            var _result = _book.GetPriceAt(_expectedDate);
            Assert.Equal(_expectedPrice, _result.Value);
        }

        [Fact]
        public void Getting_Price_in_inverval_should_return_the_oldest_Price()
        {
            var _expectedPrice = 10m;
            var _expectedDate = DateTime.Now;
            var _book = new Book(ValidTitle, MockedAuthors, MockedPublisher);

            _book.SetPrice(_expectedPrice + 5, _expectedDate.AddDays(20));
            _book.SetPrice(_expectedPrice, _expectedDate);
            _book.SetPrice(_expectedPrice - 5, _expectedDate.AddDays(-20));

            var _result = _book.GetPriceAt(_expectedDate.AddDays(10));
            Assert.Equal(_expectedPrice, _result.Value);
        }

        [Fact]
        public void Getting_Price_for_an_unset_Price_history_should_return_value_0_for_Today()
        {
            var _book = new Book(ValidTitle, MockedAuthors, MockedPublisher);
            var _result = _book.GetPriceAt(DateTime.Now);
            Assert.Equal(0m, _result.Value);
        }

        // RATING

        [Fact]
        public void Placing_Review_greater_than_5_should_thrown_ArgumentOutOfRangeException()
        {
            void act() => MockedBook.PlaceReview(6);

            Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal(0, MockedBook.Reviews.Count);
        }

        [Fact]
        public void Getting_average_rating_should_be_the_Reviews_raging_average()
        {
            ushort? _expectedRating = 2;
            var book = MockedBook;
            book.PlaceReview(3);
            book.PlaceReview(1);

            var result = book.GetAverageRating();

            Assert.Equal(_expectedRating, result);
        }

        [Fact]
        public void Getting_average_rating_for_an_unset_Review_history_should_return_Null()
        {
            ushort? _expectedRating = null;

            var result = MockedBook.GetAverageRating();

            Assert.Equal(_expectedRating, result);
        }
    }
}
