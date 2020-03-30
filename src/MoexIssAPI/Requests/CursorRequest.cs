using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoexIssAPI.Requests
{
    public abstract class CursorRequest<T>: IssRequest where T: ICursorResponse
    {
        Dictionary<string, string> adds = new Dictionary<string, string>();
        public CursorRequest(string url, IDictionary<string,string> opts=null)
        {
            _url = url;
            if (opts != null)
             adds = new Dictionary<string, string>(opts);
            

            var json = Fetch(adds);
            Response = JsonConvert.DeserializeObject<T>(json);
            int start = 0;
            int total = int.MaxValue;
            if (Response.Cursor!=null) total = int.Parse(Response.Cursor.Data[0]["TOTAL"]);
            int pg = Response.Object.Data.Count;
            while (start + pg < total)
            {
                start += pg;
                adds["start"] = $"{start}";
                json = Fetch(adds);
                var obj = (JsonConvert.DeserializeObject<T>(json) as ICursorResponse);
                pg = obj.Object.Data.Count;
                if (pg == 0) break;
                Add(obj);
            }
        }

        void Add(ICursorResponse add)
        {
            Response.Cursor = add.Cursor;
            Response.Object.Data.AddRange(add.Object.Data);
        }

        public T Response { get; set; }
    }
}
