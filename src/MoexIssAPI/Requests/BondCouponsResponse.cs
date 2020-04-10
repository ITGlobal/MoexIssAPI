using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoexIssAPI.Requests
{
    public class BondCouponsResponse
    {
        [JsonProperty("coupons")]
        public IssResponsePayload Coupons { get; set; }
    }
}
