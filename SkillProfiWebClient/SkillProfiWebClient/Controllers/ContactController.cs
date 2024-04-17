using Microsoft.AspNetCore.Mvc;
using SkillProfiWebClient.Data;
using ModelLibrary.Contacts;

namespace SkillProfiWebClient.Controllers
{
	[Route("[controller]")]
	public class ContactController : Controller
	{
		private readonly ContactDataService _contactData;

		public ContactController(ContactDataService contactData)
		{
			_contactData = contactData;
		}

		[HttpGet("getall")]
		public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
		{
			try
			{
				var contacts = await _contactData.GetContactsAsync();
				return View(contacts);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while loading contacts: {ex.Message}" });
			}
		}

		[HttpGet("getone/{id}")]
		public async Task<ActionResult<Contact>> GetContactById(int id)
		{
			try
			{
				var contact = await _contactData.GetContactByIdAsync(id);
				return Ok(contact);
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while loading a contact: {ex.Message}" });
			}
		}

		public IActionResult ContactForm()
		{
			return View(new ContactModel());
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateContact([FromForm]ContactModel model)
		{
			try
			{
				await _contactData.CreateContactAsync(model);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while creating a contact: {ex.Message}" });
			}
		}

		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateContact(int id, [FromForm]ContactModel model)
		{
			try
			{
				await _contactData.UpdateContactAsync(id, model);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while updating a contact: {ex.Message}" });
			}
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteContact(int id)
		{
			try
			{
				await _contactData.DeleteContactAsync(id);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while deleting a contact: {ex.Message}" });
			}
		}
	}
}
