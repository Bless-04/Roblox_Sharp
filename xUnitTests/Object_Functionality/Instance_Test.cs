using Roblox_Sharp.Framework;

using Roblox_Sharp.JSON_Models;
using Roblox_Sharp.JSON_Models.Users;
using Roblox_Sharp.JSON_Models.Badges;
using System;

namespace xUnitTests.Object_Functionality
{
    /// <summary>
    /// Tests if objects are derived from the correct types
    /// </summary>
    public class Instance
    {
        [Fact]
        public void User() => Assert.IsAssignableFrom<IUser>(new User()); //IUser>

        [Fact]
        public void User_Presence() => Assert.IsAssignableFrom<User>(new User_Presence());

        [Fact]
        public void Page() =>
            Assert.IsAssignableFrom<IPage>(
                new Page<bool>()
                {
                    previousPageCursor = null,
                    nextPageCursor = null,
                    data = Array.Empty<bool>()
                }
            );
        
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