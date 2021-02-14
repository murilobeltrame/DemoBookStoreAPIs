using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookStore.Application.Carts.Commands.RemoveItem
{
    public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand, RemoveItemResponse>
    {
        private readonly IRepository<Cart> _repository;

        public RemoveItemCommandHandler(IRepository<Cart> repository)
        {
            _repository = repository;
        }

        public async Task<RemoveItemResponse> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var cart = await _repository.GetAsync(cart => cart.SessionId == request.SessionId, cancellationToken);
            cart.RemoveItem(request.BookTitle);

            _repository.Update(cart);
            await _repository.SaveChangesAsync(cancellationToken);
            return new RemoveItemResponse();
        }
    }
}
