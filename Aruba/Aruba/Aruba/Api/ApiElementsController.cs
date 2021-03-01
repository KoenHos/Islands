using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aruba.Core;
using Aruba.Data;
using Aruba.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aruba.Api
{
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ApiElementsController : Controller 
    {
        private readonly IElementDataService _elementDataService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<StoreUser> _userManager;

        
        public ApiElementsController(IElementDataService elementDataService,
            ILogger<ApiElementsController> logger,
            IMapper mapper,
            UserManager<StoreUser> userManager)
        {
            _elementDataService = elementDataService;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Element>> Get()
        {
            var userName = User.Identity.Name;

            var elements = _elementDataService.GetByName("");
            var elementsByUser = _elementDataService.GetByUserAndName(userName, "");

            try
            {
                return Ok(_mapper.Map<IEnumerable<Element>, IEnumerable<ElementViewModel>>(elementsByUser));
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
        public async Task<IActionResult> Post([FromBody]ElementViewModel model)
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

                    var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                    element.User = currentUser;

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
