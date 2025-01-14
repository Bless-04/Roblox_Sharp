using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Exceptions;
using System.Threading.Tasks;
using System.Collections.Generic;

using static xUnitTests.User_Constants;
namespace xUnitTests.Integration
{
    /// <summary>
    /// Tests <see cref="Inventory_v1"/> Endpoint
    /// </summary>
    [Collection("Integration")]
    public class Inventorys 
    {
        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_CanViewInventory()
        {
            bool test = await Inventory_v1.Get_CanViewInventoryAsync(ROBLOX);

            Assert.True(test, "Get_CanViewInventory() is failing");

        }

        [IntegrationTrait.Long_Integration]
        [Theory]
        [InlineData(BANNED)]
        [InlineData(DOEST_EXIST)]
        public async Task Get_CanViewInventory_Error(ulong id) 
        {
            await Assert.ThrowsAsync<InvalidUserException>(() => Inventory_v1.Get_CanViewInventoryAsync(id));
        }

    }
}
