using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MoexIssAPI
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
