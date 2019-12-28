using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aruba.Core;
using Aruba.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Aruba.Pages.Islands
{
    public class TopRatedModel : PageModel
    {
        public string Message { get; set; }
        public IEnumerable<Island> Islands { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        private IConfiguration configuration;
        private IIslandData islandData;

        public TopRatedModel(IConfiguration configuration, IIslandData islandData)
        {
            this.configuration = configuration;
            this.islandData = islandData;
        }

        public void OnGet()
        {
            Message = configuration["Message"];
            Islands = islandData.GetByName(SearchTerm);
        }
    }

}
