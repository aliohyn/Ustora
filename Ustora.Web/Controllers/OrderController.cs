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
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Make(Order order)
        {
            List<CartLine> cartLines = HttpContext.Session.Get<List<CartLine>>("Cart");
            if (cartLines != null)
            {
                int orderId = _orderService.Add(order, cartLines);
                HttpContext.Session.Set<List<CartLine>>("Cart", null);
                ViewBag.OrderId = orderId;
                return View("Completed");
            }
            
            return View("Index", order);
        }
    }
}
