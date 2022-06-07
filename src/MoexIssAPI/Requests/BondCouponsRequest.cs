using MoexIssAPI.Helper;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MoexIssAPI.Requests
{

    /// <summary>
    ///     - <br />
    ///     Макет запроса: - <br />
    ///     Описание параметров: - <br />
    ///     Пример: http://iss.moex.com/iss/securities/RU000A0JXMB0/bondization?limit=unlimited&from=2020-05-20 <br />
    /// </summary>
    public class BondCouponsRequest : IssRequest, IGetRequest<BondCouponsResponse>
    {
        public BondCouponsRequest(string sec, DateTime? from = null, string limit="unlimited", IWebProxy webProxy = null)
        {
            _webProxy = webProxy;
            _url = $"{BaseUrl}securities/{sec}/bondization.json{QueryHelper.Compile(new { limit, from })}";
        }

        public async Task<BondCouponsResponse> Get(CancellationToken token = default)
        {
            var json = await Fetch(token: token);
            return JsonConvert.DeserializeObject<BondCouponsResponse>(json);
        }
    }
}
