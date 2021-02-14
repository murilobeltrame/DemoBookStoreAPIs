using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookStore.Application.Carts.Commands.ChangeItemQuantity
{
    public class ChangeItemQuantityCommandHandler : IRequestHandler<ChangeItemQuantityCommand, ChangeItemQuantityResponse>
    {
        private readonly IRepository<Cart> _repository;

        public ChangeItemQuantityCommandHandler(IRepository<Cart> repository)
        {
            _repository = repository;
        }

        public async Task<ChangeItemQuantityResponse> Handle(ChangeItemQuantityCommand request, CancellationToken cancellationToken)
        {
            var cart = await _repository.GetAsync(cart => cart.SessionId == request.SessionId, cancellationToken);
            cart.UpdateItemQuantity(request.BookTitle, request.NewQuantity);

            _repository.Update(cart);
            await _repository.SaveChangesAsync(cancellationToken);
            return new ChangeItemQuantityResponse();
        }
    }
}
