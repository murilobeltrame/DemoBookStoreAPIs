using DemoBookStore.Application.Common.Interfaces;
using DemoBookStore.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookStore.Application.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler: IRequestHandler<GetBooksQuery, IEnumerable<GetBooksResponse>>
    {
        private readonly IRepository<Book> _repository;

        public GetBooksQueryHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetBooksResponse>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.ListAsync(null, cancellationToken);
            return books.Select(book => GetBooksResponse.FromBook(book));
        }
    }
}
