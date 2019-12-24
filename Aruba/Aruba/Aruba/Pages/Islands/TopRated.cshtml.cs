using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Aruba.Pages.Islands
{
    public class TopRatedModel : PageModel
    {
        public string Message { get; set; }
        private IConfiguration configuration;

        public TopRatedModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnGet()
        {
            Message = configuration["Message"];
        }
    }

}
