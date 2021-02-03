using DemoBookStore.Api.GraphQl.Data;
using DemoBookStore.Api.GraphQl.Models;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookStore.Api.GraphQl.DataLoader
{
    public class BookByIdDataLoader : BatchDataLoader<Guid, Book>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public BookByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<ApplicationDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory;
        }

        protected override async Task<IReadOnlyDictionary<Guid, Book>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            await using var context = _dbContextFactory.CreateDbContext();
            return await context.Books.Where(book => keys.Contains(book.Id)).ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
