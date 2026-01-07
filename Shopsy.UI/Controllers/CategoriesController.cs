using Microsoft.AspNetCore.Mvc;
using Shopsy.Core.DTOs;
using Shopsy.Core.Interfaces;
using Shopsy.UI.Models;
using System.Threading.Tasks;

namespace Shopsy.UI.Controllers
{
    [Route("categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var dtoCategories =  await _categoryService.GetAllCategoriesAsync();

            var categories = dtoCategories.Select(p => new Category
            {
                Id = p.Id,
                Name = p.Name,

            }).ToList();
            return View(categories);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);
            var dto = new CategoryRequestDTO
            {
                Name = category.Name,
            };
            await _categoryService.CreateCategoryAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _categoryService.GetCategoryByIdAsync(id);
            if(dto == null)
            {
                return NotFound();
            }
            var category = new Category
            {
                Id = dto.Id,
                Name = dto.Name,
            };

            return View(category);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);
            var dto = new CategoryResponseDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
            var success = await _categoryService.UpdateCategoryAsync(dto);

            if (!success)
            {
                ModelState.AddModelError("", "Failed to update category");
                return View(category);
            }
                return RedirectToAction("Index");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }
    }
}
