using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoexIssAPI.Requests
{
    public class MarketSecuritiesHistoryListResponse : SecurityHistoryResponse
    {
        public IssResponsePayload Securities => History;
    }
}
