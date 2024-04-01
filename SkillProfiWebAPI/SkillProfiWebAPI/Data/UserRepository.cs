using Microsoft.EntityFrameworkCore;
using ModelLibrary.Auth;
using ModelLibrary.Auth.Dto;
using SkillProfiWebAPI.Interfaces;
using SkillProfiWebAPI.DataContext;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkillProfiWebAPI.Data
{
	public class UserRepository : IRepository
	{
		private readonly SkillProfiDBContext _db;
		private string secretKey;
		public UserRepository(SkillProfiDBContext dB, IConfiguration config)
		{
			_db = dB;
			secretKey = config.GetValue<string>("JwtSettings:SecretKey");
		}
		public bool IsUniqueUser(string username)
		{
			var user = _db.Users.SingleOrDefault(x => x.UserName == username);
			if (user == null)
			{
				return true;
			}
			return false;
		}

		public async Task<LoginResponse> Login(LoginRequest login)
		{
			var user = _db.Users.FirstOrDefault(u => u.UserName.ToLower() == login.UserName.ToLower() && u.Password == login.Password);

			if (user == null)
			{
				return new LoginResponse()
				{
					Token = "",
					User = null
				};
			}

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			var loginResponse = new LoginResponse()
			{
				Token = tokenHandler.WriteToken(token),
				User = user
			};
			return loginResponse;
		}

		public async Task<User> Register(RegistrationRequest registration)
		{
			User user = new()
			{
				UserName = registration.UserName,
				Password = registration.Password,
				Role = registration.Role
			};
			_db.Users.Add(user);
			await _db.SaveChangesAsync();
			user.Password = "";
			return user;
		}
	}
}
