using Draft.Core.Entities;
using Draft.Core.Interfaces;

namespace Draft.Core.Services
{
    public class LeagueService
    {
        private readonly IRepository _repository;

        public LeagueService(IRepository repository)
        {
            _repository = repository;
        }
        public void StartLeague()
        {
        }
    }
}