using System;
using System.Net.Http;

namespace Roblox_Sharp
{
    /// <summary>
    /// event args for requests
    /// </summary>
    public class FailedRequestEventArgs : EventArgs
    {
        /// <summary>
        /// the response
        /// </summary>
        public readonly HttpResponseMessage Response;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="response"></param>
        public FailedRequestEventArgs(HttpResponseMessage response) => Response = response;
    }
}
