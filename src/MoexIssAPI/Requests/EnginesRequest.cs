using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    /// <summary>
    /// Запрос доступных торговых систем
    /// </summary>
    public class EnginesRequest : IssRequest, IGetRequest<EnginesResponse>
    {
        public EnginesRequest(IWebProxy webProxy = null)
        {
            _url = $"{BaseUrl}engines.json";
            _webProxy = webProxy;
        }

        public async Task<EnginesResponse> Get(CancellationToken token = default)
        {
            var json = await Fetch(token: token);
            return JsonConvert.DeserializeObject<EnginesResponse>(json);
        }
    }
}
