using ModelLibrary.Auth;

namespace SkillProfiWebClient
{
	public static class AuthSession
	{
		public static bool IsAuthenticated { get; set; }

		public static User? User { get; set; }

		public static string? Token { get; set; }

		public static void ClearSession()
		{
			IsAuthenticated = false;
			User = null;
			Token = string.Empty;
		}
	}
}
