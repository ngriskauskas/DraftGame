using System.Collections.Generic;
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

        public async Task RemovePlayersAsync(int teamId, List<int> playerIds)
        {
            var team = await _repository.GetAsync(new TeamWithPlayers(teamId));
            team.RemovePlayers(playerIds);
            await _repository.UpdateAsync(team);
        }

        public async Task<bool> AddPlayersAsync(int teamId, List<int> playerIds)
        {
            var season = await _repository.GetAsync(new CurrentSeasonWithPhase());
            var team = await _repository.GetAsync(new TeamWithPlayers(teamId));

            if (season.CurPhase.MaxRosterSize <= team.RosterSize + playerIds.Count) return false;

            var players = await _repository.ListAsync<Player>(new PlayersById(playerIds));

            team.AddPlayers(players);
            await _repository.UpdateAsync(team);
            return true;
        }
    }
}