using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MoexIssAPI
{
    /// <summary>
    /// Часть ответа, данные определённого типа с описанием колонок и метаданными
    /// </summary>
    [JsonConverter(typeof(JsonIssResponseToObjectConverter))]
    public class IssResponsePayload
    {
        /// <summary>
        /// Метаданные
        /// </summary>
        //[JsonProperty("metadata")]
        //public string Metadata { get; set; }

        /// <summary>
        /// Описание колонок
        /// </summary>
        [JsonProperty("columns")]
        public List<string> Columns { get; set; }

        /// <summary>
        /// Данные
        /// </summary>
        [JsonProperty("data")]
        public List<Dictionary<string, string>> Data { get; set; }
    }
}
