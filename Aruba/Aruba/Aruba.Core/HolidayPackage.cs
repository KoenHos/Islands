using System;
namespace Aruba.Core
{
    public class HolidayPackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string MedicalPrecautions { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPackeOfTheWeek { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public HolidayCategory HolidayCategory { get; set; }
    }
}
