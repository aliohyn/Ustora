using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ustora.Data.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
