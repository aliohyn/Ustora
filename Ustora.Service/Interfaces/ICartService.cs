using Ustora.Data.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Ustora.Service.Interfaces
{
    public interface ICartService
    {
        void Add(CartLine line);
    }
}
