//using DemoBookstore.Infrastructure.Database.Entities;
using DemoBookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoBookstore.Infrastructure.Database.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
