using System;
using System.Threading.Tasks;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class PhaseHub : Hub<IPhaseHub>
    {

    }

    public interface IPhaseHub
    {
        Task UpdatePhase(string phaseName);
        Task UpdateDate(DateTime date);
    }
}
