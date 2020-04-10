using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoexIssAPI.Requests
{
    public class BondCouponsRequest : IssRequest
    {
        public BondCouponsRequest(string sec)
        {
            _url = $"{BaseUrl}securities/{sec}/bondization.json";
            var json = Fetch();
            Response = JsonConvert.DeserializeObject<BondCouponsResponse>(json);
        }

        public BondCouponsResponse Response { get; set; }
    }
}
