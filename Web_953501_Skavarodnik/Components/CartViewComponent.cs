using Microsoft.AspNetCore.Mvc;

namespace Web_953501_Skavarodnik.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
