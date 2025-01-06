using Roblox_Sharp.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static Roblox_Sharp.WebAPI;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// Groups management endpoints <br></br>
    /// <b><see href="https://groups.roblox.com/docs//index.html">Groups Documentation</see></b>
    /// </summary>
    public static class Groups_v2
    {
        /// <summary>
        /// Multi-get groups information by <paramref name="groupIds[]"/>.
        /// </summary>
        /// <param name="groupIds"></param>
        /// <returns>Array of Groups</returns>
        public static async Task<IReadOnlyList<Group>> Get_GroupsAsync(ulong[] groupIds) =>
            /// example url https://groups.roblox.com/v2/groups?groupIds=2,3,1
            JsonSerializer.Deserialize<Page<Group>>(
                await Get_RequestAsync($"https://groups.roblox.com/v2/groups?groupIds={string.Join(',', groupIds)}")
            )!.data!;
    }
}
