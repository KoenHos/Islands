using System;
using System.Collections.Generic;
using System.Linq;
using Aruba.Core;
using Aruba.Data;
using Aruba.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aruba.api
{
    [Route("/api/apielements/{elementid}/occurences")]
    [ApiController]
    [Produces("application/json")]
    public class ElementOccurencesController : Controller
    {
        private readonly IElementDataService _elementDataService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ElementOccurencesController(IElementDataService elementDataService, ILogger<ElementOccurencesController> logger, IMapper mapper)
        {
            _elementDataService = elementDataService;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public ActionResult<IEnumerable<ElementOccurrence>> Get(int elementid)
        {
            try
            {
                var occurences = _elementDataService.GetOccurrenceByElementId(elementid);
                if (occurences == null || occurences.Count() == 0)  return NotFound();
                return Ok(occurences);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get occurences for element with id: {elementid} - {ex}");
                return BadRequest($"Failed to get occurences for element with id: {elementid}");
            }
        }



        [HttpPost]
        public IActionResult Post([FromBody] ElementOccurrenceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var element = _mapper.Map<ElementOccurrenceViewModel, ElementOccurrence>(model);

                    _elementDataService.Add(element);
                    if (_elementDataService.Commit())
                    {
                        var result = _mapper.Map<ElementOccurrence, ElementOccurrenceViewModel>(element);

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
