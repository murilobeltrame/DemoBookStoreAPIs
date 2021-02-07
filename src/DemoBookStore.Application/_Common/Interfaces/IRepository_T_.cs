using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookStore.Application.Common.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(T item, CancellationToken cancellationToken);
        Task<T> GetAsync(Func<T, bool> clause, CancellationToken cancellationToken);
        Task<IEnumerable<T>> ListAsync(Func<T, bool> clause, CancellationToken cancellationToken); // TODO: Sorting and Paging
        Task DeleteAsync(T item, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}