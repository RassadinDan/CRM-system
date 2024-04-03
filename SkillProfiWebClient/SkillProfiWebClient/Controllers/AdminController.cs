using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Applications;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace SkillProfiWebClient.Controllers
{
	[Route("[controller]")]
	public class AdminController : Controller
	{
		private readonly ILogger<AdminController> _logger;
		private readonly HttpClient _httpClient;

		public AdminController(ILogger<AdminController> logger, HttpClient httpClient)
		{
			_logger = logger;
			_httpClient = httpClient;
		}

		[HttpGet("workbench")]
		public async Task<IActionResult> Workbench()
		{
			if(AuthSession.User != null) 
			{
				if (AuthSession.User.Role == "Administrator") 
				{
					var url = "https://localhost:7044/api/admin/getapplications";
					var result = await _httpClient.GetStringAsync(url);
					var model = JsonConvert.DeserializeObject<IEnumerable<Application>>(result);

					return View(model);
				}
				else
				{
					return RedirectToAction("Login", "Auth");
				}
			}
			return BadRequest(new { message = "Error while logging in" });
		}


		// TODO Сначала нужно разобраться с логикой обработки заявок
		// (открпавки со стороны гостя, апдейта статуса со стороны админа), а потом уже можно
		// разрабатывать логику остальных представлений.

		[HttpGet]
		public IActionResult Main()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Projects() 
		{
			return View();
		}

		[HttpGet]
		public IActionResult Services() 
		{
			return View();
		}

		[HttpGet]
		public IActionResult Blog()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Contacts() 
		{
			return View();
		}
	}
}
