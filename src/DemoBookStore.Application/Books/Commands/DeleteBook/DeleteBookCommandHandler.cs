using System.Threading;
using System.Threading.Tasks;
using DemoBookStore.Application.Common.Exceptions;
using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using MediatR;

namespace DemoBookStore.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler: IRequestHandler<DeleteBookCommand, DeleteBookResponse>
    {
        private readonly IRepository<Book> _repository;

        public DeleteBookCommandHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteBookResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetAsync(book => book.Title == request.Title, cancellationToken);
            if (book == null) throw new RecordNotFoundException();
            await _repository.DeleteAsync(book, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return new DeleteBookResponse();
        }
    }
}
