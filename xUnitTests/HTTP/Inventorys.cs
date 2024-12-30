using Roblox_Sharp.Endpoints;
using System.ComponentModel;
using System.Reflection;

namespace xUnitTests.HTTP
{
    /// <summary>
    /// Tests <see cref="Inventory_v1"/> Endpoint
    /// </summary>
    [Collection("Endpoints")]
    public class Inventorys : IRateLimited
    {
        [RateLimitedFact]
        public void Get_CanViewInventory() => Test(async () =>
        {
            bool x = await Inventory_v1.Get_CanViewInventoryAsync(1);

            Assert.True(x, "Get_CanViewInventory() is failing");

        }, "Get_CanViewInventory()");

    }
}
