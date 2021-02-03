using DemoBookStore.Api.GraphQl.Attributes;
using DemoBookStore.Api.GraphQl.Data;
using DemoBookStore.Api.GraphQl.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBookStore.Api.GraphQl
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Author>> GetAuthors([ScopedService] ApplicationDbContext context) => context.Authors.ToListAsync();
        [UseApplicationDbContext]
        public Task<List<Book>> GetBooks([ScopedService] ApplicationDbContext context) => context.Books.ToListAsync();
        [UseApplicationDbContext]
        public Task<List<Publisher>> GetPublishers([ScopedService] ApplicationDbContext context) => context.Publishers.ToListAsync();
    }
}
