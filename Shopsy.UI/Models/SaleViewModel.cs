using Shopsy.Core.DTOs;

namespace Shopsy.UI.Models
{
    public class SaleViewModel
    {
        public List<SaleResponseDTO> Sales { get; set; } = new();
        public decimal TotalRevenue { get; set; }
    }
}
