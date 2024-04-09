using ModelLibrary.Applications;
using Newtonsoft.Json;

namespace SkillProfiWebClient.Data
{
	public class AdminDataService
	{
		private readonly HttpClient _httpClient;

		public AdminDataService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<Application>> GetApplicationsAsync()
		{
			var url = "https://localhost:7044/api/admin/getApplications";
			var result = await _httpClient.GetStringAsync(url);
			var model = JsonConvert.DeserializeObject<IEnumerable<Application>>(result);
			return model;
		}

		public async Task<bool> UpdateApplicationStatusAsync(int id, ApplicationStatus newStatus)
		{
			var url = $"https://localhost:7044/api/admin/updateApplicationStatus/{id}";
			var result = await _httpClient.PostAsJsonAsync(url, newStatus);
			if (result.IsSuccessStatusCode)
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
