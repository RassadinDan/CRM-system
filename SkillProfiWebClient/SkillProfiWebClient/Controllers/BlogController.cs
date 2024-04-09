using Microsoft.AspNetCore.Mvc;
using SkillProfiWebClient.Data;
using ModelLibrary.Blogs;

namespace SkillProfiWebClient.Controllers
{
	[Route("[controller]")]
	public class BlogController : Controller
	{
		private readonly BlogDataService _blogDataService;

		public BlogController(BlogDataService blogDataService)
		{
			_blogDataService = blogDataService;
		}

		[HttpGet("getall")]
		public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
		{
			try
			{
				var blogs = await _blogDataService.GetBlogsAsync();
				return Ok(blogs);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while loading blogs: {ex.Message}" });
			}
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateBlog(BlogModel model)
		{
			var result = await _blogDataService.CreateBlogAsync(model);
			if(result)
			{
				return Ok();
			}
			else
			{
				return BadRequest(new { message = "Error while creating a blog" });
			}
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteBlog(int id)
		{
			var result = await _blogDataService.DeleteBlogAsync(id);
			if(result)
			{
				return Ok();
			}
			else
			{
				return NotFound();
			}
		}
	}
}
