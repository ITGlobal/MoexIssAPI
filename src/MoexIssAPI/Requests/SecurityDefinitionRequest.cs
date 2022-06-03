using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    public class SecurityDefinitionRequest : IssRequest, IGetRequest<SecurityDefinitionResponse>
    {
        public SecurityDefinitionRequest(string secCode)
        {
            _url = $"{BaseUrl}securities/{secCode}.json";
        }

        public async Task<SecurityDefinitionResponse> Get(CancellationToken token = default)
        {
            var json = await Fetch(token: token);
            return JsonConvert.DeserializeObject<SecurityDefinitionResponse>(json);
        }
    }
}
