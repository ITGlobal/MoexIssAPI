using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoexIssAPI.Requests
{
    public class SecurityHistoryResponse: ICursorResponse
    {
        [JsonProperty("history")]
        public IssResponsePayload History { get; set; }
        public IssResponsePayload Object => History;

        [JsonProperty("history.cursor")]
        public IssResponsePayload Cursor { get; set; }

        [JsonProperty("securities")]
        public IssResponsePayload Securities { get; set; }

        [JsonProperty("marketdata")]
        public IssResponsePayload Marketdata { get; set; }

        [JsonProperty("dataversion")]
        public IssResponsePayload Dataversion { get; set; }
    }
}
