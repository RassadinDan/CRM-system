using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using System.Text;
using SkillProfiWebAPI.DataContext;
using Microsoft.EntityFrameworkCore;
using SkillProfiWebAPI.Interfaces;
using SkillProfiWebAPI.Data;
using ModelLibrary.Applications;

namespace SkillProfiWebAPI
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "SkillProfiWebAPI",
					Version = "v1",
					Description = "ASP.NET Core Web API for CRM system"
				});
			});
			services.AddDbContext<SkillProfiDBContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
			});
			services.AddScoped<IRepository, UserRepository>();
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JwtSettings:SecretKey"]))
					};
				});
			services.AddAuthorization();
			services.AddScoped<IApplicationRepository, ApplicationRepository>();
			services.AddScoped<ApplicationFactory>();
			services.AddScoped<SettingsRepository>();
			services.AddScoped<BlogRepository>();
			services.AddScoped<ServiceRepository>();
			services.AddScoped<ContactRepository>();
		}
		public void Configure(IApplicationBuilder app)
		{
			app.UseHttpsRedirection();

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactWebAPI V1");
				options.RoutePrefix = "swagger";
			});
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
				endpoints.MapControllers());
		}
	}
}
