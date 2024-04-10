using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Projects;
using SkillProfiWebClient.Data;

namespace SkillProfiWebClient.Controllers
{
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
				return Ok(projects);
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

		[HttpPost("createProject")]
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

		[HttpPut("updateProject/{id}")]
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

		[HttpDelete("deleteProject/{id}")]
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
