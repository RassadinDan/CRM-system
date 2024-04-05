using ModelLibrary.UISettings;
using SkillProfiWebAPI.DataContext;

namespace SkillProfiWebAPI.Data
{
	public class SettingsRepository
	{
		private readonly SkillProfiDBContext _db;

		public SettingsRepository(SkillProfiDBContext db)
		{
			_db = db;
		}

		public async Task<MainSettings> GetSettingsAsync()
		{
			var settings =  _db.MainSettings.First();
			await Task.CompletedTask;
			return settings;
		}

		public async Task UpdateSettingsAsync(MainSettings newSettings)
		{
			var settings = _db.MainSettings.First();
			settings.LayoutHeader = newSettings.LayoutHeader;
			settings.MainHeader = newSettings.MainHeader;
			settings.ProjectsHeader = newSettings.ProjectsHeader;
			settings.ServicesHeader = newSettings.ServicesHeader;
			settings.BlogHeader	= newSettings.BlogHeader;
			settings.ContactsHeader = newSettings.ContactsHeader;
			await _db.SaveChangesAsync();
		}

		//public async Task CreateSetAsync(MainSettings newSet)
		//{
		//	_db.Add(newSet);
		//	await _db.SaveChangesAsync();
		//}
	}
}
