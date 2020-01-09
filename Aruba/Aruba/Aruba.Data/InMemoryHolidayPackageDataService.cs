using System.Collections.Generic;
using System.Linq;
using Aruba.Core;

namespace Aruba.Data
{
    public class InMemoryHolidayPackageDataService : IHolidayPackageDataService
    {
        private readonly IHolidayCategoryDataService holidayCategoryDataService = new InMemoryHolidayCategoryDataService();

        public IEnumerable<HolidayPackage> AllHolidayPackages =>
            new List<HolidayPackage>
            {
                new HolidayPackage { Id = 1,
                                   Name="Hiking on La Palma",
                                   Price=850.00M,
                                   ShortDescription="Discover the nature of La Palma by seven days of hiking.",
                                   LongDescription="Discover the nature of La Palma by seven days of hiking. Flight, transfers to 1st and last hotel and all hotels included.",
                                   HolidayCategory=holidayCategoryDataService.AllHolidayCategories.FirstOrDefault(c => c.Name == "Hiking"),
                                   ImageUrl="",
                                   ImageThumbnailUrl="",
                                   IsAvailable = true,
                                   IsPackeOfTheWeek=true,
                                   MedicalPrecautions="You need a good health and be a bit sportive and like to sweat."},

               new HolidayPackage { Id = 1,
                                   Name="Baking on Aruba",
                                   Price=2550.00M,
                                   ShortDescription="Get burned on a tropical beach.",
                                   LongDescription="14 days of hot white beaches and unlimited cocktails. All inclusive, no hidden costs.",
                                   HolidayCategory=holidayCategoryDataService.AllHolidayCategories.FirstOrDefault(c => c.Name == "Sun sea beach"),
                                   ImageUrl="",
                                   ImageThumbnailUrl="",
                                   IsAvailable = true,
                                   IsPackeOfTheWeek=true,
                                   MedicalPrecautions="Watch your liver!" }
            };

        public IEnumerable<HolidayPackage> HolidayPackagesOfTheWeek => AllHolidayPackages.Where(c => c.IsPackeOfTheWeek == true);

        public HolidayPackage GetHolidayPackageById(int HolidayPackageId)
        {
            return AllHolidayPackages.FirstOrDefault(p => p.Id == HolidayPackageId);
        }

    }

}
