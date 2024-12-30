using System.Net.Http;

namespace Roblox_Sharp.Framework
{
    /// <summary>
    /// helper class that allows for easy sharing of <paramref name="HttpClient"/>
    /// </summary>
    public static class WebHost 
    {
        private static HttpClient _client = new();

        /// <summary>
        /// <paramref name="HttpClient"/> used for all web requests
        /// </summary>
        internal static HttpClient client {get => _client;}

        /// <summary>
        /// sets the <paramref name="HttpClient"/>
        /// useful for configuring httpclient
        /// sets to default if null
        /// </summary>
        /// <param name="new_client"></param>
        public static void Set_HttpClient(HttpClient? new_client)
        {
            _client.Dispose();

            _client = new_client ?? new HttpClient();
        }
    }
}
