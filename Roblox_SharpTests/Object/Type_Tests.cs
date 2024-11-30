using Roblox_Sharp.Templates;

using Roblox_Sharp.JSON;
using Roblox_Sharp.JSON.Users;

namespace Roblox_SharpTests
{
    [TestClass]
    public partial class Type_Tests
    {
        [TestMethod]
        public void User_Presence() => Assert.IsInstanceOfType<IUser>(new User_Presence());

        [TestMethod]
        public void Avatar() => 
            Assert.IsInstanceOfType<User>(new Avatar(1) 
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

    }
}