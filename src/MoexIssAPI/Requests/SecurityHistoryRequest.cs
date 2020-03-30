using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoexIssAPI.Requests
{
    public class SecurityHistoryRequest: CursorRequest<SecurityHistoryResponse>
    {
        public SecurityHistoryRequest(string engine, string market, string security)
            : base( $"{BaseUrl}history/engines/{engine}/markets/{market}/securities/{security}.json")
        { 
        }
        public SecurityHistoryRequest(string engine, string market, string board, string security)
            : base($"{BaseUrl}history/engines/{engine}/markets/{market}/boards/{board}/securities/{security}.json")
        {
        }

        public SecurityHistoryRequest(string engine, string market, string security, string board, DateTime from, DateTime till)
            :base ($"{BaseUrl}history/engines/{engine}/markets/{market}/boards/{board}/securities/{security}.json", 
                 new Dictionary<string, string>() { { "from", from.ToString() }, { "till", till.ToString() } })
        {
        }

    }
}
