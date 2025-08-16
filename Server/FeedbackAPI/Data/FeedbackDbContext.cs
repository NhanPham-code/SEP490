using FeedbackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackAPI.Data
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Comment).HasMaxLength(1000);
                entity.Property(f => f.Rating).IsRequired();
                entity.Property(f => f.UserId).IsRequired();
                entity.Property(f => f.StadiumId).IsRequired();
                entity.Property(f => f.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}
