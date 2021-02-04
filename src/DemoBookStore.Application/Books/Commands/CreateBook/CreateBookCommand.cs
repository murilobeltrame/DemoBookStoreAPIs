using System.Collections.Generic;
using System.Linq;
using DemoBookStore.Domain.Entities;
using MediatR;

namespace DemoBookStore.Application.Books.Commands.CreateBook
{
    public record CreateBookCommand: IRequest<CreateBookResponse>
    {
        public string Title { get; set; }
        public IEnumerable<AuthorDto> Authors { get; set; }
        public string PublisherName { get; set; }
        public ushort? Pages { get; set; }

        public Book ToBook() => new Book(
            Title,
            Authors.Select(author => new Author(author.FirstName, author.LastName)),
            new Publisher(PublisherName),
            Pages);
    }

    public record AuthorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
