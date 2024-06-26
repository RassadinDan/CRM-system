﻿using ModelLibrary.Services;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ModelLibrary.Data
{
	public class ServiceDataService
	{
		private readonly HttpClient _httpClient;

		public ServiceDataService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("AuthorizedClient");
		}

		public ServiceDataService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<Service>> GetServicesAsync()
		{
			var url = "https://localhost:7044/api/service/getall";
			var result = await _httpClient.GetStringAsync(url);
			var services = JsonConvert.DeserializeObject<IEnumerable<Service>>(result);
			return services;
		}

		public async Task<Service> GetServiceByIdAsync(int id)
		{
			var url = $"https://localhost:7044/api/service/getone/{id}";
			var result = await _httpClient.GetStringAsync(url);
			var service = JsonConvert.DeserializeObject<Service>(result);
			return service;
		}

		public async Task<bool> CreateServiceAsync(ServiceModel model)
		{
			var url = "https://localhost:7044/api/service/createService";
			var result = await _httpClient.PostAsJsonAsync(url, model);
			return result.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateServiceAsync(int id, ServiceModel model)
		{
			var url = $"https://localhost:7044/api/service/updateService/{id}";
			var result = await _httpClient.PutAsJsonAsync(url, model);
			return result.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteServiceAsync(int id)
		{
			var url = $"https://localhost:7044/api/service/deleteService/{id}";
			var result = await _httpClient.DeleteAsync(url);
			return result.IsSuccessStatusCode;
		}
	}
}
