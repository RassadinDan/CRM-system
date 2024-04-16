using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ModelLibrary.Contacts;
using SkillProfiWebAPI.Data;

namespace SkillProfiWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly ContactRepository _contactRepository;

		public ContactController(ContactRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}

		[HttpGet("getall")]
		public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
		{
			try
			{
				var contacts = await _contactRepository.GetContactsAsync();
				return Ok(contacts);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while loading contacts: {ex.Message}" });
			}
		}

		[HttpGet("getone/{id}")]
		public async Task<ActionResult<Contact>> GetContactById(int id)
		{
			try
			{
				var contact = await _contactRepository.GetContactByIdAsync(id);
				return Ok(contact);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while loading a contact: {ex.Message}" });
			}
		}

		[HttpPost("createContact")]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> CreateContact([FromBody]ContactModel model)
		{
			try
			{
				await _contactRepository.CreateContactAsync(model);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = $"Error while creating a contact: {ex.Message}" });
			}
		}

		[HttpPut("updateContact/{id}")]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> UpdateContact(int id, [FromBody]ContactModel model)
		{
			try
			{
				await _contactRepository.UpdateContactAsync(id, model);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while updating a contact: {ex.Message}" });
			}
		}

		[HttpDelete("deleteContact/{id}")]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> DeleteContact(int id)
		{
			try
			{
				await _contactRepository.DeleteContactAsync(id);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(new { message = $"Error while deleting a contact: {ex.Message}" });
			}
		}
	}
}
