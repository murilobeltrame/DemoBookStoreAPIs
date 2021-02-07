using DemoBookStore.Application.Common.Interfaces.Queries;
using MediatR;
using System.Collections.Generic;

namespace DemoBookStore.Application.Books.Queries.GetBooks
{
    public record GetBooksQuery : IOrderedQuery, IPagedQuery, IRequest<IEnumerable<GetBooksResponse>>
    {
        public string Sort { get; }

        public int Offset { get; }

        public ushort Limit { get; }

        public GetBooksQuery(string sort, int offset, ushort limit) => (Sort, Offset, Limit) = (sort, offset, limit);
    }
}
