using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Roblox_Sharp.Enums;
using Roblox_Sharp.Models;
using Roblox_Sharp.Models.v1;
using static Roblox_Sharp.WebAPI;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// endpoints for direct Roblox user information. <br></br>
    /// <b><see href="https://users.roblox.com/docs//index.html">Users Documentation v1</see></b>
    /// </summary>
    public static class Users_v1
    {
        #region Display Names
        #endregion

        #region Users

        /// <summary>
        /// Gets detailed user information using the user's <paramref name="ID"/>
        /// </summary>
        /// <param name="ID">The users id</param>
        /// <param name="cancellationToken"></param>
        /// <returns> The deserialized <see cref="UserInfo"/> if successful</returns>
        public static async Task<UserInfo?> Get_UserAsync(ulong ID, CancellationToken cancellationToken = default) => (await Get_RequestAsync($"https://users.roblox.com/v1/users/{ID}", cancellationToken))
            .Deserialize<UserInfo>();

        /// <summary>
        /// Gets the minimal user information for the authenticated user
        /// </summary>
        /// <returns>The deserialized <see cref="UserAuthenticated"/></returns>
        public static async Task<UserAuthenticated?> Get_AuthenticatedAsync(CancellationToken cancellationToken = default) => (await Get_RequestAsync("https://users.roblox.com/v1/users/authenticated", cancellationToken))
            .Deserialize<UserAuthenticated>();

        /// <summary>
        /// Get users information given a <see cref="IEnumerable{T}"/> of <paramref name="Usernames"/>
        /// </summary>
        /// <param name="Usernames"></param>
        /// <param name="ExcludeBannedUsers"></param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IReadOnlyList{T}"/> of <see cref="UserByUsername"/></returns>
        public static async Task<IReadOnlyList<UserByUsername>?> Get_UsersAsync(IEnumerable<string> Usernames, bool ExcludeBannedUsers, CancellationToken cancellationToken = default) => (await Post_RequestAsync("https://users.roblox.com/v1/usernames/users", new UserByX(Usernames, ExcludeBannedUsers), cancellationToken)).Deserialize<Page<UserByUsername>>()?.Data;

        /// <summary>
        /// Get users information given a <see cref="IEnumerable{T}"/> of <paramref name="UserIds"/>
        /// </summary>
        /// <param name="UserIds"></param>
        /// <param name="ExcludeBannedUsers"></param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IReadOnlyList{T}"/> of <see cref="UserByUserId"/></returns>
        public static async Task<IReadOnlyList<UserByUserId>?> Get_UsersAsync(IEnumerable<ulong> UserIds, bool ExcludeBannedUsers, CancellationToken cancellationToken = default) =>
            (await Post_RequestAsync("https://users.roblox.com/v1/users", new UserByX(UserIds, ExcludeBannedUsers)))
            .Deserialize<Page<UserByUserId>>()?
            .Data;

        #endregion

        #region Usernames

        /// <summary>
        /// Retrieves the username history for a particular <paramref name="userId"/>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="limit"></param>
        /// <param name="sortOrder"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public static async Task<Page<string>?> Get_UsernameHistoryAsync(ulong userId, Limit limit = Limit.Ten, Sort sortOrder = Sort.Asc, string? cursor = null)
        {
            //url example 'https://users.roblox.com/v1/users/416181091/username-history?limit=100&sortOrder=Asc

            Page<UsernameHistory_Response>? page = (await Get_RequestAsync(
                    $"https://users.roblox.com/v1/users/{userId}" +
                    $"/username-history?limit={limit}" +
                    $"&cursor={cursor}" +
                    $"&sortOrder={sortOrder}"))
            .Deserialize<Page<UsernameHistory_Response>>();

            if (page == null) return null;

            return new Page<string>()
            {
                Data = [.. page.Data.Select(u => u.Name)],
                NextPageCursor = page.NextPageCursor,
                PreviousPageCursor = page.PreviousPageCursor
            };
        }

        #endregion

        #region UserSearch

        /// <summary>
        /// Searches for user's by <paramref name="keyword"/>
        /// </summary>
        /// <param name="keyword">The search keyword</param>
        /// <param name="sessionId"></param>
        /// <param name="LIMIT">The number of results per request</param>
        /// <param name="cursor">The paging cursor for the previous or next page</param>
        /// <param name="cancellationToken"></param>
        /// <returns> The deserialized <see cref="Page{T}"/>  of <see cref="UserBySearch"/> if successful</returns>
        public static async Task<Page<UserBySearch>?> Get_UserSearchAsync(string keyword, string? sessionId = null, Limit LIMIT = Limit.Ten, string? cursor = null, CancellationToken cancellationToken = default)
        => (await Get_RequestAsync(
                    $"https://users.roblox.com/v1/users/search?" +
                    $"keyword={keyword}" +
                    $"&sessionId={sessionId}" +
                    $"&limit={(byte)LIMIT}" +
                    $"&cursor={cursor}", cancellationToken))
            .Deserialize<Page<UserBySearch>>(); /* example url https://users.roblox.com/v1/users/search?keyword=string&sessionId=session&limit=10*/

        #endregion
    }

}
