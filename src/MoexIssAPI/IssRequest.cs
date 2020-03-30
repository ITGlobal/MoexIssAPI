using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

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

        #endregion

        #region Protected methods

        /// <summary>
        /// Выполнить запрос по _url и вернуть json
        /// </summary>
        /// <returns></returns>
        protected string Fetch(IDictionary<string,string> adds=null)
        {
            var json = "";
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                json = wc.DownloadString(_url+ (adds!=null? "?"+string.Join("&",adds.Select(a=>$"{a.Key}={a.Value}")): ""));
            }
            return json;
        }

        #endregion
    }
}
