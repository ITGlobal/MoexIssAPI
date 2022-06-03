using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class SecurityDetailsRequest : IssRequest, IGetRequest<SecurityDetailsResponse>
    {
        public SecurityDetailsRequest(string engine, string market, string secCode)
        {
            _url = $"{BaseUrl}engines/{engine}/markets/{market}/securities/{secCode}.json";
        }

        public async Task<SecurityDetailsResponse> Get(CancellationToken token = default)
        {
            var json = await Fetch(token: token);
            return JsonConvert.DeserializeObject<SecurityDetailsResponse>(json);
        }
    }
}
