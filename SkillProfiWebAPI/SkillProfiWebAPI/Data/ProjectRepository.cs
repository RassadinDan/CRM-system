using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Blogs;
using ModelLibrary.Projects;
using SkillProfiWebAPI.DataContext;

namespace SkillProfiWebAPI.Data
{
	public class ProjectRepository
	{
		private readonly SkillProfiDBContext _db;

		public ProjectRepository(SkillProfiDBContext db)
		{
			_db = db;
		}

		public async Task<IEnumerable<Project>> GetProjectsAsync()
		{
			var projects = _db.Projects.AsEnumerable();
			await Task.CompletedTask;
			return projects;
		}

		public async Task<Project> GetProjectByIdAsync(int id)
		{
			var project = await _db.Projects.FirstOrDefaultAsync(p=>p.Id== id);
			return project;
		}

		public async Task CreateProjectAsync(ProjectModel model)
		{
			Console.WriteLine($"{model.Preview}\n{model.Description}\n{model.ImageContentType}\n{model.ImageDataUrl}\n{model.ImageData}");
			//var project = new Project()
			//{
			//	Preview = model.Preview,
			//	Description = model.Description
			//};
			if(model.ImageFile != null)
			{
				using(var memoryStream = new MemoryStream())
				{
					await model.ImageFile.CopyToAsync(memoryStream);
					model.ImageData = memoryStream.ToArray();
					model.ImageContentType = model.ImageFile.ContentType;
				}
			}
			//if (model.ImageData != null)
			//{
			//	project.ImageData = model.ImageData;
			//}
			_db.Projects.Add(model);
			_db.SaveChanges();
		}

		public async Task UpdateProjectAsync(int id, ProjectModel model)
		{
			var project = await _db.Projects.FirstOrDefaultAsync(p=>p.Id== id);
			project = model;

			//project.Preview = model.Preview;
			//project.Description = model.Description;
			if (model.ImageFile != null)
			{
				using (var memoryStream = new MemoryStream())
				{
					await model.ImageFile.CopyToAsync(memoryStream);
					project.ImageData = memoryStream.ToArray();
					project.ImageContentType = model.ImageFile.ContentType;
				}
			}
			_db.SaveChanges();
		}

		public async Task DeleteProjectAsync(int id)
		{
			var project = await _db.Projects.FirstOrDefaultAsync(p => p.Id == id);
			if (project != null)
			{
				_db.Projects.Remove(project);
				_db.SaveChanges();
			}
		}
	}
}
