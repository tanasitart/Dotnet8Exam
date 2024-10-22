using backapi.Models;

namespace backapi.Services
{
    public interface InterfaceProductService
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task UpdateStock(int productId, int amount);

    }
}
