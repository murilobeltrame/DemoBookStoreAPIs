using DemoBookStore.Api.Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoBookStore.Api.Rest.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
