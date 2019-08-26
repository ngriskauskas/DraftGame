using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Draft.Web.ViewModels
{
    public class RefreshTokenViewModel
    {
        [Required, JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}