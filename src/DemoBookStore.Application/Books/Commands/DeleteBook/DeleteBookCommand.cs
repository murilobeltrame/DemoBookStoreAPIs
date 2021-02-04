using MediatR;

namespace DemoBookStore.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand: IRequest<DeleteBookResponse>
    {
        public string Title { get; set; }
    }
}
