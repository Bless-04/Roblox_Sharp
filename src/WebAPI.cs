using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Roblox_Sharp
{

    /// <summary>
    /// static class that holds the functions and logic used for making web requests to Roblox API <br></br>
    /// <b><see href="https://github.com/matthewdean/roblox-web-apis?tab=readme-ov-file">Endpoints Documentation</see></b>
    /// </summary>
    public static class WebAPI
    {
        internal static volatile HttpClient _client = new();

        /// <summary>
        /// <see cref="HttpClient"></see> used for all web requests
        /// </summary>
        public static HttpClient Client
        {
            get => _client;
            set => Interlocked.Exchange(ref _client, value).Dispose(); //atomic dispose of old http client
        }


        static WebAPI()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Set_UserAgent(nameof(Roblox_Sharp));
            //_client.DefaultRequestHeaders.Authorization needed for auth
        }

        /// <summary>
        /// an event that is raised when the web request is successful/statuscode is between 200 and 299
        /// </summary>
        public static event EventHandler? OnSuccessfulRequest;

        /// <summary>
        /// an event that is raised when the web request fails / statuscode is not successful
        /// </summary>
        public static event EventHandler<FailedRequestEventArgs>? OnFailedRequest;

        /// <summary>
        /// Raises the <see cref="OnSuccessfulRequest"/> and <see cref="OnFailedRequest"/> events
        /// </summary>
        /// <param name="response"></param>
        public static void FireEvents(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) OnSuccessfulRequest?.Invoke(null, EventArgs.Empty);
            else OnFailedRequest?.Invoke(null, new FailedRequestEventArgs(response));
        }

        #region Set
        /// <summary>
        /// sets the name of the user agent used for all requests
        /// </summary>
        /// <param name="name"></param>
        /// <inheritdoc cref="HttpHeaderValueCollection{T}.TryParseAdd(string?)"/>
        public static bool Set_UserAgent(string name)
        {
            _client.DefaultRequestHeaders.UserAgent.Clear();
            return _client.DefaultRequestHeaders.UserAgent.TryParseAdd(name);
        }
        #endregion

        #region Requests

        /// <summary>
        /// Helper Functions for making get requests <br/>
        /// <inheritdoc cref="HttpClient.GetAsync(string?)"/>
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="FetchedData"/></returns>
        /// <inheritdoc cref="HttpClient.GetAsync(string?)"/>
        public static async ValueTask<FetchedData> Get_RequestAsync([StringSyntax(StringSyntaxAttribute.Uri)] string url, CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response = await _client.GetAsync(url, cancellationToken);

            response.FireEvents();
            return new FetchedData(await response.Content.ReadAsStringAsync(cancellationToken), response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Helper Functions for making post requests
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">the req url</param>
        /// <param name="cancellationToken"></param>
        /// <param name="model">the post model</param>
        /// <returns><see cref="FetchedData"/></returns>
        public static async ValueTask<FetchedData> Post_RequestAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string url, T model, CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response = await _client.PostAsJsonAsync(url, model, cancellationToken);

            response.FireEvents();
            return new FetchedData(await response.Content.ReadAsStringAsync(cancellationToken), response.IsSuccessStatusCode);
        }

        #endregion
    }
}
