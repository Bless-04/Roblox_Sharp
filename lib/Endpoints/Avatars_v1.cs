using Roblox_Sharp.Models;
using Roblox_Sharp.Models.Internal;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static Roblox_Sharp.WebAPI;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// Endpoints relating to the customization of player avatars <br></br>
    /// <b><see href="https://avatar.roblox.com//docs/index.html?urls.primaryName=Avatar%20Api%20v2">Avatars Documentation</see></b>
    /// </summary>
    public static class Avatars_v1
    {
        /// <summary>
        /// Returns details about a avatar using specified with<paramref name="userId"/> <br></br>
        /// Allows requesting terminated users
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Avatar</returns>
        public static async Task<Avatar> Get_AvatarAsync(ulong userId) =>
            //url https://avatar.roblox.com/v1/users/1/avatar
            JsonSerializer.Deserialize<Avatar>(
                await Get_RequestAsync($"https://avatar.roblox.com/v1/users/{userId}/avatar")
            )!;

        /// <summary>
        /// Gets a list of asset ids that the <paramref name="userId"/> is currently wearing
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of ulong</returns>
        public static async Task<IReadOnlyList<ulong>> Get_CurrentlyWearingAsync(ulong userId) =>
            JsonSerializer.Deserialize<assetIds_Response>(
                await Get_RequestAsync($"https://avatar.roblox.com/v1/users/{userId}/currently-wearing")
            )!.assetIds;

    }
}
