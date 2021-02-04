using System.Threading;
using System.Threading.Tasks;
using DemoBookStore.Application.Common.Exceptions;
using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using MediatR;

namespace DemoBookStore.Application.Books.Commands.UpdateBookPrice
{
    public class UpdateBookPriceCommandHandler : IRequestHandler<UpdateBookPriceCommand, UpdateBookPriceResponse>
    {
        private readonly IRepository<Book> _repository;

        public UpdateBookPriceCommandHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<UpdateBookPriceResponse> Handle(UpdateBookPriceCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetAsync(book => book.Title == request.Title, cancellationToken);
            if (book == null) throw new RecordNotFoundException();
            book.SetPrice(request.Price, request.StartingAt);
            await _repository.SaveChangesAsync(cancellationToken);
            return new UpdateBookPriceResponse();
        }
    }
}
