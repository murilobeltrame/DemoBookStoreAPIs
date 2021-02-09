using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookStore.Application.Carts.Commands.Checkout
{
    public class CheckoutCommandHandler : IRequestHandler<CheckoutCommand, CheckoutResponse>
    {
        private readonly IRepository<Cart> _repository;

        public CheckoutCommandHandler(IRepository<Cart> repository)
        {
            _repository = repository;
        }

        public async Task<CheckoutResponse> Handle(CheckoutCommand request, CancellationToken cancellationToken)
        {
            var cart = await _repository.GetAsync(cart => cart.SessionId == request.SessionId, cancellationToken);
            cart.Checkout();
            await _repository.UpdateAsync(cart, cancellationToken);
            return new CheckoutResponse();
        }
    }
}
