using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Auth.Dto;
using ModelLibrary.Auth;

namespace SkillProfiWebClient.Controllers
{
	public class AuthController : Controller
	{
		private readonly AuthService _authService;
		private readonly ILogger<AuthController> _logger;
		public AuthController(AuthService service, ILogger<AuthController> logger)
		{
			_authService = service;
			_logger = logger;
		}
		
		[HttpGet]
		public IActionResult Login()
		{
			return View(new LoginRequest());
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginRequest model)
		{
			var r = await _authService.LoginAsync(model);
			_logger.Log(LogLevel.Information, $"{r.User.UserName}===>{r.Token}");
			if (r.User != null && r.Token != string.Empty)
			{
				AuthSession.User = r.User;
				AuthSession.Token = r.Token;
				AuthSession.IsAuthenticated = true;
				if (AuthSession.User.Role == "Administrator")
				{
					return RedirectToAction("Workbench", "Admin");
				}
				if(AuthSession.User.Role == "Guest")
				{
					return RedirectToAction("Main", "Guest");
				}
			}
			return BadRequest(new { message = "Something go wrong" });
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegistrationRequest model)
		{
			var r = await _authService.RegisterAsync(model);
			if(r == true)
			{
				return RedirectToAction("Login");
			}
			else
			{
				return BadRequest(new { message = "Error while registering" });
			}
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			var r = await _authService.LogoutAsync();
			if(r == true)
			{
				AuthSession.ClearSession();
				return RedirectToAction("Login");
			}
			else
			{
				return BadRequest(new { message = "Error while loggin out" });
			}
		}
	}
}
