using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ModelLibrary.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SkillProfiWebClient.Data;

namespace SkillProfiWebClient
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddScoped<AuthService>();
			services.AddScoped<AdminDataService>();
			services.AddScoped<GuestDataService>();
			services.AddScoped<UISettingsManager>();
			services.AddHttpClient();
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
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
		}
		public void Configure(IApplicationBuilder app)
		{
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Auth}/{action=Login}/{id?}"));
		}
	}
}
