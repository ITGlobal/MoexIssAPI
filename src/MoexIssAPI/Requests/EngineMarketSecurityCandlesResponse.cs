using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class EngineMarketSecurityCandlesResponse
    {
        [JsonProperty("candles")]
        public IssResponsePayload Candles { get; set; }
    }
}