

using Shopsy.Core.DTOs;

namespace Shopsy.Core.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponseDTO>> GetAllProductsAsync();

        Task<bool> AddProductAsync(ProductRequestDTO product);

        Task<bool> UpdateProductAsync(ProductRequestDTO product);
        Task<ProductResponseDTO> GetProductByIdAsync(int id);
        Task<bool> DeleteProductAsync(int id);

    }
}
