using System.Threading;
using System.Threading.Tasks;
using DemoBookStore.Application.Common.Exceptions;
using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using MediatR;

namespace DemoBookStore.Application.Books.Commands.ReviewBook
{
    public class ReviewBookCommandHandler: IRequestHandler<ReviewBookCommand, ReviewBookResponse>
    {
        private readonly IRepository<Book> _repository;

        public ReviewBookCommandHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<ReviewBookResponse> Handle(ReviewBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetAsync(book => book.Title == request.Title, cancellationToken);
            if (book == null) throw new RecordNotFoundException();
            book.PlaceReview(request.Rating, request.Note);
            await _repository.SaveChangesAsync(cancellationToken);
            return new ReviewBookResponse();
        }
    }
}
