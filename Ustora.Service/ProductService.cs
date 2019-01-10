using System.Collections.Generic;
using Ustora.Data;
using Ustora.Data.Models;
using Ustora.Data.Interfaces;
using System.Linq;

namespace Ustora.Service
{
    public class ProductService : IProductService
    {
        private UstoraContext _context;
        public ProductService(UstoraContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Add(product);
        }
        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }
        public IEnumerable<Slide> GetMainPageSlider()
        {
            return _context.Slides;
        }
        public IEnumerable<Product> GetMainPageLatest()
        {
            return _context.Products;
        }
        public IEnumerable<Brand> GetMainPageBrands()
        {
            return _context.Brands;
        }
    }
}
