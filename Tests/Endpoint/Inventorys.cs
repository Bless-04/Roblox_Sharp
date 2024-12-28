using Roblox_Sharp.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Endpoint
{
    [Collection("Endpoints")]
    public class Inventorys : IRateLimited
    {
        [RateLimited]
        public void Get_CanViewInventory() => Test(async () =>
        {
            bool x = await Inventory_v1.Get_CanViewInventoryAsync(1);

            Assert.True(x, "Get_CanViewInventory() is failing");
            
        });

    }
}
