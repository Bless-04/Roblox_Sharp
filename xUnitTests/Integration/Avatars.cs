using Roblox_Sharp.Endpoints;
using Roblox_Sharp.Exceptions;
using Roblox_Sharp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using static xUnitTests.User_Constants;
namespace xUnitTests.Integration
{
    /// <summary>
    /// Tests <see cref="Avatars_v1"/> and <see cref="Avatars_v2"/> Endpoints
    /// </summary>
    [Collection(nameof(Integration))]
    public class Avatars
    {
        [IntegrationTrait.Long_Integration]
        [Fact]
        public async Task Get_CurrentlyWearing() 
        {
            IReadOnlyList<ulong> assets = await Avatars_v1.Get_CurrentlyWearingAsync(ROBLOX);

            Assert.NotNull(assets);
            Assert.True(assets.Count > 0, "Assets.Count is failing");
        }

        /// <summary>
        /// tests both Avatar_v1 and Avatar_v2 using one another
        /// </summary>
        [IntegrationTrait]
        [Fact]
        public async Task Get_Avatar()
        {
            Avatar v1 = await Avatars_v1.Get_AvatarAsync(ROBLOX);
            Avatar v2 = await Avatars_v2.Get_AvatarAsync(ROBLOX);

            Assert.Equal(v1.scales, v2.scales); //should be the same ; can be value checked as it is a struct

            Assert.NotNull(v1.assets);
            Assert.NotNull(v2.assets);

            Assert.Equal(v1.assets[0].meta, v2.assets[0].meta); //can be value checked as it is a struct
        }

        [IntegrationTrait]
        [Fact]             //v1 allows banned users
        public async Task Get_Avatar2_Error() => await Assert.ThrowsAsync<InvalidUserException>(() => Avatars_v2.Get_AvatarAsync(5)); //the BANNED user 


    }
}
