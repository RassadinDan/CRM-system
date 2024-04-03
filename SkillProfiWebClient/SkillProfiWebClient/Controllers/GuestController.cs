using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Applications;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;

namespace SkillProfiWebClient.Controllers
{
	public class GuestController : Controller
	{
		private readonly ILogger<GuestController> _logger;
		private readonly HttpClient _httpClient;

		public GuestController(ILogger<GuestController> logger, HttpClient httpClient)
		{
			_logger = logger;
			_httpClient = httpClient;
		}

		[HttpGet]
		public IActionResult Main()
		{
			return View(new ApplicationRequest());
		}

		[HttpPost]
		public async Task<IActionResult> PostApplication([FromBody]ApplicationRequest model)
		{
			var url = "https://localhost:7044/api/guest/postapplication";
			var r = await _httpClient.PostAsJsonAsync(url, model);
			if(r.IsSuccessStatusCode)
			{
				return RedirectToAction("Main", "Guest");
			}
			return BadRequest(new { message = "Error while creating an application" });
		}
	}
}
