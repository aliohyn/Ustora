using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ustora.Service.Interfaces;
using Ustora.Service;
using Ustora.Data.Models;
using Ustora.Web.ViewModels;
using System;

namespace Ustora.Web.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private IProductService _productService;
        public CartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            decimal sum;
            List<CartLine> cart = HttpContext.Session.Get<List<CartLine>>("Cart");
            if (cart != null)
            {
                sum = cart.Sum(l => l.Product.Price * l.Quantity);
            } else {
                sum = 0;
            }
            CartViewModel model = new CartViewModel
            {
                Cart = cart,
                AllSum = sum
            };
            return View(model);
        }

        [HttpPost]
        public string AddToCart(int productId, int quantity)
        {
            string resultMessage = "Error add to cart";
            Product product = _productService.GetById(productId);
            if (product != null) {
                List<CartLine> lineCollection = HttpContext.Session.Get<List<CartLine>>("Cart");
                if (lineCollection == null)
                {
                    lineCollection = new List<CartLine>();
                }

                CartLine line = lineCollection
                    .Where(p => p.Product.ProductId == product.ProductId)
                    .FirstOrDefault();
                if (line == null)
                {
                    lineCollection.Add(new CartLine
                    {
                        Product = product,
                        Quantity = quantity
                    });
                }
                else
                {
                    line.Quantity += quantity;
                }
                HttpContext.Session.Set<List<CartLine>>("Cart", lineCollection);
                resultMessage = "Product successfully added!";
            }
            return resultMessage;
        }

        [HttpPost]
        public string Remove(int productId)
        {
            List<CartLine> lineCollection = HttpContext.Session.Get<List<CartLine>>("Cart");
            lineCollection.RemoveAll(p => p.Product.ProductId == productId);
            HttpContext.Session.Set<List<CartLine>>("Cart", lineCollection);
            return "Product deleted";
        }
    }
}
