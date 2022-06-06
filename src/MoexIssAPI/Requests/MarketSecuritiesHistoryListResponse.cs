using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoexIssAPI.Requests
{
    public class MarketSecuritiesHistoryListResponse : SecurityHistoryResponse
    {
        public new IssResponsePayload Securities => History;
    }
}
