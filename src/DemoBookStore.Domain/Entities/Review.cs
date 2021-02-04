namespace DemoBookStore.Domain.Entities
{
    public record Review
    {
        public Review(Book book, ushort rating, string note) => (Book, Rating, Note) = (book, rating, note);

        public Book Book { get; }
        public ushort Rating { get; }
        public string Note { get; }
    }
}