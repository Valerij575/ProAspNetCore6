using Microsoft.AspNetCore.Mvc;
using SportsStore.Application.Services;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _service;

        public int PageSize = 4;

        public HomeController(IProductService service)
        {
            _service = service;
        }

        public ViewResult Index(int productPage = 1)
        {
            var result = new ProductListViewModel{
                Products = _service.GetProducts()
                                    .OrderBy(x => x.ProductId)
                                    .Skip((productPage - 1)* PageSize)
                                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _service.GetProducts().Count
                }
            };
            return View(result);
        }
    }
}
