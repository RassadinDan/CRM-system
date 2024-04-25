using ModelLibrary.Blogs;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SkillProfiWebClient.Data
{
	public class BlogDataService
	{
		private readonly HttpClient _httpClient;

		public BlogDataService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("AuthorizedClient");
		}

		public async Task<IEnumerable<Blog>> GetBlogsAsync()
		{
			var url = "https://localhost:7044/api/blog/getBlogs";
			var result = await _httpClient.GetStringAsync(url);
			var blogs = JsonConvert.DeserializeObject<IEnumerable<Blog>>(result);
			return blogs;
		}


		public  async Task<Blog> GetByIdAsync(int id)
		{
			var url = $"https://localhost:7044/api/blog/getById/{id}";
			var result = await _httpClient.GetStringAsync(url);
			var blog = JsonConvert.DeserializeObject<Blog>(result);
			return blog;
		}

		public async Task<bool> CreateBlogAsync(BlogModel model)
		{
			var url = "https://localhost:7044/api/blog/createBlog";

			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(model.Name ?? string.Empty), "Name");
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
				var result = await _httpClient.PostAsync(url, formData);
				return result.IsSuccessStatusCode;
			}
		}

		public async Task<bool> UpdateBlogAsync(int id, BlogModel model)
		{
			var url = $"https://localhost:7044/api/blog/updateBlog/{id}";
			
			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(model.Name ?? string.Empty), "Name");
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
				var result = await _httpClient.PutAsync(url, formData);
				return result.IsSuccessStatusCode;
			}
		}

		public async Task<bool> DeleteBlogAsync(int id)
		{
			var url = $"https://localhost:7044/api/blog/deleteBlog/{id}";
			var result = await _httpClient.DeleteAsync(url);
			return result.IsSuccessStatusCode;
		}
	}
}
