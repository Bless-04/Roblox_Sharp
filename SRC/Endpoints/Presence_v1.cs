﻿using System.Text.Json;
using System.Threading.Tasks;
using static Roblox_Sharp.WebAPI;
using Roblox_Sharp.JSON;
namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// all Endpoints for managing presence 
    /// <br></br> 
    /// <b><see href="https://presence.roblox.com//docs/index.html">Presence API Documentation v1</see></b>
    /// </summary>
    public static class Presence_v1
    {
        /// <summary>
        /// Get Presence for the given array of <paramref name="userIds"/> 
        /// <br></br>
        /// <b><see href="https://presence.roblox.com//docs/index.html">Presence API Documentation v1</see></b>
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns>userPresence[]</returns>
        public static async Task<userPresence[]> Get_PresencesAsync(ulong[] userIds)
        {
            // url example https://presence.roblox.com/v1/presence/users
            string content = await Post_RequestAsync($"https://presence.roblox.com/v1/presence/users", new UserPOST(userIds));

            return JsonSerializer.Deserialize<Presence_Response>(content)!.userPresences;
        }

        
    }
}
