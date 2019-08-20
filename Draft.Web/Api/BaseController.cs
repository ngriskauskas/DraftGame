using Microsoft.AspNetCore.Mvc;

namespace Draft.Web.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
    }
}