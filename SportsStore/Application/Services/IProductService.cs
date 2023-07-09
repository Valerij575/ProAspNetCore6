using SportsStore.Models;

namespace SportsStore.Application.Services
{
    public interface IProductService
    {
        List<Product> GetProducts(string category);
    }
}
