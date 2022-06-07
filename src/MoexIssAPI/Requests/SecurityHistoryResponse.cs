using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class SecurityHistoryResponse: ICursorResponse
    {
        [JsonProperty("history")]
        public IssResponsePayload History { get; set; }
        public IssResponsePayload Object => History;

        [JsonProperty("history.cursor")]
        public IssResponsePayload Cursor { get; set; }
    }
}
