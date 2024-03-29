using ModelLibrary.Auth.Dto;
using ModelLibrary.Auth;

namespace SkillProfiWebAPI.Interfaces
{
	public interface IRepository
	{
		bool IsUniqueUser(string username);
		Task<LoginResponse> Login(LoginRequest login);
		Task<User> Register(RegistrationRequest registration);
	}
}
