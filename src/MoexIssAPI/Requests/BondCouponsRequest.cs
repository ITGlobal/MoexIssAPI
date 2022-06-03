using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoexIssAPI.Requests
{
    public class BondCouponsRequest : IssRequest, IGetRequest<BondCouponsResponse>
    {
        public BondCouponsRequest(string sec, IWebProxy webProxy = null)
        {
            _webProxy = webProxy;
            _url = $"{BaseUrl}securities/{sec}/bondization.json";
        }

        public async Task<BondCouponsResponse> Get(CancellationToken token = default)
        {
            var json = await Fetch(token: token);
            return JsonConvert.DeserializeObject<BondCouponsResponse>(json);
        }
    }
}
