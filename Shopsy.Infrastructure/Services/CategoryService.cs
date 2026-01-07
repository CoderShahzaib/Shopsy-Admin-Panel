using Shopsy.Core.DTOs;
using Shopsy.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace Shopsy.Infrastructure.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/Category");

            if (!response.IsSuccessStatusCode)
                return new List<CategoryResponseDTO>();

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponseDTO<List<CategoryResponseDTO>>>();

            return apiResponse?.Data ?? new List<CategoryResponseDTO>();
        }

        public async Task<CategoryResponseDTO> GetCategoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/v1/Category/{id}");
            if (!response.IsSuccessStatusCode)
                return null;
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponseDTO<CategoryResponseDTO>>();
            return apiResponse?.Data ?? null;
        }

        public async Task<bool> CreateCategoryAsync(CategoryRequestDTO category)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v1/Category", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryResponseDTO category)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/v1/Category/{category.Id}", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/v1/Category/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
