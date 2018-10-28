using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    /// <summary>
    /// Ответ на запрос списка доступных рынков в торговой системе
    /// </summary>
    public class MarketsResponse
    {
        [JsonProperty("markets")]
        public IssResponsePayload Markets { get; set; }
    }
}
