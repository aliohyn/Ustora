using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ustora.Data.Models
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
