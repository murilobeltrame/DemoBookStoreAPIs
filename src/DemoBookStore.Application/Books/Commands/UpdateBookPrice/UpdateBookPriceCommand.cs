using System;
using MediatR;

namespace DemoBookStore.Application.Books.Commands.UpdateBookPrice
{
    public record UpdateBookPriceCommand: IRequest<UpdateBookPriceResponse>
    {
        public UpdateBookPriceCommand(
            string title,
            decimal price,
            DateTime startingAt) => (Title, Price, StartingAt) = (title, price, startingAt);

        public string Title { get; }
        public decimal Price { get; }
        public DateTime StartingAt { get; }
    }
}
