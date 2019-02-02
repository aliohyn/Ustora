using System.Collections.Generic;
using Ustora.Data;
using Ustora.Data.Models;
using Ustora.Service.Interfaces;

namespace Ustora.Service
{
    public class OrderService : IOrderService
    {
        private readonly UstoraContext _context;

        public OrderService(UstoraContext context)
        {
            _context = context;
        }
        public int Add(Order order, IEnumerable<CartLine> CartLines)
        {
            int orderId = 0;
            _context.Orders.Add(order);
            _context.SaveChanges();
            if(order.OrderId > 0)
            {
                orderId = order.OrderId;
                foreach (CartLine line in CartLines)
                {
                    line.OrderId = orderId;
                    line.ProductId = line.Product.ProductId;
                    _context.CartLines.Add(line);
                }
                _context.SaveChanges();
            }
            return orderId;
        }
    }
}
