using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Projects;
using SkillProfiWebClient.Data;

namespace SkillProfiWebClient.Controllers
{
	[Route("[controller]")]
	public class ProjectController : Controller
	{
		private readonly ProjectDataService _projectData;

		public ProjectController(ProjectDataService projectData)
		{
			_projectData = projectData;
		}

		[HttpGet("getall")]
		public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
		{
			try
			{
				var projects = await _projectData.GetProjectsAsync();
				return View(projects);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while loading projects: {ex.Message}" });
			}
		}

		[HttpGet("getone/{id}")]
		public async Task<ActionResult<Project>> GetProjectById(int id)
		{
			try
			{
				var project = await _projectData.GetProjectByIdAsync(id);
				return Ok(project);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while loading a project: {ex.Message}" });
			}
		}

		[HttpGet("createform")]
		public IActionResult CreateForm()
		{
			return View(new ProjectModel());
		}

		[HttpGet("updateform/{id}")]
		public async Task<IActionResult> UpdateForm(int id)
		{
			var project = await _projectData.GetProjectByIdAsync(id);
			var model = new ProjectModel()
			{
				Id = project.Id,
				Preview = project.Preview,
				Description = project.Description
			};
			if(project.ImageData != null)
			{
				string imageBase64Data = Convert.ToBase64String(project.ImageData);
				model.ImageDataUrl = string.Format("data:image/jpeg;base64,{0}", imageBase64Data);
			}
			return View(model);
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateProject([FromForm]ProjectModel model)
		{
			try
			{
				await _projectData.CreateProjectAsync(model);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while creating a project: {ex.Message}" });
			}
		}

		[HttpPost("update/{id}")]
		public async Task<IActionResult> UpdateProject(int id, [FromForm]ProjectModel model)
		{
			try
			{
				await _projectData.UpdateProjectAsync(id, model);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while updating a project: {ex.Message}" });
			}
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteProject(int id)
		{
			try
			{
				await _projectData.DeleteProjectAsync(id);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while deleting a project: {ex.Message}" });
			}
		}
	}
}
