using ModelLibrary.Applications;
using Newtonsoft.Json;
using System.Text;

namespace SkillProfiWebClient.Data
{
	public class GuestDataService
	{
		private readonly HttpClient _httpClient;

		public GuestDataService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<bool> PostApplicationAsync(ApplicationRequest model)
		{
			var url = "https://localhost:7044/api/guest/postapplication";

			var r = await _httpClient.PostAsync(
				requestUri: url,
				content: new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8,
				mediaType: "application/json"));
			if(r.IsSuccessStatusCode)
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
