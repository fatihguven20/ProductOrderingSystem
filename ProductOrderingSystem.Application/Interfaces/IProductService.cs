using ProductOrderingSystem.Contracts;

namespace ProductOrderingSystem.Application.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductDto productDto);
        Task<List<ProductDto>> GetLowStockProductsAsync();
        Task<List<ProductDto>> GetAllAsync();
    }

}
