namespace DemoBookStore.Application.Carts.Commands.AddItem
{
    public record CartItemDto
    {
        public CartItemDto(
            string bookTitle,
            decimal unitPrice,
            ushort quantity
        ) => (BookTitle, UnitPrice, Quantity) = (bookTitle, unitPrice, quantity);

        public string BookTitle { get; }
        public decimal UnitPrice { get; }
        public ushort Quantity { get; }
    }
}