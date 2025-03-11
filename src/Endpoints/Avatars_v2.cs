using Roblox_Sharp.Models;

using System.Text.Json;
using System.Threading.Tasks;

using static Roblox_Sharp.WebAPI;
namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// Endpoints relating to the customization of player avatars <br></br>
    /// <b><see href="https://avatar.roblox.com//docs/index.html?urls.primaryName=Avatar%20Api%20v2">Avatars Documentation</see></b>
    /// </summary>
    public static class Avatars_v2
    {
        /// <summary>
        /// Returns details about a avatar using specified <paramref name="userId"/>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Avatar</returns>
        public static async Task<Avatar> Get_AvatarAsync(ulong userId) =>
            JsonSerializer.Deserialize<Avatar>(
                await Get_RequestAsync($"https://avatar.roblox.com/v2/avatar/users/{userId}/avatar")
            )!;
    }
}
