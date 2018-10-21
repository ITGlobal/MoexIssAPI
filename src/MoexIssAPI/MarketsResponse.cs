using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MoexIssAPI
{
    /// <summary>
    /// Ответ на запрос списка доступных рынков в торговой системе
    /// </summary>
    public class MarketsResponse
    {
        [JsonProperty("markets")]
        public IssResponsePayload Markets { get; set; }
    }
}
