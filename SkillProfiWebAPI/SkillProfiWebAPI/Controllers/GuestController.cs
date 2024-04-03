﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Applications;
using SkillProfiWebAPI.Interfaces;

namespace SkillProfiWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GuestController : ControllerBase
	{
		private readonly IApplicationRepository _repository;
		private readonly ILogger<GuestController> _logger;

		public GuestController(IApplicationRepository repository, ILogger<GuestController> logger)
		{
			_repository = repository;
			_logger = logger;
		}

		[HttpPost("postapplication")]
		public async Task<IActionResult> PostApplication([FromBody]ApplicationRequest model)
		{
			try
			{ 
				await _repository.CreateAsync(model.Name, model.Text, model.Email);
				return Ok(new { message = "Application created successfully" });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
