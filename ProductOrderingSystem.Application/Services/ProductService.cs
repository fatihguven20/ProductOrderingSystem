using ProductOrderingSystem.Application.Interfaces;
using ProductOrderingSystem.Contracts;

namespace ProductOrderingSystem.Application.Services;

public class ProductService : IProductService
{
    private static readonly List<ProductDto> _products = new();

    public Task AddProductAsync(ProductDto productDto)
    {
        _products.Add(productDto);
        return Task.CompletedTask;
    }

    public Task<List<ProductDto>> GetLowStockProductsAsync()
    {
        var result = _products
            .Where(p => p.stock < p.threshold)
            .ToList();

        return Task.FromResult(result);
    }

    public Task<List<ProductDto>> GetAllAsync()
    {
        return Task.FromResult(_products.ToList());
    }


}
