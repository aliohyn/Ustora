using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Ustora.Data.Models
{
    public class RelatedProduct
    {
        public int RelateId { get; set; }
        [Required]
        public int BaseProductId { get; set; }
        [Required]
        public int RelatedProductId { get; set; }
    }
}
