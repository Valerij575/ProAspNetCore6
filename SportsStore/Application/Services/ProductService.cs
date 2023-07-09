using SportsStore.Models;
using SportsStore.Persistance.Interfaces;

namespace SportsStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public List<Product> GetProducts(string category = null)
        {
            var result = _repository.Products;

            if (!string.IsNullOrEmpty(category))
            {
                result = result.Where(p => p.Category != null && p.Category == category);
            }

            return result.ToList();    

        }
    }
}
