using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Services
{
    public class WaiverService
    {
        private readonly IRepository _repository;
        private readonly Waiver _waiver;

        public WaiverService(IRepository repository)
        {
            _repository = repository;
            _waiver = _repository.Get(new CurrentSeasonWithWaiver()).Waiver;
        }

        public void AddPlayerToWaiver(Player player)
        {
            player.Transfer();
            _waiver.AddPlayer(player);
            _repository.Update(player);
            _repository.Update(_waiver);
        }

        public void TransferPlayerToTeam(Player player, Team team)
        {
            player.Transfer(team);
            _repository.Update(player);
            team.UpdateStarters();
            _repository.Update(team);
            _waiver.RemovePlayer(player);
            _repository.Update(_waiver);
        }
    }
}