using System.ComponentModel.DataAnnotations;
using static Aruba.Core.ElementTypes;

namespace Aruba.Models
{
    public class ElementViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public int AtomicNumber { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(2)]
        public string Symbol { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Decription cannot be longer than 1000 characters.")]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public ElementType Type { get; set; }
    }

}