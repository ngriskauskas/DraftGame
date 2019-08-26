using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Draft.Web.ViewModels;

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
        public async Task<IActionResult> GetSeason()
        {
            var season = await _repository.GetAsync(new CurrentSeasonWithStandingsPhase());
            var model = _mapper.Map<Season, SeasonViewModel>(season);
            return Ok(model);
        }
    }
}