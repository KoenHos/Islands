using System;
using Microsoft.AspNetCore.Mvc;
using Aruba.Data;
using Aruba.Models;
using Aruba.Core;
using System.Collections.Generic;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aruba.Controllers
{
    public class ElementsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Element> _elements = new List<Element>
            {
                new Element { Name="Gold",
                              Price="1800",
                              Description="Gold is one of the most valuable elements in the world",
                              Type = ElementType.TransitionMetal
                            },
                new Element { Name="Lithium",
                              Price="112",
                              Description="Source of batteryingredients",
                              Type = ElementType.AlkaliMetal
                            },
                new Element { Name="Samarium",
                              Price="unknown",
                              Description="tnot yet available",
                              Type = ElementType.Lanthanide
                            },
                new Element { Name="Silicium",
                              Price="0,1",
                              Description="one of the most common elements on teh continental crust" ,
                              Type = ElementType.Metaloid
                            },
            };

            var viewModel = new ElementsViewModel()
            {
                Elements = _elements
            };

            return View(viewModel);
        }
    }
}
