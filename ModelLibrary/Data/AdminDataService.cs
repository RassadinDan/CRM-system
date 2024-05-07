using ModelLibrary.Applications;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace ModelLibrary.Data
{
	public class AdminDataService
	{
		private readonly HttpClient _httpClient;

		public AdminDataService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("AuthorizedClient");
		}

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
			return result.IsSuccessStatusCode;
		}
	}
}
