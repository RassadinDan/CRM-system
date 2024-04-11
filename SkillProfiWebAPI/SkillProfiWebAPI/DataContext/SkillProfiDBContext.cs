using Microsoft.EntityFrameworkCore;
using ModelLibrary.Auth;
using ModelLibrary.Applications;
using ModelLibrary.UISettings;
using ModelLibrary.Blogs;
using ModelLibrary.Services;
using ModelLibrary.Projects;
using ModelLibrary.Contacts;

namespace SkillProfiWebAPI.DataContext
{
	public class SkillProfiDBContext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Application> Applications { get; set; }
		public DbSet<MainSettings> MainSettings { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public SkillProfiDBContext(DbContextOptions options):base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(options => options.HasKey("UserName"));
			modelBuilder.Entity<Application>(options => options.HasKey("Id"));
			modelBuilder.Entity<MainSettings>(options => options.HasKey("LayoutHeader"));
			modelBuilder.Entity<Blog>(options => options.HasKey("Id"));
			modelBuilder.Entity<Service>(options => options.HasKey("Id"));
			modelBuilder.Entity<Project>(options => options.HasKey("Id"));
			modelBuilder.Entity<Contact>(options => options.HasKey("Id"));
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
		public SkillProfiDBContext() { }
		public SkillProfiDBContext(DbContextOptionsBuilder optionsBuilder) : base() {}
	}
}
