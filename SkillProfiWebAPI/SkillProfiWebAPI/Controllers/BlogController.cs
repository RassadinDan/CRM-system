using Microsoft.AspNetCore.Authorization;
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
		[Authorize(Roles = "Guest, Administrator")]
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

		[HttpGet("getById/{id}")]
		[Authorize(Roles = "Guest, Administrator")]
		public async Task<ActionResult<Blog>> GetBlogById(int id)
		{
			try
			{
				var blog = await _blogRepository.GetBlogByIdAsync(id);
				return Ok(blog);
			}
			catch(Exception ex) 
			{
				return NotFound(new { message = $"Error while loading blog: {ex.Message}" });
			}
		}

		[HttpPost("createBlog")]
		[Authorize(Roles = "Administrator")]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> CreateBlog([FromForm]BlogModel model)
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

		[HttpPut("updateBlog/{id}")]
		[Authorize(Roles = "Administrator")]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> UpdateBlog(int id, [FromForm]BlogModel model)
		{
			try
			{
				await _blogRepository.UpdateBlogAsync(id, model);
				return Ok(new { message = "Blog update successfully" });
			}
			catch(Exception ex)
			{
				return BadRequest(new {message = $"Error while updating blog: {ex.Message}"}) ;
			}
		}

		[HttpDelete("deleteBlog/{id}")]
		[Authorize(Roles = "Administrator")]
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
