using System.Threading;
using Draft.Core.Interfaces;
using Draft.Core.Services;
using Draft.Inf.Hub;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Inf.Services
{
    public class TimerService : ITimerService
    {
        private readonly IHubContext<TimerHub, ITimer> _timerHub;
        private readonly LeagueService _leagueService;
        private static Timer _timer;

        public TimerService(IHubContext<TimerHub, ITimer> timerHub, LeagueService leagueService)
        {
            _timerHub = timerHub;
            _leagueService = leagueService;
        }
        public void StartTimer(int time)
        {
            var state = new TimerState { TimeLeft = time };
            _timer = new Timer(new TimerCallback(UpdateTimer), state, 0, 1000);
        }

        public void EndTimer()
        {
            _timer.Dispose();
            UpdateHubTime(0);
            _leagueService.EndPhase();
        }

        private void UpdateTimer(object state)
        {
            var timerState = state as TimerState;
            timerState.TimeLeft--;
            UpdateHubTime(timerState.TimeLeft);

            if (timerState.TimeLeft <= 0)
                _timer.Dispose();
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