using Microsoft.EntityFrameworkCore;
using ModelLibrary.Contacts;
using SkillProfiWebAPI.DataContext;

namespace SkillProfiWebAPI.Data
{
	public class ContactRepository
	{
		private readonly SkillProfiDBContext _db;

		public ContactRepository(SkillProfiDBContext db)
		{
			_db = db;
		}

		public async Task<IEnumerable<Contact>> GetContactsAsync()
		{
			var contacts = _db.Contacts.AsEnumerable();
			await Task.CompletedTask;
			return contacts;
		}

		public async Task<Contact> GetContactByIdAsync(int id)
		{
			var contact = await _db.Contacts.FirstOrDefaultAsync(c=>c.Id == id);
			return contact;
		}

		public async Task CreateContactAsync(ContactModel model)
		{ 
			var contact = new Contact()
			{
				Name = model.Name,
				Email = model.Email,
				Address	= model.Address,
				Phone = model.Phone
			};
			await _db.Contacts.AddAsync(contact);
			_db.SaveChanges();
		}

		public async Task UpdateContactAsync(int id, ContactModel model)
		{
			var contact = await _db.Contacts.FirstOrDefaultAsync(c=>c.Id == id);
			contact.Name = model.Name;
			contact.Email = model.Email;
			contact.Address = model.Address;
			contact.Phone = model.Phone;
			_db.SaveChanges();
		}

		public async Task DeleteContactAsync(int id)
		{
			var contact = await _db.Contacts.FirstOrDefaultAsync(c => c.Id == id);
			_db.Contacts.Remove(contact);
			_db.SaveChanges();
		}
	}
}
