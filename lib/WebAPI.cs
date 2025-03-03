using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models.Internal.POST;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

///#pragma warning disable IDE1006 // Naming Styles ; idc
namespace Roblox_Sharp
{


    /// <summary>
    /// static class that holds the functions and logic used for making web requests to Roblox API <br></br>
    /// <b><see href="https://github.com/matthewdean/roblox-web-apis?tab=readme-ov-file">Endpoints Documentation</see></b>
    /// </summary>
    public static class WebAPI
    {
        private static HttpClient _client = new();

        /// <summary>
        /// <see cref="HttpClient"></see> used for all web requests
        /// </summary>
        public static HttpClient client => _client;

        /// <summary>
        /// an event that is raised when the web request is successful/statuscode 200
        /// </summary>
        public static event EventHandler? OnSuccessfulRequest;

        /// <summary>
        /// an event that is raised when the web request fails / statuscode is not 200
        /// </summary>
        public static event EventHandler? OnFailedRequest;

        static WebAPI()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Set_UserAgent(nameof(Roblox_Sharp));
            //_client.DefaultRequestHeaders.Authorization needed for auth
        }
        /// <summary>
        /// sets the <see cref="HttpClient"/> used for all web requests
        /// useful for configuring httpclient
        /// sets to default if null
        /// </summary>
        /// <param name="new_client"></param>
        public static void Set_HttpClient(HttpClient new_client)
        {
            _client.Dispose();
            _client = new_client;
        }

        /// <summary>
        /// sets the name of the user agent used for all requests
        /// </summary>
        /// <param name="name"></param>
        public static void Set_UserAgent(string name)
        {
            _client.DefaultRequestHeaders.UserAgent.Clear();
            _client.DefaultRequestHeaders.UserAgent.TryParseAdd(name);
        }


        internal static bool SuccessfulRequest(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                OnSuccessfulRequest?.Invoke(response, EventArgs.Empty);
                return true;
            }
            else
            {
                OnFailedRequest?.Invoke(response, EventArgs.Empty);
                return false;
            }
        }

        /// <summary>
        /// helper function for get requests for roblox api
        /// </summary>
        /// <param name="url"></param>
        /// <returns>content string</returns>
        /// <exception cref="InvalidUserException">When the userid doesnt exist or is terminated/banned</exception>
        internal static async Task<string> Get_RequestAsync(string url)
        {
            using HttpResponseMessage response = await client.GetAsync(url);
            {
                if (SuccessfulRequest(response)) return await response.Content.ReadAsStringAsync();

                //errors
                throw response.StatusCode switch
                {
                    HttpStatusCode.TooManyRequests => new RateLimitException($"Rate Limit Exceeded\n{url}\nStatusCode: {response.StatusCode}\n{response.Content}"),
                    HttpStatusCode.BadRequest => new InvalidUserException($"User either doesnt exist or is terminated/banned \nStatusCode: {response.StatusCode}\n{url}"),
                    HttpStatusCode.NotFound => new InvalidIdException($"Invalid User Id\nStatusCode: {response.StatusCode}\n{url}"),
                    (HttpStatusCode)443 => new HttpRequestException("There is an Internet Connection Issue\nPlease Connect to the Internet"),
                    HttpStatusCode.InternalServerError => new HttpRequestException($"There may be a problem with the Roblox Servers.\nStatusCode: {response.StatusCode}\n{url}"),
                    _ => new NotImplementedException($"Unhandled Error\nStatusCode: {response.StatusCode} \n{response.Content}"),
                };
            }
        }

        /// <summary>
        /// helper function for post requests for roblox api
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postreq"></param>
        /// <returns></returns>
        /// <exception cref="InvalidUserException"></exception>
        /// <exception cref="InvalidIdException"></exception>
        internal static async Task<string> Post_RequestAsync(string url, User_POST postreq)
        {
            using HttpResponseMessage response = await client.PostAsync(
                    url, new StringContent(
                    JsonSerializer.Serialize(postreq),
                    Encoding.UTF8, "application/json")
                );
            {
                if (SuccessfulRequest(response))
                    return await response.Content.ReadAsStringAsync();
                //errors
                switch (response.StatusCode)
                {
                    case HttpStatusCode.TooManyRequests:
                        throw new RateLimitException($"Rate Limit Exceeded\n{url}\nStatusCode: {response.StatusCode}");

                    case HttpStatusCode.BadRequest:
                        if (postreq.userIds != null) throw new InvalidIdException("A userId may not exist,or there is to many");
                        else throw new InvalidUserException("A username may not exist,or there is too many");

                    case (HttpStatusCode)443:
                        throw new HttpRequestException("There is an Internet Connection Issue\nPlease Connect to the Internet");

                    default:
                        throw new NotImplementedException($"Unhandled Error: {response.StatusCode}\n{url}\n{response.Content}");
                }
                ;
            }
        }
    }
}
