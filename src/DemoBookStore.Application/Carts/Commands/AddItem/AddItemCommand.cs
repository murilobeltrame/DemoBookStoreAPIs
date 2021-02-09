using MediatR;
using System;

namespace DemoBookStore.Application.Carts.Commands.AddItem
{
    public record AddItemCommand: IRequest<AddItemResponse>
    {
        public AddItemCommand(
            Guid sessionId,
            string bookTitle,
            decimal unitPrice,
            ushort quantity
        ) => (SessionId, BookTitle, UnitPrice, Quantity) = (sessionId, bookTitle, unitPrice, quantity);

        public Guid SessionId { get; }
        public string BookTitle { get; }
        public decimal UnitPrice { get; }
        public ushort Quantity { get; }
    }
}
