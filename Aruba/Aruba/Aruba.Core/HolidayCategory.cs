using System;
using System.Collections.Generic;

namespace Aruba.Core
{
    public class HolidayCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<HolidayPackage> HolidayPackages { get; set; }
    }
}
