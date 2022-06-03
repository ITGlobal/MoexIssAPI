using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace MoexIssAPI.Requests
{
    public abstract class CursorRequest<T>: IssRequest, IGetRequest<T> where T: ICursorResponse
    {
        Dictionary<string, string> adds = new Dictionary<string, string>();
        public CursorRequest(string url, IDictionary<string,string> opts=null, IWebProxy webProxy = null)
        {
            _url = url;
            _webProxy = webProxy;
            if (opts != null)
             adds = new Dictionary<string, string>(opts);
        }

        public async Task<T> Get(CancellationToken token = default)
        {
            var json = await Fetch(adds, token);
            var response = JsonConvert.DeserializeObject<T>(json);
            int start = 0;
            int total = int.MaxValue;
            if (response.Cursor!=null) total = int.Parse(response.Cursor.Data[0]["TOTAL"]);
            int pg = response.Object.Data.Count;
            while (start + pg < total)
            {
                start += pg;
                adds["start"] = $"{start}";
                json = await Fetch(adds);
                var obj = (JsonConvert.DeserializeObject<T>(json) as ICursorResponse);
                pg = obj.Object.Data.Count;
                if (pg == 0) break;
                response.Cursor = obj.Cursor;
                response.Object.Data.AddRange(obj.Object.Data);
            }

            return response;
        }
    }
}
