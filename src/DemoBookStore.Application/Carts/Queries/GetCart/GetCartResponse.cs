using DemoBookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoBookStore.Application.Carts.Queries.GetCart
{
    public record GetCartResponse
    {
        public GetCartResponse(
            Guid sessionId,
            DateTime createdAt,
            IEnumerable<CartItemDto> items
        ) => (SessionId, CreatedAt, Items) = (sessionId, createdAt, items);

        public Guid SessionId { get; }
        public DateTime CreatedAt { get; }
        public IEnumerable<CartItemDto> Items { get; }

        internal static GetCartResponse FromCart(Cart cart) => new GetCartResponse(
            cart.SessionId,
            cart.CreatedAt,
            cart.Items.Select(item => new CartItemDto(
                item.Book?.Title,
                item.Price,
                item.Quantity)
            )
        );
    }
}