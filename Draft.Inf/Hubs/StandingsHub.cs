using System;
using System.Threading.Tasks;
using Draft.Core.Entities;
using Draft.Inf.Services;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Inf.Hub
{
    public class StandingsHub : Hub<IStandingsHub>
    {

    }

    public interface IStandingsHub
    {
        Task UpdateStandings(TeamViewModel[] teams);
    }
}
