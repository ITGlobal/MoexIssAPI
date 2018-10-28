using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    /// <summary>
    /// Запрос доступных торговых систем
    /// </summary>
    public class EnginesRequest : IssRequest
    {
        public EnginesRequest()
        {
            _url = $"{BaseUrl}engines.json";
            var json = Fetch();
            Response = JsonConvert.DeserializeObject<EnginesResponse>(json);
        }
        
        public EnginesResponse Response { get; }
    }
}
