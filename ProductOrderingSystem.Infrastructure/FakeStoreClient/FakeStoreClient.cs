using System.Net.Http.Json;

namespace ProductOrderingSystem.Infrastructure.FakeStoreClient;

public class FakeStoreClient
{
    private readonly HttpClient _httpClient;

    public FakeStoreClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<FakeStoreProductDto>> GetProductsAsync()
    {
        var products = await _httpClient.GetFromJsonAsync<List<FakeStoreProductDto>>("https://fakestoreapi.com/products");
        return products ?? new List<FakeStoreProductDto>();
    }
}
