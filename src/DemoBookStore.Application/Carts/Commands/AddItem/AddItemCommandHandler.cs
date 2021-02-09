using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookStore.Application.Carts.Commands.AddItem
{
    public class AddItemCommandHandler: IRequestHandler<AddItemCommand, AddItemResponse>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Cart> _cartRepository;

        public AddItemCommandHandler(
            IRepository<Book> bookRepository,
            IRepository<Cart> cartRepository
        )
        {
            _bookRepository = bookRepository;
            _cartRepository = cartRepository;
        }

        public async Task<AddItemResponse> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(book => book.Title == request.BookTitle, cancellationToken);
            var cart = await _cartRepository.GetAsync(cart => cart.SessionId == request.SessionId, cancellationToken);

            if (cart == null) cart = new Cart(Guid.NewGuid(), DateTime.Now);
            cart.AddItem(book, request.Quantity);

            await _cartRepository.WriteAsync(cart, cancellationToken);
            return new AddItemResponse(
                cart.CreatedAt,
                cart.TotalValue,
                cart.Items.Select(item =>
                    new CartItemDto(item.Book?.Title, item.Price, item.Quantity)
                )
            );
        }
    }
}
