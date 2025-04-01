using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        /// <returns> The deserialized <see cref="User"/> if successful</returns>
        public static async Task<User?> Get_UserAsync(ulong ID) => Deserialize<User>(await Get_RequestAsync($"https://users.roblox.com/v1/users/{ID}"));

        /// <summary>
        /// Gets the minimal user information for the authenticated user
        /// </summary>
        /// <returns>The deserialized <see cref="UserAuthenticated"/></returns>
        public static async Task<UserAuthenticated?> Get_AuthenticatedAsync() => Deserialize<UserAuthenticated>(await Get_RequestAsync("https://users.roblox.com/v1/users/authenticated"));
        
        /// <summary>
        /// Get users information given a <see cref="IEnumerable{T}"/> of <paramref name="Usernames"/>
        /// </summary>
        /// <param name="Usernames"></param>
        /// <param name="ExcludeBannedUsers"></param>
        /// <returns><see cref="IReadOnlyList{T}"/> of <see cref="UserByUsername"/></returns>
        public static async Task<IReadOnlyList<UserByUsername>?> Get_UsersAsync(IEnumerable<string> Usernames, bool ExcludeBannedUsers) => Deserialize<Page<UserByUsername>?>(await Post_RequestAsync("https://users.roblox.com/v1/usernames/users", new UserByX(Usernames, ExcludeBannedUsers)))?.Data;
        
        /// <summary>
        /// Get users information given a <see cref="IEnumerable{T}"/> of <paramref name="UserIds"/>
        /// </summary>
        /// <param name="UserIds"></param>
        /// <param name="ExcludeBannedUsers"></param>
        /// <returns><see cref="IReadOnlyList{T}"/> of <see cref="UserByUserId"/></returns>
        public static async Task<IReadOnlyList<UserByUserId>?> Get_UsersAsync(IEnumerable<ulong> UserIds,bool ExcludeBannedUsers) => Deserialize<Page<UserByUserId>?>(await Post_RequestAsync("https://users.roblox.com/v1/users", new UserByX(UserIds, ExcludeBannedUsers)))?.Data;

        #endregion

        #region Usernames

        public static async Task<Page<string>?> Get_UsernameHistoryAsync(ulong userId, Limit limit=Limit.Ten,string? cursor=null,Sort sortOrder=Sort.Asc)
        {
            //url example 'https://users.roblox.com/v1/users/416181091/username-history?limit=100&sortOrder=Asc
          
            Page<UsernameHistory_Response>? page = Deserialize<Page<UsernameHistory_Response>>(
                await Get_RequestAsync(
                    $"https://users.roblox.com/v1/users/{userId}" +
                    $"/username-history?limit={limit}" +
                    $"&cursor={cursor}" +
                    $"&sortOrder={sortOrder}")
            );

            if (page == null) return null;

            return new Page<string>()
            {
                Data = [.. page.Data.Select(u => u.Name)],
                NextPageCursor = page.NextPageCursor,
                PreviousPageCursor = page.PreviousPageCursor
            };
        }

        #endregion


    }

}
