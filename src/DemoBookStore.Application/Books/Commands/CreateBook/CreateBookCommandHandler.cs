using System.Threading;
using System.Threading.Tasks;
using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using MediatR;

namespace DemoBookStore.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler: IRequestHandler<CreateBookCommand, CreateBookResponse>
    {
        private readonly IRepository<Book> _repository;

        public CreateBookCommandHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<CreateBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.ToBook();
            var result = await _repository.CreateAsync(book, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return CreateBookResponse.FromBook(result);
        }
    }
}
