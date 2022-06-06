using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class EngineMarketBoardSecurityResponse
    {
        [JsonProperty("securities")]
        public IssResponsePayload Securities { get; set; }

        [JsonProperty("marketdata")]
        public IssResponsePayload Marketdata { get; set; }

        [JsonProperty("dataversion")]
        public IssResponsePayload Dataversion { get; set; }
    }
}