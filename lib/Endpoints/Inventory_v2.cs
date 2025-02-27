﻿using Roblox_Sharp.Enums;
using System;
using System.Threading.Tasks;

namespace Roblox_Sharp.Endpoints
{
    /// <summary>
    /// <inheritdoc cref="Roblox_Sharp.Endpoints.Inventory_v1"/>
    /// </summary>
    public static class Inventory_v2
    {
        /// <summary>
        /// Get user's inventory by multiple Roblox.Platform.Assets.AssetType. <br/>
        /// <b>GamePass and Badges not allowed.</b>
        /// </summary>
        /// <param name="userId">The inventory owner's userId.</param>
        /// <param name="assetTypes">The asset Types to query</param>
        /// <param name="filterDisapprovedAssets">Filters moderated assets when enabled</param>
        /// <param name="showApprovedOnly">Filters moderated assets and assets pending review when enabled</param>
        /// <param name="limit">The number of results per request</param>
        /// <param name="sortOrder">The paging cursor for the previous or next page</param>
        /// <param name="cursor">The order the results are sorted in.</param>
        /// <returns></returns>
        [Obsolete("This method has not been tested", true)]
        public static async Task<bool> Get_InventoryAsync(ulong userId, AssetType[] assetTypes, bool filterDisapprovedAssets = false, bool showApprovedOnly = false, Limit limit = Limit.Ten, Sort sortOrder = Sort.Asc, string? cursor = null)
        {

        }

    }
}
