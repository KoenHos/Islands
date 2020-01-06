using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aruba.Core;
using Aruba.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aruba.Pages.Islands
{
    public class TopRatedModel : PageModel
    {
        private IConfiguration configuration;
        private IIslandDataService islandData;
        private ILogger<TopRatedModel> logger;

        public string Message { get; set; }
        public IEnumerable<Island> Islands { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public TopRatedModel(IConfiguration configuration,
            IIslandDataService islandData,
            ILogger<TopRatedModel> logger) 
        {
            this.configuration = configuration;
            this.islandData = islandData;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogWarning("executing Get all islands from TopRatedModel");
            Message = configuration["Message"];
            Islands = islandData.GetByName(SearchTerm);
        }
    }

}
