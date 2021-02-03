using DemoBookStore.Api.GraphQl.Attributes;
using DemoBookStore.Api.GraphQl.Data;
using DemoBookStore.Api.GraphQl.Models;
using HotChocolate;
using System.Threading.Tasks;

namespace DemoBookStore.Api.GraphQl
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<Author> AddAuthorAsync(Author author, [ScopedService] ApplicationDbContext context)
        {
            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
            return author;
        }

        [UseApplicationDbContext]
        public async Task<Book> AddBookAsync(Book book, [ScopedService] ApplicationDbContext context)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;
        }

        [UseApplicationDbContext]
        public async Task<Publisher> AddPublisherAsync(Publisher publisher, [ScopedService] ApplicationDbContext context)
        {
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();
            return publisher;
        }
    }
}
