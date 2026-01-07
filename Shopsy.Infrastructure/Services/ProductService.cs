using Shopsy.Core.DTOs;
using Shopsy.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace Shopsy.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddProductAsync(ProductRequestDTO product)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v1/Product", product);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/v1/Product/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<ProductResponseDTO>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/Product");

            if (!response.IsSuccessStatusCode)
                return new List<ProductResponseDTO>();

            var apiResponse = await response.Content.ReadFromJsonAsync<ProductApiResponseDTO<List<ProductResponseDTO>>>();

            return apiResponse?.Data.Products ?? new List<ProductResponseDTO>();
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/v1/Product/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponseDTO<ProductResponseDTO>>();

            return apiResponse?.Data ?? null;
        }

        public async Task<bool> UpdateProductAsync(ProductRequestDTO product)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"/api/v1/Product/{product.Id}", product);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API ERROR: {response.StatusCode}");
                Console.WriteLine(error);
            }

            return response.IsSuccessStatusCode;
        }


    }
}
