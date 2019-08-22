using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly PreDraftService _testService;
        private static readonly Dictionary<string, bool> clientReady = new Dictionary<string, bool>();

        public TimerHub(PreDraftService testService)
        {
            _testService = testService;
        }
        public void ReadyClient()
        {
            clientReady[Context.ConnectionId] = true;
            if (!clientReady.Values.Any(v => v == false))
            {
                _testService.EndTimer();
                foreach (var key in clientReady.Keys.ToList())
                    clientReady[key] = false;
            }
        }
        public async Task StartTimer()
        {
            _testService.Handle();
        }

        public override Task OnConnectedAsync()
        {
            clientReady.Add(Context.ConnectionId, false);
            return base.OnConnectedAsync();
        }
    }
}
