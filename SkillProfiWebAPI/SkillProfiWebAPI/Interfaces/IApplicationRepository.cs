using ModelLibrary.Applications;
namespace SkillProfiWebAPI.Interfaces
{
	public interface IApplicationRepository
	{
		Task CreateAsync(string name, string text, string email);
		Task UpdateStatusAsync(int id, ApplicationStatus status);
		Task<IEnumerable<Application>> GetApplicationsAsync();
	}
}
