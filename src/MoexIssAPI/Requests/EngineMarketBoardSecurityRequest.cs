using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    /// <summary>
    /// Запрос доступных торговых систем
    /// </summary>
    public class EngineMarketBoardSecurityRequest : IssRequest, IGetRequest<EngineMarketBoardSecurityResponse>
    {
        public EngineMarketBoardSecurityRequest(string engine, string market, string board, string security, IWebProxy webProxy = null)
        {
            _url = $"{BaseUrl}engines/{engine}/markets/{market}/boards/{board}/securities/{security}.json";
            _webProxy = webProxy;
        }

        public async Task<EngineMarketBoardSecurityResponse> Get(CancellationToken token = default)
        {
            var json = await Fetch(token: token);
            return JsonConvert.DeserializeObject<EngineMarketBoardSecurityResponse>(json);
        }
    }
}
