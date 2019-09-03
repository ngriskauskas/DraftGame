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
    public class PlayerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public PlayerController(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _repository.ListAsync<Player>(new PlayersWithTeam());
            var playerModels = _mapper.Map<List<Player>, PlayerViewModel[]>(players);

            return Ok(playerModels);
        }
    }
}