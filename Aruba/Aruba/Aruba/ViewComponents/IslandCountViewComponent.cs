using System;
using Aruba.Data;
using Microsoft.AspNetCore.Mvc;

namespace Aruba.ViewComponents
{
    public class IslandCountViewComponent : ViewComponent
    {
        private readonly IIslandDataService islandDataService;

        public IslandCountViewComponent(IIslandDataService islandDataService)
        {
            this.islandDataService = islandDataService;
        }

        public IViewComponentResult Invoke()
        {
            var count = islandDataService.GetCountOfIslands();
            return View(count);
        }

    }
}
