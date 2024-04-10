﻿using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Services;
using SkillProfiWebClient.Data;

namespace SkillProfiWebClient.Controllers
{
	public class ServiceController : Controller
	{
		private readonly ServiceDataService _serviceData;

		public ServiceController(ServiceDataService serviceData)
		{
			_serviceData = serviceData;
		}

		[HttpGet("getall")]
		public async Task<ActionResult<IEnumerable<Service>>> GetServices()
		{
			try
			{
				var services = await _serviceData.GetServicesAsync();
				return Ok(services);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("getone/{id}")]
		public async Task<ActionResult<Service>> GetServiceById(int id)
		{
			try
			{
				var service = await _serviceData.GetServiceByIdAsync(id);
				return Ok(service);
			}
			catch (Exception ex)
			{
				return NotFound();
			}
		}

		[HttpPost("createService")]
		public async Task<IActionResult> CreateService([FromForm]ServiceModel model)
		{
			try
			{
				await _serviceData.CreateServiceAsync(model);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("updateService/{id}")]
		public async Task<IActionResult> UpdateService(int id, [FromBody] ServiceModel model)
		{
			try
			{
				await _serviceData.UpdateServiceAsync(id, model);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("deleteService/{id}")]
		public async Task<IActionResult> DeleteService(int id)
		{
			try
			{
				await _serviceData.DeleteServiceAsync(id);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}