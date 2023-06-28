using SportsStore.Data;
using SportsStore.Models;
using SportsStore.Persistance.Interfaces;

namespace SportsStore.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
           _context = context;
        }

        public IQueryable<Product> Products => _context.Products;
    }
}
