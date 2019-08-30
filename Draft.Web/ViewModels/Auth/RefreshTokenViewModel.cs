using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Draft.Web.ViewModels
{
    public class RefreshTokenViewModel
    {
        [Required, JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}