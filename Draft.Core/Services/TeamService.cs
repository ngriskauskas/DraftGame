using System.Threading.Tasks;
using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Services
{
    public class TeamService
    {
        private readonly IRepository _repository;

        public TeamService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task RemovePlayerAsync(int teamId, int playerId)
        {
            var team = await _repository.GetAsync(new TeamWithPlayers(teamId));
            var player = await _repository.GetByIdAsync<Player>(playerId);
            team.RemovePlayer(player);
            await _repository.UpdateAsync(team);
        }

        public async Task<bool> AddPlayerAsync(int teamId, int playerId)
        {
            var season = await _repository.GetAsync(new CurrentSeasonWithPhase());
            var team = await _repository.GetAsync(new TeamWithPlayers(teamId));
            var player = await _repository.GetByIdAsync<Player>(playerId);

            if (season.CurPhase.MaxRosterSize <= team.RosterSize) return false;

            team.AddPlayer(player);
            await _repository.UpdateAsync(team);
            return true;
        }
    }
}