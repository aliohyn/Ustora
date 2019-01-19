using System.Collections.Generic;
using Ustora.Data.Models;

namespace Ustora.Web.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<Slide> MainSlider { get; set; }
        public IEnumerable<Product> LatestProducts { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
