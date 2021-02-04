using MediatR;

namespace DemoBookStore.Application.Books.Commands.ReviewBook
{
    public record ReviewBookCommand: IRequest<ReviewBookResponse>
    {
        public ReviewBookCommand(
            string title,
            ushort rating,
            string note) => (Title, Rating, Note) = (title, rating, note);

        public string Title { get; }
        public ushort Rating { get; }
        public string Note { get; }
    }
}
