using ModelLibrary.Blogs;
using Newtonsoft.Json;

namespace SkillProfiWebClient.Data
{
	public class BlogDataService
	{
		private readonly HttpClient _httpClient;

		public BlogDataService(HttpClient httpClient)
		{
			_httpClient = httpClient;
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
