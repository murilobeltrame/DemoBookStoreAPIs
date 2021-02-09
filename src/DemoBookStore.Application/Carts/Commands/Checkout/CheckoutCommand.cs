using MediatR;
using System;

namespace DemoBookStore.Application.Carts.Commands.Checkout
{
    public record CheckoutCommand: IRequest<CheckoutResponse>
    {
        public CheckoutCommand(Guid sessionId) => SessionId = sessionId;

        public Guid SessionId { get; }
    }
}
