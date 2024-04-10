using SkillProfiWebAPI.DataContext;
using ModelLibrary.Services;
using Microsoft.EntityFrameworkCore;

namespace SkillProfiWebAPI.Data
{
	public class ServiceRepository
	{
		private readonly SkillProfiDBContext _db;

		public ServiceRepository(SkillProfiDBContext db)
		{
			_db = db;
		}

		public async Task<IEnumerable<Service>> GetServicesAsync()
		{
			var services = _db.Services.AsEnumerable();
			await Task.CompletedTask;
			return services;
		}

		public async Task<Service> GetByIdAsync(int id)
		{
			var service = await _db.Services.FirstOrDefaultAsync(s => s.Id == id);
			return service;
		}

		public async Task CreateServiceAsync(ServiceModel model)
		{
			var service = new Service()
			{
				Name = model.Name,
				Description = model.Description,
			};
			await _db.Services.AddAsync(service);
			_db.SaveChanges();
		}

		public async Task UpdateServiceAsync(int id, ServiceModel model)
		{
			var service = _db.Services.FirstOrDefault(s => s.Id == id);
			if(model!=null)
			{
				service.Name = model.Name;
				service.Description = model.Description;
			}
			await _db.SaveChangesAsync();
		}

		public async Task DeleteServiceAsync(int id)
		{
			var service = _db.Services.FirstOrDefault(s => s.Id == id);
			if (service != null)
			{
				_db.Services.Remove(service);
				await _db.SaveChangesAsync();
			}
		}
	}
}
