using System.Threading.Tasks;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class WaiverHub : Hub<IWaiverHub>
    {

    }
    public interface IWaiverHub
    {
        Task UpdateWaiver(WaiverViewModel waiver);
    }
}