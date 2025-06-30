using Microsoft.AspNetCore.Mvc;
using ProductOrderingSystem.Application.Interfaces;

namespace ProductOrderingSystem.API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        
        private readonly IProductService _productService;

        public OrdersController(IProductService productService)
        {
            _productService = productService;
            
        }

        [HttpPost("check-and-place")]
        public async Task<IActionResult> CheckAndPlaceOrder()
        {
            var lowStockProducts = await _productService.GetLowStockProductsAsync();
            if (!lowStockProducts.Any())
                return Ok("Kritik seviyede ürün bulunamadı.");

            // Maliyet hesapla: (threshold - stock) × price
            var productToOrder = lowStockProducts
                .Select(p => new
                {
                    Product = p,
                    QuantityToOrder = p.threshold - p.stock,
                    TotalCost = (p.threshold - p.stock) * p.price
                })
                .OrderBy(x => x.TotalCost)
                .First();

            // "Sipariş" işlemi: stok değerini eşik değere güncelle
            productToOrder.Product.stock = productToOrder.Product.threshold;

            return Ok(new
            {
                productToOrder.Product.productCode,
                productToOrder.Product.title,
                productToOrder.Product.image,
                OrderedQuantity = productToOrder.QuantityToOrder,
                UnitPrice = productToOrder.Product.price,
                TotalCost = productToOrder.TotalCost,
                NewStock = productToOrder.Product.stock
            });
        }
    }


}

