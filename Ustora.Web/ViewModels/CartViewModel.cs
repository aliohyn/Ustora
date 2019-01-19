using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ustora.Data.Models;

namespace Ustora.Web.ViewModels
{
    public class CartViewModel
    {
        public List<CartLine> Cart;
        public decimal AllSum;
    }
}
