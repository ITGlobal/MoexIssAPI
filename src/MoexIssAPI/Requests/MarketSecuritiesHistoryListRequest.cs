using System;
using System.Collections.Generic;
using System.Text;

namespace MoexIssAPI.Requests
{
    public class MarketSecuritiesHistoryListRequest: CursorRequest<MarketSecuritiesHistoryListResponse>
    {
        public MarketSecuritiesHistoryListRequest(string engine, string market):base($"{BaseUrl}history/engines/{engine}/markets/{market}/securities.json")
        {
        }
    }
}
