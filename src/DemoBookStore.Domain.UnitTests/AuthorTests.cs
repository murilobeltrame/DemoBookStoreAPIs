using DemoBookStore.Domain.Entities;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace DemoBookStore.Domain.UnitTests
{
    public class AuthorTests
    {
        private static readonly string validFirstName = "Jhon";
        private static readonly string validLastName = "Doe";

        [Fact]
        public void Should_Be_Instantiated()
        {
            var _author = new Author(validFirstName, validLastName);
            Assert.Equal(validFirstName, _author.FirstName);
            Assert.Equal(validLastName, _author.LastName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Author_without_firstname_should_thrown_ArgumentNullException()
        {
            var expectedExceptionFieldName = "firstName";
            static void act() => new Author(null, validLastName);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Author_without_lastname_should_thrown_ArgumentNullException()
        {
            var expectedExceptionFieldName = "lastName";
            static void act() => new Author(validFirstName, null);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }
    }
}
