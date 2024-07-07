using ModelLibrary.Projects;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace ModelLibrary.Data
{
	public class ProjectDataService
	{
		private readonly HttpClient _httpClient;

		public ProjectDataService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("AuthorizedClient");
		}

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

			using(var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(model.Preview ?? string.Empty), "Preview");
				formData.Add(new StringContent(model.Description ?? string.Empty), "Description");

				if(model.ImageFile != null)
				{
					using (var memoryStream = new MemoryStream())
					{
						await model.ImageFile.CopyToAsync(memoryStream);
						var fileBytes = memoryStream.ToArray();
						var fileContent = new ByteArrayContent(fileBytes);
						fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(model.ImageFile.ContentType);
						formData.Add(fileContent, "ImageFile", model.ImageFile.FileName);
					}
				}

				Console.WriteLine(model.ImageData != null);
				if (model.ImageData != null)
				{
					using (var memoryStream = new MemoryStream())
					{
						//model.ImageData.CopyTo(memoryStream);
						var bytes = new ByteArrayContent(model.ImageData);
						bytes.Headers.ContentType = new MediaTypeHeaderValue(model.ImageContentType);
						formData.Add(bytes, "ImageData", model.ImageDataUrl);

					}

					Console.WriteLine($"{model.ImageDataUrl}\n{formData.Headers}\n{model.ImageContentType}");
                }
				foreach(var item in formData)
				{
					Console.WriteLine($"{item.Headers}");
				}
                var result = await _httpClient.PostAsync(url, formData);
				Console.WriteLine($"{result.StatusCode.ToString()}");
				return result.IsSuccessStatusCode;
			}
		}

		public async Task<bool> CreateAsync(ProjectModel model)
		{
            var url = "https://localhost:7044/api/project/createFromDesc";

			var result = await _httpClient.PostAsJsonAsync(url, model);
			Console.WriteLine(result.StatusCode.ToString());
			return result.IsSuccessStatusCode;
        }

		public async Task<bool> UpdateProjectAsync(int id, ProjectModel model)
		{
			var url = $"https://localhost:7044/api/project/updateProject/{id}";

			using(var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(model.Preview ?? string.Empty), "Preview");
				formData.Add(new StringContent(model.Description ?? string.Empty), "Description");

				if(model.ImageFile != null)
				{
					using(var memoryStream = new MemoryStream())
					{
						await model.ImageFile.CopyToAsync(memoryStream);
						var fileBytes = memoryStream.ToArray();
						var fileContent = new ByteArrayContent(fileBytes);
						fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(model.ImageFile.ContentType);
						formData.Add(fileContent, "ImageFile", model.ImageFile.FileName);
					}
				}
				var result = await _httpClient.PutAsync(url, formData);
				return result.IsSuccessStatusCode;
			}
		}

		public async Task<bool> UpdateAsync(int id, ProjectModel model)
		{
            var url = $"https://localhost:7044/api/project/updateFromDesc/{id}";
			var result = await _httpClient.PutAsJsonAsync(url, model);
            Console.WriteLine(result.StatusCode.ToString());
            return result.IsSuccessStatusCode;
        }

		public async Task<bool> DeleteProjectAsync(int id)
		{
			var url = $"https://localhost:7044/api/project/deleteProject/{id}";
			var result = await _httpClient.DeleteAsync(url);
			return result.IsSuccessStatusCode;
		}
	}
}
