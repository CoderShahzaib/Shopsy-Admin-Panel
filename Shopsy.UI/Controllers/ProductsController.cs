using Microsoft.AspNetCore.Mvc;
using Shopsy.Core.DTOs;
using Shopsy.Core.Interfaces;
using Shopsy.UI.Models;
using System.Threading.Tasks;

namespace Shopsy.UI.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var dtoProducts = await _productService.GetAllProductsAsync();

            var products = dtoProducts.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                CategoryId = p.CategoryId,
                ProductImageUrl = p.ProductImageUrl
            }).ToList();
            return View(products);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);
                        var dto = new ProductRequestDTO
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                ProductImageUrl = product.ProductImageUrl
            };
            await _productService.AddProductAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _productService.GetProductByIdAsync(id);

            if (dto == null)
            {
                return NotFound();
            }

            var product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Quantity = dto.Quantity,
                CategoryId = dto.CategoryId,
                ProductImageUrl = dto.ProductImageUrl
            };

            return View(product);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var dto = new ProductRequestDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                ProductImageUrl = product.ProductImageUrl
            };

            var success = await _productService.UpdateProductAsync(dto);

            if (!success)
            {
                ModelState.AddModelError("", "Failed to update product");
                return View(product);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }


    }
}
