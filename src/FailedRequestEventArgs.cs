using System;
using System.Net.Http;

namespace Roblox_Sharp
{
    /// <summary>
    /// event args for requests
    /// </summary>
    public class FailedRequestEventArgs (HttpResponseMessage response) : EventArgs
    {

        public readonly HttpResponseMessage Response = response;


        /// <summary>
        /// disposes the response
        /// </summary>
        ~FailedRequestEventArgs()
        {
            Response.Dispose();
        }
        
    }
}
