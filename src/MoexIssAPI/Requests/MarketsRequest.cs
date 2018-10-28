using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    /// <summary>
    /// Запрос списка доступных рынков в торговой системе
    /// </summary>
    public class MarketsRequest : IssRequest
    {
        public MarketsRequest(string engine)
        {
            
            _url = $"{BaseUrl}engines/{engine}/markets.json";
            var json = Fetch();
            Response = JsonConvert.DeserializeObject<MarketsResponse>(json);
        }

        public MarketsResponse Response { get; }
    }
}
