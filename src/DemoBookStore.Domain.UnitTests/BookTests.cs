using DemoBookStore.Domain.Entities;
using System;
using Xunit;

namespace DemoBookStore.Domain.UnitTests
{
    public class BookTests
    {
        Book _dummyBook => new Book(
            "DummyBook",
            new Author[] { new Author("John", "Doe") },
            new Publisher("Publishers House")
        );

        [Fact]
        public void Should_Be_Instatiated() { }

        [Fact]
        public void Book_without_title_should_throw_an_ArgumentException() { }

        [Fact]
        public void Book_without_a_least_one_Author_should_throw_an_ArgumentException() { }

        [Fact]
        public void Book_without_a_Publish_should_throw_an_ArgumentException() { }

        // PRINCING

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
            Action act = () => _dummyBook.PlaceReview(6);

            Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal(0, _dummyBook.Reviews.Count);
        }

        [Fact]
        public void Getting_average_rating_should_be_the_Reviews_raging_average()
        {
            ushort? _expectedRating = 2;
            var book = _dummyBook;
            book.PlaceReview(3);
            book.PlaceReview(1);

            var result = book.GetAverageRating();

            Assert.Equal(_expectedRating, result);
        }

        [Fact]
        public void Getting_average_rating_for_an_unset_Review_history_should_return_Null()
        {
            ushort? _expectedRating = null;

            var result = _dummyBook.GetAverageRating();

            Assert.Equal(_expectedRating, result);
        }
    }
}
