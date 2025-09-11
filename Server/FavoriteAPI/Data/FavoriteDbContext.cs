using Microsoft.EntityFrameworkCore;

namespace FavoriteAPI.Data
{
    public class FavoriteDbContext : DbContext
    {
        public FavoriteDbContext(DbContextOptions<FavoriteDbContext> options) : base(options)
        {
        }

        public DbSet<Model.Favorite> Favorites { get; set; } = null!;
    }
}
