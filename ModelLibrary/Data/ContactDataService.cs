using ModelLibrary.Contacts;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ModelLibrary.Data
{
	public class ContactDataService
	{
		private readonly HttpClient _httpClient;

		public ContactDataService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("AuthorizedClient");
		}

		public ContactDataService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<Contact>> GetContactsAsync()
		{
			var url = "https://localhost:7044/api/contact/getall";
			var result = await _httpClient.GetStringAsync(url);
			var contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(result);
			return contacts;
		}

		public async Task<Contact> GetContactByIdAsync(int id)
		{
			var url = $"https://localhost:7044/api/contact/getone/{id}";
			var result = await _httpClient.GetStringAsync(url);
			var contact = JsonConvert.DeserializeObject<Contact>(result);
			return contact;
		}

		public async Task<bool> CreateContactAsync(ContactModel model)
		{
			var url = "https://localhost:7044/api/contact/createContact";
			var result = await _httpClient.PostAsJsonAsync(url, model);
			return result.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateContactAsync(int id, ContactModel model)
		{
			var url = $"https://localhost:7044/api/contact/updateContact/{id}";
			var result = await _httpClient.PutAsJsonAsync(url, model);
			return result.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteContactAsync(int id)
		{
			var url = $"https://localhost:7044/api/contact/deleteContact/{id}";
			var result = await _httpClient.DeleteAsync(url);
			return result.IsSuccessStatusCode;
		}
	}
}
