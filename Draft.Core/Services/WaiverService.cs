using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Services
{
    public class WaiverService
    {
        private readonly IRepository _repository;

        public WaiverService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task AddPlayersAsync(List<int> playerIds)
        {
            var season = await _repository.GetAsync(new CurrentSeasonWithWaiver());
            var waiver = season.Waiver;
            var players = await _repository.ListAsync(new PlayersById(playerIds));
            waiver.AddPlayers(players);
            await _repository.UpdateAsync(waiver);
        }

        public async Task<bool> RemovePlayersAsync(List<int> playerIds)
        {
            var season = await _repository.GetAsync(new CurrentSeasonWithWaiver());
            var waiver = season.Waiver;

            if (!playerIds.All(id => waiver.Players.Any(p => p.Id == id))) return false;

            waiver.RemovePlayers(playerIds);
            _repository.Update(waiver);
            return true;
        }
    }
}