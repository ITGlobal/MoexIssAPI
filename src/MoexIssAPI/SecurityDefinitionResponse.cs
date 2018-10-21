using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MoexIssAPI
{
    public class SecurityDefinitionResponse
    {
        [JsonProperty("description")]
        public IssResponsePayload Description { get; set; }

        [JsonProperty("boards")]
        public IssResponsePayload Boards { get; set; }
    }
}
