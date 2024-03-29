﻿using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    /// <summary>
    /// Запрос списка доступных рынков в торговой системе
    /// </summary>
    public class MarketsRequest : IssRequest, IGetRequest<MarketsResponse>
    {
        public MarketsRequest(string engine, IWebProxy webProxy = null)
        {
            _url = $"{BaseUrl}engines/{engine}/markets.json";
            _webProxy = webProxy;
        }

        public async Task<MarketsResponse> Get(CancellationToken token = default)
        {
            var json = await Fetch(token: token);
            return JsonConvert.DeserializeObject<MarketsResponse>(json);
        }
    }
}
