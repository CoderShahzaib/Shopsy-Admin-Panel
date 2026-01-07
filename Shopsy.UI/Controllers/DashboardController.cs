using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopsy.Core.Interfaces;
using Shopsy.UI.Models;
using System.Threading.Tasks;

namespace Shopsy.UI.Controllers
{
    [Authorize(AuthenticationSchemes = "AdminCookie")]
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISaleService _salesService;
        private readonly IUserService _userService;

        public DashboardController(IProductService productService, ISaleService salesService, IUserService userService)
        {
            _productService = productService;
            _salesService = salesService;
            _userService = userService;
        }
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var productResponse = await _productService.GetAllProductsAsync();

            var salesResponse = await _salesService.GetAllSalesAsync();

            var userResponse = await _userService.GetAllUsersAsync();   

            var totalRevenue = await _salesService.TotalRevenueAsync();

            var model = new DashboardViewModel
            {
                TotalProducts = productResponse.Count,
                TotalSales = salesResponse.Count,
                totalUsers = userResponse.Count,
                TotalRevenue = totalRevenue.TotalRevenue,

                RecentSales = salesResponse.Take(5).ToList()
            };
            return View(model);
        }
    }
}
