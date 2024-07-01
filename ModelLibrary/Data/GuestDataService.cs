using ModelLibrary.Applications;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace ModelLibrary.Data
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
			if (model.Name == string.Empty || model.Email == string.Empty || model.Text == string.Empty)
			{
				return false;
			}
			var url = "https://localhost:7044/api/guest/postapplication";

			var r = await _httpClient.PostAsync(
				requestUri: url,
				content: new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8,
				mediaType: "application/json"));
			return r.IsSuccessStatusCode;
		}
	}
}
