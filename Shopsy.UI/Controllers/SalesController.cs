using Microsoft.AspNetCore.Mvc;
using Shopsy.Core.DTOs;
using Shopsy.Core.Interfaces;
using Shopsy.Infrastructure.Services;
using Shopsy.UI.Models;
using System.Threading.Tasks;

namespace Shopsy.UI.Controllers
{
    [Route("Sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService _saleService;
        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var dtoSales = await _saleService.GetAllSalesAsync();
            var totalRevenue = await _saleService.TotalRevenueAsync();

            var sales = dtoSales.Select(p => new SaleResponseDTO
            {
                Id = p.Id,
                CustomerId = p.CustomerId,
                CustomerName = p.CustomerName,
                PaymentMethod = p.PaymentMethod,
                PaymentStatus = p.PaymentStatus,
                OrderDate = p.OrderDate,
                GrandTotal = p.GrandTotal,
                IsDelivered = p.IsDelivered,
            }).ToList();

            var viewModel = new SaleViewModel
            {
                Sales = sales,
                TotalRevenue = totalRevenue.TotalRevenue
            };

            return View(viewModel);
        }


        [HttpPost("MarkDelivered/{id}")]
        public async Task<IActionResult> MarkDelivered(int id)
        {
            var success = await _saleService.MarkDeliveredAsync(id);

            if (!success)
                return BadRequest("Failed to mark sale as delivered.");

            return RedirectToAction(nameof(Index));
        }

    }
}
