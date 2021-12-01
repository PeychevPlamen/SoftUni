namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
	{
        public DbSet<Cell> Cells { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Mail> Mails { get; set; }

        public DbSet<Officer> Officers { get; set; }

        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        public DbSet<Prisoner> Prisoners { get; set; }

        public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<OfficerPrisoner>(x =>
			{
				x.HasKey(x => new { x.PrisonerId, x.OfficerId});
			});

			base.OnModelCreating(builder);

			//Introducing FOREIGN KEY constraint 'FK_OfficersPrisoners_Prisoners_PrisonerId' on table 'OfficersPrisoners' may cause cycles or multiple cascade paths

			//builder.Entity<OfficerPrisoner>()
			//	.HasOne(x=>x.Prisoner)
			//	.WithMany(x=>x.PrisonerOfficers)
			//	.HasForeignKey(x => x.PrisonerId)
			//	.OnDelete(DeleteBehavior.Restrict);
		}
	}
}