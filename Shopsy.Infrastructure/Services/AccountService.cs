using Shopsy.Core.DTOs;
using Shopsy.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace Shopsy.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request, string apiVersion = "1")
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/v{apiVersion}/Account/Login", request);

            if(!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response .Content.ReadFromJsonAsync<LoginResponseDTO>();
        }
    }
}
