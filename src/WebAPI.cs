using Roblox_Sharp.Models.v1;
using Roblox_Sharp.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
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

        internal static HttpClient _client = new();

        /// <summary>
        /// <see cref="HttpClient"></see> used for all web requests
        /// </summary>
        public static HttpClient Client() => _client;

        /* not needed
        /// <summary>
        /// <see cref="JsonSerializerOptions"></see> used for all web requests
        /// </summary>
        public static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true,
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        */

        /// <summary>
        /// an event that is raised when the web request is successful/statuscode 200
        /// </summary>
        public static event EventHandler? OnSuccessfulRequest;

        /// <summary>
        /// an event that is raised when the web request fails / statuscode is not 200
        /// </summary>
        public static event EventHandler<FailedRequestEventArgs>? OnFailedRequest;

        #region internal helpers
        internal static void FireRequestEvents(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) OnSuccessfulRequest?.Invoke(null, EventArgs.Empty);
            else OnFailedRequest?.Invoke(null, new FailedRequestEventArgs(response));
        }

        /// <returns>
        /// the deserialized <typeparamref name="T"/> <br/> 
        /// <see langword="null"/> or <see langword="default"/> if the request is not successful
        /// </returns>
        /// <inheritdoc cref="JsonSerializer.Deserialize{TValue}(string, JsonSerializerOptions?)"/>
        internal static T? Deserialize<T>(FetchedData data) => data.Success ? JsonSerializer.Deserialize<T>(data.Json) : default;

        #endregion

        static WebAPI()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Set_UserAgent(nameof(Roblox_Sharp));
            //_client.DefaultRequestHeaders.Authorization needed for auth
        }


        /// <summary>
        /// atomically sets the <see cref="HttpClient"/> used for all web requests
        /// useful for configuring httpclient
        /// sets to default if null
        /// </summary>
        /// <param name="new_client"></param>
        public static void Set_HttpClient(HttpClient new_client) => Interlocked.Exchange(ref _client, new_client).Dispose(); //thread safe because of this?

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


        #region Requests

        /// <summary>
        /// Helper Functions for making get requests <br/>
        /// <inheritdoc cref="HttpClient.GetAsync(string?)"/>
        /// </summary>
        /// <param name="url"></param>
        /// <returns><see cref="FetchedData"/></returns>
        /// <inheritdoc cref="HttpClient.GetAsync(string?)"/>
        public static async Task<FetchedData> Get_RequestAsync([StringSyntax(StringSyntaxAttribute.Uri)] string url)
        {
            using HttpResponseMessage response = await _client.GetAsync(url);
            
            FireRequestEvents(response);
            return new FetchedData(await response.Content.ReadAsStringAsync(),response.IsSuccessStatusCode);
        }

        /// <summary>
        /// Helper Functions for making post requests
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">the req url</param>
        /// <param name="model">the post model</param>
        /// <returns><see cref="FetchedData"/></returns>
        public static async Task<FetchedData> Post_RequestAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string url,T model)
        {
            using HttpResponseMessage response = await _client.PostAsJsonAsync(url, model);

            FireRequestEvents(response);
            return new FetchedData(await response.Content.ReadAsStringAsync(), response.IsSuccessStatusCode);
        }

        /*
        /// <summary>
        /// function for User.Post request that is pretty much a get request
        /// </summary>
        public static async Task<string> Post_RequestAsync([StringSyntax(StringSyntaxAttribute.Uri)] string url, Response.Post POST)
        {
            using HttpResponseMessage response = await _client.PostAsync(url, new StringContent(JsonSerializer.Serialize(POST),Encoding.UTF8, "application/json"));
            {
                FireRequestEvents(response);
                return await response.Content.ReadAsStringAsync();
            }
                
        }
        /* Not needed yet
        public static async Task<string> Post_RequestAsync<T>(string url,)

        */
        #endregion
    }
}
