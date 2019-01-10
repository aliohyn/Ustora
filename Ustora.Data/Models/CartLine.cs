using System.ComponentModel.DataAnnotations;

namespace Ustora.Data.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
