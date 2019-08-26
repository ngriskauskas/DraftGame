using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Draft.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public SeasonController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public SeasonViewModel Get()
        {
            var season = _repository.Get(new CurrentSeasonWithStandingsPhase());
            return _mapper.Map<Season, SeasonViewModel>(season);
        }
    }
}