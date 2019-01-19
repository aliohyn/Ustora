using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Ustora.Data.Models;

namespace Ustora.Web.Components
{
    public class CartLineViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartLine> cart = HttpContext.Session.Get<List<CartLine>>("Cart");
            if (cart == null)
            {
                ViewBag.Sum = 0;
                ViewBag.Count = 0;
            }
            else
            {
                ViewBag.Sum = cart.Sum(l => l.Product.Price * l.Quantity);
                ViewBag.Count = cart.Count();
            }
            return View();
        }
    }
}
