using System.ComponentModel.DataAnnotations;

namespace Ustora.Data.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
