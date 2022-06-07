using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using MoexIssAPI.Helper;

namespace MoexIssAPI
{
    /// <summary>
    /// Базовый класс запроса к iss
    /// </summary>
    public abstract class IssRequest
    {
        #region Fields

        protected const string BaseUrl = "https://iss.moex.com/iss/";

        protected string _url;

        protected IWebProxy _webProxy;

        #endregion

        #region Protected methods

        /// <summary>
        /// Выполнить запрос по _url и вернуть json
        /// </summary>
        /// <returns></returns>
        protected async Task<string> Fetch(IDictionary<string, object>? adds = null, CancellationToken token = default)
        {
            if (_url == null) throw new Exception("_url must be defined");

            var json = "";
            using var handler = new HttpClientHandler { Proxy = _webProxy };
            using var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync(_url + QueryHelper.CompileDict(adds), token);
            json = await response.Content.ReadAsStringAsync();
            return json;
        }

        #endregion
    }
}
