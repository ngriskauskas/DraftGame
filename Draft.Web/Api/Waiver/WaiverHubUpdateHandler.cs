using System.Collections.Generic;
using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class WaiverHubUpdateHandler : IHandle<WaiverPlayersAddedEvent>, IHandle<WaiverPlayersRemovedEvent>
    {
        private readonly IHubContext<WaiverHub, IWaiverHub> _waiverHub;
        private readonly IMapper _mapper;

        public WaiverHubUpdateHandler(IHubContext<WaiverHub, IWaiverHub> waiverHub, IMapper mapper)
        {
            _waiverHub = waiverHub;
            _mapper = mapper;
        }
        public void Handle(WaiverPlayersAddedEvent domainEvent)
        {
            var playerModels = _mapper.Map<IEnumerable<Player>, WaiverPlayerViewModel[]>(domainEvent.Players);
            _waiverHub.Clients.All.AddPlayers(playerModels);
        }
        public void Handle(WaiverPlayersRemovedEvent domainEvent)
        {
            _waiverHub.Clients.All.RemovePlayers(domainEvent.PlayerIds);
        }


    }
}