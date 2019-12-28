using System.ComponentModel.DataAnnotations;

namespace Aruba.Core
{
    public class Island
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        public int Rating { get; set; }
        [Required]
        public ClimateType ClimateType{ get; set; }
    }
}
