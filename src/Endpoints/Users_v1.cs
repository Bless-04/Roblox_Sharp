using Roblox_Sharp.Enums;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static Roblox_Sharp.WebAPI;

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
        /// <returns>A <see cref="Page{T}"/> of Users</returns>
        public static async Task<Page<User>> Get_UserSearchAsync(string keyword, Limit LIMIT = Limit.Minimum, Page<User>? page = null) =>
            /* example url https://users.roblox.com/v1/users/search?keyword=robl&sessionId=l&limit=10 */
            JsonSerializer.Deserialize<Page<User>>(
                await Get_RequestAsync(
                    $"https://users.roblox.com/v1/users/search?" +
                    $"keyword={keyword}" +
                    $"&limit={EnumExtensions.ToString(LIMIT)}" +
                    $"&cursor={page?.NextPageCursor}")
            )!;

        /// <summary>
        /// Get detailed user information for the given <paramref name="userId"/> asynchronously
        /// <br></br>
        /// <b><seealso href="https://users.roblox.com//docs/index.html">Users Documentation v1</seealso></b>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User</returns>
        /// <exception cref="InvalidUserException">if userid is invalid</exception>
        /// <exception cref="RateLimitException">If the request is rate limited</exception>
        public static async Task<User> Get_UserAsync(ulong userId) =>
            JsonSerializer.Deserialize<User>(
                await Get_RequestAsync($"https://users.roblox.com/v1/users/{userId}")
            ) ?? throw new InvalidUserException($"User id is invalid {userId}");

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
        /// <returns>List of Users</returns>
        public static async Task<IReadOnlyList<User>> Get_UsernamesAsync(List<ulong> userIds, bool excludeBannedUsers = false)
        {
            //url example https://users.roblox.com/v1/users

            IReadOnlyList<User> users = JsonSerializer.Deserialize<Page<User>>(
                await Post_RequestAsync("https://users.roblox.com/v1/users", new User.Post(userIds, excludeBannedUsers))
            )!.Data;

            if (users.Count == 0) throw new InvalidUserException($"No valid user ids\n[{string.Join(',', userIds)}]");

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
        public static async Task<IReadOnlyList<User>> Get_UsersAsync(List<string> usernames, bool excludeBannedUsers = false)
        {
            //url example https://users.roblox.com/v1/usernames/users

            //StringContent(json, Encoding.UTF8, "application/json");
            IReadOnlyList<User> users = JsonSerializer.Deserialize<Page<User>>(
                await Post_RequestAsync("https://users.roblox.com/v1/usernames/users", new User.Post(usernames, excludeBannedUsers))
            )!.Data;

            if (users.Count == 0) throw new InvalidUserException($"No valid usernames\n[{string.Join(',', usernames)}]");

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
        public static async Task<Page<User>> Get_UsernameHistoryAsync(ulong userId, Limit LIMIT = Limit.Minimum, Sort SORT = Sort.Asc, Page<User>? page = null) =>
            //url example 'https://users.roblox.com/v1/users/416181091/username-history?limit=100&sortOrder=Asc
            JsonSerializer.Deserialize<Page<User>>(
                await Get_RequestAsync(
                    $"https://users.roblox.com/v1/users/{userId}" +
                    $"/username-history?limit={EnumExtensions.ToString(LIMIT)}" +
                    $"&cursor={page?.NextPageCursor}" +
                    $"&sortOrder={SORT}")
            )!;

        /// <summary>
        /// Gets the minimal Authenticated User asynchronously
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<User> Get_AuthenticatedAsync() =>
            JsonSerializer.Deserialize<User>(
                await Get_RequestAsync("https://users.roblox.com/v1/users/authenticated")
            ) ?? throw new InvalidOperationException("There is no authenticated user");      
    }
}
