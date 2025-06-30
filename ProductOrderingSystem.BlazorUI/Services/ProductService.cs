using ProductOrderingSystem.Contracts;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ProductOrderingSystem.BlazorUI.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task AddProductAsync(ProductDto product)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:7076/products", product);
            response.EnsureSuccessStatusCode(); 
        }

        public async Task<List<ProductDto>> GetLowStockProductsAsync()
        {
            var products = await _http.GetFromJsonAsync<List<ProductDto>>("https://localhost:7076/products/low-stock");
            return products ?? new();
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var products = await _http.GetFromJsonAsync<List<ProductDto>>("https://localhost:7076/products/all-stock");
            return products ?? new();
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<ProductDto>($"https://fakestoreapi.com/products/{id}");
            }
            catch
            {
                return null;
            }
        }
    }


}
