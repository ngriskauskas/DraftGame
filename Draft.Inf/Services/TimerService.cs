using System.Collections.Generic;
using System.Linq;
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
        private readonly Dictionary<int, bool> teamManagersReady = new Dictionary<int, bool>();
        private readonly IComponentContext _container;
        private Timer _timer;
        private DomainEvent _endEvent;

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

        public void AddTeamManager(int id)
        {
            teamManagersReady.Add(id, false);
        }
        public void RemoveTeamManager(int id)
        {
            teamManagersReady.Remove(id);
        }
        public void SetManagerReady(int id, bool ready)
        {
            teamManagersReady[id] = ready;
            if (!teamManagersReady.Values.Any(v => v == false))
                EndTimer();
        }


        private void ResetManagersReady()
        {
            foreach (var key in teamManagersReady.Keys.ToList())
                teamManagersReady[key] = false;
        }
        private void EndTimer()
        {
            _timer.Dispose();
            var dispatcher = GetDispatcher();
            dispatcher.Dispatch(new TimerChangedEvent(0));
            dispatcher.Dispatch(_endEvent);
            ResetManagersReady();
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