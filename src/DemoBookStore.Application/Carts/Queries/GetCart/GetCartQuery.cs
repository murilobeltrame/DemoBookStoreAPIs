using MediatR;
using System;

namespace DemoBookStore.Application.Carts.Queries.GetCart
{
    public record GetCartQuery: IRequest<GetCartResponse>
    {
        public GetCartQuery(Guid sessionId) => SessionId = sessionId;

        public Guid SessionId { get; }
    }
}
