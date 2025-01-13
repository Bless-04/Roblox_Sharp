using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Exceptions;
using System.Threading.Tasks;

namespace xUnitTests.HTTP
{
    /// <summary>
    /// Tests <see cref="Inventory_v1"/> Endpoint
    /// </summary>
    [Collection("Endpoints")]
    [Trait("Tests", "Integration")]
    public class Inventorys : IDelayedTest
    {
        [Fact]
        public async Task Get_CanViewInventory()
        {
            bool test = await Inventory_v1.Get_CanViewInventoryAsync(1);

            Assert.True(test, "Get_CanViewInventory() is failing");

        }

        [Fact]
        public async Task Get_CanViewInventory_Error() => await Assert.ThrowsAsync<InvalidUserException>(() => Inventory_v1.Get_CanViewInventoryAsync(0));

    }
}
