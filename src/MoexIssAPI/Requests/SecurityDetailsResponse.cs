using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class SecurityDetailsResponse
    {
        [JsonProperty("securities")]
        public IssResponsePayload Details { get; set; }
    }
}