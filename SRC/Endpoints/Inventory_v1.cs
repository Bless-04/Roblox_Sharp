using System.Text.Json;
using System.Threading.Tasks;

using static Roblox_Sharp.WebAPI;

namespace Roblox_Sharp.Endpoints
{
    public static class Inventory_v1
    {
        /// <summary>
        /// Gets whether the specified user's inventory can be viewed.
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> Get_CanViewInventoryAsync(ulong userId)
        {
            //url https://inventory.roblox.com/v1/users/1/can-view-inventory

            string content = await Get_RequestAsync($"https://inventory.roblox.com/v1/users/{userId}/can-view-inventory");
            return JsonSerializer.Deserialize<dynamic>(content)!.canView;
        }
    }
}
