using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ustora.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter a street")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter a home")]
        public string Home { get; set; }
    }
}
