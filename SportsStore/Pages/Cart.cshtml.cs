using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Application.Services;
using SportsStore.Infrastructure;
using SportsStore.Models;
using System.Text;
using System.Text.Json;

namespace SportsStore.Pages
{
    public class CartModel : PageModel
    {
        private IProductService _productService;

        public CartModel(IProductService productService)
        {
            _productService = productService;
        }

        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _productService.GetProducts(null).FirstOrDefault(p => p.ProductId == productId);
            if(product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                var serialize = JsonSerializer.Serialize(Cart);
                byte[] byteArray = Encoding.UTF8.GetBytes(serialize);
                HttpContext.Session.Set("cart", byteArray);
            }

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
