using SkillProfiWebAPI.DataContext;
using ModelLibrary.Blogs;
using Microsoft.EntityFrameworkCore;

namespace SkillProfiWebAPI.Data
{
	public class BlogRepository
	{
		private readonly SkillProfiDBContext _db;

		public BlogRepository(SkillProfiDBContext db)
		{
			_db = db;
		}
		public async Task<IEnumerable<Blog>> GetBlogsAsync()
		{
			var blogs = _db.Blogs.AsEnumerable();
			await Task.CompletedTask;
			return blogs;
		}

		public async Task<Blog> GetBlogByIdAsync(int id)
		{
			var blog = await _db.Blogs.FirstOrDefaultAsync(b=> b.Id == id);
			return blog;
		}

		public async Task CreateBlogAsync(BlogModel model)
		{
			var blog = new Blog()
			{
				Name = model.Name,
				Preview = model.Preview,
				Description = model.Description,
			};

			if(model.ImageFile != null)
			{
				using(var memoryStream = new  MemoryStream())
				{
					await model.ImageFile.CopyToAsync(memoryStream);
					blog.ImageData = memoryStream.ToArray();
					blog.ImageContentType = model.ImageFile.ContentType;
				}
			}
			_db.Blogs.Add(blog);
			await _db.SaveChangesAsync();
		}

		public async Task UpdateBlogAsync(int id, BlogModel model)
		{
			var blog = await _db.Blogs.FirstOrDefaultAsync(b=>b.Id == id);
			blog.Name = model.Name;
			blog.Preview = model.Preview;
			blog.Description = model.Description;

			if (model.ImageFile != null)
			{
				using (var memoryStream = new MemoryStream())
				{
					await model.ImageFile.CopyToAsync(memoryStream);
					blog.ImageData = memoryStream.ToArray();
					blog.ImageContentType = model.ImageFile.ContentType;
				}
			}
			_db.SaveChanges();
		}

		public async Task DeleteBlogAsync(int id)
		{
			var blog = _db.Blogs.FirstOrDefault(b => b.Id == id);
			if (blog != null)
			{
				_db.Blogs.Remove(blog);
				await _db.SaveChangesAsync();
			}
		}
	}
}
