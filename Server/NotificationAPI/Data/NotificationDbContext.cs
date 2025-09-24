using Microsoft.EntityFrameworkCore;

namespace NotificationAPI.Data
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {
        }

        public DbSet<NotificationAPI.Model.Notification> Notifications { get; set; }
    }
}
