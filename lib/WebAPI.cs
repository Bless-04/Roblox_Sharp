using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models.Internal.POST;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
        /// <paramref name="HttpClient"/> used for all web requests
        /// </summary>
        public static HttpClient client { get => _client; }

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
        /// <summary>
        /// an event that is raised when the web request is successful/statuscode 200
        /// </summary>
        public static event EventHandler? OnSuccessfulRequest;

        /// <summary>
        /// an event that is raised when the web request fails / statuscode is not 200
        /// </summary>
        public static event EventHandler? OnFailedRequest;


        internal static bool SuccessfulRequest(HttpResponseMessage response, EventArgs e)
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
        /// <exception cref="InvalidUserException"></exception>
        internal static async Task<string> Get_RequestAsync(string url, bool RateLimitRetry = false, int MS_Delay = 60009)
        {
            using HttpResponseMessage response = await client.GetAsync(url);
            {
                if (SuccessfulRequest(response, EventArgs.Empty))
                    return await response.Content.ReadAsStringAsync();

                //errors
                switch (response.StatusCode)
                {
                    case HttpStatusCode.TooManyRequests:
                        {
                            if (RateLimitRetry)
                            {
                                await Task.Delay(MS_Delay); //default is 60 secs
                                return await Get_RequestAsync(url, false); //retries once
                            }
                            else
                                throw new RateLimitException($"Rate Limit Exceeded\n{url}\nStatusCode: {response.StatusCode}");
                        }
                    case HttpStatusCode.BadRequest:
                        throw new InvalidUserException($"User either doesnt exist or is terminated/banned \nStatusCode: {response.StatusCode}\n{url}");
                    case HttpStatusCode.NotFound:
                        throw new InvalidUserException($"Invalid User Id\nStatusCode: {response.StatusCode}\n{url}");

                    case (HttpStatusCode)443:
                        throw new HttpRequestException("There is an Internet Connection Issue\nPlease Connect to the Internet");

                    case HttpStatusCode.InternalServerError:
                        throw new HttpRequestException($"There may be a problem with the Roblox Servers.\nStatusCode: {response.StatusCode}\n{url}");
                }
                throw new NotImplementedException($"Unhandled Error\nStatusCode: {response.StatusCode} \n{response.Content}");
            }
        }

        /// <summary>
        /// helper function for post requests for roblox api
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postreq"></param>
        /// <returns></returns>
        /// <exception cref="InvalidUserException"></exception>
        /// <exception cref="InvalidUserException"></exception>
        internal static async Task<string> Post_RequestAsync(string url, User_POST postreq)
        {
            using HttpResponseMessage response = await client.PostAsync(
                    url, new StringContent(
                    JsonSerializer.Serialize(postreq),
                    Encoding.UTF8, "application/json")
                );
            {
                if (SuccessfulRequest(response, EventArgs.Empty))
                    return await response.Content.ReadAsStringAsync();
                //errors
                switch (response.StatusCode)
                {
                    case HttpStatusCode.TooManyRequests:
                        throw new RateLimitException($"Rate Limit Exceeded\n{url}\nStatusCode: {response.StatusCode}");

                    case HttpStatusCode.BadRequest:
                        if (postreq.userIds != null) throw new InvalidUserException("A userId may not exist,or there is to many");
                        else throw new InvalidUserException("A usernamename may not exist,or there is too many");

                    case (HttpStatusCode)443:
                        throw new HttpRequestException("There is an Internet Connection Issue\nPlease Connect to the Internet");

                    default:
                        throw new NotImplementedException($"Unhandled Error: {response.StatusCode}\n{url}\n{response.Content}");
                };
            }
        }
    }
}
