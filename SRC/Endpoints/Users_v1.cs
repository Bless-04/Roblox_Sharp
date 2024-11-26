using System;
using System.Threading.Tasks;
using System.Text.Json;

using static Roblox_Sharp.WebAPI;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.JSON;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// endpoints for direct Roblox user information. <br></br>
    /// <b><see href="https://users.roblox.com/docs//index.html">Users Documentation v1</see></b>
    /// </summary>
    public static class Users_v1
    {
        /// <summary>
        /// Gets a list of users that either have a similar username or display name of the given <paramref name="keyword"/> asynchronously
        /// <br></br><b><seealso href="https://users.roblox.com/docs//index.html">Users Documentation v1</seealso></b>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="LIMIT"></param>
        /// <param name="page"></param>
        /// <returns>A <paramref name="Page"/> of Users</returns>
        public static async Task<Page<User>> Get_UserSearchAsync(string keyword, Limit LIMIT = Limit.Minimum, Page<User>? page = null)
        {
            /* example url https://users.roblox.com/v1/users/search?keyword=robl&sessionId=l&limit=10 */
            string content = await Get_RequestAsync($"https://users.roblox.com/v1/users/search?" +
                $"keyword={keyword}" +
                $"&limit={EnumExtensions.ToString(LIMIT)}" +
                $"&cursor={page?.nextPageCursor}"
            );

            return JsonSerializer.Deserialize<Page<User>>(content)!;
        }

        /// <summary>
        /// Get detailed user information for the given <paramref name="userId"/> asynchronously
        /// <br></br>
        /// <b><seealso href="https://users.roblox.com//docs/index.html">Users Documentation v1</seealso></b>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User</returns>
        /// <exception cref="InvalidUserIdException"></exception>
        /// <exception cref="RateLimitException"></exception> 
        public static async Task<User> Get_UserAsync(ulong userId)
        {
            string content = await Get_RequestAsync($"https://users.roblox.com/v1/users/{userId}");

            User? user = JsonSerializer.Deserialize<User>(content);
            if (user == null) throw new NotImplementedException($"Unhandled Error User was null: {content}");
            return user;
        }


        /// <summary>
        /// get usernames using the given array of <paramref name="userIds"/> asynchronousoly 
        /// <br></br>
        /// ignores <paramref name="userIds"/> that dont exist
        /// <br></br>
        /// <b><seealso href="https://users.roblox.com/docs//index.html">Users Documentation v1</seealso></b>
        /// </summary>
        /// 
        /// <param name="userIds"></param>
        /// <param name="excludeBannedUsers"></param>
        /// <returns>User[]</returns>
        public static async Task<User[]> Get_UsernamesAsync(ulong[] userIds, bool excludeBannedUsers = false)
        {
            //url example https://users.roblox.com/v1/users
            string content = await Post_RequestAsync("https://users.roblox.com/v1/users", new UserPOST(userIds, excludeBannedUsers));

            User[] users = JsonSerializer.Deserialize<Page<User>>(content)!.data;
            if (users.Length == 0) throw new InvalidUserIdException($"No valid user ids\n[{string.Join(',', userIds)}]");

            return users;
        }

        /// <summary>
        /// get usersIds using the given array of <paramref name="usernames"/> asynchronously
        /// <br></br>
        /// ignores <paramref name="usernames"/> that dont exist
        /// <br></br>
        /// <br></br>
        /// <b><seealso href="https://users.roblox.com/docs//index.html">Users Documentation v1</seealso></b>
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="excludeBannedUsers"></param>
        /// <returns>User[]</returns>
        public static async Task<User[]> Get_UsersAsync(string[] usernames, bool excludeBannedUsers = false)
        {
            //url example https://users.roblox.com/v1/usernames/users

            //StringContent(json, Encoding.UTF8, "application/json");
            string content = await Post_RequestAsync("https://users.roblox.com/v1/usernames/users", new UserPOST(usernames, excludeBannedUsers));

            User[] users = JsonSerializer.Deserialize<Page<User>>(content)!.data;
            if (users.Length == 0) throw new InvalidUsernameException($"No valid usernames\n[{string.Join(',', usernames)}]");

            return users;

        }


        /// <summary>
        /// Retrieves the username history for a given <paramref name="userId"/>.
        /// <br></br>
        /// <seealso href="https://users.roblox.com/docs//index.html">Users Documentation v1</seealso>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="LIMIT"></param>
        /// <param name="SORT"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task<Page<User>> Get_UsernameHistoryAsync(ulong userId, Limit LIMIT = Limit.Minimum, Sort SORT = Sort.Asc, Page<User>? page = null)
        {
            ///url example 'https://users.roblox.com/v1/users/416181091/username-history?limit=100&sortOrder=Asc

            string content = await Get_RequestAsync($"https://users.roblox.com/v1/users/{userId}/username-history?limit={EnumExtensions.ToString(LIMIT)}&cursor={page?.nextPageCursor}&sortOrder={SORT}");
            return JsonSerializer.Deserialize<Page<User>>(content)!;
        }

    }
}
