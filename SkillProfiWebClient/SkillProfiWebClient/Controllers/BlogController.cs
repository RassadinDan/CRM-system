﻿using Microsoft.AspNetCore.Mvc;
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
				return View(blogs);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while loading blogs: {ex.Message}" });
			}
		}

		[HttpGet("getone/{id}")]
		public async Task<ActionResult<Blog>> GetById(int id)
		{
			try
			{
				var blog = await _blogDataService.GetByIdAsync(id);
				return View(blog);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while loading a blog: {ex.Message}" });
			}
		}

		[HttpGet("createform")]
		public IActionResult CreateForm()
		{
			return View(new BlogModel());
		}

		[HttpGet("updateform/{id}")]
		public async Task<IActionResult> UpdateForm(int id) 
		{
			var blog = await _blogDataService.GetByIdAsync(id);
			var model = new BlogModel()
			{
				Id = blog.Id,
				Name = blog.Name,
				Preview = blog.Preview,
				Description = blog.Description,
			};

			if (blog.ImageData != null)
			{
				string imageBase64Data = Convert.ToBase64String(blog.ImageData);
				model.ImageDataUrl = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
			}
			return View(model);
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateBlog([FromForm]BlogModel model)
		{
			try
			{ 
				await _blogDataService.CreateBlogAsync(model);
				return RedirectToAction("GetBlogs");
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while creating a blog: {ex.Message}" });
			}
		}

		[HttpPost("update/{id}")]
		public async Task<IActionResult> UpdateBlog(int id, [FromForm] BlogModel model)
		{
			try
			{
				await _blogDataService.UpdateBlogAsync(id, model);
				return RedirectToAction("GetBlogs");
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while updating a blog: {ex.Message}" });
			}
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteBlog(int id)
		{
			try
			{ 
				var result = await _blogDataService.DeleteBlogAsync(id);
				return RedirectToAction("GetBlogs");
			}
			catch(Exception ex)
			{
				return BadRequest(new {message=$"Error while deleting a blog: {ex.Message}"});
			}
		}
	}
}
