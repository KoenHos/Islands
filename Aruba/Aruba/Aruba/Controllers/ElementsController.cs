using System;
using Microsoft.AspNetCore.Mvc;
using Aruba.Models;
using System.Collections.Generic;
using Aruba.Core;
using Aruba.Services;
using Aruba.Data;
using System.Linq;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aruba.Controllers
{
    public class ElementsController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IElementDataService _elementDataService;

        public ElementsController(IMailService mailService, IElementDataService elementDataService)
        {
            _mailService = mailService;
            _elementDataService = elementDataService;
        }


        [HttpGet("GeologyElements")]
        public IActionResult Index()
        {
            IEnumerable<Element> _elements = GetElements().OrderBy(e => e.AtomicNumber);


            var viewModel = new ElementsViewModel()
            {
                Elements = _elements
            };

            return View(viewModel);
        }

        [HttpPost("GeologyElements")]
        public IActionResult Index(ElementViewModel model)
        {
            if (ModelState.IsValid)
            {
                _elementDataService.Add(new Element
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price=model.Price,
                    Type= model.Type,
                    Symbol = model.Symbol,
                    AtomicNumber = model.AtomicNumber
                });
                _elementDataService.Commit();
                _mailService.SendMessage("koenhos@hotmail.com", model.Name, $"Element added: {model.Description}");
                ViewBag.UserMessage = $"Mail sent for new element: {model.Name} with price: {model.Price} and decription: {model.Description}";
                ModelState.Clear();
            }

            IEnumerable<Element> _elements = GetElements();

            var viewModel = new ElementsViewModel()
            {
                Elements = _elements
            };


            return View(viewModel);
        }

        public IActionResult Reset()
        {
            _elementDataService.Truncate();
            _elementDataService.Commit();

            IEnumerable<Element> _elements = GetElements().OrderBy(e => e.AtomicNumber);


            var viewModel = new ElementsViewModel()
            {
                Elements = _elements
            };

            return View("Index", viewModel);
        }

        private  IEnumerable<Element> GetElements()
        {
            return _elementDataService.GetByName("");


            //return new List<Element>
            //{
            //    new Element { Name="Gold",
            //                  Price="1800",
            //                  Description="Gold is one of the most valuable elements in the world",
            //                  Type = ElementType.TransitionMetal
            //                },
            //    new Element { Name="Lithium",
            //                  Price="112",
            //                  Description="Source of batteryingredients",
            //                  Type = ElementType.AlkaliMetal
            //                },
            //    new Element { Name="Samarium",
            //                  Price="unknown",
            //                  Description="tnot yet available",
            //                  Type = ElementType.Lanthanide
            //                },
            //    new Element { Name="Silicium",
            //                  Price="0,1",
            //                  Description="one of the most common elements on teh continental crust" ,
            //                  Type = ElementType.Metaloid
            //                },
            //};
        }

        public IActionResult UnKnownAction()
        {
            throw new NotImplementedException();
        }
    }
}