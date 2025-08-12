using Microsoft.EntityFrameworkCore;
using StadiumAPI.Models;
using StadiumAPI.DTOs;

namespace StadiumAPI.Data
{
    public class StadiumDbContext : DbContext
    {
    
            public StadiumDbContext(DbContextOptions<StadiumDbContext> options) : base(options)
            {
            }
            public DbSet<Courts> Courts { get; set; }
            public DbSet<Stadiums> Stadiums { get; set; }
            public DbSet<StadiumImages> StadiumImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Courts>().ToTable("Courts");
                modelBuilder.Entity<Stadiums>().ToTable("Stadiums");
                modelBuilder.Entity<StadiumImages>().ToTable("StadiumImages");
        }
        public DbSet<StadiumAPI.DTOs.ReadStadiumDTO> ReadStadiumDTO { get; set; } = default!;
    }
}
