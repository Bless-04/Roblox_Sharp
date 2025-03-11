using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Roblox_Sharp.Framework;
using Roblox_Sharp.Models;

namespace xUnitTests.Model_Functionality
{
    /// <summary>
    /// Tests if objects are derived from the correct types
    /// </summary>
    [Trait(nameof(Roblox_Sharp.Models), nameof(Model_Functionality))]
    public class Instance
    {
        #region Interfaces

            [Fact]
            public void Page() => Assert.IsAssignableFrom<IPage>(new Page<bool>());

            [Fact]
            public void User() => Assert.IsAssignableFrom<IUser>(new User());

            [Fact]
            public void User_Presence() => Assert.IsAssignableFrom<IUser>(new User.Presence());

            [Fact]
            public void Asset() => Assert.IsAssignableFrom<IAsset>(new Avatar.Asset());

            [Fact]
            public void Emote() => Assert.IsAssignableFrom<IAsset>(new Avatar.Emote() { AssetName = string.Empty });
        
        #endregion

        [Fact]
        public void Badge_Award() => Assert.IsAssignableFrom<IBadge>(new Badge.Award()
        {
            BadgeId = ulong.MaxValue
        });


       


    }
}