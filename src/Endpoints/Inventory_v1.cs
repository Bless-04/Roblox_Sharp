using System;
using System.Text.Json;
using System.Threading.Tasks;
using Roblox_Sharp.Models;
using Roblox_Sharp.Models.Internal;
using Roblox_Sharp.Enums;
using static Roblox_Sharp.WebAPI;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// Endpoints for inventory
    /// <b><see href="https://inventory.roblox.com//docs/index.html">Inventory Documentation</see></b>
    /// </summary>
    public static class Inventory_v1
    {
        /// <summary>
        /// Gets whether the specified user's inventory can be viewed.
        /// </summary>
        /// <param name="userId">The users id </param>
        /// <returns>true if the inventory can be viewed</returns>
        public static async Task<bool> Get_CanViewInventoryAsync(ulong userId) =>
            //url https://inventory.roblox.com/v1/users/1/can-view-inventory
            JsonSerializer.Deserialize<Inventory_Response>(
                await Get_RequestAsync($"https://inventory.roblox.com/v1/users/{userId}/can-view-inventory")
            ).canView;

        /// <summary>
        ///Gets owned items of the specified item type.  <br/>
        ///Game Servers can make requests for any user, but can only make requests for game passes that belong to the place sending the request.  <br/>
        ///Place creators can make requests as if they were the Game Server <br/>
        /// </summary>
        /// <param name="userId">Id of the user in question</param>
        /// <param name="itemType">Type of the item in question (ie. Asset, GamePass, Badge, Bundle)</param>
        /// <param name="itemTargetId">Id of the item in question</param>
        /// <returns></returns>
        [Obsolete("This method has not been tested", true)]
        public static async Task<Page<Item>> Get_ItemsAsync(ulong userId, ItemType itemType, ulong itemTargetId) => JsonSerializer.Deserialize<Page<Item>>(await Get_RequestAsync($"https://inventory.roblox.com/v1/users/{userId}/items/{itemType}/{itemTargetId}"))!;
    }
}
