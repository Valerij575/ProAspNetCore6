using SportsStore.Models;

namespace SportsStore.Persistance.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
