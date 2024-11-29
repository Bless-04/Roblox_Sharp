using Roblox_Sharp.JSON;
using Roblox_Sharp.Templates;
using System.Diagnostics;

namespace Roblox_SharpTests.Object
{
    [TestClass]
    /// <summary>
    /// tests functionality of objects
    /// </summary>
    public class Logic_Test
    {
        [TestMethod]
        public void IUser_OperatorTests()
        {
            // x > y > z
            User x = new(1); //roblox



            User y = new(16); //erik.cassel
            User z = new(156); //builderman
            User X = new(1); //roblox

            Assert.AreNotEqual(x, y);

            Assert.IsTrue(x > y);
            Assert.IsTrue(y > z);
            Assert.IsTrue(x > z);

            Assert.IsTrue(z < x);
            Assert.IsTrue(z < x);
            Assert.IsTrue(y < x);

            Assert.IsFalse(x.Equals(y));
            Assert.IsTrue(x.Equals(X));
        }


    }

}
