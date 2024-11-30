using Roblox_Sharp.Templates;

using Roblox_Sharp.JSON_Models;
using Roblox_Sharp.JSON_Models.Users;
using Roblox_Sharp.JSON_Models.Badges; 

namespace Roblox_SharpTests
{
    [TestClass]
    public partial class Type_Tests
    {
        [TestMethod]
        public void User() => Assert.IsInstanceOfType<IUser>(new User());

        [TestMethod]
        public void User_Presence() => Assert.IsInstanceOfType<User>(new User_Presence());

        [TestMethod]
        public void Avatar() => 
            Assert.IsInstanceOfType<User>(new Avatar(default) 
            {
                imageUrl = "",
                version = "",
                state = ""
            });

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
            id = 0
        });
        
    }
}