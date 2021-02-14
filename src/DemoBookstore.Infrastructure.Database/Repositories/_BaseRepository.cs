using DemoBookstore.Infrastructure.Database.Data;
using DemoBookStore.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookstore.Infrastructure.Database.Repositories
{
    public abstract class BaseRepository<T>: IRepository<T> where T: class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context) => _context = context;

        public async Task<T> CreateAsync(T item, CancellationToken cancellationToken) =>
            (await _context.Set<T>().AddAsync(item, cancellationToken)).Entity;

        public void Delete(T item) => _context.Set<T>().Remove(item);

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> clause,
            CancellationToken cancellationToken
        ) => clause != null ? await _context.Set<T>()
            .Where(clause)
            .FirstOrDefaultAsync(cancellationToken) :
            throw new ArgumentNullException("clause");

        public async Task<IEnumerable<T>> ListAsync(
            Expression<Func<T, bool>> clause,
            CancellationToken cancellationToken
        )
        {
            IQueryable<T> set = _context.Set<T>();
            if (clause != null) set = set.Where(clause);
            return await set.ToListAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) =>
            await _context.SaveChangesAsync(cancellationToken);

        public T Update(T item) => _context.Set<T>().Update(item).Entity;
    }
}
