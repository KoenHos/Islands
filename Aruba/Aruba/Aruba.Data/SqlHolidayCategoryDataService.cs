using System;
using System.Collections.Generic;
using System.Linq;
using Aruba.Core;

namespace Aruba.Data
{
    public class SqlHolidayCategoryDataService : IHolidayCategoryDataService
    {
        private readonly IslandDbContext db;

        public SqlHolidayCategoryDataService(IslandDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<HolidayCategory> AllHolidayCategories => db.HolidayCategories;
    }
}
