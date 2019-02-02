using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Ustora.Service.Interfaces;
using Ustora.Web.ViewModels;

namespace Ustora.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            Log.Information("test logger");
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
