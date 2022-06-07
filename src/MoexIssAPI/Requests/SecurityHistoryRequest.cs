using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MoexIssAPI.Requests
{
    /// <summary>
    ///     Получить историю по одной бумаге на рынке за интервал дат <br />
    ///     Макет запроса: /iss/history/engines/[engine]/markets/[market]/securities/[security] <br />
    ///     Описание параметров: https://iss.moex.com/iss/reference/63 <br />
    ///     Пример: https://iss.moex.com/iss/history/engines/stock/markets/bonds/securities/SU26225RMFS1?from=2019-03-19 <br />
    ///     Описание колонок: https://iss.moex.com/iss/history/engines/stock/markets/bonds/securities/columns <br />
    /// </summary>
    public class SecurityHistoryRequest : CursorRequest<SecurityHistoryResponse>
    {
        public SecurityHistoryRequest(string engine, string market, string security, DateTime? from = null, DateTime? till = null, IWebProxy webProxy = null)
            : base($"{BaseUrl}history/engines/{engine}/markets/{market}/securities/{security}.json", 
            new Dictionary<string, object>() { { "from", from }, { "till", till } }, 
            webProxy: webProxy)
        {
        }
        public SecurityHistoryRequest(string engine, string market, string board, string security, IWebProxy webProxy = null)
            : base($"{BaseUrl}history/engines/{engine}/markets/{market}/boards/{board}/securities/{security}.json", webProxy: webProxy)
        {
        }

        public SecurityHistoryRequest(string engine, string market, string security, string board, DateTime from, DateTime till, IWebProxy webProxy = null)
            : base($"{BaseUrl}history/engines/{engine}/markets/{market}/boards/{board}/securities/{security}.json",
                 new Dictionary<string, object>() { { "from", from.ToString() }, { "till", till.ToString() } }, webProxy: webProxy)
        {
        }
    }
}
