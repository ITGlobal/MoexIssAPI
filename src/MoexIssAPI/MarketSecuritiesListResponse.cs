using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MoexIssAPI
{
    /// <summary>
    /// Ответ на запрос списка инструментов рынка
    /// </summary>
    public class MarketSecuritiesListResponse
    {
        [JsonProperty("securities")]
        public IssResponsePayload Securities { get; set; }
    }
}
