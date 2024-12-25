using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// helper class that allows for easy sharing of <paramref name="HttpClient"/>
    /// </summary>
    public static class WebHelper 
    {
        private static readonly Lazy<HttpClient> _client = new(() => new HttpClient());

        /// <summary>
        /// <paramref name="HttpClient"/> used for all web requests
        /// </summary>
        internal static HttpClient client {get => _client.Value;}
    }
}
