using Microsoft.AspNetCore;

namespace SkillProfiWebClient
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args)
				.Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.ConfigureLogging(log => log.AddConsole())
				.Build();
		
	}
}
