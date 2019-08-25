using System.Threading;
using Autofac;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Services;
using Draft.Core.SharedKernel;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Inf.Services
{
    public class TimerService : ITimerService
    {
        private readonly IComponentContext _container;
        private Timer _timer;
        private DomainEvent _endEvent;

        //Hub context may be left open because singleton
        public TimerService(IComponentContext container)
        {
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
            var dispatcher = GetDispatcher();
            dispatcher.Dispatch(new TimerChangedEvent(0));
            dispatcher.Dispatch(_endEvent);
        }

        private void UpdateTimer(object state)
        {
            var timerState = state as TimerState;
            timerState.TimeLeft--;
            GetDispatcher().Dispatch(new TimerChangedEvent(timerState.TimeLeft));

            if (timerState.TimeLeft <= 0)
                EndTimer();
        }

        private IDomainEventDispatcher GetDispatcher()
        {
            return _container.Resolve<IDomainEventDispatcher>();
        }
    }
    class TimerState
    {
        public int TimeLeft { get; set; }
    }
}