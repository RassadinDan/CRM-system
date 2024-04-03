using Microsoft.EntityFrameworkCore;
using ModelLibrary.Auth;
using ModelLibrary.Applications;

namespace SkillProfiWebAPI.DataContext
{
	public class SkillProfiDBContext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Application> Applications { get; set; }
		public SkillProfiDBContext(DbContextOptions options):base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(options => options.HasKey("UserName"));
			modelBuilder.Entity<Application>(options => options.HasKey("Id"));
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
		public SkillProfiDBContext() { }
		public SkillProfiDBContext(DbContextOptionsBuilder optionsBuilder) : base() {}
	}
}
