using System.Collections.Generic;
using Ustora.Data.Models;

namespace Ustora.Service.Interfaces
{
    public interface IOrderService
    {
        int Add(Order order, IEnumerable<CartLine> Cart);
    }
}
