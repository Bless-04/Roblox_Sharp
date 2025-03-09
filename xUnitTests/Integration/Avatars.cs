using Roblox_Sharp.Endpoints;
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
#pragma warning disable CS0618 // Type or member is obsolete ; testing
            Avatar v1 = await Avatars_v1.Get_AvatarAsync(ROBLOX);
            Avatar v2 = await Avatars_v2.Get_AvatarAsync(ROBLOX);

            Assert.Equal(v1.scales, v2.scales); //should be the same ; can be value checked as it is a struct

            Assert.NotNull(v1.Assets);
            Assert.NotNull(v2.Assets);

            Assert.Equal(v1.Assets[0].Meta, v2.Assets[0].Meta); //can be value checked as it is a struct
        }

    }
}
