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

        public async Task AddPlayerAsync(int playerId)
        {
            var season = await _repository.GetAsync(new CurrentSeasonWithWaiver());
            var waiver = season.Waiver;
            var player = await _repository.GetByIdAsync<Player>(playerId);

            waiver.AddPlayer(player);
            await _repository.UpdateAsync(waiver);
        }

        public async Task<bool> RemovePlayerAsync(int playerId)
        {
            var season = await _repository.GetAsync(new CurrentSeasonWithWaiver());
            var waiver = season.Waiver;
            var player = await _repository.GetByIdAsync<Player>(playerId);
            if (!waiver.Players.Contains(player)) return false;

            waiver.RemovePlayer(player);
            _repository.Update(waiver);
            return true;
        }
    }
}