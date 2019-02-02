using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ustora.Data.Models;
using Ustora.Service.Interfaces;

namespace Ustora.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            List<CartLine> cartLines = HttpContext.Session.Get<List<CartLine>>("Cart");
            if(cartLines == null || cartLines.Count < 1) {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid) {
                int orderId = _orderService.Add(order, cartLines);
                HttpContext.Session.Set<List<CartLine>>("Cart", null);
                ViewBag.OrderId = orderId;
                return View("Completed");
            } else {
                return View("Index", order);
            }
        }
    }
}
