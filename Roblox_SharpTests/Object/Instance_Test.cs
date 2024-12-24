using Roblox_Sharp.Framework;

using Roblox_Sharp.JSON_Models;
using Roblox_Sharp.JSON_Models.Users;
using Roblox_Sharp.JSON_Models.Badges; 

namespace Roblox_SharpTests
{
    [TestCategory("Object Usage Tests")]
    [TestClass]
    public partial class Instance_Test
    {
        [TestMethod]
        public void User() => Assert.IsInstanceOfType<IUser>(new User());

        [TestMethod]
        public void User_Presence() => Assert.IsInstanceOfType<User>(new User_Presence());

        [TestMethod]
        public void Page() =>
            Assert.IsInstanceOfType<IPage>(new Page<bool>()
            {
                previousPageCursor = "",
                nextPageCursor = "",
                data = Array.Empty<bool>()
            });
        
        [TestMethod]
        public void Badge_Award() => Assert.IsInstanceOfType<Badge>(new Badge_Award()
        {
            name = "",
            description = "",
            badgeId = 0
        });

        [TestMethod]
        public void Emote() => Assert.IsInstanceOfType<Avatar.Asset>(new Avatar.Emote());    
    }
}