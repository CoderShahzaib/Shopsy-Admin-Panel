using Shopsy.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();
        Task<CategoryResponseDTO> GetCategoryByIdAsync(int id);
        Task<bool> CreateCategoryAsync(CategoryRequestDTO category);
        Task<bool> UpdateCategoryAsync(CategoryResponseDTO category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
