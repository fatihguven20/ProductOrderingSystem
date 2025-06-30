using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace ProductOrderingSystem.Infrastructure.FakeStoreClient;

public class FakeStoreClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public FakeStoreClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["ExternalServices:FakeStoreApiUrl"];
    }

    public async Task<List<FakeStoreProductDto>> GetProductsAsync()
    {
        var products = await _httpClient.GetFromJsonAsync<List<FakeStoreProductDto>>($"{_baseUrl}/products");
        return products ?? new List<FakeStoreProductDto>();
    }
}
