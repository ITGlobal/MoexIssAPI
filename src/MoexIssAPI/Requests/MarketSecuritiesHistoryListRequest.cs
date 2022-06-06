using System.Net;

namespace MoexIssAPI.Requests
{
    public class MarketSecuritiesHistoryListRequest : CursorRequest<MarketSecuritiesHistoryListResponse>
    {
        public MarketSecuritiesHistoryListRequest(string engine, string market, IWebProxy webProxy = null)
            : base($"{BaseUrl}history/engines/{engine}/markets/{market}/securities.json", webProxy: webProxy)
        {
        }
    }
}
