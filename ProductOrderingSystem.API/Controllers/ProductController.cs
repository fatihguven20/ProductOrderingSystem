using Microsoft.AspNetCore.Mvc;
using ProductOrderingSystem.Application.Interfaces;
using ProductOrderingSystem.Contracts;

namespace ProductOrderingSystem.API.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IProductIntegrationService _integrationService;
    public ProductsController(
        IProductService productService,
        IProductIntegrationService integrationService)
    {
        _productService = productService;
        _integrationService = integrationService;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductDto dto)
    {
        await _productService.AddProductAsync(dto);
        return Ok();
    }

    [HttpGet("low-stock")]
    public async Task<IActionResult> GetLowStockProducts()
    {
        var result = await _productService.GetLowStockProductsAsync();
        return Ok(result);
    }

    [HttpGet("all-stock")]
    public async Task<IActionResult> GetAllStockProducts()
    {
        var result = await _productService.GetAllAsync();
        return Ok(result);
    }


    [HttpPost("import")]
    public async Task<IActionResult> ImportFromFakeStore()
    {
        var addedProductCount = await _integrationService.ImportProductsAsync();
        return Ok($"Ürünler başarıyla içe aktarıldı.Toplam:{addedProductCount}");
    }
}
