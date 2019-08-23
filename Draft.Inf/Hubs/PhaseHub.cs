using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Inf.Hub
{
    public class PhaseHub : Hub<IPhaseHub>
    {

    }

    public interface IPhaseHub
    {
        Task UpdatePhase(string phaseName);
    }
}
