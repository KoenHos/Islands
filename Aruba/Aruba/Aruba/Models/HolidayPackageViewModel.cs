using System;
using System.Collections.Generic;
using Aruba.Core;

namespace Aruba.Models
{
    public class HolidayPackageViewModel
    {
        public IEnumerable<HolidayPackage> HolidayPackages { get; set; }
        public IEnumerable<HolidayCategory> HolidayCategories { get; set; }
    }
}
