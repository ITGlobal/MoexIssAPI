using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    /// <summary>
    /// Ответ на запрос списка доступных торговых систем
    /// </summary>
    public class EnginesResponse
    {
        [JsonProperty("engines")]
        public IssResponsePayload Engines { get; set; }
    }
}
    