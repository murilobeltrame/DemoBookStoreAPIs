using DemoBookStore.Domain.Entities;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace DemoBookStore.Domain.UnitTests
{
    public class PublisherTests
    {
        private static readonly string validName = "The Publisher";

        [Fact]
        public void Should_be_instantiated()
        {
            var _publisher = new Publisher(validName);
            Assert.Equal(validName, _publisher.Name);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Author_without_name_should_thrown_ArgumentNullException()
        {
            var expectedExceptionFieldName = "name";
            static void act() => new Publisher(null);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }
    }
}
