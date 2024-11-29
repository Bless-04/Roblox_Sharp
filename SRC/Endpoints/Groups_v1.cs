using System.Threading.Tasks;
using System.Text.Json;

using Roblox_Sharp.JSON;
using static Roblox_Sharp.WebAPI;
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
                await Get_RequestAsync($"https://groups.roblox.com/v1/groups/{groupId}"),
                _ = new JsonSerializerOptions
                {
                    IncludeFields = true
                }
            )!;
        
        
    }
}
