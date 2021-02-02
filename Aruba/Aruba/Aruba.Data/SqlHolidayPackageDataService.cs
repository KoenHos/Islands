using System;
using System.Collections.Generic;
using System.Linq;
using Aruba.Core;
using Microsoft.EntityFrameworkCore;

namespace Aruba.Data
{
    public class SqlHolidayPackageDataService : IHolidayPackageDataService
    {
        private readonly IslandDbContext db;

        public SqlHolidayPackageDataService(IslandDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<HolidayPackage> AllHolidayPackages
        {
            get
            {
                return db.HolidayPackages.Include(c => c.HolidayCategory);
            }
        }

        public IEnumerable<HolidayPackage> HolidayPackagesOfTheWeek
        {
            get
            {
                return db.HolidayPackages.Include(c => c.HolidayCategory).Where(h => h.IsPackeOfTheWeek);
            }
        }

        public HolidayPackage GetHolidayPackageById(int holidayPackageId)
        {
            return db.HolidayPackages.Include(c => c.HolidayCategory).FirstOrDefault(h => h.Id == holidayPackageId);
        }
    }
}
