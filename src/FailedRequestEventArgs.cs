using System;
using System.Net;
using System.Net.Http;

namespace Roblox_Sharp
{
    /// <summary>
    /// event args for requests
    /// </summary>
    public class FailedRequestEventArgs (HttpResponseMessage response) : EventArgs
    {

        public readonly HttpStatusCode StatusCode = response.StatusCode;

        public readonly HttpRequestMessage? Request = response.RequestMessage;


        public readonly HttpResponseMessage Reponse = response;
        
        
    }
}
