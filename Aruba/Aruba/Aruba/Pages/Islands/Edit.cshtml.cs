using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aruba.Core;
using Aruba.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aruba.Pages.Islands
{
    public class EditModel : PageModel
    {
        private readonly IIslandDataService islandData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Island Island { get; set; }
        public IEnumerable<SelectListItem> Climates { get; set; }

        public EditModel(IIslandDataService islandData, IHtmlHelper htmlHelper)
        {
            this.islandData = islandData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? islandId)
        {
            this.Climates = htmlHelper.GetEnumSelectList<ClimateType>();
            if (islandId.HasValue)
            {
                Island = islandData.GetById(islandId.Value);
            }
            else
            {
                Island = new Island();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                this.Climates = htmlHelper.GetEnumSelectList<ClimateType>();
                return Page();
            }

            if (Island.Id > 0)
            {
                islandData.Update(Island); // Island = islandData.Update(Island); => "Island" can be ommitted here because it is automatically popultaed by model binding.
                TempData["Message"] = "Resaurant successfully updated";  // TempData only available for next request and not for subsequent requests.
            }
            else
            {
                islandData.Add(Island);
                TempData["Message"] = "Resaurant successfully added";
            }

            islandData.Commit();
            return RedirectToPage("./Detail", new { islandId = Island.Id }); // Do not leave user on a page with post form after successful post: page refresh might lead to problems.


        }

    }
}
