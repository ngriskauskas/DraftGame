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
        [HttpGet]
        public List<TeamViewModel> Get()
        {
            var teams = _repository.List<Team>(new FullTeam());
            return _mapper.Map<List<Team>, List<TeamViewModel>>(teams);
        }
    }
}