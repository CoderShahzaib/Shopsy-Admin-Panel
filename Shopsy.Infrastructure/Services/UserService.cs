using Shopsy.Core.DTOs;
using Shopsy.Core.Interfaces;
using System.Net.Http.Json;

namespace Shopsy.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/api/v1/Account/{id}");
            return response.IsSuccessStatusCode;
        }

        
        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/Account/users");
            if (!response.IsSuccessStatusCode)
                return new List<UserResponseDTO>();
            var apiResponse = await response.Content.ReadFromJsonAsync<UserApiResponseDTO<List<UserResponseDTO>>>();
            return apiResponse?.Data.Users ?? new List<UserResponseDTO>();
                
        }

    }
}
