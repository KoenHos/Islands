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
    public class DetailModel : PageModel
    {
        private IIslandData islandData;

        [TempData]
        public string Message { get; set; }

        public Island Island { get; set; }

        public DetailModel(IIslandData islandData)
        {
            this.islandData = islandData;
        }

        public IActionResult OnGet(int islandId)
        {
            Island = islandData.GetById(islandId);
            if (Island == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
