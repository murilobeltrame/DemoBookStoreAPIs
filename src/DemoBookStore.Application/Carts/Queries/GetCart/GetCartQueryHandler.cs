using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookStore.Application.Carts.Queries.GetCart
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, GetCartResponse>
    {
        private readonly IRepository<Cart> _repository;

        public GetCartQueryHandler(IRepository<Cart> repository)
        {
            _repository = repository;
        }

        public async Task<GetCartResponse> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _repository.GetAsync(cart => cart.SessionId == request.SessionId, cancellationToken);
            return GetCartResponse.FromCart(cart);
        }
    }
}
