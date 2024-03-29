using Microsoft.EntityFrameworkCore;
using ModelLibrary.Auth;

namespace SkillProfiWebAPI.DataContext
{
	public class SkillProfiDBContext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public SkillProfiDBContext(DbContextOptions options):base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(options => options.HasKey("UserName"));
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
		public SkillProfiDBContext() { }
		public SkillProfiDBContext(DbContextOptionsBuilder optionsBuilder) : base() {}
	}
}
