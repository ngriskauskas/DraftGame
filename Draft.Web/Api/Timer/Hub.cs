using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Services;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public interface ITimerHub
    {
        Task UpdateTime(int timeLeft);
    }
    public class TimerHub : Hub<ITimerHub>
    {

    }
}
