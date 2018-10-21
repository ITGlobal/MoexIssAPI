using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MoexIssAPI
{
    public class SecurityDefinitionRequest : IssRequest
    {
        public SecurityDefinitionRequest(string secCode)
        {
            _url = $"{BaseUrl}securities/{secCode}.json";
            var json = Fetch();
            Response = JsonConvert.DeserializeObject<SecurityDefinitionResponse>(json);

        }

        public SecurityDefinitionResponse Response { get; }
    }
}
