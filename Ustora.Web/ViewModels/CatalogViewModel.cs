using System.Collections.Generic;
using Ustora.Data.Models;

namespace Ustora.Web.ViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
