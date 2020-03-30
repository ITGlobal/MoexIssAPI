using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoexIssAPI.Requests
{
    public interface ICursorResponse
    {

        IssResponsePayload Cursor {get; set;}
        IssResponsePayload Object { get;}

    }
}
