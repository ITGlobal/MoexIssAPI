using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class SecurityDefinitionResponse
    {
        [JsonProperty("description")]
        public IssResponsePayload Description { get; set; }

        [JsonProperty("boards")]
        public IssResponsePayload Boards { get; set; }
    }
}
