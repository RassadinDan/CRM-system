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
			var memoryStream = new MemoryStream();
			await model.ImageFile.CopyToAsync(memoryStream);
			var fileBytes = memoryStream.ToArray();
			var fileContent = new ByteArrayContent(fileBytes);
			fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");

			using (var formData = new MultipartFormDataContent())
			{
				formData.Add(new StringContent(model.Name), "Name");
				formData.Add(new StringContent(model.Preview), "Preview");
				formData.Add(new StringContent(model.Description), "Description");
				formData.Add(fileContent, "ImageFile", model.ImageFile.FileName);

				var result = await _httpClient.PostAsync(url, formData);
				memoryStream.Dispose();
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

		public async Task<bool> UpdateBlogAsync(int id, BlogModel model)
		{
			var url = $"https://localhost:7044/api/blog/updateBlog/{id}";
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

		public async Task<bool> DeleteBlogAsync(int id)
		{
			var url = $"https://localhost:7044/api/blog/deleteBlog/{id}";
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
