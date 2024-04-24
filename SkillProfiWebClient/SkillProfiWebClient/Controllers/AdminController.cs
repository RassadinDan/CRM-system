using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Applications;
using ModelLibrary.UISettings;
using Newtonsoft.Json;
using SkillProfiWebClient.Data;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using ModelLibrary.Projects;


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
	}
}
