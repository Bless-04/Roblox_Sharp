﻿using Roblox_Sharp.Endpoints;

namespace Tests.Endpoint
{
    /// <summary>
    /// Tests <see cref="Roblox_Sharp.Endpoints.Inventory_v1"/> Endpoint
    /// </summary>
    [Collection("Endpoints")]
    public class Inventorys : IRateLimited
    {
        [RateLimitedFact]
        public void Get_CanViewInventory() => Test(async () =>
        {
            bool x = await Inventory_v1.Get_CanViewInventoryAsync(1);

            Assert.True(x, "Get_CanViewInventory() is failing");
            
        });

    }
}
