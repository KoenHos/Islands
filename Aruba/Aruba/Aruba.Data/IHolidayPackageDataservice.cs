using System;
using System.Collections.Generic;
using Aruba.Core;

namespace Aruba.Data
{
    public interface IHolidayPackageDataService
    {
        IEnumerable<HolidayPackage> AllHolidayPackages { get; }
        IEnumerable<HolidayPackage> HolidayPackagesOfTheWeek { get; }
        HolidayPackage GetHolidayPackageById(int holidayPackageId);
    }
}
