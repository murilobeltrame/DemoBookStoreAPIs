using DemoBookStore.Application.Books.Commands.CreateBook;
using Xunit;

namespace DemoBookStore.Application.Unit.Tests
{
    public class CreateBookCommandTests
    {
        [Fact]
        public void CreateBookCommand_should_be_instantiated()
        {
            var createBookCommand = new CreateBookCommand();
        }
    }
}
