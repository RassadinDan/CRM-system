using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Applications;
using SkillProfiWebAPI.Interfaces;

namespace SkillProfiWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly IApplicationRepository _repository;

		public AdminController(IApplicationRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("getapplications")]
		public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
		{
			try
			{
				var applications = await _repository.GetApplicationsAsync();
				return Ok(applications);
			}
			catch(Exception ex)
			{
				return BadRequest(new {message = $"Error while loading application list: {ex.Message}"});
			}
		}
	}
}
