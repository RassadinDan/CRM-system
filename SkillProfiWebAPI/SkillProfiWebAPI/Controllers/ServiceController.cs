using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Services;
using SkillProfiWebAPI.Data;

namespace SkillProfiWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiceController : ControllerBase
	{
		private readonly ServiceRepository _serviceRepository;

		public ServiceController(ServiceRepository serviceRepository)
		{
			_serviceRepository = serviceRepository;
		}

		[HttpGet("getall")]
		[Authorize(Roles ="Guest, Administrator")]
		public async Task<ActionResult<IEnumerable<Service>>> GetServices()
		{
			try
			{
				var services = await _serviceRepository.GetServicesAsync();
				return Ok(services);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error whie loading services: {ex.Message}" });
			}
		}

		[HttpGet("getone/{id}")]
		[Authorize(Roles = "Guest, Administrator")]
		public async Task<ActionResult<Service>> GetServiceById(int id)
		{
			try
			{
				var service = await _serviceRepository.GetByIdAsync(id);
				return Ok(service);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while loading service: {ex.Message}" });
			}
		}

		[HttpPost("createService")]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> CreateService([FromBody]ServiceModel model)
		{
			try
			{
				await _serviceRepository.CreateServiceAsync(model);
				return Ok(new { message = "Service created successfully" });
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while creating a service: {ex.Message}" });
			}
		}

		[HttpPut("updateService/{id}")]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> UpdateService(int id, [FromBody]ServiceModel model)
		{
			try
			{
				await _serviceRepository.UpdateServiceAsync(id, model);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while updating service: {ex.Message}" });
			}
		}

		[HttpDelete("deleteService/{id}")]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteService(int id)
		{
			try
			{
				await _serviceRepository.DeleteServiceAsync(id);
				return Ok(new { message = "Service deleted successfully" });
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while deleting service: {ex.Message}" });
			}
		}
	}
}
