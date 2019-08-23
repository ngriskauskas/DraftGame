using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Draft.Core.Interfaces;
using Draft.Core.Services;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Inf.Hub
{
    public interface ITimer
    {
        Task UpdateTime(int timeLeft);
    }
    public class TimerHub : Hub<ITimer>
    {
        private static readonly Dictionary<string, bool> clientReady = new Dictionary<string, bool>();
        private readonly LeagueService _testService;
        private readonly ITimerService _timerService;

        public TimerHub(LeagueService testService, ITimerService timerService)
        {
            _testService = testService;
            _timerService = timerService;
        }
        public void ReadyClient()
        {
            clientReady[Context.ConnectionId] = true;
            if (!clientReady.Values.Any(v => v == false))
            {
                _timerService.EndTimer();
                foreach (var key in clientReady.Keys.ToList())
                    clientReady[key] = false;
            }
        }
        public async Task StartTimer()
        {
            _testService.StartLeague();
        }

        public override Task OnConnectedAsync()
        {
            clientReady.Add(Context.ConnectionId, false);
            return base.OnConnectedAsync();
        }
    }
}
