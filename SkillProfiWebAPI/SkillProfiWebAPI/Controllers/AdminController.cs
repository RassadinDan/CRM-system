﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Applications;
using ModelLibrary.UISettings;
using SkillProfiWebAPI.Data;
using SkillProfiWebAPI.Interfaces;

namespace SkillProfiWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize(Roles = "Administrator")]
	public class AdminController : ControllerBase
	{
		private readonly IApplicationRepository _repository;
		private readonly SettingsRepository _settings;

		public AdminController(IApplicationRepository repository, SettingsRepository settingsRepository)
		{
			_repository = repository;
			_settings = settingsRepository;
		}

		[HttpGet("getApplications")]
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

		[HttpPost("updateApplicationStatus/{id}")]
		public async Task<IActionResult> UpdateApplicationStatus(int id, [FromBody]ApplicationStatus status)
		{
			try
			{
				await _repository.UpdateStatusAsync(id, status);
				return Ok(new {message = "Status updated successfully"});
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while updating application status: {ex.Message}" });
			}
		}

		[HttpGet("getSettings")]
		public async Task<ActionResult<MainSettings>> GetSettings()
		{
			try
			{
				var settings = await _settings.GetSettingsAsync();
				return Ok(settings);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while loading UI settings: {ex.Message}" });
			}
		}

		[HttpPost("updateSettings")]
		public async Task<IActionResult> UpdateSettings([FromBody]MainSettings newSettings)
		{
			try
			{
				await _settings.UpdateSettingsAsync(newSettings);
				return Ok(new { message = "Settings updated successfully" });
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while updating UI settings: {ex.Message}" });
			}
		}
	}
}
