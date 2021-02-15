using System;
using System.Collections.Generic;
using Aruba.Core;
using Aruba.Data;
using Aruba.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aruba.Api
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ApiElementsController : Controller 
    {
        private readonly IElementDataService _elementDataService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        
        public ApiElementsController(IElementDataService elementDataService, ILogger<ApiElementsController> logger, IMapper mapper)
        {
            _elementDataService = elementDataService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Element>> Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Element>, IEnumerable<ElementViewModel>>(_elementDataService.GetByName("")));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get elements: {ex}");
                return BadRequest("Failed to get elements");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<Element> Get(int id)
        {
            try
            {
                Element result = _elementDataService.GetById(id);
                if (result != null) return Ok(_mapper.Map<Element,ElementViewModel>(result));
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get element: {ex}");
                return BadRequest("Failed to get element");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]ElementViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var element = new Element
                    //{
                    //    Name = elementViewModel.Name,
                    //    AtomicNumber = elementViewModel.AtomicNumber,
                    //    Description = elementViewModel.Description,
                    //    Symbol = elementViewModel.Symbol,
                    //    Price = elementViewModel.Price,
                    //    Type = elementViewModel.Type
                    //};
                    Element element = _mapper.Map<ElementViewModel, Element>(model);

                    _elementDataService.Add(element);
                    if (_elementDataService.Commit())
                    {
                        //ElementViewModel result = new ElementViewModel()
                        //{
                        //    ElementId = element.Id,
                        //    AtomicNumber = element.AtomicNumber,
                        //    Symbol = element.Symbol,
                        //    Type = element.Type,
                        //    Price = element.Price,
                        //    Name = element.Name,
                        //    Description = element.Description
                        //};
                        var result = _mapper.Map<Element, ElementViewModel>(element);

                        return Created($"api/apielements/{element.Id}", result);
                    };
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save element: {ex}");
            }

            return BadRequest("Failed to save element");
        }

    }
}
