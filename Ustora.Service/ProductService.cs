using System.Collections.Generic;
using Ustora.Data;
using Ustora.Data.Models;
using Ustora.Service.Interfaces;
using System.Linq;

namespace Ustora.Service
{
    public class ProductService : IProductService
    {
        private readonly UstoraContext _context;
        
        public ProductService(UstoraContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Add(product);
        }
        public IEnumerable<Product> GetAll(int page = 1, int pageSize = 4)
        {
            return _context.Products.Skip((page - 1) * pageSize).Take(pageSize);
        }
        public Product GetById(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }
        public IEnumerable<Product> GetListById(IEnumerable<int> listId)
        {
            return _context.Products.Where(p => listId.Contains(p.ProductId));
        }

        public IEnumerable<Slide> GetMainPageSlider()
        {
            return _context.Slides;
        }
        public IEnumerable<Product> GetMainPageLatest()
        {
            return _context.Products.Take(10);
        }
        public IEnumerable<Brand> GetMainPageBrands()
        {
            return _context.Brands;
        }
    }
}
