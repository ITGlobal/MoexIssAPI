using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class SecurityDefinitionRequest : IssRequest, IGetRequest<SecurityDefinitionResponse>
    {
        public SecurityDefinitionRequest(string secCode, IWebProxy webProxy = null)
        {
            _url = $"{BaseUrl}securities/{secCode}.json";
            _webProxy = webProxy;
        }

        public async Task<SecurityDefinitionResponse> Get(CancellationToken token = default)
        {
            var json = await Fetch(token: token);
            return JsonConvert.DeserializeObject<SecurityDefinitionResponse>(json);
        }
    }
}
