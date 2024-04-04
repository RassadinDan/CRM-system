using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Applications;
using Newtonsoft.Json;
using SkillProfiWebClient.Data;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace SkillProfiWebClient.Controllers
{
	[Route("[controller]")]
	public class AdminController : Controller
	{
		private readonly ILogger<AdminController> _logger;
		private readonly AdminDataService _adminDataService;

		public AdminController(ILogger<AdminController> logger, AdminDataService dataService)
		{
			_logger = logger;
			_adminDataService = dataService;
		}

		[HttpGet("workbench")]
		public async Task<IActionResult> Workbench()
		{
			if(AuthSession.User != null) 
			{
				if (AuthSession.User.Role == "Administrator") 
				{
					var model = await _adminDataService.GetApplicationsAsync();
					return View(model);
				}
				else
				{
					return RedirectToAction("Login", "Auth");
				}
			}
			return BadRequest(new { message = "Error while logging in" });
		}

		[HttpPost("updateApplicationStatus/{id}")]
		public async Task<IActionResult> UpdateApplicationStatus(int id, ApplicationStatus NewStatus)
		{
			var r = await _adminDataService.UpdateApplicationStatusAsync(id, NewStatus);
			if(r)
			{
				return RedirectToAction("Workbench", "Admin");
			}
			else
			{
				return BadRequest(new { message = "Error while updating application status" });
			}
		}

		[HttpGet]
		public IActionResult Main()
		{
			return View();
		}

		// TODO Сначала нужно разобраться с логикой обработки заявок
		// (открпавки со стороны гостя, апдейта статуса со стороны админа), а потом уже можно
		// разрабатывать логику остальных представлений.


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
