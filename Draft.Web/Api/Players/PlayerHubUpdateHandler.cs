using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class PlayerHubUpdateHandler : IHandle<PlayerChangedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IHubContext<PlayerHub, IPlayerHub> _playerHub;

        public PlayerHubUpdateHandler(IMapper mapper, IHubContext<PlayerHub, IPlayerHub> playerHub)
        {
            _mapper = mapper;
            _playerHub = playerHub;
        }
        public void Handle(PlayerChangedEvent domainEvent)
        {
            var playerModel = _mapper.Map<Player, PlayerViewModel>(domainEvent.Player);
            _playerHub.Clients.All.PlayerChanged(playerModel);
        }
    }
}