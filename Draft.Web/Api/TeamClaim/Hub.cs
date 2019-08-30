using System.Threading.Tasks;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class TeamClaimHub : Hub<ITeamClaimHub>
    {

    }

    public interface ITeamClaimHub
    {
        Task TeamClaimed(int teamId);
        Task TeamUnClaimed(int teamId);

    }
}