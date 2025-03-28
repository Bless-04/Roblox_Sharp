using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Roblox_Sharp.Models;
using Roblox_Sharp.Models.v1;
using static Roblox_Sharp.Models.v1.User;
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
        public static async Task<User?> Get_UserAsync(ulong ID) => JsonSerializer.Deserialize<User>(await Get_RequestAsync($"https://users.roblox.com/v1/users/{ID}"));

        public static async Task<IReadOnlyList<UserByUsername>?> Get_UsersAsync(IEnumerable<string> Ids,bool ExcludeBannedUsers = false)
        {
            using HttpResponseMessage response = await _client.PostAsync($"https://users.roblox.com/v1/usernames/users", new StringContent(JsonSerializer.Serialize(new 
            { 
                ids = Ids, 
                excludeBannedUsers = ExcludeBannedUsers 
            }), Encoding.UTF8, "application/json"));
            {
                RaiseRequestEvents(response);
                return JsonSerializer.Deserialize<Page<UserByUsername>>(await response.Content.ReadAsStringAsync()).Data;
            }
        }

        #endregion
    }
      
}
