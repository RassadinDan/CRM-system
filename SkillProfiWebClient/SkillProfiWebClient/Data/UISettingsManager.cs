using ModelLibrary.UISettings;
using Newtonsoft.Json;

namespace SkillProfiWebClient.Data
{
	public class UISettingsManager
	{
		private readonly HttpClient _httpClient;

		public UISettingsManager(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("AuthorizedClient");
		}

		public MainSettings GetSettings()
		{
			var url = "https://localhost:7044/api/admin/getSettings";
			var result = _httpClient.GetStringAsync(url).Result;
			var settings = JsonConvert.DeserializeObject<MainSettings>(result);
			return settings;
		}

		// TODO
		public async Task<bool> UpdateSettings(MainSettings newSettings)
		{
			var url = "https://localhost:7044/api/admin/updateSettings";
			var result = await _httpClient.PostAsJsonAsync(url, newSettings);
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
