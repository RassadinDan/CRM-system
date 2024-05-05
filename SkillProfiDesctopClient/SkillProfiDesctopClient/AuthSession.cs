using ModelLibrary.Auth;

namespace SkillProfiDesctopClient
{
    public static class AuthSession
    {
        public static bool IsAuthenticated {get; set;}
        public static User? User {get; set;}
        public static string? Token {get; set;}

        public static void Clear()
        {
            IsAuthenticated = false;
            User = null;
            Token = null;
        }
    }
}