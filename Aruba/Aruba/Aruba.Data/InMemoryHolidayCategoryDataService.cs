using System;
using System.Collections.Generic;
using Aruba.Core;

namespace Aruba.Data
{
    public class InMemoryHolidayCategoryDataService : IHolidayCategoryDataService
    {
        public IEnumerable<HolidayCategory> AllHolidayCategories => new List<HolidayCategory>
        {
            new HolidayCategory { Id = 1,
                Description = "Fly to new worlds and dicover them by car",
                Name ="Fly-drive" },
            new HolidayCategory { Id = 2,
                Description = "Eperience nature by foot",
                Name ="Hiking" },
             new HolidayCategory { Id = 3,
                Description = "Do nothing while getting burned",
                Name ="Sun sea beach" },
        };
    }
}
