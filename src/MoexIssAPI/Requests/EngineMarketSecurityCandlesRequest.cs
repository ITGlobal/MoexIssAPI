using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class EngineMarketSecurityCandlesRequest : IssRequest
    {
        public EngineMarketSecurityCandlesRequest(string secId, string market, int interval, IWebProxy webProxy = null)
        {
            _webProxy = webProxy;

            // Зачем ограничивать параметром from, если есть сортировка iss.reverse=true?
            // Т.к. есть неверно отсортированные акции ETF, например:
            // https://iss.moex.com/iss/engines/stock/markets/shares/securities/FXRU/candles?interval=24&iss.reverse=true
            var fromActual = DateTime.Today.AddYears(-2);

            _url =
                $"{BaseUrl}engines/stock/markets/{market}/securities/{secId}/candles.json?interval={interval}&iss.reverse=true&from={fromActual:yyyy-MM-dd}";
        }

        public EngineMarketSecurityCandlesRequest(string url,  IWebProxy webProxy = null)
        {
            _webProxy = webProxy;
            _url = $"{BaseUrl}{url}";
        }

        public async Task<EngineMarketSecurityCandlesResponse> Get(CancellationToken token = default)
        {
            var json = await Fetch(token: token);
            return JsonConvert.DeserializeObject<EngineMarketSecurityCandlesResponse>(json);
        }
    }
}