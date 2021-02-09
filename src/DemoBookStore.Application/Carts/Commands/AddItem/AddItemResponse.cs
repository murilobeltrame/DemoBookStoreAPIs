using System;
using System.Collections.Generic;

namespace DemoBookStore.Application.Carts.Commands.AddItem
{
    public record AddItemResponse
    {
        public AddItemResponse(
            DateTime createdAt,
            decimal totalValue,
            IEnumerable<CartItemDto> items
        ) => (CreatedAt, TotalValue, Items) = (createdAt, totalValue, items);

        public DateTime CreatedAt { get; }
        public decimal TotalValue { get; }
        public IEnumerable<CartItemDto> Items { get; }
    }
}