using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillProfiWebAPI.Interfaces;
using ModelLibrary.Auth.Dto;

namespace SkillProfiWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IRepository _userRepo;
		private readonly ILogger<AuthController> _logger;

		public AuthController(IRepository userRepo, ILogger<AuthController> logger)
		{
			_userRepo = userRepo;
			_logger = logger;
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync([FromBody] LoginRequest model)
		{
			var loginResponse = await _userRepo.Login(model);
			if (loginResponse == null || string.IsNullOrEmpty(loginResponse.Token))
			{
				return BadRequest(new { message = "Username or password is incorrect" });
			}
			return Ok(loginResponse);
		}

		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequest model)
		{
			_logger.Log(LogLevel.Information, model.UserName);
			bool IfUserNameUnique = _userRepo.IsUniqueUser(model.UserName);
			if(!IfUserNameUnique)
			{
				return BadRequest(new { message = "User already exists" });
			}

			var user = await _userRepo.Register(model);
			if (user == null)
			{
				return BadRequest(new {message = "Error while registering"});
			}
			return Ok();
		}

		[HttpPost("logout")]
		public async Task<IActionResult> LogoutAsync()
		{
			Response.Headers.Remove("Authorization");
			await Task.CompletedTask;
			return Ok(new {message = "Logout succeeded"});
		}
	}
}
