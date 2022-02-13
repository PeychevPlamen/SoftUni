namespace SMS.Data
{
    using Microsoft.EntityFrameworkCore;
    using SMS.Data.Models;

    // ReSharper disable once InconsistentNaming
    public class SMSDbContext : DbContext
    {
        public SMSDbContext()
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Cart>(x =>
            //{
            //    x.HasKey(x => new { x.Id});
            //});

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Cart>()
            //    .HasOne<User>(u => u.User)
            //    .WithOne(c => c.Cart)
            //    .HasForeignKey<User>(fk => fk.CartId);
        }
    }
}