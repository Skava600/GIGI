using Microsoft.AspNetCore.Mvc;
using Web_953501_Skavarodnik.Models;

namespace Web_953501_Skavarodnik.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
