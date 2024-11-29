﻿using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

using Roblox_Sharp.Exceptions;
using Roblox_Sharp.JSON;

namespace Roblox_Sharp
{
    /// <summary>
    /// static class that defines the logic used for making web requests to Roblox API <br></br>
    /// <b><see href="https://github.com/matthewdean/roblox-web-apis?tab=readme-ov-file">Endpoints Documentation</see></b>
    /// </summary>
    public static class WebAPI
    {
        /// <summary>
        /// an event that is raised when the web request is successful/statuscode 200
        /// </summary>
        public static event EventHandler? OnSuccessfulRequest;

        /// <summary>
        /// an event that is raised when the web request fails
        /// </summary>
        public static event EventHandler? OnFailedRequest;

        /// <summary>
        /// an instance of the http client. Used for all web requests
        /// </summary>
        internal static readonly HttpClient client = new(); 

        /// <summary>
        /// helper function for get requests for roblox api
        /// </summary>
        /// <param name="url"></param>
        /// <returns>content string</returns>
        /// <exception cref="InvalidIdException"></exception>
        internal static async Task<string> Get_RequestAsync(string url, bool RateLimitRetry = false,int MS_Delay = 59000)
        {
            using HttpResponseMessage response = await client.GetAsync(url);
            {
                if (response.IsSuccessStatusCode)
                {
                    OnSuccessfulRequest?.Invoke(response, EventArgs.Empty);
                    return await response.Content.ReadAsStringAsync();
                }
                else 
                    OnFailedRequest?.Invoke(response, EventArgs.Empty);

                //errors
                switch (response.StatusCode)
                {
                    case HttpStatusCode.TooManyRequests:
                    {
                        if (RateLimitRetry)
                        {
                            await Task.Delay(MS_Delay); //default is 59 secs
                            return await Get_RequestAsync(url, false); //retries once
                        }
                        else
                            throw new RateLimitException($"Rate Limit Exceeded\n{url}\nStatusCode: {response.StatusCode}"); 
                    }

                    case HttpStatusCode.BadRequest:
                        throw new InvalidIdException($"User either doesnt exist or is terminated/banned \nStatusCode: {response.StatusCode}\n{url}");
                    case HttpStatusCode.NotFound:
                        throw new InvalidIdException($"Invalid User Id\nStatusCode: {response.StatusCode}\n{url}");

                    case (HttpStatusCode)443:
                        throw new HttpRequestException("There is an Internet Connection Issue\nPlease Connect to the Internet");

                    default:
                        throw new NotImplementedException($"Unhandled Error: code:{response.StatusCode} \n{response.Content}");
                }
                
            }

          
        }

        /// <summary>
        /// helper function for post requests for roblox api
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postreq"></param>
        /// <returns></returns>
        /// <exception cref="InvalidUsernameException"></exception>
        /// <exception cref="InvalidIdException"></exception>
        internal static async Task<string> Post_RequestAsync(string url, object postreq)
        {
            string json = JsonSerializer.Serialize(postreq);

            using HttpResponseMessage response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            {
                if (response.IsSuccessStatusCode)
                {
                    OnSuccessfulRequest?.Invoke(response, EventArgs.Empty);
                    return await response.Content.ReadAsStringAsync();
                }
                else
                    OnFailedRequest?.Invoke(response, EventArgs.Empty);
                //errors
                switch (response.StatusCode)
                {
                    case HttpStatusCode.TooManyRequests:
                        throw new RateLimitException($"Rate Limit Exceeded\n{url}\nStatusCode: {response.StatusCode}");

                    case HttpStatusCode.BadRequest:
                        UserPOST p = (UserPOST)postreq;
                        if (p.userIds != null)
                            throw new InvalidUsernameException("Too many ids.");
                        else
                            throw new InvalidIdException("Too many usernames.");

                    case (HttpStatusCode)443:
                        throw new HttpRequestException("There is an Internet Connection Issue\nPlease Connect to the Internet");

                    default:
                        throw new NotImplementedException($"Unhandled Error: {response.StatusCode}\n{url}\n{response.Content}");
                };
            }

            
        }
    }
}
