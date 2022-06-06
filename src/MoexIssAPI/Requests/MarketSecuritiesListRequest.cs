using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    /// <summary>
    /// Запрос списка инструментов рынка
    /// </summary>
    public class MarketSecuritiesListRequest : IssRequest, IGetRequest<MarketSecuritiesListResponse>
    {
        public MarketSecuritiesListRequest(string engine, string market, IWebProxy webProxy = null)
        {
            _url = $"{BaseUrl}engines/{engine}/markets/{market}/securities.json";
            _webProxy = webProxy;
        }

        public async Task<MarketSecuritiesListResponse> Get(CancellationToken token = default)
        {
            var json = await Fetch(token: token);
            return JsonConvert.DeserializeObject<MarketSecuritiesListResponse>(json);
        }
    }

}
