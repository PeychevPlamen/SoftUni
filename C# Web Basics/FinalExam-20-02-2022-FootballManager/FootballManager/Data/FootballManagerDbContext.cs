namespace FootballManager.Data
{
    using FootballManager.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class FootballManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballManager;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPlayer>(x =>
            {
                x.HasKey(x => new { x.UserId, x.PlayerId });
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; init; }

        public DbSet<Player> Players { get; init; }

        public DbSet<UserPlayer> UserPlayers { get; init; }
    }
}
