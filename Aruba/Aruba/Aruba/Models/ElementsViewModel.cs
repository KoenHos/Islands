using System.ComponentModel.DataAnnotations;
using Aruba.Core;
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
        [MaxLength(1000, ErrorMessage = "Decription cannot be longer than 1000 characters.")]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public ElementType Type { get; set; }
    }

}