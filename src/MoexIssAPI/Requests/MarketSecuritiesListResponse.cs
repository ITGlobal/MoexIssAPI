using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    /// <summary>
    /// Ответ на запрос списка инструментов рынка
    /// </summary>
    public class MarketSecuritiesListResponse
    {
        [JsonProperty("securities")]
        public IssResponsePayload Securities { get; set; }
    }
}
