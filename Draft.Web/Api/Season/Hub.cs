using System;
using System.Threading.Tasks;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Draft.Web.ViewModels;

namespace Draft.Web.Api
{
    public class SeasonHub : Hub<ISeasonHub>
    {

    }

    public interface ISeasonHub
    {
        Task UpdatePhase(PhaseViewModel phase);
        Task UpdateDate(DateTime date);
        Task UpdateStandings(StandingsViewModel standings);

    }
}
