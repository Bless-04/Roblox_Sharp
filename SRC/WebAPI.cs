using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

using Roblox_Sharp.Exceptions;

using Roblox_Sharp.JSON_Models.Internal.POST;
using static Roblox_Sharp.Framework.WebHelper;



namespace Roblox_Sharp
{
  
    /// <summary>
    /// class that defines the logic used for making web requests to Roblox API <br></br>
    /// <b><see href="https://github.com/matthewdean/roblox-web-apis?tab=readme-ov-file">Endpoints Documentation</see></b>
    /// </summary>
    public static class WebAPI
    {
        /// <summary>
        /// an event that is raised when the web request is successful/statuscode 200
        /// </summary>
        public static event EventHandler? OnSuccessfulRequest;

        /// <summary>
        /// an event that is raised when the web request fails / statuscode is not 200
        /// </summary>
        public static event EventHandler? OnFailedRequest;
        
        /// <summary>
        /// helper function for get requests for roblox api
        /// </summary>
        /// <param name="url"></param>
        /// <returns>content string</returns>
        /// <exception cref="InvalidIdException"></exception>
        internal static async Task<string> Get_RequestAsync(string url, bool RateLimitRetry = false,int MS_Delay = 60009)
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
                            await Task.Delay(MS_Delay); //default is 60 secs
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
        /// <exception cref="InvalidUsernameException"></exception>
        /// <exception cref="InvalidIdException"></exception>
        internal static async Task<string> Post_RequestAsync(string url, User_POST postreq)
        {
            using HttpResponseMessage response = await client.PostAsync(
                url, new StringContent(
                    JsonSerializer.Serialize(postreq), 
                    Encoding.UTF8, "application/json")
                );
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
                        User_POST post = postreq;
                        if (post.userIds != null)
                            throw new InvalidIdException("A userId may not exist,or there is to many");
                        else
                            throw new InvalidUsernameException("Too many usernames.");

                    case (HttpStatusCode)443:
                        throw new HttpRequestException("There is an Internet Connection Issue\nPlease Connect to the Internet");

                    default:
                        throw new NotImplementedException($"Unhandled Error: {response.StatusCode}\n{url}\n{response.Content}");
                };
            }

            
        }

       
    }
}
