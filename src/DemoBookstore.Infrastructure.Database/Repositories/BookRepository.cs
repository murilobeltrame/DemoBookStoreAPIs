using DemoBookstore.Infrastructure.Database.Data;
using DemoBookStore.Domain.Entities;

namespace DemoBookstore.Infrastructure.Database.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }
    }
}
