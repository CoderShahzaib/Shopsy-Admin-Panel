using Shopsy.Core.DTOs;

namespace Shopsy.UI.Models
{
    public class DashboardViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalSales { get; set; }
        public int totalUsers { get; set; }
        public decimal TotalRevenue { get; set; }

        public List<SaleResponseDTO> RecentSales { get; set; } = new();
    }

}
