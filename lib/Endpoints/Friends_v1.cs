using Roblox_Sharp.Enums;
using Roblox_Sharp.Models;
using Roblox_Sharp.Models.Internal;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static Roblox_Sharp.WebAPI;


namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// Endpoints for all Friends, followers, and contacts management
    /// <b><see href="https://friends.roblox.com/docs//index.html">Friends Documentation</see></b>
    /// </summary>
    public static class Friends_v1
    {
        /// <summary>
        /// Get list of <b>all</b> friends for the specified <paramref name="userId"/>
        /// <br></br>
        ///  <b><see href="https://friends.roblox.com/docs//index.html">Friends Documentation v1</see></b>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User[]</returns>
        public static async Task<IReadOnlyList<User>> Get_FriendsAsync(ulong userId) =>
            //url example 'https://friends.roblox.com/v1/users/16/friends?userSort=0
            JsonSerializer.Deserialize<Page<User>>(
                await Get_RequestAsync($"https://friends.roblox.com/v1/users/{userId}/friends")
            )!.data!;

        /// <summary>
        /// Get a <paramref name="Page"/> of all users that follow the given <paramref name="userId"/> with targetUserId in page response format
        /// <br></br>
        /// <b><seealso href="https://friends.roblox.com/docs//index.html">Friends API Documentation v1</seealso></b>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="limit"></param>
        /// <param name="sortOrder"></param>
        /// <param name="page">The page to start at.</param>
        /// <returns>Page</returns>
        public static async Task<Page<User>> Get_FollowersAsync(ulong userId, Limit limit = Limit.Minimum, Sort sortOrder = Sort.Asc, Page<User>? page = null) =>
            JsonSerializer.Deserialize<Page<User>>(
                await Get_RequestAsync(
                    $"https://friends.roblox.com/v1/users/{userId}" +
                    $"/followers?limit=50&sortOrder={sortOrder}" +
                    $"&cursor={page?.nextPageCursor}")
            )!;

        /// <summary>
        /// Get the number of friends a given <paramref name="userId"/> has asynchronously
        /// <br></br>
        /// <seealso href="https://friends.roblox.com/docs//index.html">Friends Documentation v1</seealso>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>byte</returns>
        /// <exception cref="InvalidUserIdException"></exception>
        /// <exception cref="NotImplementedException"></exception>"
        public static async Task<byte> Get_FriendsCountAsync(ulong userId) => (byte)
            JsonSerializer.Deserialize<Count_Response>(
                await Get_RequestAsync($"https://friends.roblox.com/v1/users/{userId}/friends/count")
            ).count;

        /// <summary>
        /// Get the number of followers a user has asynchronously
        /// <<br></br>
        /// <b><seealso href="https://friends.roblox.com/docs//index.html">Friends Documentation v1</seealso></b>
        /// </summary>
        /// 
        /// <param name="id"></param>
        /// <returns>ulong</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="RateLimitException"></exception>
        /// <exception cref="InvalidUserIdException"></exception>
        public static async Task<ulong> Get_FollowersCountAsync(ulong userId) =>
            JsonSerializer.Deserialize<Count_Response>(
                await Get_RequestAsync($"https://friends.roblox.com/v1/users/{userId}/followings/count")
            ).count;

        /// <summary>
        /// Get the number users a <paramref name="userId"/> is following asynchronously
        /// <br></br>
        /// <seealso href="https://friends.roblox.com/docs//index.html">Friends API Documentation v1</seealso>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>ulong</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="RateLimitException"></exception>
        /// <exception cref="InvalidUserIdException"></exception>
        public static async Task<ulong> Get_FollowingsCountAsync(ulong userId) =>
            JsonSerializer.Deserialize<Count_Response>(
                await Get_RequestAsync($"https://friends.roblox.com/v1/users/{userId}/followings/count")
            ).count;

        /// <summary>
        /// Get all users that the given  <paramref name="userId"/> is following in page response format
        /// <br></br>
        /// <seealso href="https://friends.roblox.com/docs//index.html">Friends API Documentation v1</seealso>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="limit"></param>
        /// <param name="sortOrder"></param>
        /// <param name="cursor"></param>
        /// <returns>Page</returns>
        public static async Task<Page<User>> Get_FollowingsAsync(ulong userId, Limit limit = Limit.Minimum, Sort sortOrder = Sort.Asc, string? cursor = null) =>
            // url example https://friends.roblox.com/v1/users/1/followers?limit=10&sortOrder=Asc
            JsonSerializer.Deserialize<Page<User>>(
                await Get_RequestAsync(
                $"https://friends.roblox.com/v1/users/{userId}/followings?" +
                $"limit={EnumExtensions.ToString(limit)}" +
                $"&sortOrder={sortOrder}" +
                $"&cursor={cursor}")
            )!;
    }
}
