using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Roblox_Sharp.Framework;
using Roblox_Sharp.Models;
using Roblox_Sharp.Models.Badges;

namespace xUnitTests.Object_Functionality
{
    /// <summary>
    /// Tests if objects are derived from the correct types
    /// </summary>
    [Trait(nameof(xUnitTests), nameof(Object_Functionality))]
    public class Instance
    {
        [Fact]
        public void User() => Assert.IsAssignableFrom<IUser>(new User()); 

        [Fact]
        public void User_Presence() => Assert.IsAssignableFrom<IUser>(new User_Presence());

        [Fact]
        public void Page() => Assert.IsAssignableFrom<IPage>(new Page<bool>() { nextPageCursor=null});

        [Fact]
        public void Badge_Award() => Assert.IsAssignableFrom<Badge>(new Badge_Award()
        {
            name = "",
            description = "",
            badgeId = 0
        });

        [Fact]
        public void Emote() => Assert.IsAssignableFrom<Avatar.Asset>(new Avatar.Emote());
    }
}