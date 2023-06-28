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
        public List<Product> GetProducts()
        {
            return _repository.Products.ToList();
        }
    }
}
