using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Projects;
using SkillProfiWebAPI.Data;

namespace SkillProfiWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly ProjectRepository _projectRepository;
		public ProjectController(ProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;
		}

		[HttpGet("getall")]
		[Authorize(Roles = "Guest, Administrator")]
		public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
		{
			try
			{
				var projects = await _projectRepository.GetProjectsAsync();
				return Ok(projects);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while loading projects: {ex.Message}" });
			}
		}

		[HttpGet("getone/{id}")]
		[Authorize(Roles = "Guest, Administrator")]
		public async Task<ActionResult<Project>> GetProjectById(int id)
		{
			try
			{
				var project = await _projectRepository.GetProjectByIdAsync(id);
				return Ok(project);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while loading project: {ex.Message}" });
			}
		}

		[HttpPost("createProject")]
		[Authorize(Roles = "Administrator")]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> CreateProject([FromForm]ProjectModel model)
		{
			try
			{
				await _projectRepository.CreateProjectAsync(model);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while creating a project: {ex.Message}" });
			}
		}

		[HttpPost("createFromDesc")]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> CreateFromDesc([FromBody]ProjectModel model)
		{
			try
			{
				await _projectRepository.CreateProjectAsync(model);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while creating a project: {ex.Message}" });

            }
		}

		[HttpPut("updateProject/{id}")]
		[Authorize(Roles = "Administrator")]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> UpdateProject(int id, [FromForm]ProjectModel model)
		{
			try
			{
				await _projectRepository.UpdateProjectAsync(id, model);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while updating a project: {ex.Message}" });
			}
		}

		[HttpPut("updateFromDesc/{id}")]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> UpdateFromDesc(int id, [FromBody] ProjectModel model)
		{
			try
			{
				await _projectRepository.UpdateProjectAsync(id, model);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while updating a project: {ex.Message}" });
			}
		}

		[HttpDelete("deleteProject/{id}")]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteProject(int id)
		{
			try
			{
				await _projectRepository.DeleteProjectAsync(id);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while deleting a project: {ex.Message}" });
			}
		}
	}
}
