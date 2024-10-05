using Newtonsoft.Json;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.JSON;
using Roblox_Sharp.Enums;
using System.Text;
using System.Net;


namespace Roblox_Sharp
{

    /// <summary>
    /// static class for retrieving data from the Roblox API <br></br>
    /// <b><see href="https://github.com/matthewdean/roblox-web-apis?tab=readme-ov-file"></see></b>
    /// </summary>
    public static class WebData
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
        public static readonly HttpClient client = new(); 
        
        //public static HttpStatusCode statusCode { get; private set; }
        
        /// <summary>
        /// helper function for get requests for roblox api
        /// </summary>
        /// <param name="url"></param>
        /// <returns>content string</returns>
        /// <exception cref="InvalidUserIdException"></exception>
        public static async Task<string> Get_RequestAsync(string url, bool RateLimitRetry = false,int MS_Delay = 59000)
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
                        throw new InvalidUserIdException($"User either doesnt exist or is terminated/banned \nStatusCode: {response.StatusCode}\n{url}");
                    case HttpStatusCode.NotFound:
                        throw new InvalidUserIdException($"Invalid User Id\nStatusCode: {response.StatusCode}\n{url}");

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
        /// <exception cref="InvalidUserIdException"></exception>
        public static async Task<string> Post_RequestAsync(string url, object postreq)
        {
            string json = JsonConvert.SerializeObject(postreq);

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
                            throw new InvalidUserIdException("Too many usernames.");

                    case (HttpStatusCode)443:
                        throw new HttpRequestException("There is an Internet Connection Issue\nPlease Connect to the Internet");

                    default:
                        throw new NotImplementedException($"Unhandled Error: {response.StatusCode}\n{url}\n{response.Content}");
                };

                
            }

            
        }

        /// <summary>
        /// Get detailed user information for the given <paramref name="userId"/> asynchronously
        /// <br></br>
        /// <b><seealso href="https://users.roblox.com/docs/index.html">Users Documentation v1</seealso></b>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User</returns>
        /// <exception cref="InvalidUserIdException"></exception>
        /// <exception cref="RateLimitException"></exception> 
        public static async Task<User> Get_UserAsync(ulong userId)
        {
            string content = await Get_RequestAsync($"https://users.roblox.com/v1/users/{userId}");

            User? user = JsonConvert.DeserializeObject<User>(content);
                if (user == null) throw new NotImplementedException($"Unhandled Error User was null: {content}");
            return user;
        }

        /// <summary>
        /// get usernames using the given array of <paramref name="userIds"/> asynchronousoly 
        /// <br></br>
        /// ignores <paramref name="userIds"/> that dont exist
        /// <br></br>
        /// <b><seealso href="https://users.roblox.com/docs/index.html">Users Documentation v1</seealso></b>
        /// </summary>
        /// 
        /// <param name="userIds"></param>
        /// <param name="excludeBannedUsers"></param>
        /// <returns>User[]</returns>
        public static async Task<User[]> Get_UsernamesAsync(ulong[] userIds, bool excludeBannedUsers = false)
        {
            //url example https://users.roblox.com/v1/users
            string content = await Post_RequestAsync("https://users.roblox.com/v1/users", new UserPOST(userIds, excludeBannedUsers));

            User[] users = JsonConvert.DeserializeObject<Page<User>>(content)!.data;
            if (users.Length == 0) throw new InvalidUserIdException($"No valid user ids\n[{string.Join(',', userIds)}]");

            return users;
        }


        public static async Task<Page<User>> Get_PreviousUsernamesAsync(ulong userId, Limit LIMIT = Limit.Minimum, Sort SORT = Sort.Asc, Page<User>? page = null)
        {
            ///url example 'https://users.roblox.com/v1/users/416181091/username-history?limit=100&sortOrder=Asc

            string content = await Get_RequestAsync($"https://users.roblox.com/v1/users/{userId}/username-history?limit={EnumExtensions.ToString(LIMIT)}&cursor={page?.nextPageCursor}&sortOrder={SORT}");
            return JsonConvert.DeserializeObject<Page<User>>(content)!;
        }

        /// <summary>
        /// get usersIds using the given array of <paramref name="usernames"/> asynchronously
        /// <br></br>
        /// ignores <paramref name="usernames"/> that dont exist
        /// <br></br>
        /// <br></br>
        /// <b><seealso href="https://users.roblox.com/docs/index.html">Users Documentation v1</seealso></b>
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="excludeBannedUsers"></param>
        /// <returns>User[]</returns>
        public static async Task<User[]> Get_UsersAsync(string[] usernames, bool excludeBannedUsers = false)
        {
            //url example https://users.roblox.com/v1/usernames/users
            
            //StringContent(json, Encoding.UTF8, "application/json");
            string content = await Post_RequestAsync("https://users.roblox.com/v1/usernames/users", new UserPOST(usernames, excludeBannedUsers));

            User[] users = JsonConvert.DeserializeObject<Page<User>>(content)!.data;
            if (users.Length == 0) throw new InvalidUsernameException($"No valid usernames\n[{string.Join(',', usernames)}]");

            return users;

        }

        /// <summary>
        /// Get the number of friends a given <paramref name="userId"/> has asynchronously
        /// <br></br>
        /// <seealso href="https://friends.roblox.com/docs/index.html">Friends Documentation v1</seealso>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>byte</returns>
        /// <exception cref="InvalidUserIdException"></exception>
        /// <exception cref="NotImplementedException"></exception>"
        public static async Task<byte> Get_FriendsCountAsync(ulong userId)
        {
            string content = await Get_RequestAsync($"https://friends.roblox.com/v1/users/{userId}/friends/count");
           
            return (byte)JsonConvert.DeserializeObject<CountType>(content).count;
        }

        /// <summary>
        /// Get list of <b>all</b> friends for the specified <paramref name="userId"/>
        /// <br></br>
        ///  <b><see href="https://friends.roblox.com/docs/index.html">Friends Documentation v1</see></b>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User[]</returns>
        public static async Task<User[]> Get_FriendsAsync(ulong userId)
        {
            //url example 'https://friends.roblox.com/v1/users/16/friends?userSort=0

            string content = await Get_RequestAsync($"https://friends.roblox.com/v1/users/{userId}/friends");

            return JsonConvert.DeserializeObject<Page<User>>(content)!.data!;
        }

        /// <summary>
        /// Get the number of followers a user has asynchronously
        /// <<br></br>
        /// <b><seealso href="https://friends.roblox.com/docs/index.html">Friends Documentation v1</seealso></b>
        /// </summary>
        /// 
        /// <param name="id"></param>
        /// <returns>ulong</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="RateLimitException"></exception>
        /// <exception cref="InvalidUserIdException"></exception>
        public static async Task<ulong> Get_FollowersCountAsync(ulong userId)
        {
            string content = await Get_RequestAsync($"https://friends.roblox.com/v1/users/{userId}/followings/count");
            return JsonConvert.DeserializeObject<CountType>(content).count;
        }

        /// <summary>
        /// Get all users that follow the given <paramref name="userId"/> with targetUserId in page response format
        /// <br></br>
        /// <b><seealso href="https://friends.roblox.com/docs/index.html">Friends API Documentation v1</seealso></b>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="limit"></param>
        /// <param name="sortOrder"></param>
        /// <param name="page">The page to start at.</param>
        /// <returns>Page</returns>
        
        public static async Task<Page<User>> Get_FollowersAsync(ulong userId,Limit limit = Limit.Minimum,Sort sortOrder = Sort.Asc,Page<User>? page=null)
        {

            string content = await Get_RequestAsync($"https://friends.roblox.com/v1/users/{userId}/followers?limit=50&sortOrder={sortOrder}&cursor={page?.nextPageCursor}");

            
            return JsonConvert.DeserializeObject<Page<User>>(content)!;
        }

        /// <summary>
        /// Get the number users a <paramref name="userId"/> is following asynchronously
        /// <br></br>
        /// <seealso href="https://friends.roblox.com/docs/index.html">Friends API Documentation v1</seealso>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>ulong</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="RateLimitException"></exception>
        /// <exception cref="InvalidUserIdException"></exception>
        public static async Task<ulong> Get_FollowingsCountAsync(ulong userId)
        {
            string content = await Get_RequestAsync($"https://friends.roblox.com/v1/users/{userId}/followings/count");

            return JsonConvert.DeserializeObject<CountType>(content).count;
        }

        /// <summary>
        /// Get all users that the given  <paramref name="userId"/> is following in page response format
        /// <br></br>
        /// <seealso href="https://friends.roblox.com/docs/index.html">Friends API Documentation v1</seealso>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="limit"></param>
        /// <param name="sortOrder"></param>
        /// <param name="cursor"></param>
        /// <returns>Page</returns>
        public static async Task<Page<User>> Get_FollowingsAsync(ulong userId, Limit limit = Limit.Minimum, Sort sortOrder = Sort.Asc, string? cursor = null)
        {
            // url example https://friends.roblox.com/v1/users/1/followers?limit=10&sortOrder=Asc

            string content = await Get_RequestAsync($"https://friends.roblox.com/v1/users/{userId}/followings?limit=50&sortOrder={sortOrder}&cursor={cursor}");

            return JsonConvert.DeserializeObject<Page<User>>(content)!;
        }

        /// <summary>
        /// Get Avatar Full body shots for the given array of <paramref name="userIds"/> 
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="SIZE"></param>
        /// <param name="FORMAT"></param>
        /// <param name="isCircular"></param>
        /// <returns>Avatar[]</returns>
        public static async Task<Avatar[]> Get_AvatarsAsync(ulong[] userIds, Enums.Thumbnail.Size SIZE = Enums.Thumbnail.Size.x48, Enums.Thumbnail.Format FORMAT = Enums.Thumbnail.Format.Png, bool isCircular = false)
        {
            if (SIZE == Enums.Thumbnail.Size.x50) throw new ArgumentOutOfRangeException($"{SIZE} is not supported for this request.");
            //url example https://thumbnails.roblox.com/v1/users/avatar?userIds=1,156&size=30x30&format=Png&isCircular=false

            string content = await Get_RequestAsync(
                $"https://thumbnails.roblox.com/v1/users/avatar?userIds={string.Join(",", userIds)}" +
                $"&size={EnumExtensions.ToString(SIZE)}" +
                $"&format={FORMAT.ToString()}" +
                $"&isCircular={isCircular}"
            );
            
            return JsonConvert.DeserializeObject<Page<Avatar>>(content)!.data;
        }

        /// <summary>
        /// Get Avatar Headshots for the given array of <paramref name="userIds"/> 
        /// <br></br>
        /// <b><see href="https://thumbnails.roblox.com/docs/index.html">Thumbnails API Documentation v1</see></b>
        /// <br></br>
        /// <b>Will ignore users that, dont exist , are terminated/banned or are already in list</b>
        /// <br></br>
        /// <code>range (x48 to x720)</code>
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="SIZE"></param>
        /// <param name="FORMAT"></param>
        /// <param name="isCircular"></param>
        /// <returns>Avatar[]</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static async Task<Avatar[]> Get_AvatarHeadshotsAsync(ulong[] userIds, Enums.Thumbnail.Size SIZE = Enums.Thumbnail.Size.x48, Enums.Thumbnail.Format FORMAT = Enums.Thumbnail.Format.Png, bool isCircular = false)
        {
            //size smaller than minumum or larger than maximum
            if (SIZE < Enums.Thumbnail.Size.x48 || Enums.Thumbnail.Size.x720 < SIZE) throw new ArgumentOutOfRangeException("range is from x48 to x720\n"+SIZE.ToString());
            /// example https://thumbnails.roblox.com/v1/users/avatar-headshot?userIds=1&size=48x48&format=Png&isCircular=false

            

            string content = await Get_RequestAsync(
                $"https://thumbnails.roblox.com/v1/users/avatar-headshot?userIds={string.Join(",", userIds)}" +
                $"&size={EnumExtensions.ToString(SIZE)}" +
                $"&format={FORMAT}" +
                $"&isCircular={isCircular}"
            );

            return JsonConvert.DeserializeObject<Page<Avatar>>(content)!.data;
        }

        /// <summary>
        /// Get Avatar Busts for the given array of <paramref name="userIds"/>
        /// <br></br>
        /// <b><see href="https://thumbnails.roblox.com/docs/index.html">Thumbnails API Documentation v1</see></b>
        /// <br></br>
        /// <b>Will ignore users that, dont exist , are terminated/banned or are already in list</b>
        /// <br></br>
        /// <code>range (x48 to x100) or (x150 to x720)</code>
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="SIZE"></param>
        /// <param name="FORMAT"></param>
        /// <param name="isCircular"></param>
        /// <returns>Avatar[]</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<Avatar[]> Get_AvatarBustsAsync(ulong[] userIds, Enums.Thumbnail.Size SIZE = Enums.Thumbnail.Size.x48, Enums.Thumbnail.Format FORMAT = Enums.Thumbnail.Format.Png, bool isCircular = false)
        {
            if ((SIZE < Enums.Thumbnail.Size.x48 || Enums.Thumbnail.Size.x420 < SIZE) && (Enums.Thumbnail.Size.x110 == SIZE)) throw new ArgumentOutOfRangeException("range: \nx48 <= SIZE < x110 || SIZE <= x420\n" + SIZE.ToString());
            // url example https://thumbnails.roblox.com/v1/users/avatar-bust?userIds=1,156,256,2,16&size=48x48&format=Png&isCircular=false
            if (FORMAT == Enums.Thumbnail.Format.Jpeg) throw new ArgumentException($"{FORMAT} is not supported for this request");

            string content = await Get_RequestAsync(
                $"https://thumbnails.roblox.com/v1/users/avatar-bust?userIds={string.Join(",", userIds)}" +
                $"&size={EnumExtensions.ToString(SIZE)}" +
                $"&format={FORMAT}" +
                $"&isCircular={isCircular}"
            );

            return JsonConvert.DeserializeObject<Page<Avatar>>(content)!.data;
        }
        /// <summary>
        /// Asynchronously Gets timestamps for when badges were awarded to the given <typeparamref name="userId"/>
        /// <br></br>
        /// <see href="https://badges.roblox.com/docs/index.html?urls.primaryName=Badges%20Api%20v1">v1 Badges Documentation</see>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="badgeIds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidUserIdException"></exception>
        public static async Task<BadgeAward[]> Get_BadgesAwardedDatesAsync(ulong userId, ulong[] badgeIds)
        {
            if (badgeIds.Length == 0) throw new ArgumentException("atleast one badge id is required");

            //URL example https://badges.roblox.com/v1/users/63225213/badges/awarded-dates?badgeIds=2126601323,2126601209,94278219,-1
           
            string content = await Get_RequestAsync(
                $"https://badges.roblox.com/v1/users/{userId}/badges/awarded-dates?badgeIds={string.Join(',', badgeIds)}"
            );

            return JsonConvert.DeserializeObject<Page<BadgeAward>>(content)!.data;
            
        }

        /// <summary>
        /// Get Presence for the given array of <paramref name="userIds"/> 
        /// <br></br>
        /// <b><see href="https://presence.roblox.com/docs/index.html">Presence API Documentation v1</see></b>
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns>userPresence[]</returns>
        public static async Task<userPresence[]> Get_PresencesAsync(ulong[] userIds)
        {
            // url example https://presence.roblox.com/v1/presence/users
            string content = await Post_RequestAsync($"https://presence.roblox.com/v1/presence/users", new UserPOST(userIds));

            return JsonConvert.DeserializeObject<Page<userPresence>>(content)!.userPresences!;
        }

        /// <summary>
        /// Get Last Online for the given array of <paramref name="userIds"/>
        /// <br></br>
        /// <b><see href="https://presence.roblox.com/docs/index.html">Presence API Documentation v1</see></b>
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns>userPresence[]</returns>
        
        public static async Task<userPresence[]> Get_LastOnlinesAsync(ulong[] userIds)
        {
            //url example https://presence.roblox.com/v1/presence/last-online
            string content = await Post_RequestAsync($"https://presence.roblox.com/v1/presence/last-online", new UserPOST(userIds));

            return  JsonConvert.DeserializeObject<Page<userPresence>>(content)!.lastOnlineTimestamps;
        }
    }
}
