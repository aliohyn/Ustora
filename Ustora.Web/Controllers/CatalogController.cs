using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ustora.Service.Interfaces;
using Ustora.Web.ViewModels;

namespace Ustora.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService _productService;
        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int productPage = 1)
        {
            int pageSize = 3;
            int allCount = _productService.GetAll().Count();
            CatalogViewModel model = new CatalogViewModel
            {
                Products = _productService.GetAll(productPage, pageSize).ToList(),
                PagingInfo = new PagingInfo {
                    CurrentPage = productPage,
                    ItemsPerPage = pageSize,
                    TotalItems = allCount
                }
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            CatalogDetailViewModel model = new CatalogDetailViewModel
            {
                DetailProduct = _productService.GetById(id)
            };
            return View(model);
        }
    }
}
