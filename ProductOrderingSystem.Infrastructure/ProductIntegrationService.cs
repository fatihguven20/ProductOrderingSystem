using ProductOrderingSystem.Application.Interfaces;
using ProductOrderingSystem.Contracts;

namespace ProductOrderingSystem.Infrastructure.FakeStoreClient;

public class ProductIntegrationService : IProductIntegrationService
{
    private readonly FakeStoreClient _client;
    private readonly IProductService _productService;

    public ProductIntegrationService(FakeStoreClient client, IProductService productService)
    {
        _client = client;
        _productService = productService;
    }

    public async Task<int> ImportProductsAsync()
    {
        var products = await _client.GetProductsAsync();
        var count = default(int);
        foreach (var product in products)
        {
            var productDto = new ProductDto
            {
                productCode = product.Id,
                title = product.Title,
                price = (double)product.Price,
                threshold = 15, // Örnek değer
                stock = 10 ,    // Örnek değer
                description = product.Description,
                image =  product.Image
            };

            await _productService.AddProductAsync(productDto);
            count++;
        }
        return count;
    }
    

}
