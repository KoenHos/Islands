using System.Collections.Generic;
using Aruba.Core;

namespace Aruba.Data
{
    public interface IHolidayCategoryDataService
    {
        IEnumerable<HolidayCategory> AllHolidayCategories { get; }
    }
}
