using Shopsy.Core.DTOs;
using Shopsy.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace Shopsy.Infrastructure.Services
{
    public class SaleService: ISaleService
    {
        private readonly HttpClient _httpClient;
        public SaleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SaleResponseDTO>> GetAllSalesAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/Sales");
            if (!response.IsSuccessStatusCode)
                return new List<SaleResponseDTO>();
            var apiResponse = await response.Content.ReadFromJsonAsync<SalesApiResponseDTO<List<SaleResponseDTO>>>();
            return apiResponse?.Data.Sales ?? new List<SaleResponseDTO>();
        }

        public async Task<SaleResponseDTO> GetSaleByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/v1/Sales/{id}");
            if (!response.IsSuccessStatusCode)
                return null;
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponseDTO<SaleResponseDTO>>();
            return apiResponse?.Data ?? null;
        }

        public async Task<bool> DeleteSaleByIdAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/v1/Sales/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> MarkDeliveredAsync(int id)
        {
            var response = await _httpClient.PutAsync($"/api/v1/Sales/{id}/mark-delivered", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<TotalRevenueDTO> TotalRevenueAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/Sales/total-revenue");

            if (!response.IsSuccessStatusCode)
            {
                return new TotalRevenueDTO { TotalRevenue = 0 };
            }

            var apiResponse = await response.Content
                .ReadFromJsonAsync<ApiResponseDTO<TotalRevenueDTO>>();

            return apiResponse?.Data ?? new TotalRevenueDTO { TotalRevenue = 0 };
        }

    }
}
