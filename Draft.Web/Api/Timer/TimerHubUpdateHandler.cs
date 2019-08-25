using Draft.Core.Events;
using Draft.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api.Handlers
{
    public class TimerHubUpdateHandler : IHandle<TimerChangedEvent>
    {
        private readonly IHubContext<TimerHub, ITimerHub> _timerHub;

        public TimerHubUpdateHandler(IHubContext<TimerHub, ITimerHub> timerHub)
        {
            _timerHub = timerHub;
        }
        public void Handle(TimerChangedEvent domainEvent)
        {
            _timerHub.Clients.All.UpdateTime(domainEvent.Time);
        }
    }
}