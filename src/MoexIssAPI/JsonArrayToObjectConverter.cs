using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MoexIssAPI
{
    public class JsonArrayToObjectConverter<T> : Newtonsoft.Json.JsonConverter where T : PayloadDataBase, new()
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == Newtonsoft.Json.JsonToken.Null)
                return null;

            var jArray = Newtonsoft.Json.Linq.JArray.Load(reader);
            var r = new T();
            r.ReadFromJAray(jArray);

            return r;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
