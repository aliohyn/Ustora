using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ustora.Data.Models
{
    public class Slide
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public string Link { get; set; }
    }
}
