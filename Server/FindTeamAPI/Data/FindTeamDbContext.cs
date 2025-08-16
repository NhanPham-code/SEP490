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
        }
    }
}
