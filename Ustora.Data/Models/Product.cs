using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ustora.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [Required]
        public DateTime DateUpdate { get; set; }
        public string Description { get; set; }
        [Required]
        public virtual Section Section { get; set; }
        public virtual Brand Brand { get; set; }
        public bool TopSellerShow { get; set; }
        public bool MainSliderShow { get; set; }
    }
}
