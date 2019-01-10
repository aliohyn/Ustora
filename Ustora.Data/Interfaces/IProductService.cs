using Ustora.Data.Models;
using System.Collections.Generic;

namespace Ustora.Data.Interfaces
{
    public interface IProductService
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
        IEnumerable<Slide> GetMainPageSlider();
        IEnumerable<Product> GetMainPageLatest();
        IEnumerable<Brand> GetMainPageBrands();
    }
}
