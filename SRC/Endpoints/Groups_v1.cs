using System.Threading.Tasks;
using System.Text.Json;

using static Roblox_Sharp.WebAPI;
using Roblox_Sharp.JSON;
using System.Collections.Generic;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// Groups management endpoints <br></br>
    /// <b><see href="https://groups.roblox.com/docs//index.html">Groups Documentation</see></b>
    /// </summary>
    public static class Groups_v1
    {
        /// <summary>
        /// Gets group information
        /// </summary>
        /// <param name="groupId">The group id</param>
        /// <returns>Group</returns>
        public static async Task<Group> Get_GroupAsync(ulong groupId) =>
            // url https://groups.roblox.com/v1/groups/29793
            JsonSerializer.Deserialize<Group>(
                await Get_RequestAsync($"https://groups.roblox.com/v1/groups/{groupId}")
            )!;

        /// <summary>
        /// Gets a list of the rolesets in a group using the given group id
        /// </summary>
        /// <param name="groupId">The group id</param>
        /// <returns>Group.Role</returns>
        public static async Task<IReadOnlyList<Group.Role>> Get_GroupRolesAsync(ulong groupId) =>
            //url example https://groups.roblox.com/v1/groups/2/roles
            JsonSerializer.Deserialize<Group>(
                await Get_RequestAsync($"https://groups.roblox.com/v1/groups/{groupId}/roles")
            )!.roles ;

    }
}
