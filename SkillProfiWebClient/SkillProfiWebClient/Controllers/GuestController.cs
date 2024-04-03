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

		public async Task<IActionResult> PostApplication([FromForm]ApplicationRequest model)
		{
			var url = "https://localhost:7044/api/guest/postapplication";

			var r = await _httpClient.PostAsync(
				requestUri: url,
				content: new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8,
				mediaType: "application/json"));

			if(r.IsSuccessStatusCode)
			{
				return RedirectToAction("Main", "Guest");
			}
			return BadRequest(new { message = "Error while creating an application" });
		}
	}
}
