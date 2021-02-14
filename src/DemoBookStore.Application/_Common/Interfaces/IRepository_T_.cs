using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookStore.Application.Common.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(T item, CancellationToken cancellationToken);
        Task<T> GetAsync(Expression<Func<T, bool>> clause, CancellationToken cancellationToken);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> clause, CancellationToken cancellationToken); // TODO: Sorting and Paging
        T Update(T item);
        void Delete(T item);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}