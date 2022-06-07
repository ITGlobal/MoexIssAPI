namespace MoexIssAPI.Requests
{
    public class MarketSecuritiesHistoryListResponse : SecurityHistoryResponse
    {
        public IssResponsePayload Securities => History;
    }
}
