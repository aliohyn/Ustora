using Ustora.Data.Models;
using System.Collections.Generic;

namespace Ustora.Service.Interfaces
{
    public interface IProductService
    {
        void Add(Product product);
        IEnumerable<Product> GetAll(int page = 1, int pageSize = 100000);
        Product GetById(int id);
        IEnumerable<Product> GetListById(IEnumerable<int> listId);
        IEnumerable<Slide> GetMainPageSlider();
        IEnumerable<Product> GetMainPageLatest();
        IEnumerable<Brand> GetMainPageBrands();
    }
}
