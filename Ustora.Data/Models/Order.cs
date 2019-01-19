using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ustora.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Home { get; set; }
    }
}
