using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MoexIssAPI
{
    /// <summary>
    /// Ответ на запрос списка доступных торговых систем
    /// </summary>
    public class EnginesResponse
    {
        [JsonProperty("engines")]
        public IssResponsePayload Engines { get; set; }
    }
}
    