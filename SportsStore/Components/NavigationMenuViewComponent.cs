using Microsoft.AspNetCore.Mvc;
using SportsStore.Persistance.Interfaces;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository _repository;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            var categories = _repository.Products
                                .Select(x => x.Category)
                                .Distinct()
                                .OrderBy(x => x);

            return View(categories);
        }
    }
}
