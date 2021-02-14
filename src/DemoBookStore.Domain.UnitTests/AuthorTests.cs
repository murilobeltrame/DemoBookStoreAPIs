using DemoBookStore.Domain.Entities;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace DemoBookStore.Domain.UnitTests
{
    public class AuthorTests
    {
        private static readonly string _validFirstName = "Jhon";
        private static readonly string _validLastName = "Doe";

        [Fact]
        public void Should_Be_Instantiated()
        {
            var author = new Author(_validFirstName, _validLastName);
            Assert.Equal(_validFirstName, author.FirstName);
            Assert.Equal(_validLastName, author.LastName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Author_without_firstname_should_thrown_ArgumentNullException()
        {
            var expectedExceptionFieldName = "firstName";
            static void act() => new Author(null, _validLastName);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Author_without_lastname_should_thrown_ArgumentNullException()
        {
            var expectedExceptionFieldName = "lastName";
            static void act() => new Author(_validFirstName, null);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }
    }
}
