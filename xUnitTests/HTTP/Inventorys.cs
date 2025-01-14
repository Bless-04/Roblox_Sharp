using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Exceptions;
using System.Threading.Tasks;
using System.Collections.Generic;

using static xUnitTests.User_Constants;
namespace xUnitTests.HTTP
{
    /// <summary>
    /// Tests <see cref="Inventory_v1"/> Endpoint
    /// </summary>
    [Collection("Endpoints")]
    public class Inventorys 
    {
        public static IEnumerable<object[]> Errors => User_Constants.Unsafe_Users;

        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_CanViewInventory()
        {
            bool test = await Inventory_v1.Get_CanViewInventoryAsync(ROBLOX);

            Assert.True(test, "Get_CanViewInventory() is failing");

        }

        [IntegrationTrait]
        [Theory]
        [MemberData(nameof(Errors)) ]
        public async Task Get_CanViewInventory_Error(ulong id) => 
            await Assert.ThrowsAsync<InvalidUserException>(() => Inventory_v1.Get_CanViewInventoryAsync(id));

    }
}
