using System;
using System.Collections.Generic;
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
        protected string Fetch()
        {
            var json = "";
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(_url);
            }
            return json;
        }

        #endregion
    }
}
