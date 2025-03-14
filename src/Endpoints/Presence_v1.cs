﻿using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using Roblox_Sharp.Models.Internal;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static Roblox_Sharp.WebAPI;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// all Endpoints for managing presence 
    /// <br></br> 
    /// <b><see href="https://presence.roblox.com//docs/index.html">Presence API Documentation</see></b>
    /// </summary>
    public static class Presence_v1
    {
        /// <summary>
        /// Get Presence for the given array of <paramref name="userIds"/> 
        /// <br></br>
        /// <b><see href="https://presence.roblox.com//docs/index.html">Presence API Documentation</see></b>
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns>userPresence[]</returns>
        public static async Task<IReadOnlyList<User.Presence>> Get_PresencesAsync(List<ulong> userIds) =>
            // url example https://presence.roblox.com/v1/presence/users
            JsonSerializer.Deserialize<Presence_Response>(
                await Post_RequestAsync($"https://presence.roblox.com/v1/presence/users", new User.Post(userIds))
            )!.userPresences
                ?? throw new InvalidUserException($"No valid user ids\n[{string.Join(',', userIds)}]");
    }
}
