using System;
using System.Net.Http;

namespace Roblox_Sharp
{
    /// <summary>
    /// event args for requests
    /// </summary>
    public class FailedRequestEventArgs (HttpResponseMessage response) : EventArgs
    {
        /// <summary>
        /// the response
        /// </summary>
        public readonly HttpResponseMessage Response = response;
    }
}
