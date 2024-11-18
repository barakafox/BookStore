using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Gener> Geners { get; set; }
    }
}
