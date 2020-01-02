using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aruba.Core;
using Aruba.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aruba.Pages.Islands
{
    public class DeleteModel : PageModel
    {
        private readonly IIslandDataService islandDataService;

        public Island Island { get; set; }

        public DeleteModel(IIslandDataService islandData)
        {
            this.islandDataService = islandData;
        }

        public IActionResult OnGet(int islandId)
        {
            Island = islandDataService.GetById(islandId);
            if (Island == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int islandId)
        {
            var island = islandDataService.Delete(islandId);
            islandDataService.Commit();
            if (island == null)
            {
                return RedirectToPage("./NotFopund");
            }

            TempData["Message"] = $"{island.Name} deleted.";
            return RedirectToPage("./TopRated");

        }
    }
}
