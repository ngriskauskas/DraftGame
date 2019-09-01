using System.Threading.Tasks;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class TeamHub : Hub<ITeamHub>
    {

    }

    public interface ITeamHub
    {
        Task TeamChanged(TeamViewModel team);

    }
}