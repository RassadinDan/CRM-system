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
			var projects = _db.Projects.AsEnumerable<Project>();
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
			var project = new Project()
			{
				Preview = model.Preview,
				Description = model.Decription
			};
			if(model.ImageFile != null)
			{
				using(var memoryStream = new MemoryStream())
				{
					await model.ImageFile.CopyToAsync(memoryStream);
					project.ImageData = memoryStream.ToArray();
					project.ImageContentType = model.ImageFile.ContentType;
				}
			}
			_db.Projects.Add(project);
			_db.SaveChanges();
		}

		public async Task UpdateProjectAsync(int id, ProjectModel model)
		{
			var project = await _db.Projects.FirstOrDefaultAsync(p=>p.Id== id);
			project.Preview = model.Preview;
			project.Description = model.Decription;
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
