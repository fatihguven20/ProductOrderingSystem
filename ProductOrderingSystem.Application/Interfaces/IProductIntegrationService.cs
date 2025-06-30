
namespace ProductOrderingSystem.Application.Interfaces
{
    public interface IProductIntegrationService
    {
        Task<int> ImportProductsAsync();
    }

}
