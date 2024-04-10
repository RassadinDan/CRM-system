using ModelLibrary.Projects;
using Newtonsoft.Json;

namespace SkillProfiWebClient.Data
{
	public class ProjectDataService
	{
		private readonly HttpClient _httpClient;

		public ProjectDataService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<Project>> GetProjectsAsync()
		{
			var url = "https://localhost:7044/api/project/getall";
			var result = await _httpClient.GetStringAsync(url);
			var projects = JsonConvert.DeserializeObject<IEnumerable<Project>>(result);
			return projects;
		}

		public async Task<Project> GetProjectByIdAsync(int id)
		{
			var url = $"https://localhost:7044/api/project/getone/{id}";
			var result = await _httpClient.GetStringAsync(url);
			var project = JsonConvert.DeserializeObject<Project>(result);
			return project;
		}

		public async Task<bool> CreateProjectAsync(ProjectModel model)
		{
			var url = "https://localhost:7044/api/project/createProject";
			var result = await _httpClient.PostAsJsonAsync(url, model);
			if(result.IsSuccessStatusCode)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> UpdateProjectAsync(int id, ProjectModel model)
		{
			var url = $"https://localhost:7044/api/project/updateProject/{id}";
			var result = await _httpClient.PutAsJsonAsync(url, model);
			if(result.IsSuccessStatusCode)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> DeleteProjectAsync(int id)
		{
			var url = $"https://localhost:7044/api/project/deleteProject/{id}";
			var result = await _httpClient.DeleteAsync(url);
			if(result.IsSuccessStatusCode)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
