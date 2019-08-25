using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Draft.Web.Api
{
    public class TokenViewModel
    {
        public string UserName { get; set; }
        public int TeamId { get; set; }
    }
}