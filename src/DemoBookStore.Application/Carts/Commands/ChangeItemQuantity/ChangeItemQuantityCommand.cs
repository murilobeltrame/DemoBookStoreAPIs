using MediatR;
using System;

namespace DemoBookStore.Application.Carts.Commands.ChangeItemQuantity
{
    public record ChangeItemQuantityCommand: IRequest<ChangeItemQuantityResponse>
    {
        public ChangeItemQuantityCommand(
            Guid sessionId,
            string bookTitle,
            ushort newQuantity
        ) => (SessionId, BookTitle, NewQuantity) = (sessionId, bookTitle, newQuantity);

        public string BookTitle { get; }
        public Guid SessionId { get; }
        public ushort NewQuantity { get; }
    }
}
