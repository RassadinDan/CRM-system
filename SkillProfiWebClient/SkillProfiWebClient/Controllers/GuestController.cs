using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Applications;
using Newtonsoft.Json;
using SkillProfiWebClient.Data;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;

namespace SkillProfiWebClient.Controllers
{
	public class GuestController : Controller
	{
		private readonly ILogger<GuestController> _logger;
		private readonly GuestDataService _guestDataService;

		public GuestController(ILogger<GuestController> logger, GuestDataService dataService)
		{
			_logger = logger;
			_guestDataService = dataService;
		}

		[HttpGet]
		public IActionResult Main()
		{
			return View(new ApplicationRequest());
		}

		public async Task<IActionResult> PostApplication([FromForm]ApplicationRequest model)
		{
			var r = await _guestDataService.PostApplicationAsync(model);
			if(r == true)
			{
				return RedirectToAction("Main", "Guest");
			}
			return BadRequest(new { message = "Error while creating an application" });
		}
	}
}
