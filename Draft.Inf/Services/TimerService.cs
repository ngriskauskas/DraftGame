using System.Threading;
using Autofac;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Services;
using Draft.Core.SharedKernel;
using Draft.Inf.Hub;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Inf.Services
{
    public class TimerService : ITimerService
    {
        private readonly IHubContext<TimerHub, ITimerHub> _timerHub;
        private readonly IComponentContext _container;
        private Timer _timer;
        private DomainEvent _endEvent;

        //Hub context may be left open because singleton
        public TimerService(IHubContext<TimerHub, ITimerHub> timerHub, IComponentContext container)
        {
            _timerHub = timerHub;
            _container = container;

        }
        public void StartTimer(int time, DomainEvent endEvent)
        {
            _endEvent = endEvent;
            var state = new TimerState { TimeLeft = time };
            _timer = new Timer(new TimerCallback(UpdateTimer), state, 0, 1000);
        }

        public void EndTimer()
        {
            _timer.Dispose();
            UpdateHubTime(0);
            var dispatcher = _container.Resolve<IDomainEventDispatcher>();
            dispatcher.Dispatch(_endEvent);
        }

        private void UpdateTimer(object state)
        {
            var timerState = state as TimerState;
            timerState.TimeLeft--;
            UpdateHubTime(timerState.TimeLeft);

            if (timerState.TimeLeft <= 0)
                EndTimer();
        }
        private void UpdateHubTime(int timeLeft)
        {
            _timerHub.Clients.All.UpdateTime(timeLeft);
        }
    }
    class TimerState
    {
        public int TimeLeft { get; set; }
    }
}