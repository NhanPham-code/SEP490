using FindTeamAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FindTeamAPI.Data
{
    public class FindTeamDbContext : DbContext
    {
        public FindTeamDbContext(DbContextOptions<FindTeamDbContext> options) : base(options)
        {
        }
        public DbSet<Models.TeamPost> TeamPosts { get; set; }
        public DbSet<Models.TeamMember> TeamMembers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configurations can be added here
            modelBuilder.Entity<Models.TeamPost>(entity =>
            {
                // Tạo index theo PlayDate (hay được dùng để sort/filter)
                entity.HasIndex(e => e.PlayDate);

                // Tạo index cho CreatedBy (hay dùng để filter theo user)
                entity.HasIndex(e => e.CreatedBy);

                // Tạo index nhiều cột (composite index)
                entity.HasIndex(e => new { e.StadiumId, e.PlayDate });

                // Nếu cần unique index (không cho trùng)
                // entity.HasIndex(e => e.Title).IsUnique();
            });
            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasIndex(e => e.TeamPostId);
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => new { e.TeamPostId, e.UserId }).IsUnique();
            });
        }
    }
}
