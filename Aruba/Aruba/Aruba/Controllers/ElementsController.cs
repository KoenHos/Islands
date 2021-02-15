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
        private readonly IElementSeeder _elementSeeder;

        public ElementsController(IMailService mailService, IElementDataService elementDataService, IElementSeeder elementSeeder)
        {
            _mailService = mailService;
            _elementDataService = elementDataService;
            _elementSeeder = elementSeeder;
        }


        [HttpGet("GeologyElements")]
        public IActionResult Index(bool heavierThanOxygen )
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
                var succes = _elementDataService.Commit();
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
            _elementSeeder.Seed();

            IEnumerable<Element> _elements = GetElements().OrderBy(e => e.AtomicNumber);


            var viewModel = new ElementsViewModel()
            {
                Elements = _elements
            };

            return View("Index", viewModel);
        }

        private  IEnumerable<Element> GetElements(bool heavierThanOxygen = false)
        {
            return _elementDataService.GetByName("", heavierThanOxygen);
        }

        public IActionResult UnKnownAction()
        {
            throw new NotImplementedException();
        }
    }
}