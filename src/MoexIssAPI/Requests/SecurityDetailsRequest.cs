using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class SecurityDetailsRequest : IssRequest
    {
        public SecurityDetailsRequest(string engine, string market, string secCode)
        {
            _url = $"{BaseUrl}engines/{engine}/markets/{market}/securities/{secCode}.json";
            var json = Fetch();
            Response = JsonConvert.DeserializeObject<SecurityDetailsResponse>(json);
        }

        public SecurityDetailsResponse Response { get; }
    }
}
