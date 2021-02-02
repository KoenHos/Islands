using System;
using Microsoft.AspNetCore.Mvc;
using Aruba.Data;
using Aruba.Models;

namespace Aruba.Controllers
{
    public class HolidayPackageController : Controller
    {

        private readonly IHolidayPackageDataService holidayPackageDataService;
        private readonly IHolidayCategoryDataService holidayCategoryDataService;

        public HolidayPackageController(IHolidayCategoryDataService holidayCategoryDataService,
            IHolidayPackageDataService holidayPackageDataService)
        {
            this.holidayCategoryDataService = holidayCategoryDataService;
            this.holidayPackageDataService = holidayPackageDataService;
        }

        public ViewResult List()
        {
            var viewModel = new HolidayPackageViewModel() {
                HolidayPackages = holidayPackageDataService.AllHolidayPackages,
                HolidayCategories = holidayCategoryDataService.AllHolidayCategories
            };

            return  View(viewModel);
        }
    }

}
