using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Services;
using SkillProfiWebClient.Data;

namespace SkillProfiWebClient.Controllers
{
	[Route("[controller]")]
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
				return View(services);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while loading services: {ex.Message}"});
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
				return BadRequest(new {message =$"Error while loading a service: {ex.Message}"});
			}
		}

		[HttpGet("createform")]
		public IActionResult CreateForm()
		{
			return View(new ServiceModel());
		}

		[HttpGet("updateform/{id}")]
		public async Task<IActionResult> UpdateForm(int id)
		{
			var service = await _serviceData.GetServiceByIdAsync(id);
			var model = new ServiceModel()
			{
				Id = service.Id,
				Name = service.Name,
				Description = service.Description
			};
			return View(model);
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateService([FromForm]ServiceModel model)
		{
			try
			{
				await _serviceData.CreateServiceAsync(model);
				return RedirectToAction("GetServices");
			}
			catch (Exception ex)
			{
				return BadRequest(new {message = $"Error while creating a service: {ex.Message}"});
			}
		}

		[HttpPost("update/{id}")]
		public async Task<IActionResult> UpdateService(int id, [FromForm]ServiceModel model)
		{
			try
			{
				await _serviceData.UpdateServiceAsync(id, model);
				return RedirectToAction("GetServices");
			}
			catch (Exception ex)
			{
				return BadRequest(new {message=$"Error while updating a service: {ex.Message}"});
			}
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteService(int id)
		{
			try
			{
				await _serviceData.DeleteServiceAsync(id);
				return RedirectToAction("GetServices");
			}
			catch(Exception ex)
			{
				return BadRequest(new {message = $"Error while deleting a service: {ex.Message}"});
			}
		}
	}
}
