using DemoBookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace DemoBookStore.Domain.UnitTests
{
    public class BookTests
    {
        private static IEnumerable<Author> MockedAuthors => new Author[] { new Author("John", "Doe") };
        private static Publisher MockedPublisher => new Publisher("Publishers House");
        private static string ValidTitle => "DummyBook";
        private static Book MockedBook => new Book(ValidTitle, MockedAuthors, MockedPublisher);

        [Fact]
        public void Should_Be_Instatiated() { }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_title_should_throw_an_ArgumentNullException()
        {
            //static void act() => new Book(null, MockedAuthors, MockedPublisher);

            //Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_a_least_one_Author_should_throw_an_ArgumentException()
        {
            //static void act() => new Book(ValidTitle, null, MockedPublisher);

            //Assert.Throws<ArgumentNullException>(act);
        }
        // TODO: Empty Collection, Nameless Author

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_a_Publisher_should_throw_an_ArgumentException()
        {
            //static void act() => new Book(ValidTitle, MockedAuthors, null);

            //Assert.Throws<ArgumentNullException>(act);
        }
        // TODO: Nameless Publisher

        // PRICING

        [Fact]
        public void Setting_Price_should_accumulate_Price_record() { }

        [Fact]
        public void Setting_Price_without_Date_should_add_a_price_with_current_Date() { }

        [Fact]
        public void Getting_Price_at_exact_Date_should_return_the_Price() { }

        [Fact]
        public void Getting_Price_in_inverval_should_return_the_oldest_Price() { }

        [Fact]
        public void Getting_Price_for_an_unset_Price_history_should_return_value_0_for_Today() { }

        // RATING

        [Fact]
        public void Placing_Review_greater_than_5_should_thrown_ArgumentOutOfRangeException()
        {
            //void act() => MockedBook.PlaceReview(6);

            //Assert.Throws<ArgumentOutOfRangeException>(act);
            //Assert.Equal(0, MockedBook.Reviews.Count);
        }

        [Fact]
        public void Getting_average_rating_should_be_the_Reviews_raging_average()
        {
            //ushort? _expectedRating = 2;
            //var book = MockedBook;
            //book.PlaceReview(3);
            //book.PlaceReview(1);

            //var result = book.GetAverageRating();

            //Assert.Equal(_expectedRating, result);
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
