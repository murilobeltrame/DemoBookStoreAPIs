using MediatR;
using System;

namespace DemoBookStore.Application.Carts.Commands.RemoveItem
{
    public record RemoveItemCommand: IRequest<RemoveItemResponse>
    {
        public RemoveItemCommand(Guid sessionId, string bookTitle) => (SessionId, BookTitle) = (sessionId, bookTitle);

        public string BookTitle { get; }
        public Guid SessionId { get; }
    }
}
