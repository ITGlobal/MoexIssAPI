using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoexIssAPI
{
    /// <summary>
    /// Простой тип данных, состоящий из id, кода и описания
    /// </summary>
    [JsonConverter(typeof(JsonArrayToObjectConverter<SimpleData>))]
    [DebuggerDisplay("{Id} {Code} {Description}")]
    public class SimpleData: PayloadDataBase
    {
        /// <summary>
        /// Целочисленный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Строковый код
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <inheritdoc />
        public override void ReadFromJAray(JArray array)
        {
            Id = array[0].Value<int>();
            Code = array[1].Value<string>();
            Description = array[2].Value<string>();
        }
    }
}
