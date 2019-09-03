using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class WaiverHubUpdateHandler : IHandle<WaiverPlayerAddedEvent>, IHandle<WaiverPlayerRemovedEvent>
    {
        private readonly IHubContext<WaiverHub, IWaiverHub> _waiverHub;
        private readonly IMapper _mapper;

        public WaiverHubUpdateHandler(IHubContext<WaiverHub, IWaiverHub> waiverHub, IMapper mapper)
        {
            _waiverHub = waiverHub;
            _mapper = mapper;
        }
        public void Handle(WaiverPlayerAddedEvent domainEvent)
        {
            var playerModel = _mapper.Map<Player, WaiverPlayerViewModel>(domainEvent.Player);
            _waiverHub.Clients.All.AddPlayer(playerModel);
        }
        public void Handle(WaiverPlayerRemovedEvent domainEvent)
        {
            _waiverHub.Clients.All.RemovePlayer(domainEvent.PlayerId);
        }


    }
}