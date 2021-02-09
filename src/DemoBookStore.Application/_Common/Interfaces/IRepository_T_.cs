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
        Task UpdateAsync(T item, CancellationToken cancellationToken);
        Task DeleteAsync(T item, CancellationToken cancellationToken);
        Task WriteAsync(T item, CancellationToken cancellationToken); // Adds or Updates depending on key
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}