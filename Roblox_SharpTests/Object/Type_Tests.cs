using Roblox_Sharp.JSON;

using Roblox_Sharp.Templates;

namespace Roblox_SharpTests
{
    [TestClass]
    public partial class Type_Tests
    {
        [TestMethod]
        public void User_Presence() => Assert.IsInstanceOfType<IUser>(_ = new User_Presence());

        [TestMethod]
        public void Avatar() => 
            Assert.IsInstanceOfType<IUser>(_ = new Avatar() 
            {
                imageUrl = default,
                version = default,
                state = default
            }); 
    }
}