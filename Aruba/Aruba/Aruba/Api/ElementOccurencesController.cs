using System;
using Aruba.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aruba.api
{
    [Route("/api/apielements/{elementid}/occurences")]
    public class ElementOccurencesController : Controller
    {
        private readonly IElementDataService _elementDataService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ElementOccurencesController(IElementDataService elementDataService, ILogger logger, IMapper mapper)
        {
            _elementDataService = elementDataService;
            _logger = logger;
            _mapper = mapper;

        }
    }
}
