using DemoBookstore.Infrastructure.Database.Data;
using DemoBookStore.Domain.Entities;

namespace DemoBookstore.Infrastructure.Database.Repositories
{
    public class CartRepository : BaseRepository<Cart>
    {
        public CartRepository(ApplicationDbContext context) : base(context) { }
    }
}
