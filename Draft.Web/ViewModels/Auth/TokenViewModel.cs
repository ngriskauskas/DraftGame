using System.Collections.Generic;
using Newtonsoft.Json;

namespace Draft.Web.ViewModels
{
    public class TokenViewModel
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}