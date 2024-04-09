using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Blogs;
using SkillProfiWebAPI.Data;

namespace SkillProfiWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController : ControllerBase
	{
		private readonly BlogRepository _blogRepository;

		public BlogController(BlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		[HttpGet("getBlogs")]
		public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
		{
			try
			{
				var blogs = await _blogRepository.GetBlogsAsync();
				return Ok(blogs);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while loading blogs: {ex.Message}" });
			}
		}

		[HttpPost("createBlog")]
		public async Task<IActionResult> CreateBlog([FromBody]BlogModel model)
		{
			try
			{
				await _blogRepository.CreateBlogAsync(model);
				return Ok(new { message = "Blog created successfully" });
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while creating blog: {ex.Message}" });
			}
		}

		[HttpDelete("deleteBlog/{id}")]
		public async Task<IActionResult> DeleteBlog(int id)
		{
			try
			{
				await _blogRepository.DeleteBlogAsync(id);
				return Ok(new {message = "Blog deleted successfully"});
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while deleting: {ex.Message}" });
			}
		}
	}
}
