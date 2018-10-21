using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MoexIssAPI
{
    /// <summary>
    /// Запрос списка инструментов рынка
    /// </summary>
    public class MarketSecuritiesListRequest : IssRequest
    {
        public MarketSecuritiesListRequest(string engine, string market)
        {
            _url = $"{BaseUrl}engines/{engine}/markets/{market}/securities.json";
            var json = Fetch();
            Response = JsonConvert.DeserializeObject<MarketSecuritiesListResponse>(json);
        }

        public MarketSecuritiesListResponse Response { get; }
    }
}
