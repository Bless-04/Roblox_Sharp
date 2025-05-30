using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Roblox_Sharp.Models;
using Roblox_Sharp.Models.v1;
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
        /// Returns details about a avatar using specified with <paramref name="userId"/> <br></br>
        /// Allows requesting terminated users
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns> The deserialized <see cref="Avatar"/> if successful</returns>
        [Obsolete("Avatars_v2's method is better")]
        public static async Task<Avatar?> Get_AvatarAsync(ulong userId, CancellationToken cancellationToken = default) => (await Get_RequestAsync($"https://avatar.roblox.com/v1/users/{userId}/avatar")) //url https://avatar.roblox.com/v1/users/1/avatar
            .Deserialize<Avatar>();


        /// <summary>
        /// Gets a list of asset ids that the <paramref name="userId"/> is currently wearing
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IReadOnlyList{T}"/> of asset ids </returns>
        public static async Task<IReadOnlyList<ulong>?> Get_CurrentlyWearingAsync(ulong userId, CancellationToken cancellationToken = default) => (await Get_RequestAsync($"https://avatar.roblox.com/v1/users/{userId}/currently-wearing", cancellationToken))
            .Deserialize<AssetIds_Response>()?
            .AssetIds;
    }
}