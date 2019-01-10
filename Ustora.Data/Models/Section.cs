using System.ComponentModel.DataAnnotations;

namespace Ustora.Data.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
