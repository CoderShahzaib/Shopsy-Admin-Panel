using Shopsy.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.Interfaces
{
    public interface ISaleService
    {
       Task<List<SaleResponseDTO>> GetAllSalesAsync();
       Task<SaleResponseDTO> GetSaleByIdAsync(int id);

        Task<bool> DeleteSaleByIdAsync(int id);

        Task<bool> MarkDeliveredAsync(int id);
        Task<TotalRevenueDTO> TotalRevenueAsync();
    }
}
