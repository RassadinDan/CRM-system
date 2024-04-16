using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Applications;
using ModelLibrary.UISettings;
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
		private readonly UISettingsManager _uiSettingsManager;
		//private MainSettings _settings;

		public AdminController(ILogger<AdminController> logger, AdminDataService dataService, UISettingsManager settingsManager)
		{
			_logger = logger;
			_adminDataService = dataService;
			_uiSettingsManager = settingsManager;
			//_settings = _uiSettingsManager.GetSettings();
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

		//[HttpGet("main")]
		//public IActionResult Main()
		//{
		//	ViewData["Title"] = _settings.MainHeader;
		//	return View(_settings);
		//}

		[HttpPost("updateSettings")]
		public async Task<IActionResult> UpdateSettings([FromForm]MainSettings newSettings)
		{
			var result = await _uiSettingsManager.UpdateSettings(newSettings);
			if(result == true)
			{
				return RedirectToAction("Main", "Admin");
			}
			else
			{
				return BadRequest(new { message = "Error while updating settings" });
			}
		}


		// TODO Задача: разобраться с обновлением пользовательского интерфейса через администраторскую логику
		// класс для этого уже создан, логика API настроена, осталось теперь настроить это "на местах".
		// Итак, у меня есть две огромные папки с контроллерами, оборудованными для создания, обновления, удаления и получения любой модели.
		// Теперь мне необходимо разделить оставшуюся логику по ролям. Этот контроллер для администраторов, у них больше доступных функций.
		


		[HttpGet]
		public IActionResult Projects() 
		{
			return View();
		}


		// Ну и вот сюда тоже нужно сделать редирект. Или отсюда \:

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

		// А вот теперь главный вопрос: а как мне реализовать этот замечательный переход из одного контроллера в другой.
		// Как это делается я в курсе, тут все понятно)) не понятно, что именно я хочу от этого всего, не понятен ВЕСЬ путь, который нужно проделать.

		[HttpGet]
		public IActionResult Contacts() 
		{
			return RedirectToAction("GetContacts", "Contact");
		}
	}
}
