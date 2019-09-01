using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Draft.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public TeamController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //     [HttpGet]
        //     public async Task<IActionResult> GetTeams()
        //     {
        //         var teams = await _repository.ListAsync<Team>(new FullTeam());
        //         var model = _mapper.Map<List<Team>, List<TeamViewModel>>(teams);
        //         return Ok(model);
        //     }
    }
}