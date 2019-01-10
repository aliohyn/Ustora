using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ustora.Data.Interfaces;
using Ustora.Web.ViewModels;

namespace Ustora.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            MainPageViewModel model = new MainPageViewModel
            {
                MainSlider = _productService.GetMainPageSlider().ToList(),
                Brands = _productService.GetMainPageBrands().ToList(),
                LatestProducts = _productService.GetMainPageLatest().ToList()
            };
            return View(model);
        }
    }
}
