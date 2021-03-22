using DemoBookStore.Application.Books.Commands.CreateBook;
using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DemoBookStore.Application.Unit.Tests
{
    public class CreateBookCommandTests
    {
        private readonly CancellationToken _cancelationToken = new();

        [Fact]
        public async Task CreateBookCommand_should_be_instantiated()
        {
            var repositoryMock = new Mock<IRepository<Book>>();
            var createBookCommandHandler = new CreateBookCommandHandler(repositoryMock.Object);
            var createBookCommand = new CreateBookCommand{
                Title = "A book",
                Authors = new List<AuthorDto> { new AuthorDto{ FirstName = "Name", LastName = "LastName"}},
                PublisherName = "The Publisher"
            };
            repositoryMock.Setup(repository => repository.CreateAsync(createBookCommand.ToBook(), _cancelationToken).Result).Returns(createBookCommand.ToBook());

            var responseExpected = new CreateBookResponse(
                createBookCommand.Title,
                createBookCommand.Authors.Select(authorDto => new Author(authorDto.FirstName, authorDto.LastName)),
                new Publisher(createBookCommand.PublisherName),
                createBookCommand.Pages,
                0m
            );


            var response = await createBookCommandHandler.Handle(createBookCommand, _cancelationToken);

            Assert.Equal(responseExpected, response);
        }
    }
}
