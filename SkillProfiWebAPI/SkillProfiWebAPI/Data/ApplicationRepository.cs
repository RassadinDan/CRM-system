using ModelLibrary.Applications;
using SkillProfiWebAPI.DataContext;
using SkillProfiWebAPI.Interfaces;
using System.Runtime.CompilerServices;

namespace SkillProfiWebAPI.Data
{
	public class ApplicationRepository : IApplicationRepository
	{
		private readonly ApplicationFactory _factory;
		private readonly SkillProfiDBContext _db;
		public ApplicationRepository(ApplicationFactory factory, SkillProfiDBContext db)
		{
			_factory = factory;
			_db = db;
		}

		public async Task CreateAsync(string name, string text, string email)
		{
			var application = _factory.Create(name, text, email);
			_db.Applications.Add(application);
			await _db.SaveChangesAsync();
		}

		public async Task UpdateStatusAsync(int id, ApplicationStatus status)
		{
			var app = _db.Applications.FirstOrDefault(a => a.Id == id);
			app.Status = status;
			await _db.SaveChangesAsync();
		}

		public async Task<IEnumerable<Application>> GetApplicationsAsync()
		{
			var list = _db.Applications.AsEnumerable<Application>();
			return list;
		}
	}
}
