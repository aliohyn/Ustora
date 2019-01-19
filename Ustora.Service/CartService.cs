using System.Collections.Generic;
using Ustora.Data;
using Ustora.Data.Models;
using Ustora.Service.Interfaces;

namespace Ustora.Service
{
    public class CartService : ICartService
    {
        private UstoraContext _context;
        public CartService(UstoraContext context)
        {
            _context = context;
        }
        public void Add(CartLine line)
        {
            if (line.OrderId != null)
            {
                _context.CartLines.Add(line);
            }
        }
    }
}
