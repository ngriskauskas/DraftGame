using System;
using System.Linq;
using System.Threading.Tasks;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Inf.Services;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class StandingsHub : Hub<IStandingsHub>
    {

    }

    public interface IStandingsHub
    {
        Task UpdateStandings(TeamViewModel[] teams);
    }
}
