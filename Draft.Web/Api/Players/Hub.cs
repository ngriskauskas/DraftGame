
using System.Threading.Tasks;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class PlayerHub : Hub<IPlayerHub>
    {

    }

    public interface IPlayerHub
    {
        Task PlayerChanged(PlayerViewModel player);
    }
}