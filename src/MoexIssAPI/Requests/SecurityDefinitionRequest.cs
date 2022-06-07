using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoexIssAPI.Requests
{
    /// <summary>
    ///     Получить спецификацию инструмента <br />
    ///     Макет запроса: /iss/securities/[security] <br />
    ///     Описание параметров: https://iss.moex.com/iss/reference/13 <br />
    ///     Пример: https://iss.moex.com/iss/securities/SBER <br />
    /// </summary>
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
