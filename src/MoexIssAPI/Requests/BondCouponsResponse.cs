using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class BondCouponsResponse
    {
    [JsonProperty("amortizations")]
    public IssResponsePayload Amortizations { get; set; }

    [JsonProperty("coupons")]
    public IssResponsePayload Coupons { get; set; }

    [JsonProperty("offers")]
    public IssResponsePayload Offers { get; set; }
    }
}
